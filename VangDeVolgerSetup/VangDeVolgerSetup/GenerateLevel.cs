using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Tile[,] _tileMapArray = new Tile[12, 12];
        //basic information of the picturebox (pb) width, height and position 
        private int _pbHeight = 40;
        private int _pbWidth = 40;
        private int _currentPositionX = 0;
        private int _currentPositionY = 0;
        private int _placement = 0;
        private int _iRow = 0;
        private int _iCol = 0;
        private string _levelModus = string.Empty;

       

        public void ReadMyTextLevelFile(Game Form2, string Name)
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
                    //    Console.WriteLine(_levelModus);
                    break;

                case "hard":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\hard.txt");
                    //   Console.WriteLine(_levelModus);
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
                        Tile Tile = new Tile(_currentPositionX, _currentPositionY + 100, TileType.empty);
                        //     Tile.TileNr = 1;

                        switch (c)
                        {
                            case "D":
                                //creating a pictureBox when the char D is found in txt.file
                                Box Box = new Box(_currentPositionX, _currentPositionY + 100);
                                Form2.Controls.Add(Box.spriteBox);  //adding the tile to Form2 so we can see it   
                                Box.spriteBox.BringToFront();
                                Tile.TileNr = 2;
                                Tile.TileType = TileType.box;
                                // Console.WriteLine("test");
                                break;
                            case "V":
                                //creating a pictureBox when the char V is found in txt.file
                                Wall Wall = new Wall(_currentPositionX, _currentPositionY + 100);
                                Form2.Controls.Add(Wall.spriteWall);  //adding the tile to Form2 so we can see it   
                                Wall.spriteWall.BringToFront();
                                Tile.TileNr = 3;
                                Tile.TileType = TileType.wall;
                                break;
                            case "N":    
                                //creating a button if a char N is found with the type empty and img empty
                                Tile.TileNr = 0;
                                Tile.TileType = TileType.empty;
                                break;
                            //catching the error //creating a button if a char N is found with the type empty and img empty
                            case "?":                                
                                Tile.TileType = TileType.empty;
                                Tile.TileNr = 0;
                                break;

                        }                     
                        _tileMapArray[_iCol, _iRow] = Tile;
                        //Tile.Location = new Point(_currentPositionX, _currentPositionY + 100);
                        Form2.Controls.Add(Tile.BtnTile);  //adding the tile to Form2 so we can see it  

                        //its not a bug but a feature
                        if (Name.Equals("crazy"))
                        {
                            Console.WriteLine("crazy");
                            Tile.BtnTile.BringToFront();
                        }

                        _iCol++;  //adding 1 collumn eachtime we pass this    
                        _currentPositionX += _pbWidth;  //while we are in the loop we place the tiles on the form2 we increase the positionX + 1 
                    }
                    _iRow++;
                    _iCol = 0;
                    _currentPositionX = _placement;
                    _currentPositionY += _pbHeight;   //adding small margin between each tile
                }
                strReader.Close();
            }


            //checking what is inside the array
            for (int i = 0; i < _tileMapArray.GetLength(0); i++)
            {
                for (int j = 0; j < _tileMapArray.GetLength(1); j++)
                {
                    Console.Write(" "+_tileMapArray[j, i].TileType + "\t ");
                   
                }
                Console.WriteLine();
            }
            //soo if we call this function we know what is in N E S W but..
            Tile.HasNeighbour(_tileMapArray,1,1);
        }
    }
}
