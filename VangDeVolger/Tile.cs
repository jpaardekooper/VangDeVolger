using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    class Tile
    {    
        public int Speed { get; set; } // creating a integer called speed and assigning a value of 20      
        public string Name { get; set; }
        public string Tag { get; set; }
      
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int Health { get; set; }

        public Image Sprite { get; set; }
        


        public Tile()
        {
            Speed = 50;
            X = 0;
            Y = 0;
            Width = 50;
            Height = 50;
        }

    }

}
