# Relazione - Sistema Gestione Studenti

## Introduzione
In questo progetto è stato sviluppato un sistema in C# per gestire studenti universitari, professori, corsi di laurea e voti. L'obiettivo era mettere in pratica i design pattern studiati e creare un'architettura pulita e estendibile.

## Architettura e Pattern Utilizzati

Ho strutturato il sistema seguendo il pattern **MVC** con l'aggiunta del **Repository Pattern**:

- **Models**: Le entità principali (Studente, Professore, CorsoLaurea, Voto)
- **Controllers**: La logica di business per gestire le operazioni
- **Repositories**: Astrazione dell'accesso ai dati con un repository generico
- **Views**: Interfaccia console per l'interazione utente

### Repository Pattern
La scelta più importante è stata creare un `RepositoryGenerico<T>` che implementa le operazioni CRUD base per tutte le entità che implementano `IEntita`. Questo mi ha permesso di non ripetere codice e aggiungere facilmente nuove entità.


### Entità Debole
Ho implementato il concetto di entità debole per la classe `Voto`: i voti esistono solo all'interno dello studente, quindi se elimino uno studente spariscono automaticamente anche i suoi voti. Non hanno un ID indipendente ma sono identificati da materia + studente.

## Sistema di Logging Dual-Channel

Ho implementato un sistema di logging su due canali:
1. **Database MySQL**: Per audit strutturato con tabella `LogOperazioni`
2. **File di testo**: Per debug rapido usando il pattern Singleton

Il logging è automatico: ogni operazione CRUD viene tracciata nei repository. Dal menu admin posso abilitare/disabilitare i log separatamente e vedere statistiche.

