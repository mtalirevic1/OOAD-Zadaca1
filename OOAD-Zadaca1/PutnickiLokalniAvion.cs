using System;

namespace OOAD_Zadaca1
{
    public class PutnickiLokalniAvion : Avion
    {
        public const double Cijena = 120;
        public const double VikendNaknada = 500;

        public PutnickiLokalniAvion()
        {
        }

        public PutnickiLokalniAvion(string id, string vrsta, int brojSjedista) : base(id, vrsta, brojSjedista)
        {
        }

        public override double ObracunajCijenuIznajmljivanja(double brojDana, double iznosKaucije)
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
            return "Putnicki avion za lokalne letove ID: " + Id + " Vrsta: " + Vrsta + " Broj sjedišta: " +
                   BrojSjedista;
        }
    }
}