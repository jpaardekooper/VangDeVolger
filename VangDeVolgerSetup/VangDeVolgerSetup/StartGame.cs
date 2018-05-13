/*
 * This is the StartScreen of the game Vang de Volger.
 * The user has three options: easy, medium and hard. Clicking on one of these will generate a new window of Game.cs and load the game
 * easy is 8 by 8 = 64
 * medium is 10 by 10 = 100
 * hard is 12 by 12 = 144;

 * This program was created by:
 * Jasper Paardekooper 17039886
 * Roos Hoogervorst 17036895
 * 
 */

using System;
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

            //setting gameSize to 8 (game will be 8 tiles by 8 tiles)
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
            //setting gameSize to 10 (game will be 10 tiles by 10 tiles)
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
            //setting gameSize to 12 (game will be 12 tiles by 12 tiles)
            _gameSize = 12;

            // Makes the new gamewindow
            Game gameWindow = new Game(_gameSize);
        }
    }
}
