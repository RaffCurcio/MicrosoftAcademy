class Test
{
    public static void Main()
    {
        Persona p = new Persona("Mario", "Rossi", new DateTime(2002, 8, 29));
        p.Saluta();

        Console.WriteLine($"È maggiorenne? {p.VerificaMaggiorenne()}");
        Persona y = new Studente("Luigi", "Verdi", new DateTime(2005, 3, 15), "S12345");
        Console.WriteLine(y.ToString()); 

        Studente z = new Studente("Anna", "Bianchi", new DateTime(2000, 12, 1), "S54321");
        Console.WriteLine(z.ToString());
        z.Saluta();

        if(y is Studente)
        {
            ((Studente)y).Studia();
        }

        z.Studia();
    }
}