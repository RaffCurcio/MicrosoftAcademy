using System;

namespace EsercizioProdotti.Models
{
    public class Citta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Regione { get; set; }

        public Citta() { }

        public Citta(string nome, string regione)
        {
            Nome = nome;
            Regione = regione;
        }

        public Citta(int id, string nome, string regione)
        {
            Id = id;
            Nome = nome;
            Regione = regione;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Regione: {Regione}";
        }
    }
}
