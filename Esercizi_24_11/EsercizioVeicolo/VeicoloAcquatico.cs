class VeicoloAcquatico : Veicolo
{
    public double lunghezza { get; set; }
    public string tipoMotore { get; set; }

    public VeicoloAcquatico(string marca, string modello, int annoDiProduzione, double lunghezza, string tipoMotore, string targa)
        : base(marca, modello, annoDiProduzione, targa)
    {
        this.lunghezza = lunghezza;
        this.tipoMotore = tipoMotore;
    }
    public override void costoAssicurazione()
    {
        double costo = lunghezza * (tipoMotore == "diesel" ? 200 : 150);
        System.Console.WriteLine($"Il costo dell'assicurazione è: {costo} euro");
    }
    public override string ToString()
    {
        return base.ToString() + $" - Lunghezza: {lunghezza}m - Tipo Motore: {tipoMotore}";
    }
}


/*Implementazione classi derivate VeicoloAcquatico:
- Barca
- Nave*/

class Barca : VeicoloAcquatico
{
    public Barca(string marca, string modello, int annoDiProduzione, double lunghezza, string tipoMotore, string targa)
        : base(marca, modello, annoDiProduzione, lunghezza, tipoMotore, targa)
    {
    }
}

class Nave : VeicoloAcquatico
{
    public Nave(string marca, string modello, int annoDiProduzione, double lunghezza, string tipoMotore, string targa)
        : base(marca, modello, annoDiProduzione, lunghezza, tipoMotore, targa)
    {
    }
}