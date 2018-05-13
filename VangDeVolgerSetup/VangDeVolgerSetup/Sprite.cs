/*
 * This is the parent class of the following classes: Hero, Box, and Enemy
 * it has 1 abstract method in order to move the sprites
 */
using System.Drawing;

namespace VangDeVolgerSetup
{
    /// <summary>
    /// A Sprite can be a Hero, Enemy, Wall, Box or empty (null)
    /// </summary>
    abstract class Sprite
    {        
        public bool PushWall { get; set; }
        public bool CheckAlifeStatus { get; set; }
        public bool BlockEnemy { get; set; }

        //a sprite has a image
        public Image SpriteImage { get; set; }
        //a sprite has a location
        public Tile ObjectGameBox { get; set; } 

        public enum SpriteType
        {
            Hero,
            Enemy,
            Box,
            Wall,
            Empty
        }
       
        /// <summary>
        /// Sprite's constructor
        /// </summary>
        public Sprite()
        {
            // All attributes are set in child classes      
        }

        /// <summary>
        /// This abstract move function is used by all child classes  
        ///  if the SpriteObject doesn't move this function can be empty
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="direction"></param>
        public abstract void Move(Tile tile, Tile.Neighbours direction);
    }
}
