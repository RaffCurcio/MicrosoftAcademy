using System;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Repositories;

namespace ScuolaNoRepo.Controller
{
    public class CorsoController
    {
        private readonly ICorsoRepository _corsoRepository;

        public CorsoController()
        {
            _corsoRepository = new CorsoRepository();
        }

        public void AddCorso(Corso corso)
        {
            _corsoRepository.Add(corso);
        }

        public List<Corso> GetAll()
        {
            return _corsoRepository.GetAll();
        }
    }
}