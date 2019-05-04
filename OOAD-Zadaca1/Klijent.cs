using System;

namespace OOAD_Zadaca1
{
    public abstract class Klijent
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                if (value.Length != 6)
                {
                    throw new Exception("Identifikacijski broj mora imati 6 karaktera");
                }
              _Id = value;
            }
        }

        private string _Ime;
        public string Ime
        {
            get
            {
               return _Ime;
            }
            set { _Ime = value; }
        }
        
        private string _Prezime;
        public string Prezime
        {
            get
            {
                return _Prezime;
            }
            set { _Prezime = value; }
        }

        private DateTime _dateTime;

        public DateTime dateTime
        {
            get
            {
                return _dateTime;
            }
            set { _dateTime = value; }
        }

        public abstract void PlatiKauciju(double iznos);

        protected Klijent(string id, string ime, string prezime, DateTime dateTime)
        {
            _Id = id;
            _Ime = ime;
            _Prezime = prezime;
            _dateTime = dateTime;
        }

        protected Klijent()
        {
            _dateTime=DateTime.Now;
        }
    }
}