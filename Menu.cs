using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
     class Menu
    {
        private static bool inGame;

        public static void MenuStartup()
        {
            Regler();
            StartaSpel();
            HanteraAnvändaVal(AnvändarInput());
        }
        public static void InGame()
        {
            while (inGame)
            {
                if (SolitaireEngine.gameWon())
                {
                    inGame = false;
                    Console.Clear();
                    Console.WriteLine("Grattis! Du vann!");
                    Thread.Sleep(5000);
                    MenuStartup();
                }
                else
                {
                    SolitaireEngine.dragInput();
                  
                }

            }
        }
        public static void gameSetup()
        {
            SolitaireEngine.SkapaKort();
            SolitaireEngine.BlandaKort();
            SolitaireEngine.SkapaHög();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            inGame = true;
            InGame();
        }

        public static void Regler()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Hej och välkommen till spelet solitaire! Om du ej spelat solitaire tidigare står det nedan en kort förklaring av reglerna!: \n");

            Console.WriteLine("1. Spelet börjar med sju högar kort. Varje korthög har ett kort mer än högen till vänster. Det sista kortet i varje hög, allstå kortet längst ner är uppåtvänt. \n");

            Console.WriteLine("2. Ditt uppdrag är att placera korten i fallande ordning där det nästkommande kortet måste vara av en annan färg. När du har hittat ett ess kort ska du placera det i en av de fyra grundhögarna. \n");

            Console.WriteLine("3. I de fyra grundhögarna ska du sedan placera korten av samma typ i stigande ordning. \n");

            Console.WriteLine("4. Ifall du hamnar i en position där du inte kan dra fler drag ska du dra ett kort från den originella korthögen och se ifall kortet kan spelas. \n");

            Console.WriteLine("5. Spelet fortsätter tills att de fyra grundhögarna är ordnade i stigande ordning och då är spelet vunnet. \n");

            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public static void StartaSpel()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine();
            Console.WriteLine("Välj ett alternativ, skriv 1 för att starta ett nytt spel eller skriv 2 för att lämna.");
            Console.WriteLine("1. Starta ett nytt spel");
            Console.WriteLine("2. Exit");
        }

        public static int AnvändarInput()
        {
            int val;
            while (true)
            {
                Console.WriteLine("Ange ditt val.");
                string input = Console.ReadLine();
                if (int.TryParse(input, out val) && (val == 1 || val == 2))
                {
                 return val;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Vänligen skriv 1 eller 2");
                }
            }

            //return val;
        }

        public static void HanteraAnvändaVal(int val)
        {
            switch (val)
            {
                case 1:
                    Console.WriteLine("Ett nytt spel startas...");
                    gameSetup();                    
                    break;
                case 2:
                    Console.WriteLine("Du lämnar spelet...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ogiltig inmatning. Vänligen skriv 1 eller 2");
                    break;
            }
        }
    }
}
