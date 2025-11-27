using System;

namespace GestioneStudenti.View
{
    public static class ConsoleView
    {
        public static void MostraMenu()
        {
            Console.WriteLine("=========== MENU STUDENTI ===========");
            Console.WriteLine("1. Aggiungi studente");
            Console.WriteLine("2. Cerca studente per matricola");
            Console.WriteLine("3. Aggiungi voto");
            Console.WriteLine("4. Visualizza tutti gli studenti");
            Console.WriteLine("5. Trova studente con media più alta");
            Console.WriteLine("6. Visualizza libretto studente");
            Console.WriteLine("7. Esci");
            Console.Write("Scegli un'opzione: ");
        }

        public static string LeggiInput(string messaggio)
        {
            Console.Write(messaggio);
            return Console.ReadLine();
        }

        public static void Stampa(object output)
        {
            Console.WriteLine(output);
        }
    }
}
