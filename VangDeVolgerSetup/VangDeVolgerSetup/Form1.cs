using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public partial class Form1 : Form
    {
        public static string MyTextBoxValue;
      
        public Form1()
        {
            InitializeComponent();           
        }
        
      

        private void button1_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = label1.Text;
            Form2 Gameboard = new Form2();
            Gameboard.Show();
        }

    }
}
