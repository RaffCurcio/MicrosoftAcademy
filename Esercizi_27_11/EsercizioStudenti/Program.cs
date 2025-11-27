using GestioneStudenti.Controller;
using GestioneStudenti.Repository;

class Program
{
    static void Main(string[] args)
    {
        StudenteRepository studenteRepo = new StudenteRepository();
        ProfessoreRepository professoreRepo = new ProfessoreRepository();
        CorsoLaureaRepository corsoRepo = new CorsoLaureaRepository();
        
        MainController controller = new MainController(studenteRepo, professoreRepo, corsoRepo);
        
        controller.Run();
    }
}