using System;
using System.Collections.Generic;
using GestioneStudenti.Model;

namespace GestioneStudenti.Interfaces
{
    public interface IProfessore
    {
        void Aggiungi(Professore professore);
        Professore TrovaPerCodice(string codiceId);
        List<Professore> TrovaPerMateria(string materia);
        List<Professore> OttieniTutti();
        int ContaTotale();

    }
}