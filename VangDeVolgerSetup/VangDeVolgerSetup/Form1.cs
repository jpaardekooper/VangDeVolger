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
        
      

              

        //css for easy
        private void easy_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = easy.Text;
            Form2 Gameboard = new Form2();
            Gameboard.Show();
        }
        private void easy_MouseEnter(object sender, EventArgs e)
        {
            easy.BorderStyle = BorderStyle.FixedSingle;
            easy.BackColor = Color.White;       
        }

        private void easy_MouseLeave(object sender, EventArgs e)
        {
            easy.BorderStyle = BorderStyle.None;
            easy.BackColor = Color.Transparent;
        }
        //end css for easy


        //css for hard
        private void hard_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = hard.Text;
            Form2 Gameboard = new Form2();
            Gameboard.Show();
        }
        private void hard_MouseEnter(object sender, EventArgs e)
        {
            hard.BorderStyle = BorderStyle.FixedSingle;
            hard.BackColor = Color.White;
        }
        private void hard_MouseLeave(object sender, EventArgs e)
        {
            hard.BorderStyle = BorderStyle.None;
            hard.BackColor = Color.Transparent;
        }
        //end hard css


        private void crazy_Click(object sender, EventArgs e)
        {

        }

      
    }
}
