/*
 * Enemy class of the game  depending on the level modus it will move faster or slower
 * */

using System;

namespace VangDeVolgerSetup
{
    /// <summary>
    /// The enemy class of the game vang de volger
    /// </summary>
    class Enemy : Sprite
    {
        public int Speed { get; set; }
        private int _newMove { get; set; }

        // Generates a random direction
        private Random _rand { get; set; }

        /// <summary>
        /// construct the enemy class
        /// </summary>
        /// <param name="newTile"></param>
        /// <param name="size"></param>
        public Enemy(Tile newTile, int size)
        {
            _rand = new Random();

            //enemy direction speed 1000 = 1sec 
            //easy=8 as levelSize so every 700ms
            //medium = 10  as levelSize so every 650ms
            //hard = 12  as levelSize so every 550ms
            //so speed depends on levelSize
            switch (size)
            {
                case 8:
                    Speed = 700;
                    break;
                case 10:
                    Speed = 650;
                    break;
                case 12:
                    Speed = 550;
                    break;
            }
       
            CheckAlifeStatus = true;       

            //setting enemy img default left
            SpriteImage = Properties.Resources.enemyLeft;

            // Setting enemy' tile
            ObjectGameBox = newTile;
        }

        /// <summary>
        /// Checks if the enemy is alive
        /// </summary>
        public void IsEnemyAlive()
        {
            // Checking if there isn't a empty tile around the enemy
            if (!((ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.N) && ObjectGameBox._HasNeighbours[Tile.Neighbours.N].SpriteObject is null) ||
                  (ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.W) && ObjectGameBox._HasNeighbours[Tile.Neighbours.W].SpriteObject is null) ||
                  (ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.S) && ObjectGameBox._HasNeighbours[Tile.Neighbours.S].SpriteObject is null) ||
                  (ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.E) && ObjectGameBox._HasNeighbours[Tile.Neighbours.E].SpriteObject is null)))
            {
                // Checking if all tiles around the enemy are able to block him
                if (((ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.N) && ObjectGameBox._HasNeighbours[Tile.Neighbours.N].SpriteObject.BlockEnemy) || !ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.N)) &&
                   ((ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.W) && ObjectGameBox._HasNeighbours[Tile.Neighbours.W].SpriteObject.BlockEnemy) || !ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.W)) &&
                   ((ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.S) && ObjectGameBox._HasNeighbours[Tile.Neighbours.S].SpriteObject.BlockEnemy) || !ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.S)) &&
                   ((ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.E) && ObjectGameBox._HasNeighbours[Tile.Neighbours.E].SpriteObject.BlockEnemy) || !ObjectGameBox._HasNeighbours.ContainsKey(Tile.Neighbours.E)))
                {
                    // setting enemy' CheckAlifeStatus to false
                    ObjectGameBox.SpriteObject.CheckAlifeStatus = false;
                }
            }
            else
            {
                //check complete
            }
        }

        /// <summary>
        /// Moves the enemy in random directions every 850ms 
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="direction"></param>
        public override void Move(Tile tile, Tile.Neighbours direction)
        {
            _newMove = _rand.Next(0, 4);

            switch (_newMove)
            {
                case (0):
                    direction = Tile.Neighbours.N;
                    break;
                case (1):
                    direction = Tile.Neighbours.W;
                    //removing current img from ram memory 
                    SpriteImage.Dispose();
                    //sets new img for enemy 
                    SpriteImage = Properties.Resources.enemyLeft;
                    break;
                case (2):
                    direction = Tile.Neighbours.S;
                    break;
                case (3):
                    direction = Tile.Neighbours.E;
                    //removing current img from ram memory 
                    SpriteImage.Dispose();
                    //sets new img for enemy 
                    SpriteImage = Properties.Resources.enemyRight;
                    break;
                default:
                    return;
            }

            // Checks whether there is a tile in the direction of the requested move
            if (!tile._HasNeighbours.ContainsKey(direction))
            {
                return;
            }
            // Checks if the requested direction is a empty tile so we can move towards it           
            if (tile._HasNeighbours[direction].SpriteObject is null)
            {
                //sets enemy on new location
                tile._HasNeighbours[direction].SpriteObject = tile.SpriteObject;
                tile.SpriteObject = null;

                ObjectGameBox = tile._HasNeighbours[direction];
            }
            // Checks whether the requested move is the hero's tile
            else
            {
                if (tile._HasNeighbours[direction].SpriteObject is Hero)
                {
                    tile._HasNeighbours[direction].SpriteObject.CheckAlifeStatus = false;
                }

                // The encounterd box has no relation to enemy, so there will be no movement
                else
                {
                    return;
                }
            }
        }
    }
}
