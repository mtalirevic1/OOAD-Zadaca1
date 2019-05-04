using System;

namespace OOAD_Zadaca1
{
    public class DomaciKlijent : Klijent
    {
        private const double IznosKaucije = 50;
        
        public DomaciKlijent(string id, string ime, string prezime, DateTime dateTime) : base(id, ime, prezime, dateTime)
        {
        }

        public DomaciKlijent() : base()
        {
        }

        public override double PlatiKauciju()
        {
            return IznosKaucije;
        }
    }
}