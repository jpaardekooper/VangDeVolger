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

        //private int[,] _fillGridArray { get; set; }
        //public int[,] FillGridArray
        //{
        //    get
        //    {
        //        return _fillGridArray;
        //    }
        //    set
        //    {
        //        _fillGridArray = value;
        //    }
        //}        

        private Tile[,] _tileMapArray = new Tile[12, 12];
      

        //basic information of the picturebox (pb) width, height and position 
        private int _pbHeight = 40;
        private int _pbWidth = 40;
        private int _currentPositionX = 0;
        private int _currentPositionY = 0;
        private int _placement = 0;
        private string _levelModus = string.Empty;

        private int _iRow = 0;
        private int _iCol = 0;
     

        public void ReadMyTextLevelFile(Form2 Form2, string Name)
        {          
            //if we get an error show it
            //if (levelmodus <= 0)
            //{
            //    MessageBox.Show("non level found");
            //}

            //filling the levelModus          
            switch (Name)
            {
                case "easy":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\Easy.txt");
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
                        PictureBox tile = new PictureBox
                        {
                            Size = new Size(_pbHeight, _pbWidth)
                        };

                        switch (c)
                        {
                            case "D":
                                //  tile.BackColor = Color.Red;
                                tile.Name = "box";
                                tile.Tag = "box";
                                tile.Image = Properties.Resources.box;
                                break;
                            case "V":
                                //    tile.BackColor = Color.Green;
                                tile.Name = "wall";
                                tile.Tag = "wall";
                                tile.Image = Properties.Resources.wall;
                                break;
                            case "N":
                                tile.BackColor = Color.Purple;
                                tile.Name = "empty";
                                tile.Tag = "empty";
                                break;

                        }
                        //adding + 100 to the Y location to show the health bar of the player class
                        tile.Location = new Point(_currentPositionX, _currentPositionY+100);                       
                        Form2.Controls.Add(tile);  //adding the tile to Form2 so we can see it                       
                        _tileMapArray[_iRow, _iCol] = new Tile(tile); //filling the 2D array with sprites in to use them later on 
                    //    Console.Write(" " + tile.Tag + "\t");
                      
                        _iCol++;  //adding 1 collumn eachtime we pass this                       
                        _currentPositionX += _pbWidth;  //while we are in the loop we place the tiles on the form2 we increase the positionX + 1 
                    }
                 //   Console.WriteLine();
                    _iRow++;
                    _iCol = 0;
                    _currentPositionX = _placement;                  
                    _currentPositionY += _pbHeight;   //adding small margin between each tile
                  
                }
              
                strReader.Close();
            }
            for (int i = 0; i < _tileMapArray.GetLength(0); i++)
            {
                for (int j = 0; j < _tileMapArray.GetLength(1); j++)
                {
                    Debug.Write(j);
                }
                Debug.WriteLine(i);
            }
          

        }
    }
}
