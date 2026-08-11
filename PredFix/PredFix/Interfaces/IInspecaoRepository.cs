using PredFix.Domains;

namespace PredFix.Interfaces
{
    public interface IInspecaoRepository
    {
        List<Inspecao> Listar();
        Inspecao? ObterPorId(int id);
        void Adicionar(Inspecao inspecao);

    }
}
