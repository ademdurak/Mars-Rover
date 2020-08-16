using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case
{
    public class Plateau
    {
        public int maxHorizantelLineCount { get; set; }
        public int maxVeriticalLineCount { get; set; }
        public Plateau()
        {

        }
        public Plateau(int maxHorizantelLineCount, int maxVeriticalLineCount)
        {
            this.maxHorizantelLineCount = maxHorizantelLineCount;
            this.maxVeriticalLineCount = maxVeriticalLineCount;
        }
    }
}
