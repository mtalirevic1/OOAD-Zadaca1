namespace OOAD_Zadaca1
{
    public class TeretniAvion : Avion
    {
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
    }
}