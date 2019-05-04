using System;

namespace OOAD_Zadaca1
{
    public class StraniKlijent : Klijent
    {
        private string _Grad;
        public string Grad
        {
            get
            {
             return   _Grad;
            }
            set { _Grad = value; }
        }
        
        private string _Drzava;
        public string Drzava
        {
            get
            {
                return   _Drzava;
            }
            set { _Drzava = value; }
        }

        public StraniKlijent() : base()
        {
        }

        public StraniKlijent(string id, string ime, string prezime, DateTime dateTime, string grad, string drzava) : base(id, ime, prezime, dateTime)
        {
            _Grad = grad;
            _Drzava = drzava;
        }

        public override double PlatiKauciju()
        {
            return 100;
        }
    }
}