using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    class Box : Tile
    {
        PictureBox _box = new PictureBox();        
       

        public Box() : base()
        {
            Name = "box";
            Tag = Name;
            X = Utils.rnd.Next(2, 12) * 75;
            Y = Utils.rnd.Next(2, 7) * 75;

            Height = 75;
            Width = 75;
        }

        public void mkBox(Form form)
        {
            // this function will add the bullet to the game play
            // it is required to be called from the main class
            _box.Image = (Properties.Resources.box);
            _box.Name = Name;
            _box.Tag = Tag;
            _box.Left = X;
            _box.Top = Y;
            _box.Width = Width;
            _box.Height = Height;
            _box.SizeMode = PictureBoxSizeMode.StretchImage;
            
          
            form.Controls.Add(_box); // add the bullet to the screen
            _box.BringToFront(); // bring the bullet to front of other objects
        }
    }
}
