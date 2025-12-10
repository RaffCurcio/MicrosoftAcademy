using System;

namespace ScuolaNoRepo.View
{
    public class MainView
    {
        public void Menu()
        {
            bool exit = false;
            do{
                Console.WriteLine("Menu Principale");
                Console.Clear();
                Console.WriteLine("MENU PRINCIPALE");
                Console.WriteLine("1. Gestione Studenti");
                Console.WriteLine("2. Gestione Corsi");
                Console.WriteLine("3. Gestione Professori");
                // Console.WriteLine("4. Gestione iscritti");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();
                
                switch (scelta)
                {
                    case "1":
                        StudenteView studenteView = new StudenteView();
                        studenteView.MenuStudente();
                        break;
                     case "2":
                        //Gestione Corsi
                        CorsoView corsoView = new CorsoView();
                        corsoView.ShowMenu();
                         break;
                     case "3":
                        //Gestione Professori
                        DocenteView docenteView = new DocenteView();
                        docenteView.ShowMenu();
                         break;
                    // case "4":
                    //     // Gestione Iscritti
                    //     break;
                    case "0":
                         exit = true;
                         break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

            }while(!exit);
        }
    }
}