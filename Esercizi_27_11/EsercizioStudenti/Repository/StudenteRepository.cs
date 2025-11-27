using System;
using System.Collections.Generic;
using GestioneStudenti.Model;

namespace GestioneStudenti.Repository
{
    public class StudenteRepository
    {
        private List<Studente> studenti = new List<Studente>();

        public void Aggiungi(Studente studente)
        {
            if (studente == null)
                throw new ArgumentNullException(nameof(studente));
            
            studenti.Add(studente);
        }

        public Studente TrovaPerMatricola(string matricola)
        {
            foreach (var studente in studenti)
            {
                if (studente.getMatricola == matricola)
                    return studente;
            }
            return null;
        }

        public List<Studente> OttieniTutti()
        {
            return studenti;
        }

        public bool Rimuovi(string matricola)
        {
            var studente = TrovaPerMatricola(matricola);
            if (studente != null)
            {
                studenti.Remove(studente);
                return true;
            }
            return false;
        }

        public int ContaTotale()
        {
            return studenti.Count;
        }
    }
}