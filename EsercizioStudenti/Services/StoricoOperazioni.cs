using System;
using System.Collections.Generic;

namespace GestioneStudenti.Services
{
    public class StoricoOperazioni
    {
        private Stack<string> operazioni;

        public StoricoOperazioni()
        {
            operazioni = new Stack<string>();
        }

        public void Registra(string operazione)
        {
            operazioni.Push(operazione);
        }
        public string UltimaOperazione()
        {
            if (operazioni.Count > 0)
                return operazioni.Peek();
            else
                return null;
        }
        public string Annulla()
        {
            if (operazioni.Count > 0)
                return operazioni.Pop();
            else
                return null;
        }
        public string[] OttieniTutte()
        {
            return operazioni.ToArray();
        }
        public int Count()
        {
            return operazioni.Count;
        }

    }
}