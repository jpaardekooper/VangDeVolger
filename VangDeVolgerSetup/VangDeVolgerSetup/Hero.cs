using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolgerSetup
{
    class Hero : Sprite
    {
        //// defines if an object will be pushed
        //// will only take effect if used in move function

        /// <summary>
        /// hero's contstructor
        /// </summary>
        public Hero(Tile newTile)
        {
            // Setting the hero image        
            SpriteImage = Properties.Resources.Nright;   
            //when the game starts the hero alife status is true
            CheckAlifeStatus = true;   
        
            // Setting the Hero's gamebox
            ObjectGameBox = newTile;
        }

        /// <summary>
        /// Moves the Hero (player) based on direction and neighbours
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="direction"></param>
        public override void Move(Tile tile, Tile.Neighbours direction)
        {
            if (!(tile._HasNeighbours.ContainsKey(direction)))
            {
                // check if the requested move is posible, so borders work
                return;
            }
            else if (tile._HasNeighbours[direction].SpriteObject is null)
            {
                // Sets the new neighbour tile to  hero
                tile._HasNeighbours[direction].SpriteObject = tile.SpriteObject;

                // Sets the hero's last tile visited to null
                tile.SpriteObject = null;

                // Updates the  hero's Tile
                ObjectGameBox = tile._HasNeighbours[direction];
            }        
            else if (tile._HasNeighbours[direction].SpriteObject is Enemy)
            {
                // Check if the requested move is enemy tile

                // Sets the enemy' being alive status to false
                tile.SpriteObject.CheckAlifeStatus = false;
               
                //set hero to death image
                SpriteImage = Properties.Resources.death_5;
                // Stop the movement
                return;
            }
            else if (tile._HasNeighbours[direction].SpriteObject != null)
            {
                tile._HasNeighbours[direction].SpriteObject.Move(tile, direction);
                return;
            }
            else
            {
                // an error as occured, this else is used to catch the error to prevent crashing the game
                Console.WriteLine("An error has occured while moving the hero");
                return;
            }
        }
    }
}
