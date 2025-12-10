using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Data;

namespace ScuolaNoRepo.Repositories
{
    public class StudenteRepository : IStudenteRepository
    {
        public List<Studente> GetAll()
        {
            using var db = new ScuolaContext();
            return db.Studenti.Include(s => s.Corsi).ToList();
        }

        public Studente GetById(int id)
        {
            using var db = new ScuolaContext();
            return db.Studenti.Include(s => s.Corsi).FirstOrDefault(s => s.Id == id);
        }

        public void Add(Studente entity)
        {
            using var db = new ScuolaContext();
            db.Studenti.Add(entity);
            db.SaveChanges();
        }

        public void Update(Studente entity)
        {
            using var db = new ScuolaContext();
            db.Studenti.Update(entity);
            db.SaveChanges();
        }

        public void Delete(Studente entity)
        {
            using var db = new ScuolaContext();
            db.Studenti.Remove(entity);
            db.SaveChanges();
        }
    }
}