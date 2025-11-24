using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        /*Obiettivo: implementare un sistema di gestione studenti utilizzando una classe Studente.

        Classe Studente:
        campi privati: nome, cognome, matricola, ArrayList di voti
        costruttore che inizializza tutti i dati
        proprietà di sola lettura per nome, cognome e matricola
        proprietà calcolata della Media (di sola lettura)
        proprietà calcolata del NumeroVoti (di sola lettura)
        metodi: AggiungiVoto(int), RimuoviUltimoVoto(), StampaLibretto(), ToString()

        Programma prevede...
        Creare un arrayList di Studente e implementare un menu così composto:
        Aggiungi studente
        Cerca per matricola
        Aggiungi voto a studente
        Visualizza tutti
        Trova studente con media più alta
        Esci*/

        ArrayList studenti = new ArrayList();
        bool exit = false;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Aggiungi studente");
            Console.WriteLine("2. Cerca per matricola");
            Console.WriteLine("3. Aggiungi voto a studente");
            Console.WriteLine("4. Visualizza tutti");
            Console.WriteLine("5. Trova studente con media più alta");
            Console.WriteLine("6. Visualizza libretto studente");
            Console.WriteLine("7. Esci");
            Console.Write("Seleziona un'opzione: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Codice per aggiungere studente
                    Console.Write("Inserisci nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Inserisci cognome: ");
                    string cognome = Console.ReadLine();
                    Console.Write("Inserisci matricola: ");
                    string matricola = Console.ReadLine();
                    ArrayList voti = new ArrayList();
                    Studente nuovoStudente = new Studente(nome, cognome, matricola, voti);
                    studenti.Add(nuovoStudente);
                    Console.WriteLine("Studente aggiunto con successo.");
                    break;
                case "2":
                    // Codice per cercare per matricola
                    Console.Write("Inserisci matricola da cercare: ");
                    string cercaMatricola = Console.ReadLine();
                    Studente studenteTrovato = null;
                    foreach (Studente studente in studenti)
                    {
                        if (studente.getMatricola.Equals(cercaMatricola))
                        {
                            studenteTrovato = studente;
                            Console.WriteLine("Studente trovato:");
                            Console.WriteLine(studenteTrovato.ToString());
                            Console.WriteLine("Vuoi stampare il libretto? (s/n)");
                            string risposta = Console.ReadLine();
                            if (risposta.ToLower() == "s")
                            {
                                studenteTrovato.StampaLibretto();
                            }
                            break;
                        }else
                        {
                            Console.WriteLine("Studente non trovato.");
                        }
                    }
                    break;
                case "3":
                    // Codice per aggiungere voto a studente
                    Console.Write("Inserisci matricola dello studente: ");
                    string mat = Console.ReadLine();
                    Studente trovato = null;
                    foreach (Studente studente in studenti)
                    {
                        if (studente.getMatricola.Equals(mat))
                        {
                            trovato = studente;
                            Console.Write("Inserisci voto da aggiungere: ");
                            int voto = int.Parse(Console.ReadLine());
                            trovato.AggiungiVoto(voto);
                            Console.WriteLine("Voto aggiunto con successo.");
                            break;
                        }else
                        {
                            Console.WriteLine("Studente non trovato.");
                        }
                    }
                    break;
                case "4":
                    // Codice per visualizzare tutti gli studenti
                    Console.WriteLine("Elenco studenti:");
                    foreach (Studente studente in studenti)
                    {
                        Console.WriteLine(studente.ToString());
                    }
                    break;
                case "5":
                    // Codice per trovare studente con media più alta
                    if (studenti.Count == 0)
                    {
                        Console.WriteLine("Nessuno studente presente.");
                        break;
                    }
                    Studente topStudente = (Studente)studenti[0];
                    foreach (Studente studente in studenti)
                    {
                        if (studente.Media > topStudente.Media)
                        {
                            topStudente = studente;
                        }
                    }
                    Console.WriteLine("Studente con media più alta:");
                    Console.WriteLine(topStudente.ToString()+" con media: "+topStudente.Media);
                    break;
                case "6":
                    // Codice per visualizzare libretto studente
                    Console.Write("Inserisci matricola dello studente: ");
                    string m = Console.ReadLine();
                    Studente sTrovato = null;
                    foreach (Studente studente in studenti)
                    {                        
                        if (studente.getMatricola.Equals(m))
                        {
                            sTrovato = studente;
                            sTrovato.StampaLibretto();
                            break;
                        }
                    }
                    if (sTrovato == null)
                    {
                        Console.WriteLine("Studente non trovato.");
                    }
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
            Console.WriteLine();
            
        }while(!exit);
    }
}