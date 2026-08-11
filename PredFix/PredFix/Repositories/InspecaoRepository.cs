using PredFix.Contexts;
using PredFix.Domains;
using PredFix.Interfaces;

namespace PredFix.Repositories
{
    public class InspecaoRepository : IInspecaoRepository
    {
        private readonly PrediFixContext _context;

        public InspecaoRepository(PrediFixContext context)
        {
            _context = context;
        }

        public List<Inspecao> Listar()
        {
            return _context.Inspecao.ToList();
        }

        public Inspecao? ObterPorId(int id)
        {
            return _context.Inspecao.Find(id);
        }

        public void Adicionar(Inspecao inspecao)
        {
            _context.Inspecao.Add(inspecao);
            _context.SaveChanges();
        }
    }
}
