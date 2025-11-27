using System;
using System.Collections.Generic;

namespace GestioneStudenti.Model
{
    public class Studente
    {
        private string nome { get; set; }
        private string cognome { get; set; }
        private string matricola { get; set; }
        private List<int> voti = new List<int>();

        public Studente(string nome, string cognome, string matricola, List<int> voti)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.matricola = matricola;
            this.voti = voti;
        }

        public string getMatricola
        {
            get { return matricola; }
            set { matricola = value; }
        }

        public double Media
        {
            get
            {
                if (voti.Count == 0) return 0;
                double sum = 0;
                foreach (int voto in voti)
                    sum += voto;

                return sum / voti.Count;
            }
        }

        public int NumeroVoti => voti.Count;

        public void AggiungiVoto(int voto)
        {
            if (voto >= 18 && voto <= 30)
            {
                voti.Add(voto);
            }
            else
            {
                Console.WriteLine("Voto non valido (18-30).");
            }
        }

        public void RimuoviUltimoVoto()
        {
            if (voti.Count > 0)
                voti.RemoveAt(voti.Count - 1);
        }

        public void StampaLibretto()
        {
            Console.WriteLine($"\nLibretto di {nome} {cognome} (Matricola: {matricola}):");
            foreach (int voto in voti)
                Console.WriteLine($"- Voto: {voto}");

            Console.WriteLine($"Media: {Media}\n");
        }

        public override string ToString()
        {
            return $"{nome} {cognome} - Matricola: {matricola} (Voti: {voti.Count}, Media: {Media})";
        }
    }
}
