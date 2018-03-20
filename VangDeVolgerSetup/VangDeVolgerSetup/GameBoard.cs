using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    //public class GameBoard
    //{
    //    private const int gridSize = 12;
    //    private const int tileSize = 40;

    //    public PictureBox[,] GameBoardSprites = new PictureBox[gridSize, gridSize];

    //    public void CreateGameBoard(Form2 form)
    //    {            

    //        var clr1 = Color.Pink;
    //        var clr2 = Color.LightPink;

    //        // initialize the "chess board"
    //        // GameBoardSprites         


    //        // double for loop to handle all rows and columns
    //        for (var i = 0; i < GameBoardSprites.GetLength(0); i++)
    //        {
    //            for (var j = 0; j < GameBoardSprites.GetLength(1); j++)
    //            {

    //                // create new Panel control which will be one 
    //                // game board tile
    //                PictureBox myEmptySprite = new PictureBox
    //                {
    //                    Size = new Size(tileSize, tileSize),
    //                    //adding + 100 so it moved 100px from the top side so i won't interfere with the menu layout
    //                    Location = new Point(tileSize * i, tileSize * j + 100)

    //                };


    //                // add to Form's Controls so that they show up
    //                form.Controls.Add(myEmptySprite);                     

    //                // add to our 2d array of panels for future use
    //                GameBoardSprites[i, j] = myEmptySprite;

    //                //chessboard layout to check if it actually works
    //                if (i % 2 == 0)
    //                    myEmptySprite.BackColor = j % 2 != 0 ? clr1 : clr2;
    //                else
    //                    myEmptySprite.BackColor = j % 2 != 0 ? clr2 : clr1;







    //            }
    //        }      

    //    }

    //}

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

        //basic information of the picturebox (pb) width, height and position 
        private int _pbHeight = 40;
        private int _pbWidth = 40;
        private int _currentPositionX = 0;
        private int _currentPositionY = 0;
        private int _placement = 0;
        private string _levelModus = string.Empty;

        public void LoadMyTextLevel(Form2 Form2, string Name)
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
                    Console.WriteLine(_levelModus);
                    break;

                case "hard":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\hard.txt");
                    Console.WriteLine(_levelModus);
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
                                tile.BackColor = Color.Red;
                                break;
                            case "V":
                                tile.BackColor = Color.Green;
                                break;
                            case "N":
                                tile.BackColor = Color.Purple;
                                break;

                        }
                        tile.Location = new Point(_currentPositionX, _currentPositionY);
                        Form2.Controls.Add(tile);
                        tile.BringToFront();

                        //while we are in the loop we place the tiles on the form2 we increase the positionX + 1
                        _currentPositionX += _pbWidth + 1;
                    }
                    _currentPositionX = _placement;
                    _currentPositionY += _pbHeight + 1;
                }
                strReader.Close();
            }

        }
    }
}
