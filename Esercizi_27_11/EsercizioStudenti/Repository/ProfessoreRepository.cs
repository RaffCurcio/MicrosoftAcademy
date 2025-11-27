using System;
using System.Collections.Generic;
using GestioneStudenti.Model;

namespace GestioneStudenti.Repository
{
    public class ProfessoreRepository
    {
        private List<Professore> professori = new List<Professore>();

        public void Aggiungi(Professore professore)
        {
            if (professore == null)
                throw new ArgumentNullException(nameof(professore));
            
            professori.Add(professore);
        }

        public Professore TrovaPerCodice(string codiceId)
        {
            foreach (var professore in professori)
            {
                if (professore.CodiceId == codiceId)
                    return professore;
            }
            return null;
        }

        public List<Professore> OttieniTutti()
        {
            return new List<Professore>(professori);
        }

        public List<Professore> TrovaPerMateria(string materia)
        {
            List<Professore> risultato = new List<Professore>();
            foreach (var prof in professori)
            {
                if (prof.Materia.Equals(materia, StringComparison.OrdinalIgnoreCase))
                    risultato.Add(prof);
            }
            return risultato;
        }

        public int ContaTotale()
        {
            return professori.Count;
        }
    }
}