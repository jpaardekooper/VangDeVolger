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
        public PictureBox SpriteBox { get; set; }

        public Box()
        {
            SpriteBox = new PictureBox();
            SpriteBox.Size = new Size(_SpriteSize, _SpriteSize);
            SpriteBox.Name = "box";
            SpriteBox.Tag = SpriteBox.Name;
            SpriteBox.Image = Properties.Resources.box;

        }

        /// <summary>
        /// creating a box sprite on top of a tile
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PlaceBox(int locationX, int locationY)
        {
            SpriteBox.Location = new Point(locationX, locationY);
        }
    }
}
