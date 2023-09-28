using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemotingServer;

namespace TcpClient
{
    public partial class Form1 : Form
    {
        Service remoteobj = new Service();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            remoteobj = (Service)Activator.GetObject(typeof(Service), "tcp://localhost:8089/OurFirstRemoteService");
            int a = Int32.Parse(txtnum1.Text);
            int b = Int32.Parse(txtnum2.Text);
            txtresult.Text = (remoteobj.HighNumber(a, b)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
