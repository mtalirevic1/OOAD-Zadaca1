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
                    throw new Exception("Identifikacijski broj mora imati 9 karaktera");
                }

                Match match = Regex.Match(value, "[^a-z1-5]");
                if (match.Success)
                {
                    throw new Exception("Identifikacijski broj mora biti kombinacija malih slova i cifara od 1 do 5");
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
    }
}