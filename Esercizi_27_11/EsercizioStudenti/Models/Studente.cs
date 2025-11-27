using System;
using System.Collections.Generic;
using System.Linq;

namespace GestioneStudenti.Model
{
    public class Studente
    {
        private string nome;
        private string cognome;
        private string matricola;
        private List<Voto> voti;
        private CorsoLaurea corsoLaurea; // Relazione: uno studente è iscritto a UN solo corso

        public Studente(string nome, string cognome, string matricola)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.matricola = matricola;
            this.voti = new List<Voto>();
            this.corsoLaurea = null;
        }

        public string Matricola
        {
            get { return matricola; }
        }

        public string Nome
        {
            get { return nome; }
        }

        public string Cognome
        {
            get { return cognome; }
        }

        public CorsoLaurea CorsoLaurea
        {
            get { return corsoLaurea; }
        }

        public void IscriviACorso(CorsoLaurea corso)
        {
            if (corsoLaurea != null)
            {
                Console.WriteLine($"Studente già iscritto al corso {corsoLaurea.Nome}.");
                return;
            }
            corsoLaurea = corso;
            Console.WriteLine($"Studente {nome} {cognome} iscritto al corso {corso.Nome}.");
        }

        public double Media
        {
            get
            {
                if (voti.Count == 0) return 0;
                double sum = 0;
                foreach (var voto in voti)
                    sum += voto.Valore;

                return sum / voti.Count;
            }
        }

        public int NumeroVoti => voti.Count;

        public bool AggiungiVoto(int valore, string materia)
        {
            if (corsoLaurea == null)
            {
                Console.WriteLine("Errore: lo studente non è iscritto a nessun corso di laurea.");
                return false;
            }

            if (!corsoLaurea.MateriaDisponibile(materia))
            {
                Console.WriteLine($"Errore: la materia '{materia}' non è presente nel corso {corsoLaurea.Nome}.");
                Console.WriteLine($"Materie disponibili: {string.Join(", ", corsoLaurea.GetMaterie())}");
                return false;
            }

            if (valore < 18 || valore > 30)
            {
                Console.WriteLine("Voto non valido (18-30).");
                return false;
            }

            voti.Add(new Voto(valore, materia));
            Console.WriteLine($"Voto {valore} in {materia} aggiunto con successo!");
            return true;
        }

        public void RimuoviUltimoVoto()
        {
            if (voti.Count > 0)
            {
                var votoRimosso = voti[voti.Count - 1];
                voti.RemoveAt(voti.Count - 1);
                Console.WriteLine($"Rimosso voto: {votoRimosso}");
            }
            else
            {
                Console.WriteLine("Non ci sono voti da rimuovere.");
            }
        }

        public void StampaLibretto()
        {
            Console.WriteLine($"\n===== Libretto di {nome} {cognome} =====");
            Console.WriteLine($"Matricola: {matricola}");
            
            if (corsoLaurea != null)
                Console.WriteLine($"Corso di Laurea: {corsoLaurea.Nome}");
            else
                Console.WriteLine("Corso di Laurea: Non iscritto");

            Console.WriteLine("\nVoti:");
            if (voti.Count == 0)
            {
                Console.WriteLine("  Nessun voto registrato.");
            }
            else
            {
                foreach (var voto in voti)
                    Console.WriteLine($"  - {voto}");
                Console.WriteLine($"\nMedia: {Media:F2}");
            }
            Console.WriteLine("=====================================\n");
        }

        public override string ToString()
        {
            string corso = corsoLaurea != null ? corsoLaurea.Nome : "Non iscritto";
            return $"{nome} {cognome} - Matricola: {matricola} | Corso: {corso} | Voti: {voti.Count}, Media: {Media:F2}";
        }
    }
}