using System;
using System.Collections.Generic;

namespace EsercizioProdotti.Views
{
    public class ViewGenerica<T>
    {
        private string nomeEntita;

        public ViewGenerica(string nomeEntita)
        {
            this.nomeEntita = nomeEntita;
        }

        public void MostraMenu()
        {
            Console.WriteLine($"\n=== Menu {nomeEntita} ===");
            Console.WriteLine($"1. Visualizza tutti i {nomeEntita.ToLower()}");
            Console.WriteLine($"2. Aggiungi {nomeEntita.ToLower()}");
            Console.WriteLine($"3. Modifica {nomeEntita.ToLower()}");
            Console.WriteLine($"4. Elimina {nomeEntita.ToLower()}");
            Console.WriteLine("5. Esci");
            Console.Write("Seleziona un'opzione: ");
        }

        public int OttieniSceltaUtente()
        {
            try
            {
                return int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                return 0;
            }
        }

        public void MostraLista(List<T> lista)
        {
            Console.WriteLine($"\n===== Elenco {nomeEntita} =====");
            if (lista.Count == 0)
            {
                Console.WriteLine($"Nessun {nomeEntita.ToLower()} trovato.");
            }
            else
            {
                foreach (var elemento in lista)
                {
                    Console.WriteLine(elemento?.ToString());
                }
            }
        }

        public void MostraElemento(T elemento)
        {
            Console.WriteLine("\n" + elemento?.ToString());
        }

        public int OttieniId(string messaggio)
        {
            Console.Write(messaggio);
            try
            {
                return int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                return 0;
            }
        }

        public string OttieniInput(string campo)
        {
            Console.Write($"{campo}: ");
            return Console.ReadLine() ?? "";
        }

        public bool ConfermaEliminazione()
        {
            Console.Write($"Sei sicuro di voler eliminare questo {nomeEntita.ToLower()}? (s/n): ");
            string risposta = Console.ReadLine()?.ToLower() ?? "n";
            return risposta == "s" || risposta == "si";
        }

        public void MostraMessaggio(string messaggio)
        {
            Console.WriteLine(messaggio);
        }

        public void MostraOpzioneNonValida()
        {
            Console.WriteLine("Opzione non valida. Riprova.");
        }

        public void MostraTitolo(string titolo)
        {
            Console.WriteLine($"\n=== {titolo} ===");
        }
    }
}
