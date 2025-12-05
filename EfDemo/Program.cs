using System;
using EfDemo.Models;

class Program
{
    static void Main(string[] args)
    {
        using var db = new ScuolaContext();
        //CREATE
        //db.Studenti.Add(new Studente { Nome = "Mario", Eta = 22 });
        //db.Studenti.Add(new Studente { Nome = "Luca", Eta = 22 });
        //db.Studenti.Add(new Studente { Nome = "Carlo", Eta = 22 });
        //db.SaveChanges();
        // READ
        var elenco = db.Studenti.ToList();
        foreach (var s in elenco)
        Console.WriteLine($"{s.Id} - {s.Nome} - {s.Eta}");
        // UPDATE
        var stud = db.Studenti.First();
        stud.Eta = 23;
        db.SaveChanges();
        // DELETE
        //db.Studenti.Remove(stud);
        //db.SaveChanges();
        //Console.WriteLine("Operazioni completate.");

        //VISUALIZZARE 
        var studenti = db.Studenti.ToList();
        foreach (var studente in studenti)
        {
            Console.WriteLine($"{studente.Id} - {studente.Nome} - {studente.Eta}");
        }

        //MODIFICA ELEMENTO SPECIFICO
        Console.WriteLine("Inserisci l'ID dello studente da modificare:");
        int idDaModificare = int.Parse(Console.ReadLine() ?? "0");
        var studenteDaModificare = db.Studenti.Find(idDaModificare);
        if (studenteDaModificare != null)
        {
            Console.WriteLine("Inserisci il nuovo nome:");
            studenteDaModificare.Nome = Console.ReadLine() ?? studenteDaModificare.Nome;
            Console.WriteLine("Inserisci la nuova età:");
            studenteDaModificare.Eta = int.Parse(Console.ReadLine() ?? studenteDaModificare.Eta.ToString());
            db.SaveChanges();
            Console.WriteLine("Studente modificato con successo.");
        }
    }
}