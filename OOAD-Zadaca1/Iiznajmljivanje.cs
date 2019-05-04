using System;

namespace OOAD_Zadaca1
{
    public interface Iiznajmljivanje
    {
        void IznajmiVozilo(Avion a, string kid);
        void VratiVozilo(Avion a, string kid);
    }
}