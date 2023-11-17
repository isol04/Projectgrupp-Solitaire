using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal class Kort
    {
        public  string värde {  get; set; }
        public IValör valör {  get; set; }
        public Kort (string värde, IValör valör)
        {
            this.värde = värde;
            this.valör = valör;
        }
    }
}
