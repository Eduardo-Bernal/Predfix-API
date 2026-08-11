using PredFix.Domains;

namespace PredFix.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario? ObterPorId(int id);
        Usuario? ObterPorEmail(string email);
        bool EmailExiste(string email);
        void Adicionar(Usuario usuario);
    }
}
