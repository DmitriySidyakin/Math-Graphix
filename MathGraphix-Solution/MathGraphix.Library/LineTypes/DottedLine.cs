using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGraphix.Library.LineTypes
{
    public class DottedLine : LineType
    {
        public DottedLine() => line = new long[] { 1, 1 };
    }
}
