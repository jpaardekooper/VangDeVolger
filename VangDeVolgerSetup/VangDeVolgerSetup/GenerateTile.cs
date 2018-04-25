using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class GenerateTile
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

        public enum TileType
        {
            empty,
            hero,
            enemy,
            wall,
            box
        }

        public TileType Type { get; set; }
        public Tile[,] TilesArray { get; set; }
        //basic information of the picturebox (pb) width, height and position 
        private Dictionary<char, Tile> _neighbour { get; set; }
        private const int _tileSize = 40;
        private const int _maxArrLength = 12;
        private int _currentPositionY { get; set; }
        private int _currentPositionX { get; set; }
        private int _placement { get; set; }
        private int _rowX { get; set; }
        private int _colY { get; set; }
        private string _levelModus { get; set; }



        //filling the attributes with values
        public GenerateTile()
        {
            TilesArray = new Tile[_maxArrLength, _maxArrLength];

            _currentPositionY = 0;
            _currentPositionX = 0;
            _placement = 0;
            _rowX = 0;
            _colY = 0;
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
                                box.PlaceBox(_currentPositionY, _currentPositionX + 100);
                                gameplatform.Controls.Add(box.SpriteBox);  //adding the tile to Form2 so we can see it   
                                box.SpriteBox.BringToFront();
                                tileObject.Contains = TileType.box;
                                break;
                            case "V":
                                //creating a pictureBox when the char V is found in txt.file
                                Wall wall = new Wall();
                                wall.PlaceWall(_currentPositionY, _currentPositionX + 100);
                                gameplatform.Controls.Add(wall.SpriteWall);  //adding the tile to Form2 so we can see it   
                                wall.SpriteWall.BringToFront();
                                tileObject.Contains = TileType.wall;
                                break;
                            case "N":
                                tileObject.Contains = TileType.empty;
                                break;
                            //catching the error //creating a button if a char N is found with the type empty and img empty
                            case "?":
                                tileObject.Contains = TileType.empty;
                                break;


                        }
                        TilesArray[_rowX, _colY] = tileObject; //assigning the Tile object to the array      

                        gameplatform.Controls.Add(tileObject.BtnTile);  //adding the tile to Form2 so we can see it                        
                        //its not a bug but a feature
                        if (name.Equals("crazy"))
                        {
                            // Console.WriteLine("crazy");
                            tileObject.BtnTile.BringToFront();
                        }

                        _colY++;  //adding 1 collumn eachtime we pass this    
                        _currentPositionY += _tileSize;  //while we are in the loop we place the tiles on the Game window. We increase the positionX

                        //  Console.Write(tileObject.Contains +" ");
                    }
                    //  Console.WriteLine();
                    _rowX++; //add 1 new row each time we pass this
                    _colY = 0; //resetting column count to 0 so we can pass new data
                    _currentPositionY = _placement;
                    _currentPositionX += _tileSize;   //adding small margin between each tile

                    //     Console.WriteLine();
                }
                strReader.Close(); //closing the file
            }
            SetNeighbours();
        }

        /// <summary>
        /// placing ne
        /// </summary>
        private void SetNeighbours()
        {
            //checking what is inside the array         
            for (int i = 0; i < TilesArray.GetLength(0); i++)
            {
                for (int j = 0; j < TilesArray.GetLength(1); j++)
                {
                    Console.Write(TilesArray[i, j].Contains + "\t");

                    // checks for the borders and adds the neighbor if it exists
                    // in the board
                    Dictionary<char, Tile> _neighbour = new Dictionary<char, Tile>
                    {
                        { 'T', TilesArray[i,j] }
                    };
                    //  Console.Write(" "+ TilesArray[i,j]);
                    //if (i != 0)
                    //{
                    //    _neighbour.Add('W', TilesArray[i, j - 1]);
                    //}
                    //if (i != TilesArray.GetLength(0) - 1)
                    //{
                    //    _neighbour.Add('E', TilesArray[i, j + 1]);
                    //}
                    //if (j != 0)
                    //{
                    //    _neighbour.Add('N', TilesArray[i - 1, j]);
                    //}
                    //if (j != TilesArray.GetLength(1) - 1)
                    //{
                    //    _neighbour.Add('S', TilesArray[i + 1, j]);
                    //}
                }
                Console.WriteLine();

            }


        }

        //public void EnemyMovement()
        //{
        //    // Enemy.HasNeighbour(TilesArray, 11, 11, Direction.Right);

        //    Console.WriteLine(TilesArray);

        //    if (Enemy.HasNeighbour(TilesArray, 11, 11, Direction.Right))
        //    {              
        //        Console.WriteLine("ri");
        //    }
        //    else if (Enemy.HasNeighbour(TilesArray, 11, 11, Direction.Left))
        //    {
        //        Console.WriteLine("le"); 
        //    }
        //    else if (Enemy.HasNeighbour(TilesArray, 11, 11, Direction.Up))
        //    {
        //        Console.WriteLine("up");
        //    }
        //    else if (Enemy.HasNeighbour(TilesArray, 11, 11, Direction.Down))
        //    {
        //        Console.WriteLine("do");
        //    }
        //}
    }
}
