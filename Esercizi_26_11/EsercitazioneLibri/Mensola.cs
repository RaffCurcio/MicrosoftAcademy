namespace GestioneLibri
{
    public class Mensola
    {
        private List<Libro> libri = new List<Libro>();
        private const int num_max_libri = 50;

        public Mensola()
        {
        }

        public int AggiungiLibro(Libro l)
        {
            if (libri.Count >= num_max_libri)
                return -1;

            libri.Add(l);
            return libri.Count - 1;
        }

        public Libro GetLibro(int pos)
        {
            if (pos >= 0 && pos < libri.Count)
                return libri[pos];
            return null;
        }

        public bool EliminaLibro(int pos)
        {
            if (pos >= 0 && pos < libri.Count)
            {
                libri.RemoveAt(pos);
                return true;
            }
            return false;
        }

        public bool ModificaLibro(int pos, Libro nuovo)
        {
            if (pos >= 0 && pos < libri.Count)
            {
                libri[pos] = nuovo;
                return true;
            }
            return false;
        }

        public int NumeroLibri
        {
            get { return libri.Count; }
        }

        public int NumeroMax
        {
            get { return num_max_libri; }
        }

        public List<Libro> VisualizzaLibri()
        {
            return libri;
        }

        public void OrdinaPerPrezzo()
        {
            libri = libri.OrderBy(l => l.prezzoLibro()).ToList();
            foreach (var libro in libri)
            {
                Console.WriteLine(libro.ToString());
            }
            Console.WriteLine("Libri ordinati per prezzo.");
        }

        public void Svuota()
        {
            libri.Clear();
        }
    }

}