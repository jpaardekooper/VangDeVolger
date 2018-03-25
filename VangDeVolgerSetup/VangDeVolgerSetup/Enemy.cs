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
        public PictureBox _spriteEnemy = new PictureBox();
        public SpriteDirection EnemyDirection { get; set; } // creating a public string called direction
        public int EnemyHealth { get; set; }


        public Enemy() : base()
        {
            EnemyHealth = 100;

            _SpriteName = "enemy";
            _SpriteTag = _SpriteName;
            _SpriteSpeed = 3;
            _StartLocationX = (11 * 40 );
            _StartLocationY = (100 + (12 * 40) - _spriteEnemy.Height);
        }

        public void CreateEnemyInstance(Form form)
        {
            // this function will add the bullet to the game play
            // it is required to be called from the main class
            _spriteEnemy.Image = (Properties.Resources.enemyLeft);
            _spriteEnemy.Left = _StartLocationX;
            _spriteEnemy.Top = _StartLocationY;
            _spriteEnemy.Height = _SpriteHeight;
            _spriteEnemy.Width = _SpriteWidth;
            _spriteEnemy.SizeMode = PictureBoxSizeMode.Zoom;
            _spriteEnemy.BackColor = Color.Green;
            _spriteEnemy.Tag = _SpriteTag; // set the tag to bullet
            _spriteEnemy.Name = _SpriteName;
            _spriteEnemy.Bounds = _spriteEnemy.Bounds;

            form.Controls.Add(_spriteEnemy); // add the bullet to the screen
            _spriteEnemy.BringToFront(); // bring the bullet to front of other objects

        }

    }
}
