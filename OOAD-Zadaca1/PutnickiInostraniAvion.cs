using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    public class PutnickiInostraniAvion : Avion
    {
        private List<string> _Drzave;
        public List<string> Drzave
        {
            get { return _Drzave; }
            set { _Drzave = value; }
        }

        public PutnickiInostraniAvion(string id, string vrsta, int brojSjedista, List<string> drzave) : base(id, vrsta, brojSjedista)
        {
            _Drzave = drzave;
        }

        public PutnickiInostraniAvion()
        {
            _Drzave=new List<string>();
        }
    }
}