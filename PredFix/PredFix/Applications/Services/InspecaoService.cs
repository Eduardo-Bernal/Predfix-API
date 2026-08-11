using PredFix.Domains;
using PredFix.DTOs.InspecaoDto;
using PredFix.Exceptions;
using PredFix.Interfaces;

namespace PredFix.Applications.Services
{
    public class InspecaoService
    {
        private readonly IInspecaoRepository _repository;

        public InspecaoService(IInspecaoRepository repository)
        {
            _repository = repository;
        }

        private static LerInspecaoDto LerDto(Inspecao inspecao)
        {
            return new LerInspecaoDto
            {
                InspecaoID = inspecao.InspecaoID,
                Equipamento = inspecao.Equipamento,
                Localizacao = inspecao.Localizacao,
                Cliente = inspecao.Cliente,
                StatusInspecao = inspecao.StatusInspecao,
                DataCriacao = inspecao.DataCriacao,
                UsuarioID = inspecao.UsuarioID,
            };
        }

        private static byte[] ConverterFormFileParaBytes(IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                throw new DomainException("O áudio da observação é obrigatório");
            }

            using var memoryStream = new MemoryStream();
            arquivo.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public List<LerInspecaoDto> Listar()
        {
            List<Inspecao> inspecoes = _repository.Listar();
            return inspecoes.Select(i => LerDto(i)).ToList();
        }

        public LerInspecaoDto ObterPorId(int id)
        {
            Inspecao? inspecao = _repository.ObterPorId(id);
            if (inspecao == null)
            {
                throw new DomainException("Inspeção não encontrada");
            }

            return LerDto(inspecao);
        }

        public byte[] ObterAudio(int id)
        {
            Inspecao? inspecao = _repository.ObterPorId(id);
            if (inspecao == null)
            {
                throw new DomainException("Inspeção não encontrada");
            }

            return inspecao.Observacao;
        }

        public LerInspecaoDto Adicionar(CriarInspecaoDto inspecaoDto)
        {
            if (string.IsNullOrWhiteSpace(inspecaoDto.Equipamento))
            {
                throw new DomainException("Nome do Equipamento é obrigatório");
            }

            byte[] audioBytes = ConverterFormFileParaBytes(inspecaoDto.Observacao);

            Inspecao inspecao = new Inspecao
            {
                Equipamento = inspecaoDto.Equipamento,
                Localizacao = inspecaoDto.Localizacao,
                Cliente = inspecaoDto.Cliente,
                Observacao = audioBytes,
                StatusInspecao = inspecaoDto.StatusInspecao,
                DataCriacao = DateTime.Now,
                UsuarioID = inspecaoDto.UsuarioID
            };

            _repository.Adicionar(inspecao);

            return LerDto(inspecao);
        }
    }
}
