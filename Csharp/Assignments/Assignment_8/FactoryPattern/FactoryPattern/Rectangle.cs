using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Rectangle : Ishape
    {
        public double length = 20;
        public double width = 15;
        public double area()
        {
            return length * width;
        }
        public double perimeter()
        {
            return 2 * (length + width);
        }
    }
}
