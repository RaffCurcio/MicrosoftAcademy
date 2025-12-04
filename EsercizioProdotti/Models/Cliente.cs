using System;

namespace EsercizioProdotti.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataRegistrazione { get; set; }

        public Cliente(int id, string nome, string email, string dataRegistrazione)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataRegistrazione = dataRegistrazione;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Email: {Email}, DataRegistrazione: {DataRegistrazione}";
        }
    }
}