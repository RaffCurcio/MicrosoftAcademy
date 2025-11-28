using System;
using System.Collections.Generic;
using System.Linq;
using GestioneStudenti.Interfaces;

namespace GestioneStudenti.Model
{
    public class CorsoLaurea : IEntita
    {
        private string codice;
        private string nome;
        private List<Professore> professori;

        public CorsoLaurea(string codice, string nome)
        {
            this.codice = codice;
            this.nome = nome;
            this.professori = new List<Professore>();
        }

        public string Codice
        {
            get { return codice; }
        }

        public string Id
        {
            get { return codice; }
        }

        public string Nome
        {
            get { return nome; }
        }

        public void AggiungiProfessore(Professore professore)
        {
            if (professore == null)
            {
                Console.WriteLine("Professore non valido.");
                return;
            }
            if (professori.Any(p => p.CodiceId == professore.CodiceId))
            {
                Console.WriteLine("Professore già presente nel corso.");
                return;
            }

            professori.Add(professore);
            Console.WriteLine($"Professore {professore.Nome} {professore.Cognome} aggiunto al corso {nome}.");
        }

        public List<Professore> GetProfessori()
        {
            return new List<Professore>(professori);
        }

        public bool MateriaDisponibile(string materia)
        {
            return professori.Any(p => p.Materia.Equals(materia));
        }

        public List<string> GetMaterie()
        {
            return professori.Select(p => p.Materia).Distinct().ToList();
        }

        public override string ToString()
        {
            return $"{nome} (Codice: {codice}) - {professori.Count} professori";
        }

        public void StampaDettagli()
        {
            Console.WriteLine($"\n=== {nome} (Codice: {codice}) ===");
            Console.WriteLine($"Professori e materie:");
            foreach (var prof in professori)
            {
                Console.WriteLine($"  - {prof}");
            }
        }
    }
}