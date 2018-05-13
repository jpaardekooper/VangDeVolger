using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolgerSetup
{
    /// <summary>
    /// Gameboard Object makes a tileboard based on
    /// GameTiles and Gameobjects
    /// </summary>
    class GenerateTile
    {
        //setting the gamesize and sprites
        public int GameSize { get; set; }

        //a sprite needs to know on what tile it stands
        public Tile[,] GameTiles { get; set; }
        private int _amountOfBoxes { get; set; }
        private int _unmovableBoxes { get; set; }

        //getting the types from sprites with enum
        public Sprite.SpriteType _tileType { get; set; }

        //variable for random
        private Random _rand { get; set; }
        private int _randomNr { get; set; }

        //defining a standard size of 40 (img size is 40)
        private const int _BoardSize = 40;
        private Bitmap _buffer { get; set; }
        private Size _bufferSize { get; set; }

        /// <summary>
        /// Makes a new GameBoard of tiles it depends on the selected modus
        /// </summary>
        /// <param name="newSize"></param>
        public GenerateTile(int newSize)
        {
            // Declaring class attributes           
            GameSize = newSize;
            GameTiles = new Tile[GameSize, GameSize];
            // 40 refers to the image size. All tiles are 40 by 40 pixels
            _bufferSize = new Size(GameSize * _BoardSize, GameSize * _BoardSize);
            _buffer = new Bitmap(_bufferSize.Width, _bufferSize.Height);

            // creating a _rand function so we know how many boxes you can push and how many you can't
            _rand = new Random();

            switch (newSize)
            {
                //this will be  20% moveable boxes and 5% unmoveable boxres
                case 8:
                    //if its option easy
                    _amountOfBoxes = 22;
                    _unmovableBoxes = 3;
                    break;
                case 10:
                    //if its option medium
                    _amountOfBoxes = 20;
                    _unmovableBoxes = 5;
                    break;
                case 12:
                    //if its option hard
                    _amountOfBoxes = 18;
                    _unmovableBoxes = 8;
                    break;
            }

            // Filling the array GameTiles with GameTiles
            for (int i = 0; i < GameSize; i++)
            {
                for (int j = 0; j < GameSize; j++)
                {
                    // Determines what the Sprite on the tile will become

                    _randomNr = _rand.Next(100);

                    if (i == 0 && j == 0)
                    {
                        // the Hero's sprite
                        _tileType = Sprite.SpriteType.Hero;

                    }
                    else if (i == GameTiles.GetLength(0) - 1 && j == GameTiles.GetLength(1) - 1)
                    {
                        // the Enemy's sprite
                        _tileType = Sprite.SpriteType.Enemy;
                    }
                    else if (_randomNr < _unmovableBoxes)
                    {
                        // the water sprite (a wall you cannot push)
                        _tileType = Sprite.SpriteType.Wall;
                    }
                    else if (_randomNr < _amountOfBoxes)
                    {
                        // the Box sprite (a box you can push)
                        _tileType = Sprite.SpriteType.Box;
                    }
                    else
                    {
                        // empty (null) a tile where something can stand on
                        _tileType = Sprite.SpriteType.Empty;
                    }

                    // calls for tile constructor to generate the tiles
                    Tile tile = new Tile(_tileType, _rand.Next(4), GameSize);
                    GameTiles[i, j] = tile;

                    //testing map
                    //Console.Write(_tileType);
                }
                //adding an enter each time it passes the loop
                // Console.WriteLine();
            }

            // Initializing all neighbours, by calling their function
            // after the complete board has been build
            for (int i = 0; i < GameSize; i++)
            {
                for (int j = 0; j < GameSize; j++)
                {
                    // Sets the neighbour for each Tile
                    GameTiles[i, j].SetNeighbours(GameTiles, i, j);
                }
            }
        }

        /// <summary>
        /// this will draw the board on the bitmap
        /// </summary>
        /// <returns></returns>
        public Bitmap DrawTileBoard()
        {
            // using a simple way to draw the board
            for (int i = 0; i < GameTiles.GetLength(0); i++)
            {
                for (int j = 0; j < GameTiles.GetLength(1); j++)
                {
                    //using Graphics for the buffer
                    using (Graphics graphics = Graphics.FromImage(_buffer))
                    {
                        //if the gameTile[i,j] is not null
                        if (!(GameTiles[i, j].SpriteObject is null))
                        {
                            graphics.DrawImage(GameTiles[i, j].SpriteObject.SpriteImage, i * _BoardSize, j * _BoardSize, _BoardSize, _BoardSize);
                        }
                        else
                        {
                            // 40 refers to the image size. All images are 40 by 40 pixels
                            graphics.DrawImage(GameTiles[i, j].TileImage, i * _BoardSize, j * _BoardSize, _BoardSize, _BoardSize);
                        }

                    }
                }
            }
            return _buffer;
        }
    }
}
