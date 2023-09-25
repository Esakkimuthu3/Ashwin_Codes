using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concession
{
    public class concession
    {
        public int Price = 500;
        public string Name;
        public int Age;

        public void CalculatorConsession()
        {
            if (Age <= 5)
            {
                Console.WriteLine("Your name : {0}  \nYour age : {1} \nYou have won a free ticket Champion , Bravo! ", Name, Age);
            }
            else if (Age > 60)
            {
                double TicketFair = Price * 0.30;
                double dprice = Price - TicketFair;
                Console.WriteLine("Senior citizen TicketFare : {0} \nYour name : {1} \nYour age : {2}", dprice, Name, Age);
            }

            else
            {
                Console.WriteLine("Your tickets are booked {0} \nYour name : {1} \nYour age : {2}", Price, Name, Age);
            }

        }

    }

}
