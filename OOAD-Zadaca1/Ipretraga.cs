using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    public interface Ipretraga
    {
        List<Avion> PretraziPrekoId(string id);
        List<Avion> PretraziPrekoAtributa(Avion a);
    }
}