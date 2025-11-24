class Studente : Persona
{
    private string matricola { get; set; }
    private string corsoDiLaurea { get; set; }

    public Studente(string nome, string cognome, DateTime dataNascita, string matricola, string corsoDiLaurea)
        : base(nome, cognome, dataNascita)
    {
        this.matricola = matricola;
        this.corsoDiLaurea = corsoDiLaurea;
    }

    public override void Saluta()
    {
        System.Console.WriteLine($"Ciao, sono lo studente {nome} {cognome}, matricola {matricola}, iscritto al corso di laurea in {corsoDiLaurea}.");
    }

    public override string ToString()
    {
        return base.ToString() + $"\nMatricola: {matricola}\nCorso di Laurea: {corsoDiLaurea}";
    }
}