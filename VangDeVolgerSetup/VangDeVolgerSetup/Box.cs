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
       // public S Type { get; set; } 
        /// <summary>
        /// creating a box sprite on top of a tile
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public Box( int locationX, int locationY)
        {
            spriteBox.Size = new Size(_SpriteWidth, _SpriteHeight);   
            spriteBox.Name = "box";
            spriteBox.Tag = spriteBox.Name;
            spriteBox.Image = Properties.Resources.box;
            spriteBox.Location = new Point(locationX, locationY); 
        }
    }
}
