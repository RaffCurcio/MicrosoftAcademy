using System.Runtime.InteropServices.Marshalling;

class Veicolo
{
    private string marca { get; set; }
    private string modello { get; set; }
    private int annoDiProduzione { get; set; }
    private string targa { get; set; }


    public Veicolo(string marca, string modello, int annoDiProduzione, string targa)
    {
        this.marca = marca;
        this.modello = modello;
        this.annoDiProduzione = annoDiProduzione;
        this.targa = targa;
    }

    public virtual void costoAssicurazione()
    {
        System.Console.WriteLine("Calcolo costo assicurazione veicolo generico.");
    }

    public override string ToString()
    {
        return $"{marca} {modello} ({annoDiProduzione})";
    }
}