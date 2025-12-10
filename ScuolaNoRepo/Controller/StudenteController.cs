using System;
using System.Collections.Generic;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Repositories;

namespace ScuolaNoRepo.Controller
{
    public class StudenteController
    {
        private readonly IStudenteRepository _studenteRepository;

        public StudenteController()
        {
            _studenteRepository = new StudenteRepository();
        }

        public List<Studente> GetAll()
        {
            return _studenteRepository.GetAll();
        }

        public void AddStudente(Studente studente)
        {
            _studenteRepository.Add(studente);
        }

        public void ModificaStudente(Studente studente)
        {
            _studenteRepository.Update(studente);
        }

        public void EliminaStudente(Studente studente)
        {
            _studenteRepository.Delete(studente);
        }
    }
}