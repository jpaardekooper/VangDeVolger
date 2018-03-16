using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{
    class GameBoard
    {
        // Panel[,] ChessboardPanels { get; set; }
        private PictureBox[,] _gameBoardPanels;

        public List<PictureBox> items = new List<PictureBox>();

        const int tileSize = 40;
        const int gridSize = 12;

        public GameBoard(Form form)
        {  
            // initialize the "chess board"
            _gameBoardPanels = new PictureBox[gridSize, gridSize];

            // double for loop to handle all rows and columns
            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
                {
                    // create new Panel control which will be one 
                    // game board tile
                    PictureBox newPictureBox = new PictureBox
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * i, tileSize * j)
                    };

                    // add to Form's Controls so that they show up
                    form.Controls.Add(newPictureBox);
                    //adding picturebox to list
                    items.Add(newPictureBox);                  

                    // add to our 2d array of panels for future use
                    _gameBoardPanels[i, j] = newPictureBox;

                    // color the backgrounds
                    if (i == 0 && j == 0)
                    {
                        newPictureBox.BackColor = Color.Violet;
                        newPictureBox.Tag = "Hero";
                    }
                    else if (i == gridSize-1 && j == gridSize-1)
                    {
                        newPictureBox.BackColor = Color.Blue;
                        newPictureBox.Tag = "Enemy";
                    }
                    else
                    {
                        newPictureBox.BackColor = Color.DarkGray;

                    }
                   

                }
            }
        }

    }
}
