using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal interface IValör
    {
        string Värde { get; set; }
        string Display { get; set; }

        //string getValör();
        void GetDrawn();
        ConsoleColor getColor();
         bool facingUp { get; set; }

    }
}

