using System;
using System.Text.RegularExpressions;

namespace OOAD_Zadaca1
{
    public abstract class Avion
    {
        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (value.Length != 9)
                {
                    throw new ArgumentException("Identifikacijski broj mora imati 9 karaktera");
                }

                Match match = Regex.Match(value, "[^a-z1-5]");
                if (match.Success)
                {
                    throw new ArgumentException("Identifikacijski broj mora biti kombinacija malih slova i cifara od 1 do 5");
                }

                _Id = value;
            }
        }

        private string _Vrsta;
        public string Vrsta
        {
            get { return _Vrsta; }
            set { _Vrsta = value; }
        }

        private int _BrojSjedista;
        public int BrojSjedista
        {
            get
            {
              return  _BrojSjedista;
            }
            set { _BrojSjedista = value; }
        }

        protected Avion()
        {
        }

        protected Avion(string id, string vrsta, int brojSjedista)
        {
            _Id = id;
            _Vrsta = vrsta;
            _BrojSjedista = brojSjedista;
        }

        public abstract double ObracunajCijenuIznajmljivanja(int brojDana, double iznosKaucije);
        

        private bool Equals(Avion other)
        {
            return string.Equals(_Vrsta, other._Vrsta) && _BrojSjedista == other._BrojSjedista;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Avion) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_Vrsta != null ? _Vrsta.GetHashCode() : 0) * 397) ^ _BrojSjedista;
            }
        }
    }
}