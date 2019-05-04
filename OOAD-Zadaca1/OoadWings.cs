using System;
using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    public class OoadWings : Ipretraga, Iiznajmljivanje
    {
        private List<Klijent> _Klijenti;

        public List<Klijent> Klijenti
        {
            get { return _Klijenti; }
            set { _Klijenti = value; }
        }

        private List<Avion> _Avioni;

        public List<Avion> Avioni
        {
            get { return _Avioni; }
            set { _Avioni = value; }
        }

        private Dictionary<string, List<Tuple<Avion, DateTime, DateTime>>> _AktivniNajami;

        public Dictionary<string, List<Tuple<Avion, DateTime, DateTime>>> AktivniNajami
        {
            get { return _AktivniNajami; }
            set { _AktivniNajami = value; }
        }

        public OoadWings(List<Klijent> klijenti, List<Avion> avioni,
            Dictionary<string, List<Tuple<Avion, DateTime, DateTime>>> aktivniNajami)
        {
            _Klijenti = klijenti;
            _Avioni = avioni;
            _AktivniNajami = aktivniNajami;
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
            List<Avion> lista = new List<Avion>();

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
            List<Avion> lista = new List<Avion>();

            foreach (Avion avion in _Avioni)
            {
                if (avion.Equals(a))
                {
                    lista.Add(avion);
                }
            }

            return lista;
        }

        public void IznajmiVozilo(Tuple<Avion, DateTime, DateTime> a, string kid)
        {
            List<Tuple<Avion, DateTime, DateTime>> lista = new List<Tuple<Avion, DateTime, DateTime>>();
            lista.Add(a);
            if (!AktivniNajami.TryAdd(kid, lista))
            {
                AktivniNajami[kid].Add(a);
            }

            _Avioni.Remove(a.Item1);
        }

        public double VratiVozilo(string a, string kid)
        {
            double daniIzmedju = -1, ukupnaCijena = -1;

            for (int i = 0; i < AktivniNajami[kid].Count; i++)
            {
                if (AktivniNajami[kid][i].Item1.Id == a)
                {
                    daniIzmedju = (AktivniNajami[kid][i].Item3 - AktivniNajami[kid][i].Item2).TotalDays;
                    _Avioni.Add(AktivniNajami[kid][i].Item1);
                    int j = 0;
                    while (j < Klijenti.Count)
                    {
                        if (Klijenti[j].Id == kid)
                        {
                            break;
                        }

                        j++;
                    }

                    ukupnaCijena = AktivniNajami[kid][i].Item1
                        .ObracunajCijenuIznajmljivanja(daniIzmedju, Klijenti[j].PlatiKauciju());
                    AktivniNajami[kid].Remove(AktivniNajami[kid][i]);
                    break;
                }
            }

            return daniIzmedju;
        }
    }
}