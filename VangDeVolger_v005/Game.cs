using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{
    public partial class Game : Form
    {
        

        public Game()
        {
            InitializeComponent();
          
        }

        private void Game_Load(object sender, EventArgs e)
        {
            label2.Text = GameSetup.MyTextBoxValue;

            GameBoard loadLevelTiles = new GameBoard(this);

             Hero loadHero = new Hero(this);
            
            for (int i =0;i< 144; i++)
            {
                Wall loadSprites = new Wall(this);
            }

           // Sprite loadSprites = new Sprite();


          
        }
    }
}
