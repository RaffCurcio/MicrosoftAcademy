using System;

namespace GestioneStudenti.Model
{
    public class Professore
    {
        private string nome;
        private string cognome;
        private string codiceId;
        private string materia;

        public Professore(string nome, string cognome, string codiceId, string materia)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.codiceId = codiceId;
            this.materia = materia;
        }

        public string CodiceId
        {
            get { return codiceId; }
        }

        public string Nome
        {
            get { return nome; }
        }

        public string Cognome
        {
            get { return cognome; }
        }

        public string Materia
        {
            get { return materia; }
        }

        public override string ToString()
        {
            return $"Prof. {nome} {cognome} (ID: {codiceId}) - Materia: {materia}";
        }
    }
}