using System;

namespace ScuolaMVC.Models
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodiceId { get; set; }
        public List<Studente> Studenti { get; set; } = new List<Studente>();
        public List<Docente> Docenti { get; set; } = new List<Docente>();

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Codice ID: {CodiceId}, Numero Studenti: {Studenti?.Count ?? 0}, Numero Docenti: {Docenti?.Count ?? 0}";
        }
    }
}
