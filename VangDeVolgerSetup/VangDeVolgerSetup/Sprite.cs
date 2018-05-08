using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolgerSetup
{
    /// <summary>
    /// A Sprite can be anything used in the game
    /// </summary>
    abstract class Sprite
    {        
        public bool PushWall { get; set; }
        public bool CheckAlifeStatus { get; set; }
        public bool BlockEnemy { get; set; }

        public Image SpriteImage { get; set; }
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
        /// Constructor for a Sprite
        /// </summary>
        public Sprite()
        {
            // All attributes are currently set in the child classes           
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
