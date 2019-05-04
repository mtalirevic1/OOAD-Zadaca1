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

        public void DodajAvion(Avion avion)
        {
            _Avioni.Add(avion);
        }

        public void DodajKlijenta(Klijent klijent)
        {
            _Klijenti.Add(klijent);
        }

        public List<Avion> PretraziPrekoId(string id)
        {
            List<Avion> lista=new List<Avion>();
            
            foreach (Avion avion in _Avioni)
            {
                if (avion.Id.Equals(id))
                {
                    lista.Add(avion);
                }
            }
            
            return lista;
        }

        public List<Avion> PretraziPrekoAtributa(Avion a)
        {
            List<Avion> lista=new List<Avion>();
            
            foreach (Avion avion in _Avioni)
            {
                if (avion.Equals(a))
                {
                    lista.Add(avion);
                }
            }
            
            return lista;
        }
    }
}