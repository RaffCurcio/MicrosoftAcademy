using ScuolaNoRepo.Model;

namespace ScuolaNoRepo.Repositories
{
    public interface IDocenteRepository : IRepository<Docente>
    {
        Docente AggiungiDocenteACorso(int docenteId, int corsoId);
    }
}