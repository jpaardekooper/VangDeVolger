using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    class Enemy : Sprite
    {
        //   public PictureBox _spriteEnemy = new PictureBox();
        public Direction EnemyDirection { get; set; } // creating a public string called direction
        public int EnemyHealth { get; set; }


        public Enemy() : base()
        {
            EnemyHealth = 100;
            _SpriteSpeed = 3;

            _PbSpriteContainer = new PictureBox();
            _PbSpriteContainer.Name = "enemy";
            _PbSpriteContainer.Tag = _PbSpriteContainer.Name;
            _PbSpriteContainer.Left = _MaxGameWidth;
            _PbSpriteContainer.Top = _MaxGameHeight;
            _PbSpriteContainer.Size = new Size(_SpriteWidth - 7, _SpriteHeight - 7);
            _PbSpriteContainer.SizeMode = PictureBoxSizeMode.Zoom;
            _PbSpriteContainer.Image = Properties.Resources.enemyLeft;
        }

        /// <summary>
        /// Create the sprite of enemy and adding it to the form
        /// </summary>
        /// <param name="form"></param>
        public void CreateEnemyInstance(Form gameplatform)
        {
            gameplatform.Controls.Add(_PbSpriteContainer);
            _PbSpriteContainer.BringToFront();
        }

        public void SetEnemyImageLeft()
        {
            _PbSpriteContainer.Image = Properties.Resources.enemyLeft;
        }

        public void SetEnemyImageRight()
        {
            _PbSpriteContainer.Image = Properties.Resources.enemyRight;

        }      

        /// <summary>
        /// checking the Neighbour of the current tile
        /// </summary>
        /// <param name="array"></param>
        /// <param name="CellX"></param>
        /// <param name="CellY"></param>
        /// <returns></returns>
        public static bool HasNeighbour(Tile[,] array, int CellX, int CellY, Direction direction)
        {
            if (CellX < 10 && array[CellX + 1, CellY].Contains is Box && direction == Direction.Right)
            {
             //   Console.WriteLine("right is true");
                return true;
            }
            else if (CellX > 0 && array[CellX - 1, CellY].Contains is Box && direction == Direction.Left)
            {
              //  Console.WriteLine("left is true");
                return true;
            }
            else if (CellY < 10 && array[CellX, CellY + 1].Contains is Box && direction == Direction.Up)
            {
            //    Console.WriteLine("top is true");
                return true;
            }
            else if (CellY < 0 && array[CellX, CellY - 1].Contains is Box && direction == Direction.Down)
            {
           //     Console.WriteLine("bottom is true");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
