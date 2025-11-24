public class Studente : Persona
{
    private string matricola { get; set; }

    public Studente(string nome, string cognome, DateTime dataNascita, string matricola)
        : base(nome, cognome, dataNascita)
    {
        this.matricola = matricola;
    }

    public void Studia()
    {
        System.Console.WriteLine($"{nome} {cognome} sta studiando.");
    }

    public override string ToString()
    {
        return base.ToString() + $"\nMatricola: {matricola}";
    }
}