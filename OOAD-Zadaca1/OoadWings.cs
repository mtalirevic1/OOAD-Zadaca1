using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    public class OoadWings : Ipretraga
    {
        private List<Klijent> _Klijenti;
        public List<Klijent> Klijenti
        {
            get { return _Klijenti; }
            set { _Klijenti = value;}
        }
        
        private List<Avion> _Avioni;
        public List<Avion> Avioni
        {
            get { return _Avioni; }
            set { _Avioni = value;}
        }

        public OoadWings(List<Klijent> klijenti, List<Avion> avioni)
        {
            _Klijenti = klijenti;
            _Avioni = avioni;
        }

        public Avion PretraziPrekoId(string id)
        {
            foreach (Avion avion in _Avioni)
            {
                if (avion.Id.Equals(id))
                {
                    return avion;
                }
            }
            
            return null;
        }

        public bool PretraziPrekoAtributa(Avion a)
        {
            throw new System.NotImplementedException();
        }
    }
}