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
        Hero spriteHero = new Hero();
        Enemy spriteEnemy = new Enemy();

        public int levelmodus;
        public string MapName;
        //need to get the current setup game with
        // public int GameWidth;
        private bool _spaceDown;

        public List<PictureBox> AllPictureBoxesOnTheField = new List<PictureBox>();


        public GenerateLevel Generatelevel = new GenerateLevel();

        PictureBox player;

        public Form2()
        {
            InitializeComponent();

            label2.Text = Form1.MyTextBoxValue;

            MapName = label2.Text.ToString();

            //use private function _startGame to start the game
            _startGame();
            _initializePictureList();

            // GameWidth = AllPictureBoxesOnTheField.Count  40;
            //   Console.WriteLine(GameWidth);


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
            spriteHero.CreateHeroInstance(this); //run the function CreateHeroInstance from the Hero.cs class
            spriteEnemy.CreateEnemyInstance(this); //run the function CreateEnemyInstance from the Enemy.cs class
        }

        private void _initializePictureList()
        {
            foreach (PictureBox x in Controls.OfType<PictureBox>())
            {
                AllPictureBoxesOnTheField.Add(x);
            }
            for (int i = 0; i < AllPictureBoxesOnTheField.Count; i++)
            {
                if (AllPictureBoxesOnTheField[i].Tag.Equals("player"))
                {
                    player = AllPictureBoxesOnTheField[i];
                    Console.WriteLine(player.Name);
                }
                //if (AllPictureBoxesOnTheField[i].Tag.Equals("enemy"))
                //{
                //    enemy = AllPictureBoxesOnTheField[i];
                //    Console.WriteLine(enemy.Name);
                //}
            }
            //foreach (PictureBox w in AllPictureBoxesOnTheField)
            //{
            //    //    Console.WriteLine(s.Name + s.Tag);
            //    if (w.Tag.Equals("wall"))
            //    {
            //        wall = w;
            //        Console.WriteLine(wall.Name + "name");

            //    }            

            //}

            //foreach (PictureBox b in AllPictureBoxesOnTheField)
            //{
            //    if (b.Tag.Equals("box"))
            //    {
            //        box = b;
            //        Console.WriteLine(box.Name);
            //    }
            //}
        }

        private void GameEngine(object sender, EventArgs e)
        {
        //    foreach (PictureBox x in AllPictureBoxesOnTheField)
        //    {
        //        if (x.Tag.Equals("box"))
        //        {
        //            if (player.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width && spriteHero.HeroDirection == HeroDirection.Left)
        //            {
        //                x.Left += 40;
        //            }
        //        }
        //        //second for loop                
        //        //we can determine if they hit eachother
        //        foreach (PictureBox j in AllPictureBoxesOnTheField)
        //        {
        //            //walll interaction
        //            if ((j.Tag.Equals("player")) && (x.Tag.Equals("box")))
        //            {
        //                //checking if the X loop is touching the J loop
        //                //moving to the left of the wall
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width && spriteHero.HeroDirection == HeroDirection.Left)
        //                {
        //                    j.Left += spriteHero._SpriteSpeed;
        //                    if (_spaceDown == true)
        //                    {
        //                        x.Left -= 40;
        //                        x.BringToFront();
        //                    }
        //                }
        //                else if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width && spriteHero.HeroDirection == HeroDirection.Right)
        //                {
        //                    j.Left -= spriteHero._SpriteSpeed;
        //                    if (_spaceDown == true)
        //                    {
        //                        x.Left += 40;
        //                        x.BringToFront();
        //                    }
        //                }
        //                else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top && spriteHero.HeroDirection == HeroDirection.Down)
        //                {
        //                    j.Top -= spriteHero._SpriteSpeed;
        //                    if (_spaceDown == true)
        //                    {
        //                        x.Top += 40;
        //                        x.BringToFront();
        //                    }
        //                }
        //                else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top && spriteHero.HeroDirection == HeroDirection.Up)
        //                {
        //                    j.Top += spriteHero._SpriteSpeed;
        //                    if (_spaceDown == true)
        //                    {
        //                        x.Top -= 40;
        //                        x.BringToFront();
        //                    }
        //                }
        //            }

        //            //walll interaction
        //            if ((j.Tag.Equals("player")) && (x.Tag.Equals("wall")))
        //            {
        //                //checking if the X loop is touching the J loop
        //                //moving to the left of the wall
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width && spriteHero.HeroDirection == HeroDirection.Left)
        //                {
        //                    j.Left += spriteHero._SpriteSpeed;

        //                }
        //                else if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width && spriteHero.HeroDirection == HeroDirection.Right)
        //                {
        //                    j.Left -= spriteHero._SpriteSpeed;

        //                }
        //                else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top && spriteHero.HeroDirection == HeroDirection.Down)
        //                {
        //                    j.Top -= spriteHero._SpriteSpeed;

        //                }
        //                else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top && spriteHero.HeroDirection == HeroDirection.Up)
        //                {
        //                    j.Top += spriteHero._SpriteSpeed;

        //                }
        //            }

        //            //Enemy and wall collision

        //            if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("wall")))
        //            {
        //                //checking if the X loop is touching the J loop
        //                //moving to the left of the wall
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
        //                {
        //                    j.Left += spriteHero._SpriteSpeed;
        //                }
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
        //                {
        //                    j.Left -= spriteHero._SpriteSpeed;
        //                }
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
        //                {
        //                    j.Top -= spriteHero._SpriteSpeed;
        //                }
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
        //                {
        //                    j.Top += spriteHero._SpriteSpeed;
        //                }

        //            }

        //            //noy pushable boxes
        //            if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("box")))
        //            {
        //                //checking if the X loop is touching the J loop
        //                //moving to the left of the wall
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
        //                {
        //                    j.Left += spriteHero._SpriteSpeed;
        //                }
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
        //                {
        //                    j.Left -= spriteHero._SpriteSpeed;
        //                }
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
        //                {
        //                    j.Top -= spriteHero._SpriteSpeed;
        //                }
        //                if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
        //                {
        //                    j.Top += spriteHero._SpriteSpeed;
        //                }
        //            }

        //            if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("player")))
        //            {
        //                //checking if the X loop is touching the J loop
        //                //moving to the left of the wall
        //                if (j.Left < x.Left + (x.Width / 3))
        //                {
        //                    j.Left += spriteEnemy._SpriteSpeed;
        //                }
        //                if (j.Left > x.Left - (x.Width / 3))
        //                {
        //                    j.Left -= spriteEnemy._SpriteSpeed;
        //                }
        //                if (j.Top < x.Top + (x.Height / 3))
        //                {
        //                    j.Top += spriteEnemy._SpriteSpeed;
        //                }
        //                if (j.Top > x.Top - (x.Width / 3))
        //                {
        //                    j.Top -= spriteEnemy._SpriteSpeed;
        //                }

        //            }

                 

        //        }
        //    }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            spriteHero.PlayerInput = true;

            //if we pressed left arrow
            if (e.KeyCode == Keys.Left)
            {
                spriteHero.HeroDirection = HeroDirection.Left;
                spriteHero.Move_Tick();
            }
            //if we pressed left arrow
            else if (e.KeyCode == Keys.Right)
            {
                spriteHero.HeroDirection = HeroDirection.Right;
                spriteHero.Move_Tick();
            }
            else if (e.KeyCode == Keys.Down)
            {
                spriteHero.HeroDirection = HeroDirection.Down;
                spriteHero.Move_Tick();
            }
            else if (e.KeyCode == Keys.Up)
            {
                spriteHero.HeroDirection = HeroDirection.Up;
                spriteHero.Move_Tick();
            }


            else if (e.KeyCode == Keys.Space) //if the pushing is higher than 0 we continue
            {
                _spaceDown = true;
                spriteHero.Move_Tick();

            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            spriteHero.PlayerInput = false;
            _spaceDown = false;
        }
    }
}
