using System;
using ScuolaNoRepo.Model;
using ScuolaNoRepo.Data;

namespace ScuolaNoRepo.Controller
{
    public class CorsoController
    {

        public void AddCorso(Corso corso)
        {
            using var db = new ScuolaContext();
            db.Corsi.Add(corso);
            db.SaveChanges();
        }

        public List<Corso> GetAll()
        {
            using var db = new ScuolaContext();
            return db.Corsi.ToList();
        }
    }
}