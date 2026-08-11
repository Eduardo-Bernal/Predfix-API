using System.Security.Cryptography;
using System.Text;
using PredFix.Applications.Autenticacao;
using PredFix.Domains;
using PredFix.DTOs.AutenticacaoDto;
using PredFix.Exceptions;
using PredFix.Interfaces;

namespace PredFix.Applications.Services
{
    public class AutenticacaoService
    {
		private readonly IUsuarioRepository _repository;
		private readonly GeradorTokenJwt _tokenJwt;

		public AutenticacaoService(IUsuarioRepository repository, GeradorTokenJwt tokenJwt)
		{
			_repository = repository;
			_tokenJwt = tokenJwt;
		}

		private static byte[] HashSenha(string senha)
		{
			using var sha256 = SHA256.Create();
			return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
		}

		private static bool VerificarSenha(string senhaDigitada, byte[] senhaHashBanco)
		{
			return HashSenha(senhaDigitada).SequenceEqual(senhaHashBanco);
		}

		public TokenDto Login(LoginDto loginDto)
		{
			Usuario? usuario = _repository.ObterPorEmail(loginDto.Email);

			if (usuario == null)
			{
				throw new DomainException("E-mail ou senha inválidos");
			}

			if (!VerificarSenha(loginDto.Senha, usuario.Senha))
			{
				throw new DomainException("E-mail ou senha inválidos");
			}

			var token = _tokenJwt.GerarToken(usuario);

			return new TokenDto { Token = token };
		}
	}
}
