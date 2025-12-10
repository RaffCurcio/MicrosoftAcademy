using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Data;

namespace ScuolaNoRepo.Repositories
{
    public class DocenteRepository : IDocenteRepository
    {
        public List<Docente> GetAll()
        {
            using var db = new ScuolaContext();
            return db.Docenti.Include(d => d.Corsi).ToList();
        }

        public Docente GetById(int id)
        {
            using var db = new ScuolaContext();
            return db.Docenti.Include(d => d.Corsi).FirstOrDefault(d => d.Id == id);
        }

        public void Add(Docente entity)
        {
            using var db = new ScuolaContext();
            db.Docenti.Add(entity);
            db.SaveChanges();
        }

        public void Update(Docente entity)
        {
            using var db = new ScuolaContext();
            db.Docenti.Update(entity);
            db.SaveChanges();
        }

        public void Delete(Docente entity)
        {
            using var db = new ScuolaContext();
            db.Docenti.Remove(entity);
            db.SaveChanges();
        }

        public Docente AggiungiDocenteACorso(int docenteId, int corsoId)
        {
            using var db = new ScuolaContext();
            var docente = db.Docenti.Include(d => d.Corsi).FirstOrDefault(d => d.Id == docenteId);
            var corso = db.Corsi.FirstOrDefault(c => c.Id == corsoId);

            if (docente != null && corso != null)
            {
                docente.Corsi.Add(corso);
                db.SaveChanges();
            }

            return docente;
        }
    }
}