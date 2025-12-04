using GestioneStudenti.Controller;
using GestioneStudenti.Repository;
using GestioneStudenti.Services;
using GestioneStudenti.Utilities;
using GestioneStudenti.Repositories;

class Program
{
    static void Main(string[] args)
    {
        // Test connessione al DB
        StRepository stRepo = new StRepository();
        stRepo.TestConnection();

        StudenteRepository studenteRepo = new StudenteRepository();
        ProfessoreRepository professoreRepo = new ProfessoreRepository();
        CorsoLaureaRepository corsoRepo = new CorsoLaureaRepository();
        StoricoOperazioni storicoOperazioni = new StoricoOperazioni();
        CodaIscrizioni codaIscrizioni = new CodaIscrizioni();
        LoggerServices loggerServices = new LoggerServices();
        
        MainController controller = new MainController(studenteRepo, professoreRepo, corsoRepo, storicoOperazioni, codaIscrizioni, loggerServices);

        
        controller.Run();
    }
}