/*
 * A Tile knows what Sprite is on it everytime we create a new Tile we need the location
 */
using System.Drawing;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public class Tile
    {
        public Button BtnTile { get; set; }
        public Sprite Contains { get; set; }

    
        public Tile()
        {
            BtnTile = new Button();
            BtnTile.Size = new Size(40, 40);
            BtnTile.Enabled = false;
            BtnTile.Image = Properties.Resources.empty;                 
        }
        /// <summary>
        /// A tile knows what sprite is standing on top of it
        /// </summary>
        /// <param name="LocationX"></param>
        /// <param name="LocationY"></param>
        public void PlaceTile(int LocationX, int LocationY)
        {
            BtnTile.Location = new Point(LocationX, LocationY);
        }

        
    }
}
