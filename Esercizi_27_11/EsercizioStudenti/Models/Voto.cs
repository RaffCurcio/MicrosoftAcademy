using System;

namespace GestioneStudenti.Model
{
    public class Voto
    {
        private int valore;
        private string materia;

        public Voto(int valore, string materia)
        {
            this.valore = valore;
            this.materia = materia;
        }

        public int Valore
        {
            get { return valore; }
        }

        public string Materia
        {
            get { return materia; }
        }

        public override string ToString()
        {
            return $"{materia}: {valore}";
        }
    }
}