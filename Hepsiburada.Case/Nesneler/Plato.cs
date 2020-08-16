using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case
{
    public class Plato
    {
        public int En { get; set; }
        public int Boy { get; set; }
        public Plato()
        {

        }
        public Plato(int en, int boy)
        {
            this.En = en;
            this.Boy = boy;
        }
    }
}
