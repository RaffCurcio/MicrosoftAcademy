
namespace GestioneLibri
{
    public class Libro
    {
        private static int CodLibro = 0;
        private string titolo;
        private string autore;
        private int numPagine;
        private string isbn;
        private string genere;
        private const double costoPagina = 0.05;
        private const double costoFisso = 7.5;

        public Libro(string titolo, string autore, int numPagine, string isbn, string genere)
        {
            CodLibro++;
            this.titolo = titolo;
            this.autore = autore;
            this.numPagine = numPagine;
            this.isbn = isbn;
            this.genere = genere;
        }
        public int CodiceLibro
        {
            get{
                return CodLibro;
            }
            set{
                CodLibro = value;
            }
        }
        public string Titolo
        {
            get{
                return titolo;
            }
            set{
                titolo = value;
            }
        }
        public string Autore
        {
            get{
                return autore;
            }
            set{
                autore = value;
            }
        }
        public int NumPagine
        {
            get{
                return numPagine;
            }
            set{
                numPagine = value;
            }
        }
        public string Isbn
        {
            get{
                return isbn;
            }
            set{
                isbn = value;
            }
        }
        public string Genere
        {
            get{
                return genere;
            }
            set{
                genere = value;
            }
        }
        public double CostoPagina
        {
            get
            {
                return costoPagina;
            }
        }
        public double prezzoLibro()
        {
            return (numPagine * costoPagina) + costoFisso;
        }

        public override string ToString()
        {
            return $"====================== \nCodice Libro: {CodiceLibro} \nTitolo: {Titolo} \nAutore: {Autore} \nNumero Pagine: {NumPagine} \nISBN: {Isbn} \nGenere: {Genere} \nPrezzo: {prezzoLibro()} € \n======================";
        }

        public bool Equals(Libro l)
        {
            if (l == null)
                return false;
            return this.CodiceLibro == l.CodiceLibro;
        }
    }
}