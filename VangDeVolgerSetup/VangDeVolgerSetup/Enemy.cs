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
        public void CreateEnemyInstance(Game gameplatform)
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
        /// Checking the four positions of the Tile
        ///            N
        ///         W [x] O
        ///            S
        /// if the tile is empty we return true else it is false
        /// </summary>
        /// <param name="array"></param>
        /// <param name="LocationX"></param>
        /// <param name="LocationY"></param>
        /// <returns></returns>        
        public static bool HasNeighbour(Tile[,] array, int LocationX, int LocationY, Direction direction)
        {
            if (LocationX < 10 && array[LocationX + 1, LocationY].Contains is Box && direction == Direction.Right)
            {
             //   Console.WriteLine("right is true");
                return true;
            }
            else if (LocationX > 0 && array[LocationX - 1, LocationY].Contains is Box && direction == Direction.Left)
            {
              //  Console.WriteLine("left is true");
                return true;
            }
            else if (LocationY < 10 && array[LocationX, LocationY + 1].Contains is Box && direction == Direction.Up)
            {
            //    Console.WriteLine("top is true");
                return true;
            }
            else if (LocationY < 0 && array[LocationX, LocationY - 1].Contains is Box && direction == Direction.Down)
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
