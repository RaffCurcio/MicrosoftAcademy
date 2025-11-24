using System;
using System.Collections;
class Studente
{
    private string nome { get; set; }
    private string cognome { get; set; }
    private string matricola { get; set; }
    private ArrayList voti = new ArrayList();


    public Studente(string nome, string cognome, string matricola, ArrayList voti)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.matricola = matricola;
        this.voti = voti;
    }

    public string getMatricola
    {
        get{return matricola;}
        set{matricola = value;}
    }

    public double Media
    {
        get
        {
            if (voti.Count == 0) return 0;
            double somma = 0;
            foreach (int voto in voti)
            {
                somma += voto;
            }
            return somma / voti.Count;
        }
    }

    public int NumeroVoti
    {
        get { return voti.Count; }
    }

    public int AggiungiVoto(int voto)
    {
        if (voto < 18 || voto > 30) voti.Add(voto);
        else Console.WriteLine("Voto non valido. Deve essere tra 18 e 30.");
        return voti.Count;
    }

    public int RimuoviUltimoVoto()
    {
        if (voti.Count == 0) return 0;
        voti.RemoveAt(voti.Count - 1);
        return voti.Count;
    }

    public void StampaLibretto()
    {
        Console.WriteLine($"Libretto di {nome} {cognome} (Matricola: {matricola}):");
        foreach (int voto in voti)
        {
            Console.WriteLine($"- Voto: {voto}");
        }
        Console.WriteLine($"- Media: {Media}");
    }

    public virtual string ToString()
    {
        return $"{nome} {cognome}, Matricola: {matricola} - Numero Voti: {voti.Count}";
    }
}