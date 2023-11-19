using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
     class SolitaireEngine
    {
     
        public static List<Hög> Högarna = new();
        public static List<Hög> Målen = new();
        const int högcount = 7;

        public static bool gameWon()
        {
            foreach (Hög hög in Målen)
            {
                if (hög.getÖverst().Display != "K")
                {
                    return false;
                }
            }
            return true;
        }

     public static void SkapaKort()
        {
            Kort.Korten.Clear();
            for (int n = 1; n < 14; n++)
            {

                for (int v = 0; v < 4; v++)
                {
                    switch (v)
                    {
                        case 0:
                            Kort.Korten.Add(new Kort(n, new Hjärter()));
                            break;
                        case 1:
                            Kort.Korten.Add(new Kort(n, new Ruter()));
                            break;
                        case 2:
                            Kort.Korten.Add(new Kort(n, new Spader()));
                            break;
                        case 3:
                            Kort.Korten.Add(new Kort(n, new Klöver()));
                            break;
                    }
                }
            }
            
        }


     public   static void tillMål(Kort k, List<Kort> h)
        {
            foreach (Hög hög in Målen)
            {
                if ((hög.getÖverst().valör.getValör() == k.valör.getValör() && hög.getÖverst().värde == k.värde - 1))
                {
                    if (h.FindIndex(u => u.Equals(k)) == h.Count - 1 || h.FindIndex(u => u.Equals(k)) == 0)
                    {
                        hög.högensKort.Add(k);
                        h.Remove(k);
                        Menu.InGame();
                    }
                }
            }
            RitaBräde();
            Console.WriteLine("Detta drag går ej!");
            tillHög(k, h);

        }

       public static void tillHög(Kort k, List<Kort> h)
        {
            try
            {
                Console.Write($"Ange till vilken hög (1-7) du vill flytta ");
                k.valör.GetDrawn(k); 
                Console.WriteLine("eller skriv 'm' för att flytta kortet till dess grundhög \r\n eller skriv 'b' för att gå tillbaka");

                string input = Console.ReadLine();
                if (input == "b")
                {
                    dragInput();
                }

                try
                {
                    int place = int.Parse(input) - 1;
                    if (Högarna[place].högensKort.Count == 0 || (k.värde + 1 == Högarna[place].getÖverst().värde && (k.valör.getValör() != Högarna[place].getÖverst().valör.getValör())))
                    {
                        List<Kort> temp = new List<Kort>();
                        for (int i = h.FindIndex(u => u.Equals(k)); i < h.Count; i++)
                        {
                            if (h[i].facingUp)
                            {
                                Högarna[place].högensKort.Add(h[i]);
                                temp.Add(h[i]);
                            }
                        }
                        foreach (Kort kort in temp)
                        {
                            h.Remove(kort);
                        }


                        RitaBräde();
                        Menu.InGame();
                    }
                }
                catch
                {
                    if (input == "m")
                    {
                        tillMål(k, h);
                    }
                }
                throw new Exception();
            }
            catch
            {

                RitaBräde();
                Console.WriteLine("Denna plats var inte giltig! Försök igen!");
                tillHög(k, h);
            }
        }
      public  static void flyttaHög(List<Kort> h)
        {

            if (h == Kort.Korten)
            {
                RitaBräde();
                tillHög(Kort.Korten[0], h);
            }
            int tempAntalUppvända = 0;
            for (int i = 0; i < h.Count; i++)
            {
                if (h[i].facingUp) tempAntalUppvända++;
            }
            if (tempAntalUppvända == 1)
            {
                RitaBräde();
                tillHög(h[h.Count - 1], h);
            }

            Console.WriteLine();
            List<Kort> temp = new List<Kort>();
            Console.Write("Uppvända kort i den valda högen: ");
            for (int n = 0; n < h.Count; n++)
            {
                if (h[n].facingUp)
                {
                    h[n].valör.GetDrawn(h[n]);
                    temp.Add(h[n]);
                }
            }
            try
            {
                Console.WriteLine();
                Console.WriteLine($"Ange från vilket kort i högen du vill flytta (1-{temp.Count}) eller skriv 'm' för att direkt flytta det minsta kortet till dess grundhög \r\n eller skriv 'b' för att gå tillbaka");
                string input = Console.ReadLine();
                if (input == "b")
                {
                    dragInput();
                }
                if (input == "m")
                {
                    if (h.Count != 0)
                        tillMål(h[h.Count - 1], h);
                }
                int place = int.Parse(input) - 1;
                RitaBräde();
                tillHög(temp[place], h);
            }
            catch
            {
                RitaBräde();
                Console.WriteLine("Denna plats var inte giltig! Försök igen!");
                flyttaHög(h);
            }


        }
       public static void dragInput()
        {
            try
            {
                int kortLekKvar = 1;
                if (Kort.Korten.Count == 0) kortLekKvar = 0;

                RitaBräde();
                Console.WriteLine($"Ange vilken hög du vill interagera med (1-{Högarna.Count + kortLekKvar}) eller skriv 'n' för att vända upp nästa kort");
                string input = Console.ReadLine();
                if (input == "8" && Kort.Korten.Count != 0)
                {
                    flyttaHög(Kort.Korten);
                    RitaBräde();
                }
                if (input == "n")
                {
                    Kort.Korten[0].facingUp = false;
                    Kort.Korten.Add(Kort.Korten[0]);
                    Kort.Korten.RemoveAt(0);
                    dragInput();
                }
                int place = int.Parse(input) - 1;
                RitaBräde();
                flyttaHög(Högarna[place].högensKort);
            }
            catch
            {

                dragInput();

            }
        }

      public  static void RitaBräde()
        {
            Console.Clear();
            Console.Write("    ");
            foreach (Hög hög in Målen)
            {
                hög.getÖverst().valör.GetDrawn(hög.getÖverst());
            }
            Console.WriteLine("\r\n");
            Console.WriteLine("    [ 1  2  3  4  5  6  7  ]  8  n");
            Console.Write("    ");
            int tempLongest = 0;
            foreach (Hög hög in Högarna)
            {
                if (hög.högensKort.Count >= tempLongest)
                {
                    tempLongest = hög.högensKort.Count;
                }
                try
                {
                    hög.getÖverst().facingUp = true;
                }
                catch
                {

                }

            }
            for (int i = 0; i < tempLongest; i++)
            {
                Console.Write($"[ "
               );
                for (int l = 0; l < högcount; l++)
                {

                    try
                    {
                        Högarna[l].högensKort[i].valör.GetDrawn(Högarna[l].högensKort[i]);
                    }
                    catch
                    {
                        Console.Write("   ");
                    }

                }
                Console.Write($"]");
                if (i == 0 && Kort.Korten.Count != 0)
                {
                    Console.Write("  ");
                    Kort.Korten[0].facingUp = true;
                    Kort.Korten[0].valör.GetDrawn(Kort.Korten[0]);
                    if (Kort.Korten.Count >= 2)
                    {
                        Kort.Korten[1].valör.GetDrawn(Kort.Korten[1]);
                    }
                  
                }
                Console.Write($"\r\n    ");


            }
            Console.Write("\r\n ");

        }
       public static void SkapaHög()
        {
            Högarna.Clear();
            Målen.Clear();
            for (int i = 0; i < högcount; i++)
            {
                Högarna.Add(new Hög());

                for (int z = 0; z <= i; z++)
                {
                    Högarna[i].högensKort.Add(Kort.Korten[Kort.Korten.Count - 1]);
                    Kort.Korten.RemoveAt(Kort.Korten.Count - 1);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Målen.Add(new Hög());
            }
            Målen[0].högensKort.Add(new Kort(0, new Spader()));
            Målen[1].högensKort.Add(new Kort(0, new Klöver()));
            Målen[2].högensKort.Add(new Kort(0, new Hjärter()));
            Målen[3].högensKort.Add(new Kort(0, new Ruter()));



        }
       public static void BlandaKort()
        {
            Random r = new Random();
            for (int i = Kort.Korten.Count - 1; i > 0; i--)
            {
                int n = r.Next(i + 1);
                Kort temp = Kort.Korten[n];
                Kort.Korten[n] = Kort.Korten[i];
                Kort.Korten[i] = temp;
            }
        }
    }



}

