using System;
using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    public class PutnickiInostraniAvion : Avion
    {
        private const double Cijena = 200;
        private const double VikendNaknada = 1000;

        private List<string> _Drzave;

        public List<string> Drzave
        {
            get { return _Drzave; }
            set { _Drzave = value; }
        }

        public PutnickiInostraniAvion(string id, string vrsta, int brojSjedista, List<string> drzave) : base(id, vrsta,
            brojSjedista)
        {
            _Drzave = drzave;
        }

        public PutnickiInostraniAvion()
        {
            _Drzave = new List<string>();
        }

        public override double ObracunajCijenuIznajmljivanja(int brojDana, double iznosKaucije)
        {
            double cijena = Cijena * brojDana;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                cijena += VikendNaknada;
            }

            if (cijena > iznosKaucije)
            {
                cijena -= iznosKaucije;
            }

            return cijena;
        }
        
        public override string ToString()
        {
            string drzave = "";
            foreach (string VARIABLE in Drzave)
            {
                drzave = drzave + VARIABLE + " ";
            }
            
            return "Putnicki avion za inostrane letove ID: " + Id + " Vrsta: " + Vrsta + " Broj sjedišta: " +
                   BrojSjedista+" Leti u države: "+drzave;
        }
    }
}