using System;
using System.Collections.Generic;
using System.Linq;
using GestioneStudenti.Model;
using EsercizioStudenti.Interfaces;
using GestioneStudenti.Repositories;

namespace GestioneStudenti.Repository
{
    public class StudenteRepository : RepositoryGenerico<Studente>, IStudente
    {
        public Studente TrovaPerMatricola(string matricola)
        {
            return TrovaPerId(matricola);
        }

        public List<Studente> TrovaPerCorso(string codiceCorso)
        {
            return OttieniTutti().Where(s => s.CorsoLaurea != null && s.CorsoLaurea.Codice == codiceCorso).ToList();
        }
    }
}