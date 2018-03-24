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

        private bool _gameOver;
        private bool _playerInput; // creating a public string called direction
        private Random _randomMovement = new Random();
      //  public List<PictureBox> AllPictureBoxesOnTheField = new List<PictureBox>();


        public GenerateLevel Generatelevel = new GenerateLevel();

        //PictureBox player;

        public Form2()
        {
            InitializeComponent();
            lblPause.Visible = false;
            resume.Visible = false;

            label2.Text = Form1.MyTextBoxValue;

            MapName = label2.Text.ToString();

            //use private function _startGame to start the game
            _startGame();
        }

        private void _startGame()
        {
            Generatelevel.Name = MapName;
            //giving the class GenerateLevel the level modus { easy , hard , crazy }
            Generatelevel.ReadMyTextLevelFile(this, MapName);
            _loadsprites();

        }
        private void _loadsprites()
        {
            spriteHero.CreateHeroInstance(this); //run the function CreateHeroInstance from the Hero.cs class
            spriteEnemy.CreateEnemyInstance(this); //run the function CreateEnemyInstance from the Enemy.cs class
        }

        private void GameEngine(object sender, EventArgs e)
        {
            if (!_gameOver)
            {
                foreach (PictureBox x in Controls.OfType<PictureBox>())
                {
                    //we can determine if they hit eachother
                    foreach (PictureBox j in Controls.OfType<PictureBox>())
                    {
                        //walll interaction
                        if ((j.Tag.Equals("player")) && (x.Tag.Equals("box")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width && spriteHero.HeroDirection == SpriteDirection.Left)
                            {
                                j.Left += spriteHero._SpriteSpeed;
                                //box can't go out of the screen from left side
                                if (x.Left > 0)
                                {
                                    x.Left -= 40;
                                    x.BringToFront();
                                }
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width && spriteHero.HeroDirection == SpriteDirection.Right)
                            {
                                j.Left -= spriteHero._SpriteSpeed;
                                //box can't go out of the screen from right side
                                if (x.Left < (12 * 40 - x.Width))
                                {
                                    x.Left += 40;
                                    x.BringToFront();
                                }
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top && spriteHero.HeroDirection == SpriteDirection.Down)
                            {

                                j.Top -= spriteHero._SpriteSpeed;
                                //box can't go out of the screen from bottom side
                                if (x.Top < (12 * 40 + x.Height))
                                {
                                    x.Top += 40;
                                    x.BringToFront();
                                }
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top && spriteHero.HeroDirection == SpriteDirection.Up)
                            {
                                j.Top += spriteHero._SpriteSpeed;
                                //box can't go out of the screen from top side
                                if (x.Top > 100)
                                {
                                    x.Top -= 40;
                                    x.BringToFront();
                                }
                            }
                        }

                        //walll interaction
                        if ((j.Tag.Equals("player")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Left)
                            {
                                //   j.Left += spriteHero._SpriteSpeed;

                                spriteHero._SpriteSpeed = 0;
                                j.Left = x.Left + j.Height;
                            }
                            else
                            {
                                spriteHero._SpriteSpeed = 10;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Right)
                            {
                                //   j.Left -= spriteHero._SpriteSpeed;
                                spriteHero._SpriteSpeed = 0;
                                j.Left = x.Left - j.Height;
                            }
                            else
                            {
                                spriteHero._SpriteSpeed = 10;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Down)
                            {
                                // j.Top -= spriteHero._SpriteSpeed;
                                spriteHero._SpriteSpeed = 0;
                                j.Top = x.Top - j.Height;
                            }
                            else
                            {
                                spriteHero._SpriteSpeed = 10;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Up)
                            {
                                //j.Top += spriteHero._SpriteSpeed;
                                spriteHero._SpriteSpeed = 0;
                                j.Top = x.Top + j.Height;
                            }
                            else
                            {
                                spriteHero._SpriteSpeed = 10;
                            }
                        }

                        if ((j.Tag.Equals("box")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Left)
                            {
                                j.Left = x.Left + j.Height;
                            }

                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Right)
                            {
                                j.Left = x.Left - j.Height;
                            }

                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Down)
                            {
                                j.Top = x.Top - j.Height;
                            }

                            if (j.Bounds.IntersectsWith(x.Bounds) && spriteHero.HeroDirection == SpriteDirection.Up)
                            {
                                j.Top = x.Top + j.Height;
                            }
                        }





                        //Enemy and wall collision






                        //}

                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
                            {
                                j.Left += spriteHero._SpriteSpeed;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
                            {
                                j.Left -= spriteHero._SpriteSpeed;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
                            {
                                j.Top -= spriteHero._SpriteSpeed;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
                            {
                                j.Top += spriteHero._SpriteSpeed;
                            }

                        }

                        //noy pushable boxes
                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("box")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
                            {
                                j.Left += spriteHero._SpriteSpeed;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
                            {
                                j.Left -= spriteHero._SpriteSpeed;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
                            {
                                j.Top -= spriteHero._SpriteSpeed;
                            }
                            if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
                            {
                                j.Top += spriteHero._SpriteSpeed;
                            }
                        }

                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("player")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Left < x.Left )
                            {
                                j.Left += spriteEnemy._SpriteSpeed;
                            }
                            else if (j.Left > x.Left)
                            {
                                j.Left -= spriteEnemy._SpriteSpeed;
                            }
                            else if (j.Top < x.Top )
                            {
                                j.Top += spriteEnemy._SpriteSpeed;
                            }
                            else if (j.Top > x.Top )
                            {
                                j.Top -= spriteEnemy._SpriteSpeed;
                            }

                        }
                    


                    
                    if (1+1 == 5)
                        {
                            Console.WriteLine("opgesloten - 40");
                            _gameOver = false;
                        }

                        //if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("player")))
                        //{
                        //    //checking if the X loop is touching the J loop
                        //    //moving to the left of the wall
                        //    if (j.Left < x.Left + (x.Width / 3))
                        //    {
                        //        spriteEnemy.EnemyDirection = SpriteDirection.Left;
                        //        j.Left += spriteEnemy._SpriteSpeed;
                        //    }
                        //    if (j.Left > x.Left - (x.Width / 3))
                        //    {
                        //        spriteEnemy.EnemyDirection = SpriteDirection.Right;
                        //        j.Left -= spriteEnemy._SpriteSpeed;
                        //    }
                        //    if (j.Top < x.Top + (x.Height / 3))
                        //    {
                        //        spriteEnemy.EnemyDirection = SpriteDirection.Up;
                        //        j.Top += spriteEnemy._SpriteSpeed;
                        //    }
                        //    if (j.Top > x.Top - (x.Width / 3))
                        //    {
                        //        spriteEnemy.EnemyDirection = SpriteDirection.Down;
                        //        j.Top -= spriteEnemy._SpriteSpeed;
                        //    }

                        //}



                    }
                }
            }
            else
            {
                timer1.Stop();
                Console.WriteLine("GAME OVER");
            }
            // Console.WriteLine(spriteEnemy.EnemyDirection);

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_playerInput)
            {
                //    spriteHero.PlayerInput = true;
                //if we pressed left arrow
                if (e.KeyCode == Keys.Left)
                {


                    spriteHero.HeroDirection = SpriteDirection.Left;
                    spriteHero.Move_Tick();
                }
                //if we pressed left arrow
                if (e.KeyCode == Keys.Right)
                {

                    spriteHero.HeroDirection = SpriteDirection.Right;
                    spriteHero.Move_Tick();
                }
                if (e.KeyCode == Keys.Down)
                {


                    spriteHero.HeroDirection = SpriteDirection.Down;
                    spriteHero.Move_Tick();
                }
                if (e.KeyCode == Keys.Up)
                {


                    spriteHero.HeroDirection = SpriteDirection.Up;
                    spriteHero.Move_Tick();
                }

                if (e.KeyCode == Keys.P)
                {
                    _playerInput = true;
                    lblPause.Visible = true;
                    pause.Visible = false;
                    resume.Visible = true;
                    timer1.Stop();
                }

              
            }
           
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {          

            if (e.KeyCode == Keys.R)
            {
                _playerInput = false;
                lblPause.Visible = false;
                pause.Visible = true;
                resume.Visible = false;
                timer1.Start();
            }
        }

    }
}
