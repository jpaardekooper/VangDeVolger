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
            _PbSpriteContainer.Size = new Size(_SpriteWidth - 7, _SpriteHeight -7);
            _PbSpriteContainer.SizeMode = PictureBoxSizeMode.Zoom;
            _PbSpriteContainer.Image = Properties.Resources.enemyLeft;
        
 
        }

        /// <summary>
        /// Create the sprite of enemy and adding it to the form
        /// </summary>
        /// <param name="form"></param>
        public void CreateEnemyInstance(Form form2)
        {
            form2.Controls.Add(_PbSpriteContainer);
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


    }
}
