using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{
    public struct Anagrafica
    {
        public string[] CodID;
        public string[] Nome;
        public string[] Cognome;
        public int[] Eta;
        public string[] Telefono;
        public string[] Email;
        public int Count; 

        public Anagrafica(int dimensione)
        {
            CodID = new string[dimensione];
            Nome = new string[dimensione];
            Cognome = new string[dimensione];
            Eta = new int[dimensione];
            Telefono = new string[dimensione];
            Email = new string[dimensione];
            Count = 0;
        }
    }
    static Anagrafica archivio = new Anagrafica(100);

    static bool NameCheck(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter) && name.Length >= 2;
    }

    static bool EmailCheck(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    static bool PhoneCheck(string phone)
    {
        return !string.IsNullOrWhiteSpace(phone) && phone.All(char.IsDigit) && phone.Length >= 10 && phone.Length <= 15;
    }

    static bool EtaChech(int age)
    {
        return age > 0 && age < 120;
    }

    static bool CodeCheck(string codID)
    {
        for (int i = 0; i < archivio.Count; i++)
        {
            if (archivio.CodID[i] == codID)
                return false;
        }
        return true;
    }

    static void inserisciDatiAnagrafici()
    {
        int i = archivio.Count;

        string codID;
        do
        {
            Console.WriteLine("Inserisci CodID (univoco):");
            codID = Console.ReadLine();
            if (!CodeCheck(codID))
                Console.WriteLine("CodID non valido o già esistente. Riprova.");
        } while (!CodeCheck(codID));
        archivio.CodID[i] = codID;

        string nome;
        do
        {
            Console.WriteLine("Inserisci Nome:");
            nome = Console.ReadLine();
            if (!NameCheck(nome))
                Console.WriteLine("Nome non valido (solo lettere, almeno 2 caratteri). Riprova.");
        } while (!NameCheck(nome));
        archivio.Nome[i] = nome;

        string cognome;
        do
        {
            Console.WriteLine("Inserisci Cognome:");
            cognome = Console.ReadLine();
            if (!NameCheck(cognome))
                Console.WriteLine("Cognome non valido (solo lettere, almeno 2 caratteri). Riprova.");
        } while (!NameCheck(cognome));
        archivio.Cognome[i] = cognome;

        int eta;
        do
        {
            Console.WriteLine("Inserisci Età:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out eta) && EtaChech(eta))
                break;
            Console.WriteLine("Età non valida.");
        } while (true);
        archivio.Eta[i] = eta;

        string telefono;
        do
        {
            Console.WriteLine("Inserisci Telefono:");
            telefono = Console.ReadLine();
            if (!PhoneCheck(telefono))
                Console.WriteLine("Telefono non valido (solo numeri, 10-15 cifre). Riprova.");
        } while (!PhoneCheck(telefono));
        archivio.Telefono[i] = telefono;

        string email;
        do
        {
            Console.WriteLine("Inserisci Email:");
            email = Console.ReadLine();
            if (!EmailCheck(email))
                Console.WriteLine("Email non valida. Riprova.");
        } while (!EmailCheck(email));
        archivio.Email[i] = email;

        archivio.Count++;

        Console.WriteLine("\n Persona aggiunta con successo!\n");
    }

    static void visualizzaDatiAnagrafici()
    {
        int exit=0;
        do{

            Console.WriteLine("Per quale valore vuoi ricercare?");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Nome");
            Console.WriteLine("3. Cognome");
            Console.WriteLine("4. Eta");
            Console.WriteLine("5. Telefono");
            Console.WriteLine("6. Email");
            Console.WriteLine("7. Ricerca per cognome in ordine alfabetico");
            Console.WriteLine("8. Esci");
            string inputExit = Console.ReadLine();
            if (!int.TryParse(inputExit, out exit))
            {
                Console.WriteLine("Input non valido. Riprova.");
                continue;
            }

            switch(exit){
                case 1: 
                Console.WriteLine("Inserisci l'id");
                    string id = Console.ReadLine();
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == id){
                            Console.WriteLine("--------------------------");
                            Console.WriteLine($"CodID: {archivio.CodID[i]}");
                            Console.WriteLine($"Nome: {archivio.Nome[i]}");
                            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                            Console.WriteLine($"Età: {archivio.Eta[i]}");
                            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                            Console.WriteLine($"Email: {archivio.Email[i]}");
                            Console.WriteLine("---------------------------");
                        }
                    }
                break;
                case 2:
                    Console.WriteLine("Inserisci il nome");
                    string nome = Console.ReadLine();
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.Nome[i] == nome){
                            Console.WriteLine("--------------------------");
                            Console.WriteLine($"CodID: {archivio.CodID[i]}");
                            Console.WriteLine($"Nome: {archivio.Nome[i]}");
                            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                            Console.WriteLine($"Età: {archivio.Eta[i]}");
                            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                            Console.WriteLine($"Email: {archivio.Email[i]}");
                            Console.WriteLine("---------------------------");
                        }
                    }
                break;
                case 3:
                Console.WriteLine("Inserisci il Cognome");
                    string cognome = Console.ReadLine();
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.Cognome[i] == cognome){
                            Console.WriteLine("--------------------------");
                            Console.WriteLine($"CodID: {archivio.CodID[i]}");
                            Console.WriteLine($"Nome: {archivio.Nome[i]}");
                            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                            Console.WriteLine($"Età: {archivio.Eta[i]}");
                            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                            Console.WriteLine($"Email: {archivio.Email[i]}");
                            Console.WriteLine("---------------------------");
                        }
                    }

                break;

                case 4:
                Console.WriteLine("Inserisci l'eta");
                    string etaStr = Console.ReadLine();
                    if (int.TryParse(etaStr, out int eta))
                    {
                        for(int i=0; i<archivio.Count; i++){
                            if(archivio.Eta[i] == eta){
                                Console.WriteLine("--------------------------");
                                Console.WriteLine($"CodID: {archivio.CodID[i]}");
                                Console.WriteLine($"Nome: {archivio.Nome[i]}");
                                Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                                Console.WriteLine($"Età: {archivio.Eta[i]}");
                                Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                                Console.WriteLine($"Email: {archivio.Email[i]}");
                                Console.WriteLine("---------------------------");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Età non valida.");
                    }
                break;
                case 5:
                    Console.WriteLine("Inserisci il numero di telefono");
                    string telefono = Console.ReadLine();
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.Telefono[i] == telefono){
                            Console.WriteLine("--------------------------");
                            Console.WriteLine($"CodID: {archivio.CodID[i]}");
                            Console.WriteLine($"Nome: {archivio.Nome[i]}");
                            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                            Console.WriteLine($"Età: {archivio.Eta[i]}");
                            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                            Console.WriteLine($"Email: {archivio.Email[i]}");
                            Console.WriteLine("---------------------------");
                        }
                    }
                break;
                case 6:
                    Console.WriteLine("Inserisci l'email");
                    string email = Console.ReadLine();
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.Email[i] == email){
                            Console.WriteLine("--------------------------");
                            Console.WriteLine($"CodID: {archivio.CodID[i]}");
                            Console.WriteLine($"Nome: {archivio.Nome[i]}");
                            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                            Console.WriteLine($"Età: {archivio.Eta[i]}");
                            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                            Console.WriteLine($"Email: {archivio.Email[i]}");
                            Console.WriteLine("---------------------------");
                        }
                    }
                break;
                case 7:
                    Console.WriteLine("Lista dei cognomi in ordine alfabetico");
                    for(int i=0; i<archivio.Count; i++){
                        for(int j=i+1; j<archivio.Count; j++){
                            if(string.Compare(archivio.Cognome[i], archivio.Cognome[j]) > 0){
                                string tempCognome = archivio.Cognome[i];
                                archivio.Cognome[i] = archivio.Cognome[j];
                                archivio.Cognome[j] = tempCognome;
                            }
                        }
                    }
                    for(int i=0; i<archivio.Count; i++){
                        Console.WriteLine(archivio.Cognome[i]);
                    }   
                break;
                case 8:
                    Console.WriteLine("Uscita...");
                break;
                default:
                    Console.WriteLine("Errore");
                break;

            }
        }while(exit!=7);

        for (int i = 0; i < archivio.Count; i++)
        {
            Console.WriteLine($"CodID: {archivio.CodID[i]}");
            Console.WriteLine($"Nome: {archivio.Nome[i]}");
            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
            Console.WriteLine($"Età: {archivio.Eta[i]}");
            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
            Console.WriteLine($"Email: {archivio.Email[i]}");
            Console.WriteLine("---------------------------");
        }
    }

    static void aggiornaDatiAnagrafici()
    {
        Console.WriteLine("Inserire il codice della persona da modificare");
        string code = Console.ReadLine();
        int scelta=0;
        do{
            Console.WriteLine("1. Nome");
            Console.WriteLine("2. Cognome");
            Console.WriteLine("3. Età");
            Console.WriteLine("4. Telefono");
            Console.WriteLine("5. Email");
            Console.WriteLine("6. Esci");
            Console.WriteLine("Cosa desideri modificare?");
            string inputScelta = Console.ReadLine();
            if (!int.TryParse(inputScelta, out scelta))
            {
                Console.WriteLine("Input non valido. Riprova.");
                continue;
            }

            switch(scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci nuovo nome");
                    string nuovoNome;
                    do
                    {
                        nuovoNome = Console.ReadLine();
                        if (!NameCheck(nuovoNome))
                            Console.WriteLine("Nome non valido. Riprova.");
                    } while (!NameCheck(nuovoNome));
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == code){
                            archivio.Nome[i] = nuovoNome;
                        }
                    }
                break;
                case 2:
                    Console.WriteLine("Inserisci nuovo cognome");
                    string nuovoCognome;
                    do
                    {
                        nuovoCognome = Console.ReadLine();
                        if (!NameCheck(nuovoCognome))
                            Console.WriteLine("Cognome non valido. Riprova.");
                    } while (!NameCheck(nuovoCognome));
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == code){
                            archivio.Cognome[i] = nuovoCognome;
                        }
                    }
                break;
                case 3:
                    Console.WriteLine("Inserisci nuova età");
                    int nuovaEta;
                    do
                    {
                        string inputEta = Console.ReadLine();
                        if (int.TryParse(inputEta, out nuovaEta) && EtaChech(nuovaEta))
                            break;
                        Console.WriteLine("Età non valida. Riprova.");
                    } while (true);
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == code){
                            archivio.Eta[i] = nuovaEta;
                        }
                    }
                break;
                case 4:
                    Console.WriteLine("Inserisci nuovo telefono");
                    string nuovoTelefono;
                    do
                    {
                        nuovoTelefono = Console.ReadLine();
                        if (!PhoneCheck(nuovoTelefono))
                            Console.WriteLine("Telefono non valido. Riprova.");
                    } while (!PhoneCheck(nuovoTelefono));
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == code){
                            archivio.Telefono[i] = nuovoTelefono;
                        }
                    }
                
                break;
                case 5:
                    Console.WriteLine("Inserisci nuova email");
                    string nuovaEmail;
                    do
                    {
                        nuovaEmail = Console.ReadLine();
                        if (!EmailCheck(nuovaEmail))
                            Console.WriteLine("Email non valida. Riprova.");
                    } while (!EmailCheck(nuovaEmail));
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == code){
                            archivio.Email[i] = nuovaEmail;
                        }
                    }
                
                break;
                case 6:
                    for(int i=0; i<archivio.Count; i++){
                        if(archivio.CodID[i] == code){
                            Console.WriteLine("Dati aggiornati con successo:");
                            Console.WriteLine($"Nome: {archivio.Nome[i]}");
                            Console.WriteLine($"Cognome: {archivio.Cognome[i]}");
                            Console.WriteLine($"Eta: {archivio.Eta[i]}");
                            Console.WriteLine($"Telefono: {archivio.Telefono[i]}");
                            Console.WriteLine($"Email: {archivio.Email[i]}");
                        }
                    }
                break;
            }
        }while(scelta!=6);
    }

    static void eliminaDatiAnagrafici()
    {
        Console.WriteLine("Inserisci il CodID della persona da eliminare:");
        string codID = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < archivio.Count; i++)
        {
            if (archivio.CodID[i] == codID)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < archivio.Count - 1; i++)
            {
                archivio.CodID[i] = archivio.CodID[i + 1];
                archivio.Nome[i] = archivio.Nome[i + 1];
                archivio.Cognome[i] = archivio.Cognome[i + 1];
                archivio.Eta[i] = archivio.Eta[i + 1];
                archivio.Telefono[i] = archivio.Telefono[i + 1];
                archivio.Email[i] = archivio.Email[i + 1];
            }

            archivio.Count--;

            Console.WriteLine("\n✔ Persona eliminata con successo!\n");
        }
        else
        {
            Console.WriteLine("CodID non trovato.");
        }
    }

    static void Stats(){
        Console.WriteLine($"Numero totale di persone nell'archivio: {archivio.Count}");
        int sommaEta = 0;
        for(int i=0; i<archivio.Count; i++){
            sommaEta += archivio.Eta[i];
        }
        if(archivio.Count > 0){
            double mediaEta = (double)sommaEta / archivio.Count;
            Console.WriteLine($"Media Età: {mediaEta}");
        } else {
            Console.WriteLine("Nessuna persona nell'archivio per calcolare la media età.");
        }
        Console.WriteLine("---------------------------");
    }

    static void Main(string[] args)
    {
        int exit = 0;
        do{
            Console.WriteLine("1. Inserisci dati anagrafici");
            Console.WriteLine("2. Visualizza dati anagrafici");
            Console.WriteLine("3. Aggiorna dati anagrafici");
            Console.WriteLine("4. Elimina dati anagrafici");
            Console.WriteLine("5. Statistiche");
            Console.WriteLine("6. Esci");
            Console.WriteLine("Scegli un'azione:");
            string inputExit = Console.ReadLine();
            if(!int.TryParse(inputExit, out exit))
            {
                Console.WriteLine("Input non valido. Riprova.");
                continue;
            }

            switch (exit)
            {
                case 1:
                    inserisciDatiAnagrafici();
                    break;
                case 2:
                    visualizzaDatiAnagrafici();
                    break;
                case 3:
                    aggiornaDatiAnagrafici();
                    break;
                case 4:
                    eliminaDatiAnagrafici();
                    break;
                case 5:
                
                    Stats();
                break;
                case 6:
                    Console.WriteLine("Uscita dal programma.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }while(exit != 5);

    }
}
