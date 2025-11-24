public class Persona
{
    protected string nome { get; set; }
    protected string cognome { get; set; }
    protected DateTime dataNascita { get; set; }

    public Persona(string nome, string cognome, DateTime dataNascita)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.dataNascita = dataNascita;
    }

    public virtual void Saluta()
    {
        System.Console.WriteLine($"Ciao, mi chiamo {nome} {cognome}.");
    }

    public override string ToString()
    {
        return $"Nome: {nome}\nCognome: {cognome}\nData di Nascita: {dataNascita.ToShortDateString()}";
    }
}