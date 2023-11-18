namespace Projekt_Solitaire
{
    internal class Program
    {
        static List<Kort> Korten = new List<Kort>();
        static List<Hög> Högarna = new List<Hög>();
        static List<Hög> Målen = new List<Hög>();
 
        static void Main(string[] args)
        {
       
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            SkapaKort();
            BlandaKort();
            SkapaHög();
            RitaBräde();
            dragInput();
            //foreach (Kort k in Korten)
            //{
            //    k.valör.GetDrawn(k);
            //}


        }
        static void SkapaKort()
        {
            for (int n = 1; n < 14; n++)
            {
                
                for (int v = 0; v < 4; v++)
                {
                    switch (v)
                    {
                        case 0:
                            Korten.Add(new Kort(n, new Hjärter())); 
                            break;
                        case 1:
                            Korten.Add(new Kort(n, new Ruter())) ;
                            break;
                        case 2:
                            Korten.Add(new Kort(n, new Spader()));
                            break;
                        case 3:
                            Korten.Add(new Kort(n, new Klöver()));
                            break;
                    }
                }
            }
            //Console.WriteLine(Korten.Count);
        }

        static void tillMål(Kort k, List<Kort> h)
        {
            foreach (Hög hög in Målen)
            {
                if ((hög.getÖverst().valör.getValör() == k.valör.getValör() && hög.getÖverst().värde == k.värde-1))
                {
                    if (h.FindIndex(u => u.Equals(k)) == h.Count - 1 || h.FindIndex(u => u.Equals(k)) == 0)
                    {
                        hög.högensKort.Add(k);
                        h.Remove(k);
                        dragInput();
                    }
                }
            }
            RitaBräde();
                Console.WriteLine("Detta drag går ej!");
                tillHög(k, h);
           
        }

        static void tillHög(Kort k, List<Kort> h)
        {
            try
            {
                Console.Write($"Ange till vilken hög (1-7) du vill flytta ");
                k.valör.GetDrawn(k);
                Console.WriteLine("eller skriv 'm' för att flytta kortet till mål \r\n eller skriv 'b' för att gå tillbaka");
              
                string input = Console.ReadLine();
                if (input == "b")
                {
                    dragInput();
                }
                if (input == "m")
                {
                    tillMål(k, h);
                }

                int place = int.Parse(input) - 1;
                if (Högarna[place].högensKort.Count == 0 || (k.värde + 1 == Högarna[place].getÖverst().värde && (k.valör.ärRöd() != Högarna[place].getÖverst().valör.ärRöd())) )
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
                    dragInput();
                }
                else throw new Exception();
            }
            catch
            {
                RitaBräde();
                Console.WriteLine("Denna plats var inte giltig! Försök igen!");
                tillHög(k, h);
            }
        }
        static void flyttaHög(List<Kort> h)
        {
            if (h == Korten)
            {
                RitaBräde();
                tillHög(Korten[0], h);
            }
                int tempAntalUppvända = 0;
            for (int i = 0; i < h.Count; i++)
            {
                if (h[i].facingUp) tempAntalUppvända++;
            }
            if (tempAntalUppvända == 1)
            { 
                RitaBräde();
                tillHög(h[h.Count-1], h);
            }

            Console.WriteLine();
            List<Kort> temp = new List<Kort>();
            Console.Write("Uppvända kort i den valda högen: ");
            for(int n = 0; n < h.Count; n++)
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
                Console.WriteLine($"Ange från vilket kort i högen du vill flytta (1-{temp.Count}) eller skriv 'b' för att gå tillbaka");
                string input = Console.ReadLine();
                if (input == "b")
                {
                    dragInput();
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
        static void dragInput()
        {
            try
            {
                RitaBräde();
                Console.WriteLine($"Ange vilken hög du vill interagera med (1-{Högarna.Count+1}) eller skriv 'n' för att bläddra till nästa kort");
                string input = Console.ReadLine();
                if (input == "8")
                {
                    flyttaHög(Korten);
                    RitaBräde();
                }
                if (input == "n")
                {
                    Korten[0].facingUp = false;
                    Korten.Add(Korten[0]);
                    Korten.RemoveAt(0);
                    dragInput();
                }
                int place = int.Parse(input)-1;
                RitaBräde();
                flyttaHög(Högarna[place].högensKort);
            }
            catch
            {
              
                dragInput();

            }
        }

        static void RitaBräde()
        {
            Console.Clear();
            Console.Write("    ");
            foreach (Hög hög in Målen)
            {
                hög.getÖverst().valör.GetDrawn(hög.getÖverst());
            }
            Console.WriteLine("\r\n");
            Console.Write("    ");
            int tempLongest = 0;
            foreach (Hög hög in Högarna)
            {
                try
                {
                    hög.getÖverst().facingUp = true;
                }
                catch
                {

                }
                if (hög.högensKort.Count > tempLongest)
                {
                    tempLongest = hög.högensKort.Count;
                }
            }
            for (int i = 0; i < tempLongest; i++)
            {
               
                for (int l = 0; l < 7; l++)
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
                if (i == 0)
                {
                    Console.Write("   ");
                    Korten[0].facingUp = true;
                    Korten[0].valör.GetDrawn(Korten[0]);
                    Korten[1].valör.GetDrawn(Korten[1]);
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                Console.Write("\r\n    ");
            }
            Console.Write("\r\n ");
            //foreach (Hög hög in Högarna)
            //{
            //    Console.WriteLine(hög.högensKort.Count);
            //    if
            //         (hög.högensKort.Count == 0)
            //    {
            //        Högarna.Remove(hög); break;
            //    }

            //    hög.getÖverest().facingUp = true;
            //    hög.getÖverest().valör.GetDrawn(hög.getÖverest());

            //}
          //  Console.WriteLine("");
          //  //Console.Write("Överst i kortleken: ");
          //  Console.Write("  ");
          //  Korten[0].facingUp = true;
          //Korten[0].valör.GetDrawn(Korten[0]);
          //  Korten[1].valör.GetDrawn(Korten[1]);
          //  Console.ForegroundColor = ConsoleColor.Black;
          //  Console.WriteLine();
            //Console.WriteLine($"({Korten.Count - 1} kort kvar)");

        }
        static void SkapaHög()
        {
            Högarna.Clear();
            Målen.Clear(); 
            for (int i = 0; i < 7;  i++)
            {
                Högarna.Add(new Hög(i));

                for (int z = 0; z <= i; z++)
                {
                    Högarna[i].högensKort.Add(Korten[Korten.Count-1]);
                    Korten.RemoveAt(Korten.Count - 1);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Målen.Add(new Hög(i));
            }
            Målen[0].högensKort.Add(new Kort(0, new Spader()));
            Målen[1].högensKort.Add(new Kort(0, new Klöver()));
            Målen[2].högensKort.Add(new Kort(0, new Hjärter()));
            Målen[3].högensKort.Add(new Kort(0, new Ruter()));



        }
        static void BlandaKort()
        {
            Random r = new Random();
        for (int i = Korten.Count-1; i > 0; i--)
            {
                int n = r.Next(i + 1);
                Kort temp = Korten[n];
                Korten[n] = Korten[i];
                Korten[i] = temp;
            }
        }
    }
}