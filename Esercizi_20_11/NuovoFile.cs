/*class Program
{
    static double Media(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return (double)sum / numbers.Length;
    }
    static int [] inserisciNumeri(int count)
    {
        int[] numbers = new int[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Inserisci il numero {i + 1}:");
            numbers[i] = int.Parse(Console.ReadLine());
        }
        return numbers;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Quanti numeri vuoi inserire?");
        int count;
        do
     {
            count = int.Parse(Console.ReadLine() ?? "0");
            if (count >= 20)
            {
                Console.WriteLine("Errore! Devi inserire un numero minore di 20.");
            }
        } while(count>=20);
        
        int[] numbers = new int[count];
        numbers = inserisciNumeri(count);
        double media = Media(numbers);
        Console.WriteLine($"La media dei numeri inseriti è: {media}");
    }
}
*/