using GestioneStudenti.Controller;
using GestioneStudenti.Repository;

class Program
{
    static void Main(string[] args)
    {
        StudenteRepository repository = new StudenteRepository();

        StudenteController controller = new StudenteController(repository);

        controller.Run();
    }
}