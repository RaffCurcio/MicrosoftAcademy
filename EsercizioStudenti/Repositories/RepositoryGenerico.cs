using System;
using System.Collections.Generic;
using GestioneStudenti.Interfaces;

namespace GestioneStudenti.Repositories
{
    public class RepositoryGenerico<T> where T : IEntita
    {
        private List<T> entita = new List<T>();

        public void Aggiungi(T entita)
        {
            if (entita == null)
                throw new ArgumentNullException(nameof(entita));
            
            this.entita.Add(entita);
        }

        public T TrovaPerId(string id)
        {
            foreach (var e in entita)
            {
                if (e.Id == id)
                    return e;
            }
            return default(T);
        }

        public List<T> OttieniTutti()
        {
            return new List<T>(entita);
        }

        public bool Rimuovi(string id)
        {
            var e = TrovaPerId(id);
            if (e != null)
            {
                entita.Remove(e);
                return true;
            }
            return false;
        }

        public int ContaTotale()
        {
            return entita.Count;
        }
    }
}