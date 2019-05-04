using System;
using System.Collections.Generic;

namespace OOAD_Zadaca1
{
    class Program
    {
        private static OoadWings OoadWings;

        static void Main(string[] args)
        {
            OoadWings = new OoadWings(new List<Klijent>(), new List<Avion>());

            for (;;)
            {
                int izbor = -1;
                string ulaz = "";
                while (izbor != 0 && izbor != 1 && izbor != 2 && izbor != 3 && izbor != 4 && izbor != 5)
                {
                    Console.Write(
                        "Odaberite zeljenu opciju:\n0 za kraj programa\n1 za kreiranje novog vozila\n2 za kreiranje novog klijenta\n3 za iznajmljivanje vozila\n4 za povrat vozila i plaćanje\n5 za ispis liste obavijesti\nOdabir: ");

                    ulaz = Console.ReadLine();
                    izbor = Int32.Parse(ulaz);
                }

                if (izbor == 0)
                {
                    break;
                }
                else if (izbor == 1)
                {
                    int tip = -1;
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
                            Console.Write("\nUnesite id novog aviona: ");
                            id = Console.ReadLine();
                            ispravan = true;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    Console.Write("\nUnesite vrstu novog aviona: ");
                    vrsta = Console.ReadLine();
                    Console.Write("\nUnesite broj sjedista: ");
                    ulaz = Console.ReadLine();
                    brojSjedista = Int32.Parse(ulaz);
                    if (tip == 1)
                    {
                        PutnickiLokalniAvion putnickiLokalniAvion = new PutnickiLokalniAvion(id, vrsta, brojSjedista);
                        OoadWings.DodajAvion(putnickiLokalniAvion);
                    }
                    else if (tip == 2)
                    {
                        Console.Write("\nUnesite drzave u koje leti novi avion (odvojene razmakom): ");
                        ulaz = Console.ReadLine();
                        string[] strings = ulaz.Split(" ");
                        List<string> drzave = new List<string>(strings);
                        PutnickiInostraniAvion putnickiInostraniAvion =
                            new PutnickiInostraniAvion(id, vrsta, brojSjedista, drzave);
                    }
                    else if (tip == 3)
                    {
                        Console.Write("\nUnesite ukupni kapacitet novog aviona: ");
                        ulaz = Console.ReadLine();
                        int ukupniKapacitet = Int32.Parse(ulaz);
                        TeretniAvion teretniAvion = new TeretniAvion(id, vrsta, brojSjedista, ukupniKapacitet);
                    }
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

                    string id="", ime, prezime;
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
                        strings = ulaz.Split(" ");
                    } while (strings.Length != 3);

                    dateTime = new DateTime(Int32.Parse(strings[2]), Int32.Parse(strings[1]), Int32.Parse(strings[0]));

                    if (tip == 1)
                    {
                        DomaciKlijent domaciKlijent=new DomaciKlijent(id,ime,prezime,dateTime);
                        OoadWings.DodajKlijenta(domaciKlijent);
                    } 
                    else if (tip == 2)
                    {
                        string grad, drzava;
                        Console.Write("\nUnesite drzavu novog klijenta: ");
                        drzava = Console.ReadLine();
                        Console.Write("\nUnesite grad novog klijenta: ");
                        grad = Console.ReadLine();
                        StraniKlijent straniKlijent=new StraniKlijent(id,ime,prezime,dateTime,grad,drzava);
                        OoadWings.DodajKlijenta(straniKlijent);
                    }
                }
                else if (izbor == 3)
                {
                    
                }
                else if (izbor == 4)
                {
                    
                }
                else if (izbor == 5)
                {
                    
                }
            }
        }
    }
}