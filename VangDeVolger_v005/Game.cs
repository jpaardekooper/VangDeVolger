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

        Timer gameTimer = new Timer();

        public Game()
        {
            InitializeComponent();


            gameTimer.Interval = 20;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

        }

        private void Game_Load(object sender, EventArgs e)
        {
            label2.Text = GameSetup.MyTextBoxValue;

            GameBoard loadLevelTiles = new GameBoard(this);

       //      Hero player = new Hero(this);
            
            for (int i =0;i< 144; i++)
            {
                Wall loadSprites = new Wall(this);
            }

            // Sprite loadSprites = new Sprite();
       //     GameBoard.GameBoardBoxes[0, 0] = new Hero();

            Console.WriteLine(GameBoard.GameBoardBoxes[0, 0].Name + "test");
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }
     
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {          
            Input.ChangeState(e.KeyCode, false);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check for Game Over
           
                if (Input.KeyPressed(Keys.Right))
                {
                Console.Write("right was pressed");
                Settings.direction = Direction.Right;
                    MovePlayer();
                }

                else if (Input.KeyPressed(Keys.Left))
                {
                    Settings.direction = Direction.Left;
                    MovePlayer();
                }

                else if (Input.KeyPressed(Keys.Up))
                {
                    Settings.direction = Direction.Up;
                    MovePlayer();
                }

                else if (Input.KeyPressed(Keys.Down))
                {
                    Settings.direction = Direction.Down;
                    MovePlayer();
                }              
           
            Invalidate();
        }

        private void MovePlayer()
        {
            switch (Settings.direction)
            {
                case Direction.Right:
                   
                    break;
                case Direction.Left:
                    Console.Write("left was pressed");
                    break;
                case Direction.Up:
                    Console.Write("up was pressed");
                    break;
                case Direction.Down:
                    Console.Write("down was pressed");
                    break;
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                   
                       
                    
                }
            }
           
           
        }
    }
}
