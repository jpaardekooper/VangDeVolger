using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{
    class Wall : Sprite
    {
        public Wall(Form form) : base()
        {
            PictureBox wall = new PictureBox
            {
                Size = new Size(SpriteSize, SpriteSize),
                Location = new Point(SpriteSize * rng.Next(0,12), SpriteSize * rng.Next(0, 12)),
                Name = "wall",
                Tag = "wall",
                BackColor = Color.Red

            };
            Items.Add(wall);
            form.Controls.Add(wall);
            wall.BringToFront();

        }
    }
}
