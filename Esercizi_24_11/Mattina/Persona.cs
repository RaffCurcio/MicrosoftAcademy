public class Persona
{
    protected string nome { get; set; }
    protected string cognome { get; set; }
    private DateTime dataNascita { get; set; }

    public Persona(string nome, string cognome, DateTime dataNascita)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.dataNascita = dataNascita;
    }

    public int GetEta()
    {
        int anni = DateTime.Now.Year - dataNascita.Year;
        return anni;
    }

    public bool VerificaMaggiorenne()
    {
        return GetEta() >= 18;
    }

    public void Saluta()
    {
        System.Console.WriteLine($"Ciao, mi chiamo {nome} {cognome} e ho {GetEta()} anni.");
    }

    public override string ToString()
    {
        return $"Nome: {nome}\nCognome: {cognome}\nData di Nascita: {dataNascita.ToShortDateString()}\nEtà: {GetEta()} anni";
    }
}