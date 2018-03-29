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

        /// <summary>
        /// checking the Neighbour of the current tile
        /// </summary>
        /// <param name="array"></param>
        /// <param name="CellX"></param>
        /// <param name="CellY"></param>
        /// <returns></returns>
        public static bool HasNeighbour(Tile[,] array, int CellX, int CellY)
        {
            if (array[CellX + 1, CellY].Contains is null)
            {
                Console.WriteLine(array[CellX + 1, CellY].Contains);
                Console.WriteLine("right is true");
                return true;
            }
            if (array[CellX - 1, CellY].Contains is null)
            {
                Console.WriteLine("left is true");
                return true;
            }
            if (array[CellX, CellY + 1].Contains is null)
            {
                Console.WriteLine("top is true");
                return true;
            }
            if (array[CellX, CellY - 1].Contains is null)
            {
                Console.WriteLine("bottom is true");
                return true;
            }
            return false;
        }
    }
}
