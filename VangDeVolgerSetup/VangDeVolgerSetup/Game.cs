/*
 * On this form the level will be loaded and displayed
 * There is alot of .visible true and false going on this was mostly used for styling purposes.
 * Once this form has recieved the level modus it will load the GenerateTiles.cs with the correct levelmodus.
 * After the tiles are loaded. 1 hero will be added to the screen and 1 enemy.
 * This Game.cs has the task to determine if hero or enemy is still alive. 
 * we enabled  Application.EnableVisualStyles() because we are no longer using a progress bar
 * 
 * [  small tutorial  ]
 * 
 * The user wins if the enemy is stuck between walls and boxes
 * the user loses if the enemy touches the player
 * 
 * the user cannot walk through (water) walls.
 * the user can push boxes.
 * 
 * 
 * user can walk with the arrow keys (up, down, left, right) this will also update the score
 * 
 * once the player wins or loses the game, the game will ask for a name to fill in for the highscore
 * 
 * This program was created by:
 * Jasper Paardekooper 17039886
 * Roos Hoogervorst 17036895
 */

using System;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    partial class Game : Form
    {
        // Association attributes
        public GenerateLevel GenerateTile { get; set; }
        private Highscore _callHighscoreClass { get; set; }      
        private Hero _callHeroClass { get; set; }
        private Enemy _callEnemyClass { get; set; }

        // Using 2 variables to set the new size and levelmodus
        private int _lastSize { get; set; }
        private int _newSize { get; set; }
        public string GameModus { get; set; }

        // The enemy Timer
        private Timer _moveTimer { get; set; }

        // Other attributes   
        public bool Pause { get; set; }
        private int _highScore { get; set; }
        private string _mapName { get; set; }

        
        /// <summary>
        /// Constructor for the Game
        /// Uses a size to create the requested GameBoard GameSize
        /// </summary>
        /// <param name="size"></param>
        public Game(int size)
        {
            InitializeComponent();

            //
            //styling for the highscore 
            //

            //label, submit button and input of entering a name is set to invisble
            lblName.Visible = false;
            txtBoxName.Visible = false;
            btnSubmit.Visible = false;

            //the rich textbox of highscores is set to invisible
            boxAllHighScores.Visible = false;
            //highscorebackground set to invisble
            pbHighScoreBackground.Visible = false;

            //setting the score value to 0 and highscore label to 0
            _highScore = 0;
            lblHighScore.Text = _highScore.ToString();

            ///end styling

            //defining the mapname so we call the function get map        
            GetMapName(size);  

            // Setting pause to false (default)
            Pause = false;

            //calls for function in order to create the hero and enemy instance
            GenerateSpriteObjects(size);
          

            //variable _lastSize gets the value of the current generateTile.GameSize
            _lastSize = GenerateTile.GameSize;

            // Setting keypreview to true, so the keyDown event will work
            KeyPreview = true;


            // Creating a new timer, its event and its interval
            _moveTimer = new Timer();
            _moveTimer.Tick += new EventHandler(_MoveTimer_Tick);
            _moveTimer.Interval = _callEnemyClass.Speed;
            _moveTimer.Start();

            // Drawing the board on the screen
            DrawBoardOnScreen();

            // After everything is initialized the board will be shown to the player
            ShowDialog();

        }

        /// <summary>
        ///  // Creates a new gameboard and adds a Hero and Enemy sprite
        /// </summary>
        /// <param name="size"></param>
        private void GenerateSpriteObjects(int size)
        {
            // Creates a new gameboard and adds a Hero and Enemy sprite
            GenerateTile = new GenerateLevel(size);

            for (int i = 0; i < GenerateTile.GameSize; i++)
            {
                for (int j = 0; j < GenerateTile.GameSize; j++)
                {

                    // Finding the hero and enemy on the board
                    if (GenerateTile.GameTiles[i, j].SpriteObject is Enemy)
                    {
                        _callEnemyClass = (Enemy)GenerateTile.GameTiles[i, j].SpriteObject;
                    }
                    else if (GenerateTile.GameTiles[i, j].SpriteObject is Hero)
                    {
                        _callHeroClass = (Hero)GenerateTile.GameTiles[i, j].SpriteObject;
                    }
                }
            }
        }



        /// <summary>
        ///   //defining the mapnap by size
        /// </summary>
        /// <param name="size"></param>
        private void GetMapName(int size)
        {       
            //depending on size the mapname will be displayed
            switch (size)
            {
                case 8:
                    _mapName = "easy";
                    lblMapName.Text = "map niveau is: " + _mapName;
                    return;
                case 10:
                    _mapName = "medium";
                    lblMapName.Text = "map niveau is: " + _mapName;
                    return;
                case 12:
                    _mapName = "hard";
                    lblMapName.Text = "map niveau is: " + _mapName;
                    return;
            }           
        }

        //
        //  Game functions
        //

        /// <summary>
        /// Closes the current window and makes a new one
        /// </summary>
        private void ResetGame()
        { 
            //setting the size of the game
            _newSize = _lastSize;

            // Closes the current window and removes it from the ram
            Dispose();
            this.Dispose(true);   
          
            // Makes a new GameWindow
            Game NewForm = new Game(_newSize);           
        }

        /// <summary>
        /// Checks if either the forklift or theboss is dead
        /// </summary>
        private void IsAnyoneAlive()
        {
            // Calls the Enemy' function to check if he is unable to move
            _callEnemyClass.IsEnemyAlive();

            // Checks if either the Hero or Enemy is dead
            if (!_callEnemyClass.CheckAlifeStatus)
            {
                // Pauses the game
                GamePause();
                // calls for the function ShowHighscore
                ShowHighscore();
                //setting the lblhighscore to victory
                lblHighScore.Text = "U WON!!";
               // Console.WriteLine("u won");

            }
            else if (!_callHeroClass.CheckAlifeStatus)
            {
                // calls for function Gamepause
                GamePause();
                //setting the lblhighscore to lose
                lblHighScore.Text = "U LOSE!!";
            //    Console.WriteLine("u lost");
            }
        }

        /// <summary>
        /// Draws the current gameboard on screen
        /// </summary>
        private void DrawBoardOnScreen()
        {
            // Requests the gameboard from its class and draws it to the gamewindow
            pbGameBoard.Image = GenerateTile.DrawTileBoard();
        }

        /// <summary>
        /// Switches between pauze and unpauze
        /// </summary>
        private void GamePause()
        {           
            if (Pause)
            {            
                // Unpause the game
                Pause = false;
                lblHighScore.Text = _highScore.ToString();
            }
            else
            {              
                // Pauses the game
                Pause = true;
                lblHighScore.Text = "Game is Paused";
            }
        }  

      

        /// <summary>
        /// Calls theboss' function to move every time interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _MoveTimer_Tick(object sender, EventArgs e)
        {
            // Checks if the game is pauzed
            if (Pause)
            {
                return;
            }
            // Calls the enemy' move function
            _callEnemyClass.Move(_callEnemyClass.ObjectGameBox, Tile.Neighbours.B);
            // Draws the bord to the screen
            DrawBoardOnScreen();
            // checks if the player has won or lost
            IsAnyoneAlive();
        }
   

        /// <summary>
        /// Calls the function hero move when the key is down 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {           

            // Makes a local variable to declare direcion          
            Tile.Neighbours direction = Tile.Neighbours.B;

            // Switches the input to decide what to do with it
            // arrow key(left right up down) is used to delcare direction(North, South, West, East), 
            //the keys are used in the _hasNeighbour dictonary
            switch (e.KeyCode)
            {
                case Keys.F12:
                    // Resets the game and stops the event
                    ResetGame();
                    return;
                case Keys.P:
                    // Pauzes or unpauzes the game and stops the event
                    GamePause();
                    return;
                case Keys.Left:
                    //moving hero left of the screen
                    direction = Tile.Neighbours.W;
                    //sets hero img to the left
                    _callHeroClass.SpriteImage = Properties.Resources.Nleft;
                    break;
                case Keys.Right:
                    //moving hero right of the screen
                    direction = Tile.Neighbours.E;
                    //sets hero img to the right
                    _callHeroClass.SpriteImage = Properties.Resources.Nright;
                    break;
                case Keys.Up:
                    //moving hero to the top side of the screen
                    direction = Tile.Neighbours.N;
                    break;
                case Keys.Down:
                    //moving hero to the down side of of the screen
                    direction = Tile.Neighbours.S;
                    break;              
                default:
                    return;
            }

            // Checks if the game is paused we return the keydown events so nothing happens
            if (Pause)
            {
                return;
            }
            else
            {
                //otherswise eachtime the key down is pressed highscore is added +1
                _highScore += 1;
                //setting the variable highscore to the labelhighscore
                lblHighScore.Text = _highScore.ToString();
            }

            // Calls the Hero's move function
            _callHeroClass.Move(_callHeroClass.ObjectGameBox, direction);
            // Draws the board on screen
            DrawBoardOnScreen();
            // Checks if the player has won the game or lost the game
            IsAnyoneAlive();
        }

        private void ShowHighscore()
        {
            //setting the input, submit button and label to visible in order to enter your name
            lblName.Visible = true;
            txtBoxName.Visible = true;
            btnSubmit.Visible = true;
            pbHighScoreBackground.Visible = true;
            //creating a new Highscore
            _callHighscoreClass = new Highscore();           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //setting the input, submit button and label to invisible 
            lblName.Visible = false;
            txtBoxName.Visible = false;
            btnSubmit.Visible = false;

            //filling the method with mapname, playername, and score
            _callHighscoreClass.showAllHighScores(_mapName, txtBoxName.Text.ToString(), _highScore.ToString());

            //loading the highscore txtbox
            _callHighscoreClass.ReadAllHighScores(this);
        }
    }  
}
