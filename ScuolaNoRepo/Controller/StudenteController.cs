using System;
using System.Collections.Generic;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Data;

namespace ScuolaNoRepo.Controller
{
    public class StudenteController {
        public List<Studente> GetAll() {
            using var db = new ScuolaContext();
            return db.Studenti.ToList();
        }
        public void AddStudente(Studente studente) {
            using var db = new ScuolaContext();
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public void ModificaStudente(Studente studente) {
            using var db = new ScuolaContext();
            db.Studenti.Update(studente);
            db.SaveChanges();
        }

        public void EliminaStudente(Studente studente) {
            using var db = new ScuolaContext();
            db.Studenti.Remove(studente);
            db.SaveChanges();
        }
    }
}