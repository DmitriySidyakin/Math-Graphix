using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGraphix.Library.LineTypes
{
    public class DashedLine : LineType
    {
        public DashedLine() => line = new long[] { 4, 4 };
    }
}
