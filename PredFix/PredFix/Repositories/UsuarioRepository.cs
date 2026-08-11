using PredFix.Contexts;
using PredFix.Domains;
using PredFix.Interfaces;

namespace PredFix.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PrediFixContext _context;

        public UsuarioRepository(PrediFixContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public Usuario? ObterPorId(int id) 
        {
            return _context.Usuario.Find(id);
        }

        public Usuario? ObterPorEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public bool EmailExiste(string email)
        { 
            return _context.Usuario.Any(u => u.Email == email);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}