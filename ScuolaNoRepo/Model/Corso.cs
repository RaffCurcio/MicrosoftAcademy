using System;

namespace ScuolaNoRepo.Model
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string codiceId { get; set; }
        public List<Studente> Studenti { get; set; }
        public List<Docente> Docenti { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Codice ID: {codiceId}, Numero Studenti: {Studenti?.Count ?? 0}, Numero Docenti: {Docenti?.Count ?? 0}";
        }
    }
}