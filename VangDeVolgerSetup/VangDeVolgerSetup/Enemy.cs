using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    class Enemy : Sprite
    {
        PictureBox _spriteEnemy = new PictureBox();


        public Enemy() : base()
        {
            _SpriteName = "enemy";
            _SpriteTag = _SpriteName;
            _SpriteSpeed = 3;
            _StartLocationX = (12 * 40 - _spriteEnemy.Width / 2);
            _StartLocationY = (95 + 12 * 40 - _spriteEnemy.Height / 2);
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
            _spriteEnemy.Tag = _SpriteTag; // set the tag to bullet
            _spriteEnemy.Name = _SpriteName;

            form.Controls.Add(_spriteEnemy); // add the bullet to the screen
            _spriteEnemy.BringToFront(); // bring the bullet to front of other objects

        }
    }
}
