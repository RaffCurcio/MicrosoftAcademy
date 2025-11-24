using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        //es.1 crea una classe progenitrice veicolo da cui derivano due classi principali veicolo terrestre e acquatico, nel veicolo acquatico
        //saranno presenti barca e nave, nel veicolo terrestre avremo camion, moto e auto.
        //le proprietà comuni saranno marca, modello, anno di produzione e targa. il metodo comune sarà calcola costo assicurazione.
        //proprietà tipiche di veicolo terrestre saranno numero di ruote, cilindrata.
        //proprietà tipiche di veicolo acquatico saranno lunghezza e tipo motore.
        //ogni classe specifica avrà il suo override di calcolo costo di assicurazione.
        //cerca di implementare semplicemente.

        ArrayList veicoli = new ArrayList();
        veicoli.Add(new Barca("Yamaha", "X200", 2020, 5.5, "benzina", "AB123CD"));
        veicoli.Add(new Nave("Costa", "Crociere", 2018, 300, "diesel", "EF456GH"));
        veicoli.Add(new Auto("Fiat", "Panda", 2015, "IJ789KL", 4, 1200));
        veicoli.Add(new Moto("Ducati", "Monster", 2021, "MN012OP", 2, 1100));

        foreach (Veicolo v in veicoli)
        {
            Console.WriteLine(v.ToString());
            v.costoAssicurazione();
            Console.WriteLine();
        }

    }
}