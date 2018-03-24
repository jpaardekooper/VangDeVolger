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

     //   private Tile[,] _tileMapArray = new Tile[12, 12];


        //basic information of the picturebox (pb) width, height and position 
        private int _pbHeight = 40;
        private int _pbWidth = 40;
        private int _currentPositionX = 0;
        private int _currentPositionY = 0;
        private int _placement = 0;
        private string _levelModus = string.Empty;

        //  private int _iRow = 0;
        //   private int _iCol = 0;


        public void ReadMyTextLevelFile(Form2 Form2, string Name)
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
                        Button tile3 = new Button
                        {
                            Size = new Size(_pbHeight, _pbWidth)
                        };
                        switch (c)
                        {
                            case "D":
                                PictureBox tile = new PictureBox
                                {
                                    Size = new Size(_pbHeight, _pbWidth)
                                };
                                //  tile.BackColor = Color.Red;
                                tile.Name = "box";
                                tile.Tag = "box";
                                tile.Image = Properties.Resources.box;
                                tile.Location = new Point(_currentPositionX, _currentPositionY + 100);
                                Form2.Controls.Add(tile);  //adding the tile to Form2 so we can see it   
                                tile.BringToFront();
                                break;
                            case "V":
                                PictureBox tile2 = new PictureBox
                                {
                                    Size = new Size(_pbHeight, _pbWidth)
                                };
                                //    tile.BackColor = Color.Green;
                                tile2.Name = "wall";
                                tile2.Tag = "wall";
                                tile2.Image = Properties.Resources.wall;
                                tile2.Location = new Point(_currentPositionX, _currentPositionY + 100);
                                Form2.Controls.Add(tile2);  //adding the tile to Form2 so we can see it   
                                tile2.BringToFront();
                                break;
                            case "N":
                                tile3.Name = "empty";
                                tile3.Tag = "empty";

                                break;
                            case "?":

                                tile3.Name = "empty";
                                tile3.Tag = "empty";
                                break;

                        }
                        tile3.Enabled = false;                       
                        tile3.Image = Properties.Resources.empty;
                        tile3.Location = new Point(_currentPositionX, _currentPositionY + 100);
                        Form2.Controls.Add(tile3);  //adding the tile to Form2 so we can see it  
                        //its not a bug but a feature
                        if (Name.Equals("crazy"))
                        {
                            Console.WriteLine("crazy");
                            tile3.BringToFront();
                        }
                          
                        _currentPositionX += _pbWidth;  //while we are in the loop we place the tiles on the form2 we increase the positionX + 1 
                    }             
                    _currentPositionX = _placement;
                    _currentPositionY += _pbHeight;   //adding small margin between each tile
                }
                strReader.Close();
            }
        }
    }
}
