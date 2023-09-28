using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_1
{
    class Box
    {
        public int Len { get; set; }
        public int Bred { get; set; }
        public Box(int len,int bred)
        {
            Len = len;
            Bred = bred;
        }
        public Box AddSomeBoxes(Box extraBox)
        {
            int totalLen = Len + extraBox.Len;
            int totalBred = Bred + extraBox.Bred;
            return new Box(totalLen, totalBred);
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Len} units");
            Console.WriteLine($"Breadth: {Bred} units");
        }
    }
    class BoxProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the value of Length:");
            int lenval = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("enter the value of Breadth:");
            int bredval = Convert.ToInt32(Console.ReadLine());
            Box box1 = new Box(lenval, bredval);
            Console.WriteLine("enter the value of Length for box 2:");
            lenval = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the value of Breadth for box 2: ");
            bredval = Convert.ToInt32(Console.ReadLine());
            Box box2 = new Box(lenval, bredval);
            Box box3 = box1.AddSomeBoxes(box2);
            Console.WriteLine("The details of the Box 3:");
            box3.Display();
            Console.ReadLine();
        }
    }
}
