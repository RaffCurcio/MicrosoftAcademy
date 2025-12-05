using System;

namespace GestioneStudenti.Models
{
    public class LogOperazione
    {
        public int Id { get; set; }
        public DateTime DataOra { get; set; }
        public string Operazione { get; set; }
        public string Entita { get; set; }
        public int? IdEntita { get; set; }
        public string Descrizione { get; set; }
        public string Esito { get; set; }
        public string DettagliErrore { get; set; }

        public LogOperazione() 
        {
            DataOra = DateTime.Now;
        }

        public LogOperazione(string operazione, string entita, int? idEntita, string descrizione, string esito, string dettagliErrore = null)
        {
            DataOra = DateTime.Now;
            Operazione = operazione;
            Entita = entita;
            IdEntita = idEntita;
            Descrizione = descrizione;
            Esito = esito;
            DettagliErrore = dettagliErrore;
        }

        public override string ToString()
        {
            return $"[{DataOra:yyyy-MM-dd HH:mm:ss}] {Esito} - {Operazione} su {Entita}: {Descrizione}";
        }
    }
}