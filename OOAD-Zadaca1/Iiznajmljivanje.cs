using System;

namespace OOAD_Zadaca1
{
    public interface Iiznajmljivanje
    {
        void IznajmiVozilo(Tuple<Avion,DateTime, DateTime> a, string kid);
        double VratiVozilo(string a, string kid);
    }
}