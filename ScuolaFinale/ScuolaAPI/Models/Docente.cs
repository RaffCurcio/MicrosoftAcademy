using System;
using System.Linq;

namespace ScuolaAPI.Models
{
    public class Docente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Materia { get; set; }
        public List<Corso> Corsi { get; set; } = new List<Corso>();

        public override string ToString()
        {
            var corsiNomi = Corsi != null && Corsi.Any() ? string.Join(", ", Corsi.Select(c => c.Nome)) : "Nessuno";
            return $"ID: {Id}, Nome: {Nome}, Materia: {Materia}, Corsi: {corsiNomi}";
        }
    }
}
