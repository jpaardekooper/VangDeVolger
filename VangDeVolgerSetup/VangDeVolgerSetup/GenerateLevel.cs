using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class GenerateLevel
    {
        //creating a private _name instance to set the game modus of the game (easy, hard, crazy)
        private string _name { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Tile[,] GenerateLevelMap { get; set; }
        //basic information of the picturebox (pb) width, height and position 
        private Dictionary<char, Tile> _neighbour { get; set; }
        private int _pbHeight { get; set; }
        private int _pbWidth { get; set; }
        private int _currentPositionX { get; set; }
        private int _currentPositionY { get; set; }
        private int _placement { get; set; }
        private int _iRow { get; set; }
        private int _iCol { get; set; }
        private string _levelModus { get; set; }

        //filling the attributes with values
        public GenerateLevel()
        {
            GenerateLevelMap =  new Tile[12, 12];
            _pbHeight = 40;
            _pbWidth = 40;
            _currentPositionX = 0;
            _currentPositionY = 0;
            _placement = 0;
            _iRow = 0;
            _iCol = 0;
            _levelModus = string.Empty;
        }
        /// <summary>
        /// checking the level we picked and giving it back to gameplatform
        /// if the name is not equal to an empty string we continue to go to the switch statement.
        /// We use the name that was obtained from the gameplatform to determine which txt level it needs to open.
        /// once the path is found we use a Streamreader to read all data from the txt file and convert it to an string array.
        /// while reading it out we give each char a Tile object and giving specific chars the correct object such as box, empty and wall.
        /// Also while reading the data out we  put them in an Tile[,] 2D array so we can place them on the gameplatform screen.
        /// </summary>
        /// <param name="gameplatform"></param>
        /// <param name="name"></param>
        public void ReadMyTextLevelFile(Game gameplatform, string name)
        {
            //if we get an error show it
            if (name.Equals(""))
            {
                MessageBox.Show("no level found");
            }

            //filling the levelModus          
            switch (name)
            {
                case "easy":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\easy.txt");
                    break;
                case "hard":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\hard.txt");
                    break;
                case "crazy":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\hard.txt");
                    break;
            }
            using (StreamReader strReader = new StreamReader(_levelModus))
            {
                string strLine = string.Empty;
                while ((strLine = strReader.ReadLine()) != null)
                {
                    string[] stringLineArray = strLine.Split(' ');
                    foreach (string c in stringLineArray)
                    {
                        //creating a Tile object to fill our Game with tiles
                        Tile tileObject = new Tile();
                        tileObject.PlaceTile(_currentPositionX, _currentPositionY + 100);

                        switch (c)
                        {
                            case "D":
                                //creating a pictureBox when the char D is found in txt.file
                                Box box = new Box();
                                box.PlaceBox(_currentPositionX, _currentPositionY + 100);
                                gameplatform.Controls.Add(box.SpriteBox);  //adding the tile to Form2 so we can see it   
                                box.SpriteBox.BringToFront();
                                tileObject.Contains = box;
                                break;
                            case "V":
                                //creating a pictureBox when the char V is found in txt.file
                                Wall wall = new Wall();
                                wall.PlaceWall(_currentPositionX, _currentPositionY + 100);
                                gameplatform.Controls.Add(wall.SpriteWall);  //adding the tile to Form2 so we can see it   
                                wall.SpriteWall.BringToFront();
                                tileObject.Contains = wall;
                                break;
                            case "N":
                                tileObject.Contains = null;
                                break;
                            //catching the error //creating a button if a char N is found with the type empty and img empty
                            case "?":
                                tileObject.Contains = null;
                                break;
                        }
                        GenerateLevelMap[_iCol, _iRow] = tileObject; //assigning the Tile object to the array                     
                        gameplatform.Controls.Add(tileObject.BtnTile);  //adding the tile to Form2 so we can see it                        
                        //its not a bug but a feature
                        if (name.Equals("crazy"))
                        {
                            Console.WriteLine("crazy");
                            tileObject.BtnTile.BringToFront();
                        }

                        _iCol++;  //adding 1 collumn eachtime we pass this    
                        _currentPositionX += _pbWidth;  //while we are in the loop we place the tiles on the Game window. We increase the positionX
                    }
                    //  Console.WriteLine();
                    _iRow++; //add 1 new row each time we pass this
                    _iCol = 0; //resetting column count to 0 so we can pass new data
                    _currentPositionX = _placement;
                    _currentPositionY += _pbHeight;   //adding small margin between each tile
                }
                strReader.Close(); //closing the file
            }
            SetNeighbours();
        }

        private void SetNeighbours()
        {
            //checking what is inside the array         
            for (int i = 0; i < GenerateLevelMap.GetLength(0); i++)
            {
                for (int j = 0; j < GenerateLevelMap.GetLength(1); j++)
                {
                    // checks for the borders and adds the neighbor if it exists
                    // in the board
                    Dictionary<char, Tile> _neighbour = new Dictionary<char, Tile>
                    {
                        { 'T', GenerateLevelMap[j,i] }
                    };
                    //    Console.Write(" "+ GenerateLevelMap[j, i].Contains);
                    if (i != 0)
                    {
                        _neighbour.Add('W', GenerateLevelMap[j, i - 1]);
                    }
                    if (i != GenerateLevelMap.GetLength(0) - 1)
                    {
                        _neighbour.Add('E', GenerateLevelMap[j, i + 1]);
                    }
                    if (j != 0)
                    {
                        _neighbour.Add('N', GenerateLevelMap[j - 1, i]);
                    }
                    if (j != GenerateLevelMap.GetLength(1) - 1)
                    {
                        _neighbour.Add('S', GenerateLevelMap[j + 1, i]);
                    }
                }
                //   Console.WriteLine();
            }


        }

        //public void EnemyMovement()
        //{
        //    // Enemy.HasNeighbour(GenerateLevelMap, 11, 11, Direction.Right);

        //    Console.WriteLine(GenerateLevelMap);

        //    if (Enemy.HasNeighbour(GenerateLevelMap, 11, 11, Direction.Right))
        //    {              
        //        Console.WriteLine("ri");
        //    }
        //    else if (Enemy.HasNeighbour(GenerateLevelMap, 11, 11, Direction.Left))
        //    {
        //        Console.WriteLine("le"); 
        //    }
        //    else if (Enemy.HasNeighbour(GenerateLevelMap, 11, 11, Direction.Up))
        //    {
        //        Console.WriteLine("up");
        //    }
        //    else if (Enemy.HasNeighbour(GenerateLevelMap, 11, 11, Direction.Down))
        //    {
        //        Console.WriteLine("do");
        //    }
        //}
    }
}
