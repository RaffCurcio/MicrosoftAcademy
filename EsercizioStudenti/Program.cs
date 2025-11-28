using GestioneStudenti.Controller;
using GestioneStudenti.Repository;
using GestioneStudenti.Services;

class Program
{
    static void Main(string[] args)
    {
        StudenteRepository studenteRepo = new StudenteRepository();
        ProfessoreRepository professoreRepo = new ProfessoreRepository();
        CorsoLaureaRepository corsoRepo = new CorsoLaureaRepository();
        StoricoOperazioni storicoOperazioni = new StoricoOperazioni();
        CodaIscrizioni codaIscrizioni = new CodaIscrizioni();
        
        MainController controller = new MainController(studenteRepo, professoreRepo, corsoRepo, storicoOperazioni, codaIscrizioni);

        
        controller.Run();
    }
}