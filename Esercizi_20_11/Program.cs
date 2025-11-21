/*class Program
{
    static void Main(string[] args)
    {
       
       /* string risposta;
        do
        {
            int N;
            int sum = 0;
            int n;
            Console.WriteLine($"Inserisci il numero di elementi da sommare:");
            N = int.Parse(Console.ReadLine());

            for(int i=0;i<N;i++)
            {
                Console.WriteLine($"Inserisci un numero:");
                n = int.Parse(Console.ReadLine());
                if(n%2==0 && n>5 && n<=30)
                {
                    sum+=n;
                }
            }
            Console.WriteLine($"La somma è: {sum}");

            Console.WriteLine($"\nVuoi ripetere il programma? (s/n):");
            risposta = Console.ReadLine()?.ToLower() ?? "n";
            
        } while (risposta == "s");
        
        Console.WriteLine("Programma terminato.");*/


        /*
        int numero1 = 0, numero2 = 0;
        bool successo1 = false, successo2 = false;

        do{
                if(!successo1)
                {
                    Console.WriteLine("Inserisci il primo numero:");
                    string input1 = Console.ReadLine();
                    successo1 = int.TryParse(input1, out numero1);
                    if(!successo1)
                    {
                        Console.WriteLine($"Errore! Devi inserire un numero valido.");
                    }
                }
                
                if(!successo2 && successo1)
                {
                    Console.WriteLine($"Inserisci il secondo numero:");
                    string input2 = Console.ReadLine();
                    successo2 = int.TryParse(input2, out numero2);
                    if(!successo2)
                    {
                        Console.WriteLine($"Errore! Devi inserire un numero valido.");
                    }
                }
        }while(!successo1 || !successo2);
        int somma = numero1 + numero2;
        Console.WriteLine($"La somma dei due numeri è: {somma}");

        int scelta = 0;
        int n1, n2;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Somma");
            Console.WriteLine("2. Sottrazione");
            Console.WriteLine("3. Divisione");
            Console.Write("Scegli un'operazione: ");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 0:
                    Console.WriteLine("Uscita dal programma.");
                    break;
                case 1:
                    Console.WriteLine("Hai scelto Somma.");
                    (n1, n2) = inserisci();
                    int somma = Somma(n1, n2);
                    Console.WriteLine($"Risultato: {somma}");
                    break;
                case 2:
                    Console.WriteLine("Hai scelto Sottrazione.");
                    (n1, n2) = inserisci();
                    int sottrazione = Sottrazione(n1, n2);
                    Console.WriteLine($"Risultato: {sottrazione}");
                    break;
                case 3:
                    Console.WriteLine("Hai scelto Divisione.");
                    (n1, n2) = inserisci();
                    (int divisione, int resto) = Divisione(n1, n2);
                    Console.WriteLine($"Risultato: {divisione} con resto {resto}");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        } while (scelta != 0);
    }

    static (int, int) inserisci()
    {
        int n1 = 0, n2 = 0;
        bool successo1 = false, successo2 = false;
        do{
            if(!successo1)
            {
                Console.WriteLine("Inserisci il primo numero:");
                string input1 = Console.ReadLine();
                successo1 = check(input1, out n1);
                if(!successo1)
                {
                    Console.WriteLine($"Errore! Devi inserire un numero valido.");
                }
            }
            if(!successo2 && successo1)
            {
                Console.WriteLine($"Inserisci il secondo numero:");
                string input2 = Console.ReadLine();
                successo2 = check(input2, out n2);
                if(!successo2)
                {
                    Console.WriteLine($"Errore! Devi inserire un numero valido.");
                }
            }
        }while(!successo1 || !successo2);
        return (n1, n2);
    }
    static bool check(string input, out int n){
        bool successo = int.TryParse(input, out n);
        return successo;
    }

    static int Somma(int a, int b)
    {
        return a + b;
    }

    static int Sottrazione(int a, int b)
    {
        return a - b;
    }

    static (int, int) Divisione(int a, int b)
    {
        int quoziente = a / b;
        int resto = a % b;
        return (quoziente, resto);
    }
}
*/