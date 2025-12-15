using System;

namespace ScuolaMVC.Models
{
    public class Studente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Matricola { get; set; }
        public List<Corso> Corsi { get; set; } = new List<Corso>();

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Cognome: {Cognome}, Matricola: {Matricola}";
        }
    }
}
