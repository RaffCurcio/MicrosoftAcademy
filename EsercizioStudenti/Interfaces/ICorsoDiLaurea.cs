using System;
using GestioneStudenti.Model;
using System.Collections.Generic;

namespace GestioneStudenti.Interfaces
{
    public interface ICorsoDiLaurea
    {
        void Aggiungi(CorsoLaurea corso);
        CorsoLaurea TrovaPerCodice(string codice);
        int ContaTotale();
        List<CorsoLaurea> OttieniTutti();
    }
}