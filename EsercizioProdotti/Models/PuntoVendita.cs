using System;

namespace EsercizioProdotti.Models
{
    public class PuntoVendita
    {
        public int Id { get; set; }
        public string RagioneSociale { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Indirizzo { get; set; }
        public int IdCitta { get; set; }

        public PuntoVendita() { }

        public PuntoVendita(string ragioneSociale, string telefono, string email, string indirizzo, int idCitta)
        {
            RagioneSociale = ragioneSociale;
            Telefono = telefono;
            Email = email;
            Indirizzo = indirizzo;
            IdCitta = idCitta;
        }

        public PuntoVendita(int id, string ragioneSociale, string telefono, string email, string indirizzo, int idCitta)
        {
            Id = id;
            RagioneSociale = ragioneSociale;
            Telefono = telefono;
            Email = email;
            Indirizzo = indirizzo;
            IdCitta = idCitta;
        }

        public override string ToString()
        {
            return $"ID: {Id}, RagioneSociale: {RagioneSociale}, Telefono: {Telefono}, Email: {Email}, Indirizzo: {Indirizzo}, IdCitta: {IdCitta}";
        }
    }
}