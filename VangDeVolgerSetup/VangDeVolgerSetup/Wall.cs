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

        public Wall(int locationX, int locationY)
        {
            spriteWall.Size = new Size(40, 40);
            //spriteWall.Width = _SpriteWidth;
            spriteWall.Name = "wall";
            spriteWall.Tag = "wall";
            spriteWall.Image = Properties.Resources.wall;
            spriteWall.Location = new Point(locationX, locationY);
        }
    }
}
