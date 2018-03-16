using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    class Wall : Tile
    {
        PictureBox _wall = new PictureBox();

        //to make random even more random
        public static class Utils
        {
            public static readonly Random rnd = new Random();
        }

        public Wall() : base()
        {
            Name = "wall";
            Tag = Name;
            X = Utils.rnd.Next(2, 12)*75;
            Y = Utils.rnd.Next(2, 7)*75;

            Height = 75;
            Width = 75;
        }

        public void mkWall(Form form)
        {
            // this function will add the bullet to the game play
            // it is required to be called from the main class
            _wall.Image = (Properties.Resources.wall);
            _wall.Name = Name;
            _wall.Tag = Tag; 
            _wall.Left = X;
            _wall.Top = Y;
            _wall.Width = Width;
            _wall.Height = Height;
            _wall.SizeMode = PictureBoxSizeMode.StretchImage;
            
          
            form.Controls.Add(_wall); // add the bullet to the screen
            _wall.BringToFront(); // bring the bullet to front of other objects
        }
    }
}
