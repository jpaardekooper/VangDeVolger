/*
 * A Tile knows what Sprite is on it everytime we create a new Tile we need the location
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class Tile
    {
        public Button BtnTile { get; set; } 
        public GenerateTile.TileType Contains { get; set; }
        private const int _tileSize = 40;

        public Tile()
        {           
            BtnTile = new Button(); //creating a new button that has the purpose of ground for example if a player pushes a box you won't see the form but an inactive button           
            BtnTile.Size = new Size(_tileSize, _tileSize); //the size of the button is 40 by 40
            BtnTile.Enabled = false; //setting enabled to false so we won't have interference with the keyboard targetting the button
            BtnTile.Image = Properties.Resources.empty; //giving the the ground an image       
        }
        /// <summary>
        /// A tile needs to have an location. GenerateTile will create a new position eachtime it reads out a char
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void PlaceTile(int row, int col)
        {
            BtnTile.Location = new Point(row, col); //location of the ground is row by col
        }        

    }
}
