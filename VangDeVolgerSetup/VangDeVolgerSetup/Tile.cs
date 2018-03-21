using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
   public class Tile
    {
        public Control SpriteObject { get; set; }      


        public Tile(Control pbSpriteObject)
        {
            this.SpriteObject = pbSpriteObject;
        }
    }
}
