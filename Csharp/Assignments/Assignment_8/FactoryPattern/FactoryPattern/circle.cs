using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Circle : Ishape
    {
        
        public double radius = 5;
        

        public double area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        public double perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}
