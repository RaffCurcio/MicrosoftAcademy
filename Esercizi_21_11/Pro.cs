using System.Reflection.Metadata.Ecma335;

class Test
{
    static void StampaArray()
    {
        Console.WriteLine("Inserisci la dimensione dell'array:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Inserisci l'elemento {i + 1}:");
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Gli elementi dell'array sono:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
    static void StampaArrayInverso()
    {
        Console.WriteLine("Inserisci la dimensione dell'array:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Inserisci l'elemento {i + 1}:");
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Gli elementi dell'array in ordine inverso sono:");
        for (int i = n - 1; i >= 0; i--)
        {
            Console.WriteLine(array[i]);
        }
    }

    static void VerificaCrescenteDecrescente()
    {
        Console.WriteLine("Inserisci la dimensione dell'array:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Inserisci l'elemento {i + 1}:");
            array[i] = int.Parse(Console.ReadLine());
        }

        bool crescente = true;
        bool decrescente = true;

        for (int i = 1; i < n; i++)
        {
            if (array[i] <= array[i - 1])
            {
                crescente = false;
            }
            if (array[i] >= array[i - 1])
            {
                decrescente = false;
            }
        }

        if (crescente)
        {
            Console.WriteLine("L'array è strettamente crescente.");
        }
        else if (decrescente)
        {
            Console.WriteLine("L'array è strettamente decrescente.");
        }
        else
        {
            Console.WriteLine("L'array non è né strettamente crescente né strettamente decrescente.");
        }
    }
    static void DatiStatisticiVettoreCasuale()
    {
        Random rand = new Random();
        int[] array = new int[100];
        int somma = 0;
        int min = 101;
        int max = 0;

        for (int i = 0; i < 100; i++)
        {
            array[i] = rand.Next(1, 101);
            somma += array[i];
            if (array[i] < min) min = array[i];
            if (array[i] > max) max = array[i];
        }

        double media = (double)somma / 100;

        Console.WriteLine($"Somma: {somma}");
        Console.WriteLine($"Media: {media}");
        Console.WriteLine($"Minimo: {min}");
        Console.WriteLine($"Massimo: {max}");
    }

    static void ContaPariTra10e20()
    {
        Random rand = new Random();
        int[] array = new int[100];
        int count = 0;

        for (int i = 0; i < 100; i++)
        {
            array[i] = rand.Next(1, 101);
            if (array[i] % 2 == 0 && array[i] >= 10 && array[i] <= 20)
            {
                count++;
            }
        }

        Console.WriteLine($"Numero di elementi pari compresi tra 10 e 20: {count}");
    }

    static void ConversioneInteroASCII()
    {
        Console.WriteLine("Inserisci un numero intero:");
        int numero = int.Parse(Console.ReadLine());
        char carattere = (char)numero;
        Console.WriteLine($"Il carattere ASCII (UNICODE) corrispondente al numero {numero} è: '{carattere}'");
    }

    static void Main(string[] args)
    {
        int exit = 0;
        do{
            //Es. 1 leggere un numero n da tastiera dichiarare un vettore di n interi chiedere all’utente di inserire valoristampare i valori caricati nel vettore
            Console.WriteLine("1. Stampa dei valori di un array");
            //Es. 2 legga un numero n da tastiera, dichiari un vettore di K interi, riempia il vettore. Ottenga il vettore inverso, stampi il vettore ricavato.
            Console.WriteLine("2. Stampa il vettore in ordine inverso");
            //carica vettore di interi da tastiera e verifichi se: strettamente crescenti, strettamente decrescenti, Né strettamente crescenti né strettamente decrescenti
            Console.WriteLine("3. Verifica se un vettore è strettamente crescente, decrescente o nessuno dei due");
            //creare un vettore di 100 interi contenente numeri casuali compresi tra 1-100 e calcoli alcuni dati statistici: 1) somma2) media3) min4) max
            Console.WriteLine("4. Calcolo di alcuni dati statistici su un vettore di numeri casuali");
            //Ex 5 creare un vettore di 100 interi contenente numeri casuali compresi tra 1-100 e un algoritmo per contare gli elementi pari compresi tra 10 e 20
            Console.WriteLine("5. Conta gli elementi pari compresi tra 10 e 20 in un vettore di numeri casuali");
            //Es. 6 legga da tastiera un numero intero, lo converta nel corrispondente numero ASCII (UNICODE).
            Console.WriteLine("6. Conversione di un numero intero nel corrispondente carattere ASCII (UNICODE)");
            Console.WriteLine("7. Esci");
            Console.WriteLine($"Scegli un esercizio da eseguire (1-7):");
            exit = int.Parse(Console.ReadLine());

            switch(exit)
            {
                case 1:
                    StampaArray();
                    break;
                case 2:
                    StampaArrayInverso();
                    break;
                case 3:
                    VerificaCrescenteDecrescente();
                    break;
                case 4:
                    DatiStatisticiVettoreCasuale();
                    break;
                case 5:
                    ContaPariTra10e20();
                    break;
                case 6:
                    ConversioneInteroASCII();
                    break;
                case 7:
                    Console.WriteLine("Uscita dal programma.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }while(exit != 7);
    }
}