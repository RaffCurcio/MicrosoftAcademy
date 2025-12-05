using System;
using System.Collections.Generic;
using GestioneStudenti.Interfaces;
using GestioneStudenti.Repositories;

namespace GestioneStudenti.Repositories
{
    public class RepositoryGenerico<T> where T : IEntita
    {
        private List<T> entita = new List<T>();
        protected LogRepository logRepository;

        public RepositoryGenerico()
        {
            logRepository = new LogRepository();

            logRepository.CreaTabellaSeDNonEsiste();
        }

        public virtual void Aggiungi(T entita)
        {
            try
            {
                if (entita == null)
                    throw new ArgumentNullException(nameof(entita));
                
                this.entita.Add(entita);
                
                string nomeEntita = typeof(T).Name;
                logRepository.LogSuccesso("INSERT", nomeEntita, null, $"{nomeEntita} con ID '{entita.Id}' aggiunto con successo");
            }
            catch (Exception ex)
            {
                string nomeEntita = typeof(T).Name;
                logRepository.LogErrore("INSERT", nomeEntita, null, $"Errore durante l'aggiunta di {nomeEntita}", ex.Message);
                throw; 
            }
        }

        public virtual T TrovaPerId(string id)
        {
            try
            {
                foreach (var e in entita)
                {
                    if (e.Id == id)
                    {
                        string nomeEntita = typeof(T).Name;
                        logRepository.LogSuccesso("SELECT", nomeEntita, null, $"{nomeEntita} con ID '{id}' trovato");
                        return e;
                    }
                }
                
                string nomeEntitaNonTrovata = typeof(T).Name;
                logRepository.LogErrore("SELECT", nomeEntitaNonTrovata, null, $"{nomeEntitaNonTrovata} con ID '{id}' non trovato", "Entità non presente nel repository");
                return default(T);
            }
            catch (Exception ex)
            {
                string nomeEntita = typeof(T).Name;
                logRepository.LogErrore("SELECT", nomeEntita, null, $"Errore durante la ricerca di {nomeEntita} con ID '{id}'", ex.Message);
                throw;
            }
        }

        public virtual List<T> OttieniTutti()
        {
            try
            {
                string nomeEntita = typeof(T).Name;
                logRepository.LogSuccesso("SELECT_ALL", nomeEntita, null, $"Recuperati {entita.Count} elementi di tipo {nomeEntita}");
                return new List<T>(entita);
            }
            catch (Exception ex)
            {
                string nomeEntita = typeof(T).Name;
                logRepository.LogErrore("SELECT_ALL", nomeEntita, null, $"Errore durante il recupero di tutti gli elementi di tipo {nomeEntita}", ex.Message);
                throw;
            }
        }

        public virtual bool Rimuovi(string id)
        {
            try
            {
                var e = TrovaPerId(id);
                if (e != null)
                {
                    entita.Remove(e);
                    string nomeEntita = typeof(T).Name;
                    logRepository.LogSuccesso("DELETE", nomeEntita, null, $"{nomeEntita} con ID '{id}' rimosso con successo");
                    return true;
                }
                
                string nomeEntitaNonTrovata = typeof(T).Name;
                logRepository.LogErrore("DELETE", nomeEntitaNonTrovata, null, $"Impossibile rimuovere {nomeEntitaNonTrovata} con ID '{id}'", "Entità non trovata");
                return false;
            }
            catch (Exception ex)
            {
                string nomeEntita = typeof(T).Name;
                logRepository.LogErrore("DELETE", nomeEntita, null, $"Errore durante la rimozione di {nomeEntita} con ID '{id}'", ex.Message);
                throw;
            }
        }

        public int ContaTotale()
        {
            return entita.Count;
        }
    }
}