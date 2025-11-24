class VeicoloTerrestre : Veicolo
{
    private int NumeroRuote { get; set; }
    private int Cilindrata { get; set; }

    public VeicoloTerrestre(string marca, string modello, int annoDiProduzione, string targa, int numeroRuote, int cilindrata)
        : base(marca, modello, annoDiProduzione, targa)
    {
        NumeroRuote = numeroRuote;
        Cilindrata = cilindrata;
    }

    public override void costoAssicurazione()
    {
        double costo = (Cilindrata * NumeroRuote)/2;
        System.Console.WriteLine($"Il costo dell'assicurazione è: {costo} euro");
    }

    public override string ToString()
    {
        return base.ToString() + $" - Ruote: {NumeroRuote} - Cilindrata: {Cilindrata}";
    }
}


/*Implementazione classi derivate VeicoloTerrestre:
- Camion
- Moto
- Auto*/
class Camion : VeicoloTerrestre
{
    public Camion(string marca, string modello, int annoDiProduzione, string targa, int numeroRuote, int cilindrata)
        : base(marca, modello, annoDiProduzione, targa, numeroRuote, cilindrata)
    {
    }   
}

class Moto : VeicoloTerrestre
{
    public Moto(string marca, string modello, int annoDiProduzione, string targa, int numeroRuote, int cilindrata)
        : base(marca, modello, annoDiProduzione, targa, numeroRuote, cilindrata)
    {
    }   
}

class Auto : VeicoloTerrestre
{
    public Auto(string marca, string modello, int annoDiProduzione, string targa, int numeroRuote, int cilindrata)
        : base(marca, modello, annoDiProduzione, targa, numeroRuote, cilindrata)
    {
    }   
}   