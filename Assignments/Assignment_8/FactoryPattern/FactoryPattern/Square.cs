using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Square : Ishape
    {
        public double side = 9;

        public double area()
        {
            return Math.Pow(side, 2);
        }

        public double perimeter()
        {
            return 4 * side;
        }
    }
}
