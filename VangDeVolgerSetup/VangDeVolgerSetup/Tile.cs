using System.Collections.Generic;
using System.Drawing;

namespace VangDeVolgerSetup
{

    /// <summary>
    /// Tile is an object where a sprite can stand on
    /// On a Tile stands a gameobject
    /// </summary>
    class Tile
    {
        public Dictionary<Neighbours, Tile> _HasNeighbours { get; set; }
        public Sprite SpriteObject { get; set; }
        public Image TileImage { get; set; }

        //a tile has neighbours Top, left, right, bottom (North, East, South, West)
        public enum Neighbours
        {
            N,
            E,
            S,
            W,
            B,//stands for base or no direction at all
        }

        /// <summary>
        /// Tile constructor
        /// Makes a gamebox based on 3 ints 
        /// </summary>
        /// <param name="tileType"></param>
        /// <param name="randNumber"></param>
        /// <param name="Size"></param>
        public Tile(Sprite.SpriteType tileType, int randNumber, int size)
        {
            // Sets the default background image           
            TileImage = Properties.Resources.empty;

            // Generates a dictionary that will be used later on
            // the gameboard generation
            _HasNeighbours = new Dictionary<Neighbours, Tile>();

            switch (tileType)
            {
                case Sprite.SpriteType.Hero:
                    // create hero sprite
                    SpriteObject = new Hero(this);
                    break;
                case Sprite.SpriteType.Enemy:
                    // create enemy sprite
                    SpriteObject = new Enemy(this, size);
                    break;
                case Sprite.SpriteType.Wall:
                    // create unmovable water sprite
                    SpriteObject = new Box(false);
                    break;
                case Sprite.SpriteType.Box:
                    //  create moveable box sprite
                    SpriteObject = new Box(true);
                    break;
                case Sprite.SpriteType.Empty:
                    // Sets gameobject to null
                    SpriteObject = null;
                    break;
            }
        }

        /// <summary>
        /// A function that sets the neighbours for the gameboxes    
        ///         ------> columns
        ///       0 0 0 0 0 0 0 0 0 0 
        ///     | 0 0 0 0 0 0 0 0 0 0 
        ///     | 0 0 0 0 0 0 0 0 0 0 
        ///rows | 0 0 0 0 0 0 0 0 0 0 
        ///     | 0 0 0 0 0 0 0 0 0 0 
        ///     V 0 0 0 0 0 0 0 0 0 0 
        /// </summary>
        /// <param name="gameBoxes"></param>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public void SetNeighbours(Tile[,] gameBoxes, int column, int row)
        {
            // Checks for the borders and adds the neighbour if it exists
            // on the board
            if (column != 0)
            {
                // sets a Neighbour attribute on west side or (left)
                _HasNeighbours.Add(Neighbours.W, gameBoxes[column - 1, row]);
            }
            if (column != gameBoxes.GetLength(0) - 1)
            {
                // sets a Neighbour attribute on east side or(right)
                _HasNeighbours.Add(Neighbours.E, gameBoxes[column + 1, row]);
            }
            if (row != 0)
            {
                // sets a Neighbour attribute on north side or (up)
                _HasNeighbours.Add(Neighbours.N, gameBoxes[column, row - 1]);
            }
            if (row != gameBoxes.GetLength(1) - 1)
            {
                // sets a Neighbour attribute on south side or (down)
                _HasNeighbours.Add(Neighbours.S, gameBoxes[column, row + 1]);
            }
        }
    }
}
