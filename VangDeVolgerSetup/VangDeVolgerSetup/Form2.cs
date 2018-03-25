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

                ///
                /// hero health bar
                /// 
                if (spriteHero.HeroHealth > 0) //if health is higher than 1
                {
                    playerHealthBar.Value = Convert.ToInt32(spriteHero.HeroHealth); //assigning progress bar to player health *note need to change name later
                }
                else
                {
                    spriteHero._spriteHero.Image = Properties.Resources.death_5;
                    spriteHero._spriteHero.BringToFront();
                    Console.WriteLine("verloren");
                    timer1.Stop(); //stop the timer
                    _gameOver = true; // boolgame over is true
                }


                if (spriteEnemy.EnemyHealth < 60)
                {
                    playerHealthBar.ForeColor = Color.Orange; //when we enter danger zone of the health progress bar is changed to orange
                }

                if (spriteEnemy.EnemyHealth < 20)
                {
                    playerHealthBar.ForeColor = Color.Red; //when we enter danger zone of the health progress bar is changed to red
                }

                ///
                /// enemy health bar
                /// 
                if (spriteEnemy.EnemyHealth > 1) //if health is higher than 1
                {
                    enemyHealthBar.Value = Convert.ToInt32(spriteEnemy.EnemyHealth); //assigning progress bar to player health *note need to change name later
                }
                else
                {
                    Console.WriteLine("gewonnen");

                    timer1.Stop(); //stop the timer
                    _gameOver = true; // boolgame over is true
                }

                if (spriteEnemy.EnemyHealth < 60)
                {
                    playerHealthBar.ForeColor = Color.Orange; //when we enter danger zone of the health progress bar is changed to orange
                }

                if (spriteEnemy.EnemyHealth < 30)
                {
                    playerHealthBar.ForeColor = Color.Red; //when we enter danger zone of the health progress bar is changed to red
                }

                //giving yellow errors on the screen
                if (_playerInput)
                {
                    spriteHero.Move_Tick();
                }



                //   Console.WriteLine(_playerInput);
                foreach (PictureBox x in Controls.OfType<PictureBox>())
                {
                    if (x.Tag.Equals("enemy"))
                    {
                        ////stop hero from moving against walls of canvas
                        ////moving to left
                        if (x.Left < 0)
                        {
                            x.Left += spriteEnemy._SpriteSpeed;
                        }
                        //moving to Right
                        if (x.Left > (12 * 40 - x.Width))
                        {
                            x.Left -= spriteEnemy._SpriteSpeed;
                        }
                        //moving to top
                        if (x.Top < 100)
                        {
                            x.Top += spriteEnemy._SpriteSpeed;
                        }
                        //moving to bottom
                        if (x.Top > (12 * 40) + 60)
                        {
                            x.Top -= spriteEnemy._SpriteSpeed;
                        }
                    }

                    //we can determine if they hit eachother
                    foreach (PictureBox j in Controls.OfType<PictureBox>())
                    {
                        //walll interaction
                        if ((j.Tag.Equals("player")) && (x.Tag.Equals("box")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                if (j.Left < x.Left + x.Width && spriteHero.HeroDirection == SpriteDirection.Left)
                                {
                                    j.Left += spriteHero._SpriteSpeed;
                                    //box can't go out of the screen from left side
                                    if (x.Left > 0)
                                    {
                                        x.Left -= 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Left > x.Left - x.Width && spriteHero.HeroDirection == SpriteDirection.Right)
                                {
                                    j.Left -= spriteHero._SpriteSpeed;
                                    //box can't go out of the screen from right side
                                    if (x.Left < (12 * 40 - x.Width))
                                    {
                                        x.Left += 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Top < x.Top && spriteHero.HeroDirection == SpriteDirection.Down)
                                {

                                    j.Top -= spriteHero._SpriteSpeed;
                                    //box can't go out of the screen from bottom side
                                    if (x.Top < (12 * 40 + x.Height))
                                    {
                                        x.Top += 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Top > x.Top && spriteHero.HeroDirection == SpriteDirection.Up)
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
                        }



                        //walll interaction
                        else if ((j.Tag.Equals("player")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                if (j.Left < x.Left + x.Width && spriteHero.HeroDirection == SpriteDirection.Left)
                                {
                                    j.Left += spriteHero._SpriteSpeed;
                                    //box can't go out of the screen from left side                              
                                }
                                else if (j.Left > x.Left - x.Width && spriteHero.HeroDirection == SpriteDirection.Right)
                                {
                                    j.Left -= spriteHero._SpriteSpeed;
                                }
                                else if (j.Top < x.Top && spriteHero.HeroDirection == SpriteDirection.Down)
                                {
                                    j.Top -= spriteHero._SpriteSpeed;
                                }
                                else if (j.Top > x.Top && spriteHero.HeroDirection == SpriteDirection.Up)
                                {
                                    j.Top += spriteHero._SpriteSpeed;
                                }
                            }


                        }

                        else if ((j.Tag.Equals("box")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                if (spriteHero.HeroDirection == SpriteDirection.Left)
                                {
                                    j.Left = x.Left + j.Height;
                                }
                                else if (spriteHero.HeroDirection == SpriteDirection.Right)
                                {
                                    j.Left = x.Left - j.Height;
                                }
                                else if (spriteHero.HeroDirection == SpriteDirection.Down)
                                {
                                    j.Top = x.Top - j.Height;
                                }

                                else if (spriteHero.HeroDirection == SpriteDirection.Up)
                                {
                                    j.Top = x.Top + j.Height;
                                }
                            }
                        }

                        //Enemy and wall collision
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

                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("box")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                spriteEnemy.EnemyHealth -= 1;

                                if (j.Left < x.Left)
                                {
                                    j.Left -= spriteEnemy._SpriteSpeed;
                                }
                                if (j.Left > x.Left)
                                {
                                    j.Left += spriteEnemy._SpriteSpeed;
                                }
                                if (j.Top < x.Top)
                                {
                                    j.Top -= spriteEnemy._SpriteSpeed;
                                }
                                if (j.Top > x.Top)
                                {
                                    j.Top += spriteEnemy._SpriteSpeed;
                                }
                            }
                        }

                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("player")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                spriteHero.HeroHealth -= 1;
                                if (spriteEnemy.EnemyHealth < 95)
                                {
                                    spriteEnemy.EnemyHealth += 5;
                                }

                            }

                            if (j.Left < x.Left - 30)
                            {
                                j.Left += spriteEnemy._SpriteSpeed;
                                spriteEnemy._spriteEnemy.Image = Properties.Resources.enemyRight;
                            }
                            else if (j.Left > x.Left + 30)
                            {
                                j.Left -= spriteEnemy._SpriteSpeed;
                                spriteEnemy._spriteEnemy.Image = Properties.Resources.enemyLeft;
                            }
                            else if (j.Top < x.Top)
                            {
                                j.Top += spriteEnemy._SpriteSpeed;
                            }
                            else if (j.Top > x.Top)
                            {
                                j.Top -= spriteEnemy._SpriteSpeed;
                            }
                        }
                    }
                }
            }
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
                    _playerInput = true;
                }
                //if we pressed left arrow
                if (e.KeyCode == Keys.Right)
                {

                    spriteHero.HeroDirection = SpriteDirection.Right;
                    _playerInput = true;
                }
                if (e.KeyCode == Keys.Down)
                {


                    spriteHero.HeroDirection = SpriteDirection.Down;
                    _playerInput = true;
                }
                if (e.KeyCode == Keys.Up)
                {


                    spriteHero.HeroDirection = SpriteDirection.Up;
                    _playerInput = true;
                }

                if (e.KeyCode == Keys.P)
                {
                    foreach (Control c in Controls)
                    {
                        c.Visible = false;
                    }
                    _playerInput = false;
                    lblPause.Visible = true;
                    pause.Visible = false;
                    resume.Visible = true;
                    timer1.Stop();

                   
                }

                if (e.KeyCode == Keys.N)
                {
                    _resetMap();
                }

            }

        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            _playerInput = false;

            if (e.KeyCode == Keys.R)
            {
                foreach (Control c in Controls)
                {
                    c.Visible = true;
                }

                _playerInput = false;
                lblPause.Visible = false;
                pause.Visible = true;
                resume.Visible = false;
                timer1.Start();
            }
        }

        private void _resetMap()
        {
            for (int i = 0; i < 10; i++)
            {
                //foreach (Button b in Controls.OfType<Button>())
                //{
                //    b.Dispose();
                //}

                //foreach (PictureBox x in Controls.OfType<PictureBox>())
                //{
                //    x.Dispose();
                //}

                //foreach (Control c in Controls)
                //{
                //    c.Dispose();
                //}    
                if(i >= 9)
                {
                   
                }
            }
            Form2 NewForm = new Form2();
            NewForm.Show();
            this.Dispose(false);
        }       
    }
}
