using System;
using System.Collections.Generic;
using GestioneStudenti.Model;
using GestioneStudenti.Interfaces;
using GestioneStudenti.Repositories;

namespace GestioneStudenti.Repository
{
    public class CorsoLaureaRepository : RepositoryGenerico<CorsoLaurea>, ICorsoDiLaurea
    {
        public CorsoLaurea TrovaPerCodice(string codice)
        {
            return TrovaPerId(codice);
        }
    }
}