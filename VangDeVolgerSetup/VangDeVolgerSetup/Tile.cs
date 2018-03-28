using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    // a tile has a type
    public enum TileType
    {
        empty,
        wall,
        box
    }

    public class Tile
    {

        public Button BtnTile = new Button();
        public int TileNr { get; set; }

        //private int _locationX { get; set; }
        //public int LocationX
        //{
        //    get
        //    {
        //        return _locationX;
        //    }
        //    set
        //    {
        //        _locationX = value;
        //    }
        //}

        //private int _locationY { get; set; }
        //public int LocationY
        //{
        //    get
        //    {
        //        return _locationY;
        //    }
        //    set
        //    {
        //        _locationY = value;
        //    }
        //}

        private TileType _tileType { get; set; }
        public TileType TileType
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

        public Tile(int x, int y, TileType type)
        {
            BtnTile.Size = new Size(40, 40);
            TileNr = 1; //says anothing
            BtnTile.Enabled = false;
            BtnTile.Image = Properties.Resources.empty;
            BtnTile.Location = new Point(x, y);
            TileType = type;
        }

        //checking if
        public static bool HasNeighbour(Tile[,] array, int CellX, int CellY)
        {

            if (array[CellX + 1, CellY].TileType == TileType.empty)
            {
                Console.WriteLine(array[CellX + 1, CellY].TileType);
                Console.WriteLine("right is true");
                return true;
            }

            if (array[CellX - 1, CellY].TileType == TileType.empty)
            {
                Console.WriteLine("left is true");
                return true;
            }

            if (array[CellX , CellY + 1].TileType == TileType.empty)
            {
                Console.WriteLine("top is true");
                return true;
            }

            if (array[CellX, CellY - 1].TileType == TileType.empty)
            {            
                Console.WriteLine("bottom is true");
                return true;
            }
            
            return false;
        }
    }
}
