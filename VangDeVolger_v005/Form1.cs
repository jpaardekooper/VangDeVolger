using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{
    public partial class GameSetup : Form
    {
        public static string MyTextBoxValue;       

        public GameSetup()
        {
            InitializeComponent();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = label1.Text;
            Game Game = new Game();            
            Game.Show();
        }

       
    }
}

