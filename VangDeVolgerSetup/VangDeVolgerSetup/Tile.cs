/*
 * A Tile knows what Sprite is on it everytime we create a new Tile we need the location
 */
using System.Drawing;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class Tile
    {
        public Button BtnTile = new Button();
        public Sprite Contains { get; set; }
        /// <summary>
        /// checking what type the tile is and filling it in the correct array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="type"></param>
        public Tile(int x, int y)
        {
            BtnTile.Size = new Size(40, 40);
            BtnTile.Enabled = false;
            BtnTile.Image = Properties.Resources.empty;
            BtnTile.Location = new Point(x, y);         
        }

        
    }
}
