using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser.ZhangShasha
{
    public class Operation
    {
        public enum Op { Insert, Delete, Change };
        public Op O;
        public int N1;
        public int N2;
    }
}
