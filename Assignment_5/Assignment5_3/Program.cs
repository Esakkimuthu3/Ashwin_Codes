using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales
{

    internal class salesdetails
    {
        public int no;
        public int productno;
        public double price;
        public DateTime dateofsale;
        public int quantity;
        public double totalamt;
        public salesdetails(int salesno, int productno, double price, DateTime dateofsales, int qty)
        {
            this.no = no;
            this.productno = productno;
            this.price = price;
            this.dateofsale = dateofsale;
            this.quantity = quantity;

        }
        public void sales()
        {
            totalamt = quantity * price;
        }
        public void showdata()
        {
            Console.WriteLine($" 1.salesno: {no} \n 2.productNo: {productno} \n 3.price: {price} \n 5.quantity: {quantity} \n 6.total amount: {totalamt}");
            Console.WriteLine("date of sales: " + dateofsale.ToString("yyyy-MM-dd"));
            Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Parse("2023-09-15");
            salesdetails info = new salesdetails(37, 676783, 4300, date, 3);
            info.sales();
            info.showdata();
        }
    }
}