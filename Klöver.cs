﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
     class Klöver : Valör
    {
        const ConsoleColor färg = ConsoleColor.Black;

        public override ConsoleColor getColor()
        {
            return färg;
        }

        public override string getValör()
        {
            return "♣";
        }
        public override void GetDrawn(Kort k)
        {
            base.GetDrawn(k);
        }
        
    }
}
