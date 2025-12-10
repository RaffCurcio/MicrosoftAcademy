using System;
using ScuolaNoRepo.Controller;
using ScuolaNoRepo.Model;

namespace ScuolaNoRepo.View
{
    public class StudenteView
    {
        StudenteController StudenteController = new StudenteController();
        public void MenuStudente()
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("GESTIONE STUDENTI");
                Console.WriteLine("1. Aggiungi Studenti");
                Console.WriteLine("2. Visualizza Studente");
                Console.WriteLine("3. Modifica Studente");
                Console.WriteLine("4. Elimina Studente");
                Console.WriteLine("0. Torna al Menu Principale");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiStudente();
                        break;
                    case "2":
                        VisualizzaStudenti();
                        break;
                    case "3":
                        // Aggiungi voto a Studente
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

            } while (!exit);
        }

        //aggiungi studente
        public void VisualizzaStudenti()
        {
            Console.Clear();
            Console.WriteLine("LISTA STUDENTI\n");
            
            var lista = StudenteController.GetAll();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nessuno studente presente nel database.");
            }
            else
            {
                foreach (var studente in lista)
                {
                    Console.WriteLine($"ID: {studente.Id}, Nome: {studente.Nome}, Cognome: {studente.Cognome}, Matricola: {studente.matricola}");
                }
            }
            
            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        public void AggiungiStudente()
        {
            Console.Clear();
            Console.WriteLine("AGGIUNGI STUDENTE\n");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Matricola: ");
            string matricola = Console.ReadLine();

            Studente nuovoStudente = new Studente
            {
                Nome = nome,
                Cognome = cognome,
                matricola = matricola
            };

            StudenteController.AddStudente(nuovoStudente);

            Console.WriteLine("\nStudente aggiunto con successo! Premi un tasto per continuare...");
            Console.ReadKey();
        }

        public void ModificaStudente()
        {
            Console.Clear();
            Console.WriteLine("MODIFICA STUDENTE\n");
            Console.Write("Inserisci l'ID dello studente da modificare: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var lista = StudenteController.GetAll();
                var studente = lista.Find(s => s.Id == id);
                if (studente != null)
                {
                    Console.Write($"Nuovo Nome (attuale: {studente.Nome}): ");
                    string nuovoNome = Console.ReadLine();
                    Console.Write($"Nuovo Cognome (attuale: {studente.Cognome}): ");
                    string nuovoCognome = Console.ReadLine();
                    Console.Write($"Nuova Matricola (attuale: {studente.matricola}): ");
                    string nuovaMatricola = Console.ReadLine();
                    studente.Nome = string.IsNullOrWhiteSpace(nuovoNome) ? studente.Nome : nuovoNome;
                    studente.Cognome = string.IsNullOrWhiteSpace(nuovoCognome) ? studente.Cognome : nuovoCognome;
                    studente.matricola = string.IsNullOrWhiteSpace(nuovaMatricola) ? studente.matricola : nuovaMatricola;
                    StudenteController.ModificaStudente(studente);
                    Console.WriteLine("\nStudente modificato con successo! Premi un tasto per continuare...");
                }
                else
                {
                    Console.WriteLine("Studente non trovato.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
            Console.ReadKey();
        }

        public void EliminaStudente()
        {
            Console.Clear();
            Console.WriteLine("ELIMINA STUDENTE\n");
            Console.Write("Inserisci l'ID dello studente da eliminare: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var lista = StudenteController.GetAll();
                var studente = lista.Find(s => s.Id == id);
                if (studente != null)
                {
                    StudenteController.EliminaStudente(studente);
                    Console.WriteLine("\nStudente eliminato con successo! Premi un tasto per continuare...");
                }
                else
                {
                    Console.WriteLine("Studente non trovato.");
                }
            }
            else
            {
                Console.WriteLine("ID non valido.");
            }
            Console.ReadKey();
        }
    }
}