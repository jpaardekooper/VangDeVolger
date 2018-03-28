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
    public partial class Game : Form
    {
        private Hero _callHeroClass = new Hero(); //create new hero class
        private Enemy _callEnemyClass = new Enemy(); //create new enemy class
        private GenerateLevel _callGeneratelevel = new GenerateLevel(); //create new generate level class
     
        public string GetMapName; //able to detect what game modus we are playing

        private bool _gameOver = false;
        private bool _gamePaused = false;
        private bool _playerInput = false; // creating a public string called direction

      
        public Game()
        {
            InitializeComponent();
            lblPause.Visible = false;
            resume.Visible = false;
            lblGameOver.Visible = false;
            ///
            ///Able to get de level name of the screen to generate the levelwith
            ///
            label2.Text = StartScreen.MyTextBoxValue;
            GetMapName = label2.Text.ToString();
            //use private function _startGame to start the game
            _startGame(); // call startGamefunction on line 46   
        }

        private void _startGame()
        {
            _callGeneratelevel.Name = GetMapName;
            ///
            /// giving the class _callGenerateLevel the level modus [ easy , hard , crazy ]
            /// 
            _callGeneratelevel.ReadMyTextLevelFile(this, GetMapName);
            _loadsprites(); //call loadsprites function on line 51
        }

        private void _loadsprites()
        {
            _callHeroClass.CreateHeroInstance(this); //run the function CreateHeroInstance from the Hero.cs class
            _callEnemyClass.CreateEnemyInstance(this); //run the function CreateEnemyInstance from the Enemy.cs class
        }

        //this is a game engine timer this will check the interaction of each object 
        private void GameEngine(object sender, EventArgs e)
        {
            if (!_gameOver)
            {
                //   Console.WriteLine(_playerInput);
                foreach (PictureBox x in Controls.OfType<PictureBox>())
                {
                    //we can determine if they hit eachother
                    foreach (PictureBox j in Controls.OfType<PictureBox>())
                    {
                        //player with walll interaction
                        if ((j.Tag.Equals("player")) && (x.Tag.Equals("box")))
                        {                           
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                _callEnemyClass.CheckForOutOfBounds();

                                if (j.Left <= x.Right && _callHeroClass.HeroDirection == SpriteDirection.Left)
                                {
                                    Console.WriteLine("touching");
                                    j.Left += _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from left side
                                    if (x.Left > 0)
                                    {
                                        x.Left -= 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Right >= x.Left && _callHeroClass.HeroDirection == SpriteDirection.Right)
                                {                                    
                                    j.Left -= _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from right side
                                    if (x.Left < (12 * 40 - x.Width))
                                    {
                                        x.Left += 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Top < x.Top + x.Height && _callHeroClass.HeroDirection == SpriteDirection.Down)
                                {

                                    j.Top -= _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from bottom side
                                    if (x.Top < (12 * 40 + x.Height))
                                    {
                                        x.Top += 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Top > x.Top - x.Height && _callHeroClass.HeroDirection == SpriteDirection.Up)
                                {
                                    j.Top += _callHeroClass._SpriteSpeed;
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
                                if (j.Left < x.Left + x.Width && _callHeroClass.HeroDirection == SpriteDirection.Left)
                                {
                                    j.Left += _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from left side                              
                                }
                                else if (j.Left > x.Left - x.Width && _callHeroClass.HeroDirection == SpriteDirection.Right)
                                {
                                    j.Left -= _callHeroClass._SpriteSpeed;
                                }
                                else if (j.Top < x.Top + x.Height && _callHeroClass.HeroDirection == SpriteDirection.Down)
                                {

                                    j.Top -= _callHeroClass._SpriteSpeed;
                                }
                                else if (j.Top > x.Top - x.Height && _callHeroClass.HeroDirection == SpriteDirection.Up)
                                {
                                    j.Top += _callHeroClass._SpriteSpeed;
                                }
                            }

                        }

                        else if ((j.Tag.Equals("box")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                if (_callHeroClass.HeroDirection == SpriteDirection.Left)
                                {
                                    j.Left = x.Left + j.Height;
                                }
                                else if (_callHeroClass.HeroDirection == SpriteDirection.Right)
                                {
                                    j.Left = x.Left - j.Height;
                                }
                                else if (_callHeroClass.HeroDirection == SpriteDirection.Down)
                                {
                                    j.Top = x.Top - j.Height;
                                }

                                else if (_callHeroClass.HeroDirection == SpriteDirection.Up)
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
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                if (j.Left <= x.Right + x.Width)
                                {
                                    j.Left += _callHeroClass._SpriteSpeed;
                                }
                                if (j.Right >= x.Left - x.Width)
                                {
                                    j.Left -= _callHeroClass._SpriteSpeed;
                                }
                                if (j.Top  < x.Height)
                                {
                                    j.Top -= _callHeroClass._SpriteSpeed;
                                }
                                if (j.Top  > x.Top)
                                {
                                    j.Top += _callHeroClass._SpriteSpeed;
                                }
                            }

                        }

                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("box")))
                        {

                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                CheckEnemyHealth();

                                _callEnemyClass.EnemyHealth -= 1;

                                if (j.Left < x.Left)
                                {
                                    j.Left -= _callEnemyClass._SpriteSpeed;
                                }
                                if (j.Left > x.Left)
                                {
                                    j.Left += _callEnemyClass._SpriteSpeed;
                                }
                                if (j.Top < x.Top)
                                {
                                    j.Top -= _callEnemyClass._SpriteSpeed;
                                }
                                if (j.Top > x.Top)
                                {
                                    j.Top += _callEnemyClass._SpriteSpeed;
                                }
                            }
                        }

                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("player")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                CheckHeroHealth();
                                _callHeroClass.HeroHealth -= 1;
                                if (_callEnemyClass.EnemyHealth < 95)
                                {
                                    _callEnemyClass.EnemyHealth += 5;
                                }

                            }

                            if (j.Left < x.Left - 30)
                            {
                                j.Left += _callEnemyClass._SpriteSpeed;
                                _callEnemyClass._spriteEnemy.Image = Properties.Resources.enemyRight;
                            }
                            else if (j.Left > x.Left + 30)
                            {
                                j.Left -= _callEnemyClass._SpriteSpeed;
                                _callEnemyClass._spriteEnemy.Image = Properties.Resources.enemyLeft;
                            }
                            else if (j.Top < x.Top)
                            {
                                j.Top += _callEnemyClass._SpriteSpeed;
                            }
                            else if (j.Top > x.Top)
                            {
                                j.Top -= _callEnemyClass._SpriteSpeed;
                            }
                        }
                    }
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (_gameOver) return; // if game over is true then do nothing
            if (_gamePaused) return; // if gamepaused is true then do nothing

            switch (e.KeyCode)
            {
                case Keys.Left:
                    _playerInput = true;
                    _callHeroClass.HeroDirection = SpriteDirection.Left;
                    break;
                case Keys.Right:
                    _playerInput = true;
                    _callHeroClass.HeroDirection = SpriteDirection.Right;
                    break;
                case Keys.Down:
                    _playerInput = true;
                    _callHeroClass.HeroDirection = SpriteDirection.Down;
                    break;
                case Keys.Up:
                    _playerInput = true;
                    _callHeroClass.HeroDirection = SpriteDirection.Up;
                    break;

            }
            if (_playerInput && _gamePaused == false || _gameOver == false) //if it's true then we call HeroMove function
            {
                _callHeroClass.Move_Tick(_callHeroClass.HeroDirection);
            }

            //pausing the game
            if (e.KeyCode == Keys.P)
            {
                _pauseGame(); //when P is pressed we call pauseGame function on line 328
            }          
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                _resumeGame(); //when R is up again we call resumeGame on line 343
            }

            if (e.KeyCode == Keys.N)
            {
                _resetMap(); //when N is pressed we call resetMap on line 321
            }
        }

        private void _resetMap()
        {
            Game NewForm = new Game();
            NewForm.Show();
            this.Dispose(false);
        }

        private void _pauseGame()
        {
            _gamePaused = true;
            //grabbing all controls and hide them
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

        private void _resumeGame()
        {
            _gamePaused = false;
            //grabbing all controls and hide them
            foreach (Control c in Controls)
            {
                c.Visible = true;
            }
            lblPause.Visible = false;
            pause.Visible = true;
            resume.Visible = false;
            timer1.Start();
        }

        private void _gameIsOver()
        {
            _gameOver = true;
            //grabbing all controls and hide them
            foreach (Control c in Controls)
            {
                c.Visible = false;
            }
            newgame.Visible = true;
            lblGameOver.Visible = true;
            timer1.Stop();
        }

        private void CheckHeroHealth()
        {
            ///
            ///Hero health bar
            ///
            if (_callHeroClass.HeroHealth > 1) //if health is higher than 1
            {
                playerHealthBar.Value = Convert.ToInt32(_callHeroClass.HeroHealth); //assigning progress bar to player health *note need to change name later
            }
            else
            {
                _callHeroClass._spriteHero.Image = Properties.Resources.death_5;
                _callHeroClass._spriteHero.BringToFront();
                Console.WriteLine("verloren");
                _gameIsOver();
            }

            if (_callHeroClass.HeroHealth < 60)
            {
                playerHealthBar.ForeColor = Color.Orange; //when we enter danger zone of the health progress bar is changed to orange
            }

            if (_callHeroClass.HeroHealth < 20)
            {
                playerHealthBar.ForeColor = Color.Red; //when we enter danger zone of the health progress bar is changed to red
            }
        }

        private void CheckEnemyHealth()
        {
            ///
            /// enemy health bar
            /// 
            if (_callEnemyClass.EnemyHealth > 1) //if health is higher than 1
            {
                enemyHealthBar.Value = Convert.ToInt32(_callEnemyClass.EnemyHealth); //assigning progress bar to player health *note need to change name later
            }
            else
            {
                Console.WriteLine("gewonnen");

                _gameIsOver();
            }

            if (_callEnemyClass.EnemyHealth < 60)
            {
                playerHealthBar.ForeColor = Color.Orange; //when we enter danger zone of the health progress bar is changed to orange
            }

            if (_callEnemyClass.EnemyHealth < 30)
            {
                playerHealthBar.ForeColor = Color.Red; //when we enter danger zone of the health progress bar is changed to red
            }
        }
    }
}
