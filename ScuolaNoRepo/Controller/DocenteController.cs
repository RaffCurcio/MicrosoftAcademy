using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Repositories;

namespace ScuolaNoRepo.Controller
{
    public class DocenteController
    {
        private readonly IDocenteRepository _docenteRepository;

        public DocenteController()
        {
            _docenteRepository = new DocenteRepository();
        }

        public List<Docente> GetAll()
        {
            return _docenteRepository.GetAll();
        }

        public void AddDocente(Docente docente)
        {
            _docenteRepository.Add(docente);
        }

        public void ModificaDocente(Docente docente)
        {
            _docenteRepository.Update(docente);
        }

        public void EliminaDocente(Docente docente)
        {
            _docenteRepository.Delete(docente);
        }

        public Docente AggiungiDocenteACorso(int docenteId, int corsoId)
        {
            return _docenteRepository.AggiungiDocenteACorso(docenteId, corsoId);
        }
    }
}