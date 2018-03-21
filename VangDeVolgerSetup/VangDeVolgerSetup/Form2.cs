using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public partial class Form2 : Form
    {
        Hero player = new Hero();
        public int levelmodus;
        public string MapName;
        private bool _spaceDown;

        PictureBox qwe;

        public List<PictureBox> AllPictureBoxesOnTheField = new List<PictureBox>();

       
        public GenerateLevel Generatelevel = new GenerateLevel();

        public Form2()
        {
            InitializeComponent();
            
            label2.Text = Form1.MyTextBoxValue;

            MapName = label2.Text.ToString();

            //use private function _startGame to start the game
            _startGame();
            _initializePictureList();
            
        }

        private void _startGame()
        {
            Generatelevel.Name = MapName;

      //      Console.WriteLine(Generatelevel.Name);

            Generatelevel.ReadMyTextLevelFile(this, MapName);
            _loadsprites();

        }
        private void _loadsprites()
        {                    
            player.CreateHeroInstance(this); //run the function mkHero from the Hero.cs class
        }

        private void _initializePictureList()
        {
            foreach (PictureBox x in Controls.OfType<PictureBox>())
            {
                AllPictureBoxesOnTheField.Add(x);
            }
            foreach(PictureBox s in AllPictureBoxesOnTheField)
            {
                Console.WriteLine(s.Name + s.Tag);
                if (s.Tag.Equals("player"))
                {
                    Console.WriteLine("WTF");
                }
            }
        }

        private void GameEngine(object sender, EventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            player.PlayerInput = true;

            //if we pressed left arrow
            if (e.KeyCode == Keys.Left)
            {
                player.HeroDirection = HeroDirection.Left;
                player.Move_Tick();
            }
            //if we pressed left arrow
            else if (e.KeyCode == Keys.Right)
            {
                player.HeroDirection = HeroDirection.Right;
                player.Move_Tick();
            }
            else if (e.KeyCode == Keys.Down)
            {
                player.HeroDirection = HeroDirection.Down;
                player.Move_Tick();
            }
            else if (e.KeyCode == Keys.Up)
            {
                player.HeroDirection = HeroDirection.Up;
                player.Move_Tick();
            }


            else if (e.KeyCode == Keys.Space) //if the pushing is higher than 0 we continue
            {
                _spaceDown = true;

            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            player.PlayerInput = false;
            _spaceDown = false;
        }
    }
}
