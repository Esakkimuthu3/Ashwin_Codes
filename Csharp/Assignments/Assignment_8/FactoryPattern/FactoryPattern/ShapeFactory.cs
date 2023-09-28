using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class ShapeFactory
    {
        public static Ishape createshape(string shapetype)
        {
            switch (shapetype.ToLower())
            {
                case "circle":
                    return new Circle();
                case "square":
                    return new Square();
                case "rectangle":
                    return new Rectangle();
                default:
                    throw new ArgumentException("invalid shape type");

            }

        }
    }
}
