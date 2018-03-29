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
        private SpriteType _tileType { get; set; }
        public SpriteType Type
        {
            get
            {
                return _tileType;
            }
            set
            {
                _tileType = value;
            }
        }

        /// <summary>
        /// checking what type the tile is and filling it in the correct array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="type"></param>
        public Tile(int x, int y, SpriteType type)
        {
            BtnTile.Size = new Size(40, 40);
            BtnTile.Enabled = false;
            BtnTile.Image = Properties.Resources.empty;
            BtnTile.Location = new Point(x, y);
            Type = type;
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
            if (array[CellX + 1, CellY].Type == SpriteType.empty)
            {
                Console.WriteLine(array[CellX + 1, CellY].Type);
                Console.WriteLine("right is true");
                return true;
            }

            if (array[CellX - 1, CellY].Type == SpriteType.empty)
            {
                Console.WriteLine("left is true");
                return true;
            }

            if (array[CellX, CellY + 1].Type == SpriteType.empty)
            {
                Console.WriteLine("top is true");
                return true;
            }

            if (array[CellX, CellY - 1].Type == SpriteType.empty)
            {
                Console.WriteLine("bottom is true");
                return true;
            }
            return false;
        }
    }
}
