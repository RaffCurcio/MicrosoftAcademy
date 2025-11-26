namespace GestioneLibri
{
    public static class GestioneIO
    {
        public static void Menu()
        {
            Mensola mensola = new Mensola();

            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Inserire un libro");
                Console.WriteLine("2. Visualizzare tutti i libri");
                Console.WriteLine("3. Ricercare un libro per titolo");
                Console.WriteLine("4. Modificare un libro");
                Console.WriteLine("5. Eliminare un libro");
                Console.WriteLine("6. Ordina i libri per prezzo");
                Console.WriteLine("7. Svuota la mensola");
                Console.WriteLine("8. Uscire");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        InserisciLibro(mensola);
                        break;

                    case "2":
                        VisualizzaLibri(mensola);
                        break;

                    case "3":
                        RicercaLibro(mensola);
                        break;

                    case "4":
                        ModificaLibro(mensola);
                        break;

                    case "5":
                        EliminaLibro(mensola);
                        break;

                    case "6":
                        mensola.OrdinaPerPrezzo();
                        break;
                    case "7":
                        mensola.Svuota();
                        Console.WriteLine("Mensola svuotata.");
                        break;

                    case "8":
                        Console.WriteLine("Uscita in corso...");
                        return;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }

        private static void InserisciLibro(Mensola mensola)
        {
            if (mensola.NumeroLibri >= mensola.NumeroMax)
            {
                Console.WriteLine("La mensola è piena.");
                return;
            }

            Console.Write("Titolo: ");
            string titolo = Console.ReadLine();

            Console.Write("Autore: ");
            string autore = Console.ReadLine();

            Console.Write("Numero pagine: ");
            int numPagine = int.Parse(Console.ReadLine());

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            while (mensola.VisualizzaLibri().Any(libro => libro.Isbn == isbn))
            {
                Console.WriteLine("ISBN già esistente. Inserisci un ISBN univoco.");
                Console.Write("ISBN: ");
                isbn = Console.ReadLine();
            }

            Console.Write("Genere: ");
            string genere = Console.ReadLine();

            Libro l = new Libro(titolo, autore, numPagine, isbn, genere);
            mensola.AggiungiLibro(l);

            Console.WriteLine("Libro aggiunto con successo!");
        }
        private static void VisualizzaLibri(Mensola mensola)
        {
            Console.WriteLine("\n=== LIBRI PRESENTI ===");

            if (mensola.NumeroLibri == 0)
            {
                Console.WriteLine("La mensola è vuota.");
                return;
            }
            foreach (var libro in mensola.VisualizzaLibri())
            {
                Console.WriteLine(libro.ToString());
            }
        }

        private static void RicercaLibro(Mensola mensola)
        {
            Console.Write("Titolo del libro da cercare: ");
            string titolo = Console.ReadLine();
            for (int i = 0; i < mensola.NumeroLibri; i++)
            {
                Libro libro = mensola.GetLibro(i);

                if (libro.Titolo.Equals(titolo))
                {
                    Console.WriteLine("Libro trovato:");
                    Console.WriteLine(libro.ToString());
                    return;
                }
            }
            Console.WriteLine("Libro non trovato.");
        }

        private static void ModificaLibro(Mensola mensola)
        {
            Console.Write("inserisci la posizione del libro da modificare: ");
            int pos = int.Parse(Console.ReadLine()) - 1;
            Libro? libro = mensola.GetLibro(pos);
            if (libro == null)
            {
                Console.WriteLine("Posizione non valida.");
                return;
            }

            Console.Write("Cosa vuoi modificare? (titolo, autore, numPagine, isbn, genere): ");
            string campo = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo valore:");
            string nuovoValore = Console.ReadLine();
            string titolo = libro.Titolo;
            string autore = libro.Autore;
            int numPagine = libro.NumPagine;
            string isbn = libro.Isbn;
            string genere = libro.Genere;

            switch (campo.ToLower())
            {
                case "titolo":
                    titolo = nuovoValore;
                    break;
                case "autore":
                    autore = nuovoValore;
                    break;
                case "numpagine":
                    numPagine = int.Parse(nuovoValore);
                    break;
                case "isbn":
                    isbn = nuovoValore;
                    break;
                case "genere":
                    genere = nuovoValore;
                    break;
                default:
                    Console.WriteLine("Campo non valido.");
                    return;
            }

            Libro nuovoLibro = new Libro(titolo, autore, numPagine, isbn, genere);
            mensola.ModificaLibro(pos, nuovoLibro);

            Console.WriteLine("Libro modificato con successo!");
        }

        private static void EliminaLibro(Mensola mensola)
        {
            Console.Write("inserisci la posizione del libro da eliminare: ");
            int pos = int.Parse(Console.ReadLine()) - 1;
            if (mensola.EliminaLibro(pos))
            {
                Console.WriteLine("Libro eliminato.");
            }
            else
            {
                Console.WriteLine("Posizione non valida.");
            }
        }
    }
}
