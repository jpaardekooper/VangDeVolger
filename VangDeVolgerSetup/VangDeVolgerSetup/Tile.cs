/*
 * A Tile knows what Sprite is on it everytime we create a new Tile we need the location
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class Tile
    {
        public enum TileType
        {
            empty,
            hero,
            enemy,
            wall,
            box
        }

        public TileType Contains { get; set; }
        public Button BtnTile { get; set; }    
        private const int _tileSize = 40;
        private Dictionary<char, Tile> _neighbour { get; set; }

        public Tile(TileType type)
        {
            BtnTile = new Button(); //creating a new button that has the purpose of ground for example if a player pushes a box you won't see the form but an inactive button           
            BtnTile.Size = new Size(_tileSize, _tileSize); //the size of the button is 40 by 40
            BtnTile.Enabled = false; //setting enabled to false so we won't have interference with the keyboard targetting the button
            BtnTile.Image = Properties.Resources.empty; //giving the the ground an image   

            if (type == TileType.box)
            {
                Contains = TileType.box;
                Box box = new Box();
            }
            if (type == TileType.wall)
            {
                Contains = TileType.wall;
                Wall wall = new Wall();
            }
            if (type == TileType.hero)
            {

            }
            if (type == TileType.enemy)
            {

            }
            if (type == TileType.empty)
            {
                Contains = TileType.empty;
            }
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


        /// <summary>
        /// placing ne
        /// </summary>
        public void SetNeighbours(Tile[,] TilesArray, int i, int j)
        {
            //checking what is inside the array    
            // 0 = row
            // 1 = column


            // checks for the borders and adds the neighbor if it exists
            // in the board
            Dictionary<char, Tile> _neighbour = new Dictionary<char, Tile>
                    {
                        { 'T', TilesArray[i,j] }
                    };
            Console.Write(" " + TilesArray[i, j]);

            if (i != 0)
            {
                _neighbour.Add('W', TilesArray[i - 1, j]);
            }
            if (i != TilesArray.GetLength(0) - 1)
            {
                _neighbour.Add('E', TilesArray[i + 1, j]);
            }
            if (j != 0 && i != 0)
            {
                _neighbour.Add('N', TilesArray[i, j - 1]);
            }
            if (j != TilesArray.GetLength(1) - 1)
            {
                _neighbour.Add('S', TilesArray[i, j + 1]);
            }



        }
    }
}
