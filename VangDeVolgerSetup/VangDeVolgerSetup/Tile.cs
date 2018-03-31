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
        public Sprite.SpriteType Contains { get; set; }       

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
            Contains = Sprite.SpriteType.empty;
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
            if (CellX < 10 && array[CellX + 1, CellY].Contains == Sprite.SpriteType.empty)
            {
                Console.WriteLine(array[CellX + 1, CellY]);
                Console.WriteLine("right is true");
                return true;
            }
            if (CellX > 0 && array[CellX - 1, CellY].Contains is Sprite.SpriteType.empty)
            {
                Console.WriteLine("left is true");
                return true;
            }
            if (CellY < 10 && array[CellX, CellY + 1].Contains is Sprite.SpriteType.empty)
            {
                Console.WriteLine("top is true");
                return true;
            }
            if (CellY < 10 && array[CellX, CellY - 1].Contains is Sprite.SpriteType.empty)
            {
                Console.WriteLine("bottom is true");
                return true;
            }
            return false;
        }
    }
}
