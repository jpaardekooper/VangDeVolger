/*
 * On this form the level will be loaded and displayed
 * There is alot of .visible true and false going on this was mostly used for styling purposes
 * Once this form has recieved the level modus it will load the GenerateLevel.cs with the correct levelmodus.
 * After the level is loaded. 1 hero will be added to the screen and 1 enemy.
 * This Game.cs has the task to determine if there is an collision going. This can be found in GameEngine method.
 * 
 * small tutorial
 * The user wins if the enemy progressbar is 0;
 * the user loses if hes progressbar is 0;
 * 
 * user loses health if enemy touches him
 * enemy loses health if enemy touches a box
 * 
 * user can walk with the arrow keys (up, down, left, right)
 * 
 * once the player wins or loses the game, the game will ask for a name to fill in for the highscore
 */

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public partial class Game : Form
    {
        private Hero _callHeroClass; //create new hero class
        private Enemy _callEnemyClass; //create new enemy class
        private GenerateLevel _callGeneratelevel; //create new generate level class
        private Highscore _callHighscoreClass;
        public string GetMapName; //able to detect what game modus we are playing
        private bool _gameOver;
        private bool _gamePaused;

        public Game()
        {
            InitializeComponent();

            _callHeroClass = new Hero(); //create new hero class
            _callEnemyClass = new Enemy(); //create new enemy class
            _callGeneratelevel = new GenerateLevel(); //create new generate level class
            _callHighscoreClass = new Highscore();
            _gameOver = false;
            _gamePaused = false;

            //some styling for labels to show them later on
            lblPause.Visible = false;
            resume.Visible = false;
            lblGameOver.Visible = false;
            inputPlayerName.Visible = false;
            btnShowScore.Visible = false;
            lblHighscore.Visible = false;
            boxAllHighScores.Visible = false;

            ///Able to get de level name of the screen to generate the levelwith          
            label2.Text = StartScreen.MyTextBoxValue;
            GetMapName = label2.Text.ToString();
            //use private function _startGame to start the game
            _startGame(); // call startGamefunction on line 46   
        }

        private void _startGame()
        {         
            // giving the class _callGenerateLevel the level modus [ easy , hard , crazy ]         
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
                _callHeroClass.CheckForOutOfBounds();

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
                                _updateScore();
                                if (j.Left <= x.Right && _callHeroClass.HeroDirection == Direction.Left)
                                {
                                    j.Left += _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from left side                                  
                                        x.Left -= 40;
                                        x.BringToFront();
                                   
                                }
                                else if (j.Right >= x.Left && _callHeroClass.HeroDirection == Direction.Right)
                                {
                                    j.Left -= _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from right side
                                    if (x.Left < (12 * 40 - x.Width))
                                    {
                                        x.Left += 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Bottom <= x.Bottom && _callHeroClass.HeroDirection == Direction.Down)
                                {

                                    j.Top -= _callHeroClass._SpriteSpeed;
                                    //box can't go out of the screen from bottom side
                                    if (x.Top < (12 * 40 + x.Height))
                                    {
                                        x.Top += 40;
                                        x.BringToFront();
                                    }
                                }
                                else if (j.Bottom >= x.Top && _callHeroClass.HeroDirection == Direction.Up)
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
                                if (j.Left <= x.Right && _callHeroClass.HeroDirection == Direction.Left)
                                {
                                    j.Left += _callHeroClass._SpriteSpeed;
                                }
                                else if (j.Right >= x.Left && _callHeroClass.HeroDirection == Direction.Right)
                                {
                                    j.Left -= _callHeroClass._SpriteSpeed;
                                }
                                else if (j.Bottom <= x.Bottom && _callHeroClass.HeroDirection == Direction.Down)
                                {
                                    j.Top -= _callHeroClass._SpriteSpeed;
                                }
                                else if (j.Bottom >= x.Top && _callHeroClass.HeroDirection == Direction.Up)
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
                                if (j.Left <= x.Right && _callHeroClass.HeroDirection == Direction.Left)
                                {
                                    j.Left += 40;
                                }
                                else if (j.Right >= x.Left && _callHeroClass.HeroDirection == Direction.Right)
                                {
                                    j.Left -= 40;
                                }
                                else if (j.Bottom <= x.Bottom && _callHeroClass.HeroDirection == Direction.Down)
                                {
                                    j.Top -= 40;
                                }
                                else if (j.Bottom >= x.Top && _callHeroClass.HeroDirection == Direction.Up)
                                {
                                    j.Top += 40;

                                }
                            }
                        }

                        //  Enemy and wall collision
                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("wall")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                _updateScore();
                                if (j.Left <= x.Right + x.Width)
                                {
                                    j.Left += _callHeroClass._SpriteSpeed;
                                }
                                if (j.Right >= x.Left - x.Width)
                                {
                                    j.Left -= _callHeroClass._SpriteSpeed;
                                }
                                if (j.Top < x.Height)
                                {
                                    j.Top -= _callHeroClass._SpriteSpeed;
                                }
                                if (j.Top > x.Top)
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
                                _updateScore();
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

                        //this is mostly giving the events errors
                        if ((j.Tag.Equals("enemy")) && (x.Tag.Equals("player")))
                        {
                            //checking if the X loop is touching the J loop
                            //moving to the left of the wall
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                CheckHeroHealth();
                                _callHeroClass.HeroHealth -= 1;
                                //enemy player is able to heal himself if hes health is lower than 95
                                if (_callEnemyClass.EnemyHealth < 95)
                                {
                                    _callEnemyClass.EnemyHealth += 5;
                                }
                            }

                            if (j.Left < x.Left - 30)
                            {
                                j.Left += _callEnemyClass._SpriteSpeed;
                                _callEnemyClass.SetEnemyImageLeft();
                            }
                            else if (j.Left > x.Left + 30)
                            {
                                j.Left -= _callEnemyClass._SpriteSpeed;
                                _callEnemyClass.SetEnemyImageRight();
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

            //switching between keydown and giving the hero a direction
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _callHeroClass.PlayerInput = true;
                    _callHeroClass.HeroDirection = Direction.Left;
                    _updateScore();
                    break;
                case Keys.Right:
                    _callHeroClass.PlayerInput = true;
                    _callHeroClass.HeroDirection = Direction.Right;
                    break;
                case Keys.Down:
                    _callHeroClass.PlayerInput = true;
                    _callHeroClass.HeroDirection = Direction.Down;
                    break;
                case Keys.Up:
                    _callHeroClass.PlayerInput = true;
                    _callHeroClass.HeroDirection = Direction.Up;
                    break;
            }

            //pausing the game
            if (e.KeyCode == Keys.P)
            {
                _pauseGame(); //when P is pressed we call pauseGame function on line 328
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _callHeroClass.PlayerInput = false;
                    break;
                case Keys.Right:
                    _callHeroClass.PlayerInput = false;
                    break;
                case Keys.Down:
                    _callHeroClass.PlayerInput = false;
                    break;
                case Keys.Up:
                    _callHeroClass.PlayerInput = false;
                    break;
            }

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
            //to be extra sure it will be removed from the program 
            foreach (Control c in Controls)
            {
                this.Controls.Remove(c); //remove from frame display
                c.Dispose();//disposes it from the program
            }
            this.Dispose(true);

            Game NewForm = new Game();
            NewForm.Show();
        }

        private void _pauseGame()
        {
            _gamePaused = true;
            //grabbing all controls and hide them.
            foreach (Control c in Controls)
            {
                c.Visible = false;
            }
            lblScore.Visible = true;
            lblPause.Visible = true;
            pause.Visible = false;
            resume.Visible = true;
            _callHeroClass.Move.Stop();
            GameEngineTimer.Stop();
        }

        private void _resumeGame()
        {
            _gamePaused = false;
            //grabbing all controls and show them again
            foreach (Control c in Controls)
            {
                c.Visible = true;
            }
            lblPause.Visible = false;
            pause.Visible = true;
            resume.Visible = false;
            inputPlayerName.Visible = false;
            lblScore.Visible = true;
            btnShowScore.Visible = false;
            lblHighscore.Visible = false;
            boxAllHighScores.Visible = false;
            lblGameOver.Visible = false;
            _callHeroClass.Move.Start();
            GameEngineTimer.Start();
        }

        private void _gameIsOver()
        {
            _gameOver = true;
            //grabbing all controls and hide them
            foreach (Control c in Controls)
            {
                c.Visible = false;
            }
            inputPlayerName.Visible = true;
            lblScore.Visible = true;
            btnShowScore.Visible = true;
            lblNewGame.Visible = true;
            lblGameOver.Visible = true;

            _callHeroClass.Move.Stop(); //stoping the timer of the hero
            GameEngineTimer.Stop(); //stopping the timer of the gameEngine
        }

        //this will change the color of the hero progress bar
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
                _callHeroClass.HeroIsDeath(this);
                Console.WriteLine("U Lose");
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

        //this will change the color of the Enemy progress bar
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
                Console.WriteLine("u Won!");

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

        private void _updateScore()
        {
            int myScore = Convert.ToInt32(lblScore.Text);
            int newScore = myScore + 2;
            // Console.WriteLine(newScore);
            lblScore.Text = newScore.ToString();
        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            lblGameOver.Visible = false;
            btnShowScore.Visible = false;
            inputPlayerName.Visible = false;
            lblHighscore.Visible = true;

            //filling the method with mapname, playername, and score
            _callHighscoreClass.showAllHighScores(GetMapName, inputPlayerName.Text.ToString(), lblScore.Text.ToString());

            _callHighscoreClass.ReadAllHighScores(this);
        }

        private void newgame_Click(object sender, EventArgs e)
        {
            _resetMap();
        }

        private void newgame_MouseEnter(object sender, EventArgs e)
        {
            lblNewGame.BorderStyle = BorderStyle.FixedSingle;
            lblNewGame.BackColor = Color.White;
        }

        private void newgame_MouseLeave(object sender, EventArgs e)
        {
            lblNewGame.BorderStyle = BorderStyle.None;
            lblNewGame.BackColor = Color.Transparent;
        }
    }
}
