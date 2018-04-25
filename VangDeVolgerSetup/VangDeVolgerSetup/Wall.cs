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
        public PictureBox SpriteWall { get; set; }

        public Wall()
        {
            SpriteWall = new PictureBox();
            SpriteWall.Size = new Size(_SpriteSize, _SpriteSize);
            SpriteWall.Name = "wall";
            SpriteWall.Tag = SpriteWall.Name;
            SpriteWall.Image = Properties.Resources.wall;
        }

        /// <summary>
        /// creating a wall sprite that stand on top of the tile
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PlaceWall(int locationX, int locationY)
        {
            SpriteWall.Location = new Point(locationX, locationY);
        }
    }
}
