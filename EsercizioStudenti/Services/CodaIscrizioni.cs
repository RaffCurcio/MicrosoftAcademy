using System;
using System.Collections.Generic;
using GestioneStudenti.Model;

namespace GestioneStudenti.Services
{
    public class CodaIscrizioni
    {
        private Queue<Studente> iscrizioni;

        public CodaIscrizioni()
        {
            iscrizioni = new Queue<Studente>();
        }
        public void AggiungiRichiesta(Studente studente)
        {
            iscrizioni.Enqueue(studente);
        }
        public Studente ApprovaProssimaRichiesta()
        {
            if (iscrizioni.Count > 0)
            {
                Studente studente = iscrizioni.Dequeue();
                return studente;
            }
            return null;
        }
        public Studente prossimoStudente()
        {
            if (iscrizioni.Count > 0)
            {
                return iscrizioni.Peek();
            }
            return null;
        }
        public List<Studente> ottieniRichiesteInAttesa()
        {
            return new List<Studente>(iscrizioni);
        }
        public int NumeroRichieste
        {
            get { return iscrizioni.Count; }
        }
    }
}