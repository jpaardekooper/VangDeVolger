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

        public Button BtnTile = new Button();
        public int TileNr { get; set; }

        private int _locationX { get; set; }
        public int LocationX
        {
            get
            {
                return _locationX;
            }
            set
            {
                _locationX = value;
            }
        }

        private int _locationY { get; set; }
        public int LocationY
        {
            get
            {
                return _locationY;
            }
            set
            {
                _locationY = value;
            }
        }

        public Tile(int x, int y)
        {
            BtnTile.Size = new Size(40, 40);
            TileNr = 1; //says anothing
            BtnTile.Enabled = false;
            BtnTile.Image = Properties.Resources.empty;
            BtnTile.Location = new Point(x, y);

        }
    }
}
