using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Anyone shape which is shown below :");
            Console.WriteLine("1. Rectangle \n2. circle \n3. Square");
            string shapeType = Console.ReadLine();

            Ishape sh = ShapeFactory.createshape(shapeType);


            if (sh != null)
            {
                Console.WriteLine(" area : {0}", sh.area());
                Console.WriteLine(" perimeter : {0}", sh.perimeter());

            }
            else
            {
                Console.WriteLine("invalid shape");
            }
            Console.Read();
        }
    }
}
