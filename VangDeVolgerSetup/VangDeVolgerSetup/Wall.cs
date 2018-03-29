using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    class Wall : Sprite
    {
        public PictureBox spriteWall = new PictureBox();

        /// <summary>
        /// creating a wall sprite that stand on top of the tile
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public Wall(int locationX, int locationY)
        {
            spriteWall.Size = new Size(_SpriteHeight, _SpriteHeight);          
            spriteWall.Name = "wall";
            spriteWall.Tag = spriteWall.Name;
            spriteWall.Image = Properties.Resources.wall;
            spriteWall.Location = new Point(locationX, locationY);
        }
    }
}
