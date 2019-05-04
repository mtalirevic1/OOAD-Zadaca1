using System;
using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    class Program
    {
        private static OoadWings OoadWings;

        static void Main(string[] args)
        {
            OoadWings = new OoadWings(new List<Klijent>(), new List<Avion>(),
                new Dictionary<string, List<Tuple<Avion, DateTime, DateTime>>>());
               
            unesiPodatke();
            
            for (;;)
            {
                int izbor = -1;
                string ulaz = "";
                while (izbor != 0 && izbor != 1 && izbor != 2 && izbor != 3 && izbor != 4 && izbor != 5)
                {
                    Console.Write(
                        "\nOdaberite zeljenu opciju:\n0 za kraj programa\n1 za kreiranje novog vozila\n2 za kreiranje novog klijenta\n3 za iznajmljivanje vozila\n4 za povrat vozila i plaćanje\n5 za ispis liste obavijesti\nOdabir: ");

                    ulaz = Console.ReadLine();
                    izbor = Int32.Parse(ulaz);
                }

                if (izbor == 0)
                {
                    break;
                }
                else if (izbor == 1)
                {
                    OoadWings.DodajAvion(UnesiVozilo());
                }
                else if (izbor == 2)
                {
                    int tip = -1;
                    while (tip != 1 && tip != 2)
                    {
                        Console.Write(
                            "\nOdaberite tip klijenta:\n1 - Domaci klijent\n2 - Strani klijent\nOdabir: ");

                        ulaz = Console.ReadLine();
                        tip = Int32.Parse(ulaz);
                    }

                    string id = "", ime, prezime;
                    DateTime dateTime;
                    bool ispravan = false;
                    while (!ispravan)
                    {
                        try
                        {
                            Console.Write("\nUnesite id novog klijenta: ");
                            id = Console.ReadLine();
                            ispravan = true;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    Console.Write("\nUnesite ime novog klijenta: ");
                    ime = Console.ReadLine();
                    Console.Write("\nUnesite prezime novog klijenta: ");
                    prezime = Console.ReadLine();
                    Console.Write("\nUnesite datum rođenja klijenta (dd.MM.yyyy): ");
                    string[] strings;
                    do
                    {
                        ulaz = Console.ReadLine();
                        strings = ulaz.Split(".");
                    } while (strings.Length != 3);

                    dateTime = new DateTime(Int32.Parse(strings[2]), Int32.Parse(strings[1]), Int32.Parse(strings[0]));

                    if (tip == 1)
                    {
                        DomaciKlijent domaciKlijent = new DomaciKlijent(id, ime, prezime, dateTime);
                        OoadWings.DodajKlijenta(domaciKlijent);
                    }
                    else if (tip == 2)
                    {
                        string grad, drzava;
                        Console.Write("\nUnesite drzavu novog klijenta: ");
                        drzava = Console.ReadLine();
                        Console.Write("\nUnesite grad novog klijenta: ");
                        grad = Console.ReadLine();
                        StraniKlijent straniKlijent = new StraniKlijent(id, ime, prezime, dateTime, grad, drzava);
                        OoadWings.DodajKlijenta(straniKlijent);
                    }
                }
                else if (izbor == 3)
                {
                    string kid = UnesiKorisnickiId();

                    int tip = -1;
                    while (tip != 1 && tip != 2)
                    {
                        Console.Write("\nOdaberite tip pretrage:\n1 - Po ID-ju\n2 - Po atributima\nOdabir: ");

                        ulaz = Console.ReadLine();
                        tip = Int32.Parse(ulaz);
                    }

                    List<Avion> rezultat = new List<Avion>();
                    if (tip == 1)
                    {
                        string id = "";
                        Console.Write("\nUnesite id traženog aviona: ");
                        id = Console.ReadLine();
                        rezultat = OoadWings.PretraziPrekoId(id);
                    }
                    else if (tip == 2)
                    {
                        rezultat = OoadWings.PretraziPrekoAtributa(UnesiVozilo());
                    }

                    Console.Write("\nOdaberite jedan od rezultata:\n ");
                    int i = 1;
                    foreach (Avion avion in rezultat)
                    {
                        Console.WriteLine(i + " - " + avion);
                        i++;
                    }

                    tip = -1;
                    while (!(tip >= 1 && tip <= rezultat.Count))
                    {
                        Console.Write("\nOdabir: ");
                        ulaz = Console.ReadLine();
                        tip = Int32.Parse(ulaz);
                    }

                    i = tip - 1;

                    Console.Write("\nUnesite datum početka najama (dd.MM.yyyy): ");
                    string[] strings;
                    do
                    {
                        ulaz = Console.ReadLine();
                        strings = ulaz.Split(".");
                    } while (strings.Length != 3);

                    DateTime d1 = new DateTime(Int32.Parse(strings[2]), Int32.Parse(strings[1]),
                        Int32.Parse(strings[0]));

                    Console.Write("\nUnesite datum kraja najama (dd.MM.yyyy): ");
                    do
                    {
                        ulaz = Console.ReadLine();
                        strings = ulaz.Split(".");
                    } while (strings.Length != 3);

                    DateTime d2 = new DateTime(Int32.Parse(strings[2]), Int32.Parse(strings[1]),
                        Int32.Parse(strings[0]));

                    double kaucija = 0;
                    Tuple<Avion, DateTime, DateTime> tuple = new Tuple<Avion, DateTime, DateTime>(rezultat[i], d1, d2);
                    OoadWings.IznajmiVozilo(tuple, kid);
                    foreach (Klijent k in OoadWings.Klijenti)
                    {
                        if (kid == k.Id)
                        {
                            kaucija = k.PlatiKauciju();
                        }
                    }

                    Console.Write("\nVozilo uspješno iznajmljeno. Kaucija iznosi: " + kaucija + " KM");
                }
                else if (izbor == 4)
                {
                    string kid = UnesiKorisnickiId();
                    string id = "";
                    Console.Write("\nUnesite id aviona za povratak: ");
                    id = Console.ReadLine();
                    double ukupnaCijena = OoadWings.VratiVozilo(id, kid);
                    Console.Write("\nVozilo uspješno vraćeno. Ukupna cijena iznosi: " + ukupnaCijena +" KM");
                }
                else if (izbor == 5)
                {
                }
            }
        }

        public static void unesiPodatke()
        {
            OoadWings.Klijenti.Add(new DomaciKlijent("123456","Mujo","Mujic",new DateTime(1985,4,25)));
            OoadWings.Klijenti.Add(new StraniKlijent("654321","Hans","Ziegler",new DateTime(1975,7,12),"Berlin","Njemačka"));
            OoadWings.Avioni.Add(new TeretniAvion("abcde1234","Antonov",100,0.5));
            OoadWings.Avioni.Add(new PutnickiLokalniAvion("4321abcde","Lockheed",1));
            List<string> drzave=new List<string>();
            drzave.Add("USA"); drzave.Add("USSR");
            OoadWings.Avioni.Add(new PutnickiInostraniAvion("ussr4ever","Mig",2,drzave));
        }

        public static string UnesiKorisnickiId()
        {
            bool ispravan = false;
            string kid = "";
            while (!ispravan)
            {
                try
                {
                    Console.Write("\nUnesite korisnički ID: ");
                    kid = Console.ReadLine();
                    foreach (Klijent k in OoadWings.Klijenti)
                    {
                        if (k.Id == kid)
                        {
                            ispravan = true;
                            break;
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return kid;
        }

        public static Avion UnesiVozilo()
        {
            int tip = -1;
            string ulaz = "";
            while (tip != 1 && tip != 2 && tip != 3)
            {
                Console.Write(
                    "\nOdaberite tip vozila:\n1 - Putnicki avion koji leti unutar zemlje\n2 - Putnicki avion koji u inostranstvo\n3 - Teretni avion\nOdabir: ");

                ulaz = Console.ReadLine();
                tip = Int32.Parse(ulaz);
            }

            string id = "", vrsta;
            int brojSjedista;
            bool ispravan = false;
            while (!ispravan)
            {
                try
                {
                    Console.Write("\nUnesite id aviona: ");
                    id = Console.ReadLine();
                    ispravan = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.Write("\nUnesite vrstu aviona: ");
            vrsta = Console.ReadLine();
            Console.Write("\nUnesite broj sjedista: ");
            ulaz = Console.ReadLine();
            brojSjedista = Int32.Parse(ulaz);
            if (tip == 1)
            {
                PutnickiLokalniAvion putnickiLokalniAvion = new PutnickiLokalniAvion(id, vrsta, brojSjedista);
                //OoadWings.DodajAvion(putnickiLokalniAvion);
                return putnickiLokalniAvion;
            }
            else if (tip == 2)
            {
                Console.Write("\nUnesite drzave u koje leti avion (odvojene razmakom): ");
                ulaz = Console.ReadLine();
                string[] strings = ulaz.Split(" ");
                List<string> drzave = new List<string>(strings);
                PutnickiInostraniAvion putnickiInostraniAvion =
                    new PutnickiInostraniAvion(id, vrsta, brojSjedista, drzave);
                return putnickiInostraniAvion;
            }
            else if (tip == 3)
            {
                Console.Write("\nUnesite ukupni kapacitet aviona: ");
                ulaz = Console.ReadLine();
                int ukupniKapacitet = Int32.Parse(ulaz);
                TeretniAvion teretniAvion = new TeretniAvion(id, vrsta, brojSjedista, ukupniKapacitet);
                return teretniAvion;
            }

            return null;
        }
    }
}