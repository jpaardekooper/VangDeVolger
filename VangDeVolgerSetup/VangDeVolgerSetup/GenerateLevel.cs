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
        private Tile[,] _generateLevelMap = new Tile[12, 12];
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
        /// checking the level we picked and giving it back to Form2
        /// </summary>
        /// <param name="Form2"></param>
        /// <param name="Name"></param>
        public void ReadMyTextLevelFile(Game gameplatform, string Name)
        {
            //if we get an error show it
            if (Name.Equals(""))
            {
                MessageBox.Show("no level found");
            }

            //filling the levelModus          
            switch (Name)
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
                        Tile Tile = new Tile(_currentPositionX, _currentPositionY + 100);

                        switch (c)
                        {
                            case "D":
                                //creating a pictureBox when the char D is found in txt.file
                                Box box = new Box(_currentPositionX, _currentPositionY + 100);
                                gameplatform.Controls.Add(box.spriteBox);  //adding the tile to Form2 so we can see it   
                                box.spriteBox.BringToFront();
                                Tile.Contains = box;
                                break;
                            case "V":
                                //creating a pictureBox when the char V is found in txt.file
                                Wall wall = new Wall(_currentPositionX, _currentPositionY + 100);
                                gameplatform.Controls.Add(wall.spriteWall);  //adding the tile to Form2 so we can see it   
                                wall.spriteWall.BringToFront();
                                Tile.Contains = wall;
                                break;
                            case "N":
                                Tile.Contains = null;
                                break;
                            //catching the error //creating a button if a char N is found with the type empty and img empty
                            case "?":
                                Tile.Contains = null;
                                break;
                        }
                        _generateLevelMap[_iCol, _iRow] = Tile; //assigning the Tile object to the array                     
                        gameplatform.Controls.Add(Tile.BtnTile);  //adding the tile to Form2 so we can see it                        
                        //its not a bug but a feature
                        if (Name.Equals("crazy"))
                        {
                            Console.WriteLine("crazy");
                            Tile.BtnTile.BringToFront();
                        }

                        _iCol++;  //adding 1 collumn eachtime we pass this    
                        _currentPositionX += _pbWidth;  //while we are in the loop we place the tiles on the Game window. We increase the positionX
                    }
                    Console.WriteLine();
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
            for (int i = 0; i < _generateLevelMap.GetLength(0); i++)
            {
                for (int j = 0; j < _generateLevelMap.GetLength(1); j++)
                {
                    // checks for the borders and adds the neighbor if it exists
                    // in the board
                    Dictionary<char, Tile> _neighbour = new Dictionary<char, Tile>
                    {
                        { 'T', _generateLevelMap[j,i] }
                    };
                    //    Console.Write(" "+ _generateLevelMap[j, i].Contains);
                    if (i != 0)
                    {
                        _neighbour.Add('W', _generateLevelMap[j, i - 1]);
                    }
                    if (i != _generateLevelMap.GetLength(0) - 1)
                    {
                        _neighbour.Add('E', _generateLevelMap[j, i + 1]);
                    }
                    if (j != 0)
                    {
                        _neighbour.Add('N', _generateLevelMap[j - 1, i]);
                    }
                    if (j != _generateLevelMap.GetLength(1) - 1)
                    {
                        _neighbour.Add('S', _generateLevelMap[j + 1, i]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
