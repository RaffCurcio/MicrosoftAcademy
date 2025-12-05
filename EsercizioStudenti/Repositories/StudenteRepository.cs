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
            try
            {
                var studente = TrovaPerId(matricola);
                if (studente != null)
                {
                    logRepository.LogSuccesso("FIND_BY_MATRICOLA", "Studente", null, $"Studente trovato per matricola '{matricola}': {studente.Nome} {studente.Cognome}");
                }
                return studente;
            }
            catch (Exception ex)
            {
                logRepository.LogErrore("FIND_BY_MATRICOLA", "Studente", null, $"Errore durante la ricerca per matricola '{matricola}'", ex.Message);
                throw;
            }
        }

        public List<Studente> TrovaPerCorso(string codiceCorso)
        {
            try
            {
                var studenti = OttieniTutti().Where(s => s.CorsoLaurea != null && s.CorsoLaurea.Codice == codiceCorso).ToList();
                logRepository.LogSuccesso("FIND_BY_CORSO", "Studente", null, $"Trovati {studenti.Count} studenti per il corso '{codiceCorso}'");
                return studenti;
            }
            catch (Exception ex)
            {
                logRepository.LogErrore("FIND_BY_CORSO", "Studente", null, $"Errore durante la ricerca studenti per corso '{codiceCorso}'", ex.Message);
                throw;
            }
        }

        public override void Aggiungi(Studente studente)
        {
            try
            {
                if (studente == null)
                    throw new ArgumentNullException(nameof(studente));

                // Verifica se lo studente esiste già
                var studenteEsistente = TrovaPerId(studente.Id);
                if (studenteEsistente != null)
                {
                    logRepository.LogErrore("INSERT", "Studente", null, $"Tentativo di aggiungere studente già esistente: matricola '{studente.Id}'", "Studente duplicato");
                    throw new InvalidOperationException($"Studente con matricola '{studente.Id}' già esistente");
                }

                base.Aggiungi(studente);
                logRepository.LogSuccesso("INSERT", "Studente", null, $"Studente aggiunto: {studente.Nome} {studente.Cognome}, Matricola: {studente.Id}");
            }
            catch (Exception ex)
            {
                logRepository.LogErrore("INSERT", "Studente", null, $"Errore durante l'aggiunta dello studente", ex.Message);
                throw;
            }
        }

        public List<Models.LogOperazione> OttieniLogStudenti()
        {
            return logRepository.OttieniLogPerEntita("Studente");
        }
    }
}