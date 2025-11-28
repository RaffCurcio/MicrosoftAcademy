using System.Collections.Generic;
using GestioneStudenti.Model;

namespace EsercizioStudenti.Interfaces
{
    public interface IStudente
    {
        void Aggiungi(Studente studente);
        Studente TrovaPerMatricola(string matricola);
        List<Studente> OttieniTutti();
        bool Rimuovi(string matricola);
        int ContaTotale();
        List<Studente> TrovaPerCorso(string codiceCorso);
    }
}