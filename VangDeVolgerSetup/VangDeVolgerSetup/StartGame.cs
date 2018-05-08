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
    public partial class StartGame : Form
    {
        // Using a local variabale to set size
        private int _gameSize; 

        public StartGame()
        {
            InitializeComponent();
        }
               
     
        /// <summary>
        /// activing easy game modus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayEasy_Click(object sender, EventArgs e)
        {
            ////hides the current screen
            //this.Hide();

            //setting gameSize to 10 (game will be 10 tiles by 10 tiles)
            _gameSize = 8;

            // Makes the new gamewindow
            Game gameWindow = new Game(_gameSize);
        }

        /// <summary>
        /// activing medium game modus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayMedium_Click(object sender, EventArgs e)
        {
            //setting gameSize to 12 (game will be 12 tiles by 12 tiles)
            _gameSize = 10;

            // Makes the new gamewindow
            Game gameWindow = new Game(_gameSize);
        }

        /// <summary>
        /// activing hard game modus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayHard_Click(object sender, EventArgs e)
        {
            //setting gameSize to 16 (game will be 16 tiles by 16 tiles)
            _gameSize = 12;

            // Makes the new gamewindow
            Game gameWindow = new Game(_gameSize);
        }
    }
}
