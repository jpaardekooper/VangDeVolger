using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    class Box : Sprite
    {

        public PictureBox spriteBox = new PictureBox();

        public Box( int locationX, int locationY)
        {
            spriteBox.Height = _SpriteHeight;
            spriteBox.Width = _SpriteWidth;
            spriteBox.Name = "box";
            spriteBox.Tag = "box";
            spriteBox.Image = Properties.Resources.box;
            spriteBox.Location = new Point(locationX, locationY);

           
        }
      

    }
}
