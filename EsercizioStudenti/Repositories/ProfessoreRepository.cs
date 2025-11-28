using System;
using System.Collections.Generic;
using GestioneStudenti.Model;
using GestioneStudenti.Interfaces;
using GestioneStudenti.Repositories;

namespace GestioneStudenti.Repository
{
    public class ProfessoreRepository : RepositoryGenerico<Professore>, IProfessore
    {
        public Professore TrovaPerCodice(string codiceId)
        {
            return TrovaPerId(codiceId);
        }

        public List<Professore> TrovaPerMateria(string materia)
        {
            List<Professore> risultato = new List<Professore>();
            foreach (var prof in OttieniTutti())
            {
                if (prof.Materia.Equals(materia, StringComparison.OrdinalIgnoreCase))
                    risultato.Add(prof);
            }
            return risultato;
        }
    }
}