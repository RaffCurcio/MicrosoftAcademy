// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona { Nome = "Mario" };
        p.Saluta();
        p.Saluta_oldStyle();

        Studente s = new Studente { Nome = "Luigi", CorsoStudi = "Informatica" };
        s.Saluta();
        s.Saluta_oldStyle();
        s.Studia();

        Persona ps = new Studente { Nome = "Giovanni", CorsoStudi = "Matematica" };
        ps.Saluta();
        ps.Saluta_oldStyle();

        ////////////////////////////////
        Utility.StampaStringa("da esempio array\n");
        ArrayExample ae = new ArrayExample();
        Utility.StampaStringa("Esempio Array:\n");
        ae.EsempioArray();
        Console.Write("Premi un tasto per continuare\n");
        Console.ReadKey();
        ////////////////////////////////
        Utility.StampaStringa("da esempio ArrayList:\n");
        ArraylistExample ale = new ArraylistExample();
        ale.EsempioArrayList();
        Utility.StampaStringa("Premi un tasto per continuare");
        Console.ReadKey();
        Utility.StampaStringa("da esempio Interfaccia(cioè un Tipo) Animale\n");
        IAnimale a = new Cane();
        a.Verso();

        Console.WriteLine(Massimodi2Valori.Massimo(10, 20));
        Console.WriteLine(Massimodi2Valori.MaxDouble(3.14, 2.71));
        Console.WriteLine(Massimodi2Valori.MaxString("ciao", "miao"));

        Console.WriteLine(Massimodi2Valori.MaxGenerics<int>(10, 20));
        Console.WriteLine(Massimodi2Valori.MaxGenerics<double>(3.14, 2.71));
        Console.WriteLine(Massimodi2Valori.MaxGenerics<string>("Carlo", "Aldo"));
    }
}

class ArrayExample
{
    public void EsempioArray()
    {
        int[] numeri = new int[5];
        numeri[0] = 10;
        numeri[1] = 20;
        numeri[2] = 30;
        numeri[3] = 40;
        numeri[4] = 50;
        foreach (int n in numeri)
        {
        Console.WriteLine(n);
        }
    }
}

class Persona
{
    public string Nome { get; set; }

    public virtual void Saluta()
    {
        Console.WriteLine($"Ciao, mi chiamo {Nome}.");
    }

    public void Saluta_oldStyle()
    {
        Console.WriteLine($"Buondì, mi chiamo {Nome}.");
    }
}

interface IStudente
{
    void Studia();
}

class Studente : Persona, IStudente
{
    public string CorsoStudi { get; set; }

    public void Studia() => Console.WriteLine($"{Nome} sta studiando.");

    public override void Saluta() => Console.WriteLine(this + $"Ciao, sono uno studente di {CorsoStudi}."); 
}

//aggiungere classe per stampare stringa
class Utility
{
    public static void StampaStringa(string s)
    {
        Console.WriteLine(s);
    }
}

interface IAnimale
{
    void Verso();
}

class Cane : IAnimale
{
    public void Verso()
    {
        Console.WriteLine("Bau Bau");
    }
}

class ArraylistExample
{
    public void EsempioArrayList()
    {
        System.Collections.ArrayList lista = new System.Collections.ArrayList();
        lista.Add(10);
        lista.Add("Ciao");
        lista.Add(3.14);
        foreach (var item in lista)
        {
            Console.WriteLine(item);
        }
    }
}
class Massimodi2Valori
{
    public static int Massimo(int a, int b) => (a > b) ? a : b;

    public static double MaxDouble(double x, double y) => (x > y) ? x : y;


    public static string MaxString(string a, string b) => (string.Compare(a, b) > 0) ? a : b;

    //lamda expressions MaxGenerics
    public static T MaxGenerics<T>(T a, T b) where T : IComparable<T>
    {
        return (a.CompareTo(b) > 0) ? a : b;
    }

        class UsaScatole
    {
        public void Esempi()
        {
            Scatola0<string> scatolaStringhe = new Scatola0<string>();
            scatolaStringhe.Contenuto = "Ciao mondo";

            Scatola1<int> scatolaInteri = new Scatola1<int>();
            scatolaInteri.Set(42);

            Scatola1<double> scatolaDoppi = new Scatola1<double>();
            scatolaDoppi.Set(3.14);
            double valore = scatolaDoppi.Get();
        }
    }

    class Scatola0<T>
    {
        public T? Contenuto { get; set; }

    }

    class Scatola1<T>
    {
        private T? contenuto;
        public T? Get()
        {
            return contenuto;
        }
        public void Set(T obj)
        {
            contenuto = obj;
        }
        public void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

}