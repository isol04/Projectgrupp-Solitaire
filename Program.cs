namespace Projekt_Solitaire
{
    internal class Program
    {
        static List<Kort> Korten = new List<Kort>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            SkapaKort();
            BlandaKort();
            foreach (Kort k in Korten)
            {
                k.valör.GetDrawn(k);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        static void SkapaKort()
        {
            for (int n = 1; n < 14; n++)
            {
                string value;
                switch (n)
                {
                    case 1:
                        value = "A";
                        break;
                    case 11:
                        value = "Kn";
                            break;
                    case 12:
                        value = "Q";
                        break;
                    case 13:
                        value = "K";
                        break;
                    default:
                        value = n.ToString();
                        break;
                }
                for (int v = 0; v < 4; v++)
                {
                    switch (v)
                    {
                        case 0:
                            Korten.Add(new Kort(value, new Hjärter()));
                            break;
                        case 1:
                            Korten.Add(new Kort(value, new Ruter()));
                            break;
                        case 2:
                            Korten.Add(new Kort(value, new Spader()));
                            break;
                        case 3:
                            Korten.Add(new Kort(value, new Klöver()));
                            break;
                    }
                }
            }
            //Console.WriteLine(Korten.Count);
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