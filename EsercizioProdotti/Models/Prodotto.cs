using System;

namespace EsercizioProdotti.Models
{
    public class Prodotto
    {
        public int Id { get; private set; }
        public string NomeProdotto { get; set; }
        public int Giacenza { get; set; }
        public decimal Prezzo { get; set; }

        public Prodotto() { }

        public Prodotto(string nomeProdotto, int giacenza, decimal prezzo)
        {
            NomeProdotto = nomeProdotto;
            Giacenza = giacenza;
            Prezzo = prezzo;
        }

        public Prodotto(int id, string nomeProdotto, int giacenza, decimal prezzo)
        {
            Id = id;
            NomeProdotto = nomeProdotto;
            Giacenza = giacenza;
            Prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {NomeProdotto}, Prezzo: €{Prezzo:F2}, Giacenza: {Giacenza}";
        }
    }
}
