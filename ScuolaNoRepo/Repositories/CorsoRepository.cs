using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Data;

namespace ScuolaNoRepo.Repositories
{
    public class CorsoRepository : ICorsoRepository
    {
        public List<Corso> GetAll()
        {
            using var db = new ScuolaContext();
            return db.Corsi.Include(c => c.Studenti).Include(c => c.Docenti).ToList();
        }

        public Corso GetById(int id)
        {
            using var db = new ScuolaContext();
            return db.Corsi.Include(c => c.Studenti).Include(c => c.Docenti).FirstOrDefault(c => c.Id == id);
        }

        public void Add(Corso entity)
        {
            using var db = new ScuolaContext();
            db.Corsi.Add(entity);
            db.SaveChanges();
        }

        public void Update(Corso entity)
        {
            using var db = new ScuolaContext();
            db.Corsi.Update(entity);
            db.SaveChanges();
        }

        public void Delete(Corso entity)
        {
            using var db = new ScuolaContext();
            db.Corsi.Remove(entity);
            db.SaveChanges();
        }
    }
}