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
        public enum TileType
        {
            empty,
            wall,
            box
        }
        public Control TileObject { get; set; }  
       //public Control tileType { get; set; }

        public Tile(Control pbTileObject) //, TileType pbTileType
        {
            this.TileObject = pbTileObject;
      //      this.tileType = pbTileObject;
        }
    }
}
