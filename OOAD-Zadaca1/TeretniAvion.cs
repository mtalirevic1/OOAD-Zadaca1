namespace OOAD_Zadaca1
{
    public class TeretniAvion : Avion
    {
        private const double Cijena = 350;
        private const double Koeficijent = 0.02;
        
        private double _UkupniKapacitet;
        public double UkupniKapacitet
        {
            get
            {
             return   _UkupniKapacitet;
            }
            set { _UkupniKapacitet = value; }
        }

        public TeretniAvion(string id, string vrsta, int brojSjedista, double ukupniKapacitet) : base(id, vrsta, brojSjedista)
        {
            _UkupniKapacitet = ukupniKapacitet;
        }

        public TeretniAvion()
        {
        }

        public override double ObracunajCijenuIznajmljivanja(int brojDana, double iznosKaucije)
        {
            double cijena = Cijena * brojDana + UkupniKapacitet*1000*Koeficijent; //konverzija iz tona u kg
            if (cijena > iznosKaucije)
            {
                cijena -= iznosKaucije;
            }
            return cijena;
        }
    }
}