using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    class Enemy : Tile
    {
        PictureBox _enemy = new PictureBox();
       

        public Enemy() : base()
        {
            Name = "enemy";
            Tag = Name;
            Speed = 3;
            X = 1060 - _enemy.Width;
            Y = 458 - _enemy.Height;           
        }

        public void mkEnemy(Form form)
        {
            // this function will add the bullet to the game play
            // it is required to be called from the main class
            _enemy.Image = (Properties.Resources.enemyLeft);
            _enemy.Left = X;
            _enemy.Top = Y;
            _enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            _enemy.Tag = Tag; // set the tag to bullet
            _enemy.Name = Name;
            
            form.Controls.Add(_enemy); // add the bullet to the screen
            _enemy.BringToFront(); // bring the bullet to front of other objects

        }
    }
}
