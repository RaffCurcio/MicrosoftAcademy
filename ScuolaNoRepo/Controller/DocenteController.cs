using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Data;


namespace ScuolaNoRepo.Controller
{
    public class DocenteController {
        public List<Docente> GetAll() {
            using var db = new ScuolaContext();
            return db.Docenti.Include(d => d.Corsi).ToList();
        }
        public void AddDocente(Docente docente) {
            using var db = new ScuolaContext();
            db.Docenti.Add(docente);
            db.SaveChanges();
        }

        public void ModificaDocente(Docente docente) {
            using var db = new ScuolaContext();
            db.Docenti.Update(docente);
            db.SaveChanges();
        }

        public void EliminaDocente(Docente docente) {
            using var db = new ScuolaContext();
            db.Docenti.Remove(docente);
            db.SaveChanges();
        }
        public Docente AggiungiDocenteACorso(int docenteId, int corsoId) {
            using var db = new ScuolaContext();
            var docente = db.Docenti.Include(d => d.Corsi).FirstOrDefault(d => d.Id == docenteId);
            var corso = db.Corsi.FirstOrDefault(c => c.Id == corsoId);

            if (docente != null && corso != null) {
                docente.Corsi.Add(corso);
                db.SaveChanges();
            }

            return docente;
        }
    }
}