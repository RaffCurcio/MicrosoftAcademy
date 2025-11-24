class Insegnante : Persona
{
    private string materia { get; set; }
    private string stipendio { get; set; }

    public Insegnante(string nome, string cognome, DateTime dataNascita, string materia, string stipendio)
        : base(nome, cognome, dataNascita)
    {
        this.materia = materia;
        this.stipendio = stipendio;
    }

    public override void Saluta()
    {
        System.Console.WriteLine($"Ciao, sono l'insegnante {nome} {cognome}, insegno {materia} e il mio stipendio è {stipendio}.");
    }

    public override string ToString()
    {
        return base.ToString() + $"\nMateria: {materia}\nStipendio: {stipendio}";
    }
}