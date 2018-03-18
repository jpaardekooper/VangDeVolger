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
        public static PictureBox[,] GameBoardBoxes;

        private const int tileSize = 40;
        private const int gridSize = 12;

        public GameBoard(Form form)
        {
            // initialize the "chess board"
            GameBoardBoxes = new PictureBox[gridSize, gridSize];

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
                        Location = new Point(tileSize * i, tileSize * j),
                 
                    };
                    if (i == 0 && j == 0)
                    {
                        newPictureBox.Image = Properties.Resources.enemyLeft;
                        newPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        newPictureBox.Tag = "hero";

                    }

                    // add to Form's Controls so that they show up
                    form.Controls.Add(newPictureBox);
                    //adding picturebox to list

                    //adding items to the list = 


                    // add to our 2d array of panels for future use
                    //setting picture box on the i and j location so 0 0  then 0 1 then 0 2
                    GameBoardBoxes[i, j] = newPictureBox;


                    newPictureBox.BackColor = Color.DarkGray;

                    //}
                }

            }
        }

    }


}
