using System;
using System.Collections.Generic;
using GestioneStudenti.Model;

namespace GestioneStudenti.Repository
{
    public class CorsoLaureaRepository
    {
        private List<CorsoLaurea> corsi = new List<CorsoLaurea>();

        public void Aggiungi(CorsoLaurea corso)
        {
            if (corso == null)
                throw new ArgumentNullException(nameof(corso));
            
            corsi.Add(corso);
        }

        public CorsoLaurea TrovaPerCodice(string codice)
        {
            foreach (var corso in corsi)
            {
                if (corso.Codice == codice)
                    return corso;
            }
            return null;
        }

        public List<CorsoLaurea> OttieniTutti()
        {
            return new List<CorsoLaurea>(corsi);
        }

        public int ContaTotale()
        {
            return corsi.Count;
        }
    }
}