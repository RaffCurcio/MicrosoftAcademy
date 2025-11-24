using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        // Creazione di una ArrayList per memorizzare i numeri interi
        ArrayList persone = new ArrayList();

        persone.Add(new Persona("Mario", "Rossi", new DateTime(1990, 5, 15)));
        persone.Add(new Studente("Luca", "Bianchi", new DateTime(2000, 3, 22), "S12345", "Informatica"));
        persone.Add(new Insegnante("Anna", "Verdi", new DateTime(1980, 7, 10), "Matematica", "2500€"));

        foreach (Persona persona in persone)
        {
            persona.Saluta();
            Console.WriteLine(persona.ToString());
            Console.WriteLine();
        }

    }
}