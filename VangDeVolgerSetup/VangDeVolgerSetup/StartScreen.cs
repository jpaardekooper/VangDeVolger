using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public partial class StartScreen : Form
    {
        public static string MyTextBoxValue { get; set; }
        public static string myMapValue { get; set; }

        public StartScreen()
        {
            InitializeComponent();           
        }              

        //css for easy
        private void easy_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = easy.Text;
            Game Gameboard = new Game();
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

        private void changeEasyMap_Click(object sender, EventArgs e)
        {
            myMapValue = easy.Text;
            ChangeMap ChangeMap = new ChangeMap();
            ChangeMap.Show();
        }
        //end css for easy


        //css for hard
        private void hard_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = hard.Text;
            Game Gameboard = new Game();
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

        private void changeHardMap_Click(object sender, EventArgs e)
        {
            myMapValue = hard.Text;
            ChangeMap ChangeMap = new ChangeMap();
            ChangeMap.Show();
        }
        //end hard css     

      
        //css for crazy
        private void crazy_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = crazy.Text;
            Game Gameboard = new Game();
            Gameboard.Show();
        }

        private void changeCrazyMap_Click(object sender, EventArgs e)
        {
            myMapValue = crazy.Text;
            ChangeMap ChangeMap = new ChangeMap();
            ChangeMap.Show();
        }

        private void crazy_MouseEnter(object sender, EventArgs e)
        {
            crazy.BorderStyle = BorderStyle.FixedSingle;
            crazy.BackColor = Color.White;
        }

        private void crazy_MouseLeave(object sender, EventArgs e)
        {
            crazy.BorderStyle = BorderStyle.None;
            crazy.BackColor = Color.Transparent;
        }
        //end crazy css

        private void _playHoverSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }

        
    }
}
