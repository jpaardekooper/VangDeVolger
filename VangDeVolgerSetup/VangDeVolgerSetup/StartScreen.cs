/*
 * This is the StartScreen of the game Vang de Volger.
 * The user has three options: easy, hard and crazy. Clicking on one of these will generate a new window of Game.cs and load the game
 * The user can also change the map clicking on the change map button. This will create a new window of ChangeMap.cs
 * This program was created by:
 * Jasper Paardekooper 17039886
 * Roos Hoogervorst 17036895
 * 
 */
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public partial class StartScreen : Form
    {
        //the value MyTextBoxValue and myMapValue is needed to pass it to the game window in order to generate the correct map.
        public static string MyTextBoxValue { get; set; }
        public static string MyMapValue { get; set; }

        public StartScreen()
        {
            InitializeComponent();           
        }              

        //some styling for the labels easy and will generate Game.cs level modus: easy        
        private void easy_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = easy.Text;
            Game Gameboard = new Game();
            Gameboard.Show();
        }
        //adding a border when the mouse entered the label
        private void easy_MouseEnter(object sender, EventArgs e)
        {
            easy.BorderStyle = BorderStyle.FixedSingle;
            easy.BackColor = Color.White;       
        }
        //removing border when the mouse leaves the label
        private void easy_MouseLeave(object sender, EventArgs e)
        {
            easy.BorderStyle = BorderStyle.None;
            easy.BackColor = Color.Transparent;
        }
       //passing myMapValue data to the ChangeMap form in order to change the map
        private void changeEasyMap_Click(object sender, EventArgs e)
        {
            MyMapValue = easy.Text;
            ChangeMap ChangeMap = new ChangeMap();
            ChangeMap.Show();
        }
        //end styling for easy


        //some styling for the labels hard and will generate Game.cs level modus: hard
        private void hard_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = hard.Text;
            Game Gameboard = new Game();
            Gameboard.Show();
        }
        //adding a border when the mouse entered the label
        private void hard_MouseEnter(object sender, EventArgs e)
        {
            hard.BorderStyle = BorderStyle.FixedSingle;
            hard.BackColor = Color.White;
        }
        //removing border when the mouse leaves the label
        private void hard_MouseLeave(object sender, EventArgs e)
        {
            hard.BorderStyle = BorderStyle.None;
            hard.BackColor = Color.Transparent;
        }
        //passing myMapValue data to the ChangeMap form in order to change the map
        private void changeHardMap_Click(object sender, EventArgs e)
        {
            MyMapValue = hard.Text;
            ChangeMap ChangeMap = new ChangeMap();
            ChangeMap.Show();
        }
        //end styling for hard     


        //some styling for the labels crazy and will generate Game.cs level modus: crazy
        private void crazy_Click(object sender, EventArgs e)
        {
            MyTextBoxValue = crazy.Text;
            Game Gameboard = new Game();
            Gameboard.Show();
        }       
        //adding a border when the mouse entered the label
        private void crazy_MouseEnter(object sender, EventArgs e)
        {
            crazy.BorderStyle = BorderStyle.FixedSingle;
            crazy.BackColor = Color.White;
        }
        //removing border when the mouse leaves the label
        private void crazy_MouseLeave(object sender, EventArgs e)
        {
            crazy.BorderStyle = BorderStyle.None;
            crazy.BackColor = Color.Transparent;
        }
        //passing myMapValue data to the ChangeMap form in order to change the map
        private void changeCrazyMap_Click(object sender, EventArgs e)
        {
            MyMapValue = crazy.Text;
            ChangeMap ChangeMap = new ChangeMap();
            ChangeMap.Show();
        }
        //end styling for crazy       


    }
}
