using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    class Hero : Sprite
    {
        //    public PictureBox _spriteHero = new PictureBox(); // create a picture box    
        public Direction HeroDirection { get; set; } // creating a public string called direction
        public int HeroHealth { get; set; }
        public Timer Move = new Timer();
        public bool PlayerInput { get; set; } // creating a public string called direction

        public Hero() : base()
        {
            HeroHealth = 100;
            _SpriteSpeed = 5;
            _PbSpriteContainer = new PictureBox();
            _PbSpriteContainer.Name = "player";
            _PbSpriteContainer.Tag = _PbSpriteContainer.Name;  
            _PbSpriteContainer.Top = 100;
            _PbSpriteContainer.Size = new Size(_SpriteWidth, _SpriteHeight);
            _PbSpriteContainer.SizeMode = PictureBoxSizeMode.Zoom;
            _PbSpriteContainer.Image = Properties.Resources.Nright;

            Move.Interval = 24; // set the timer interval to speed    
            Move.Tick += new EventHandler(Move_Tick); // assignment the timer with an event
            Move.Start(); // start the timer   
        }

        public void CreateHeroInstance(Game gameplatform)
        {
            gameplatform.Controls.Add(_PbSpriteContainer); // add the hero to the screen
            _PbSpriteContainer.BringToFront(); // bring the hero to front of other objects    
        }

        public void HeroIsDeath(Game gameplatform)
        {
            _PbSpriteContainer.Image = Properties.Resources.death_5;
            _PbSpriteContainer.SizeMode = PictureBoxSizeMode.Zoom;
            gameplatform.Controls.Add(_PbSpriteContainer); // add the bullet to the screen
            _PbSpriteContainer.BringToFront(); // bring the bullet to front of other objects
        }

        public void Move_Tick(object sender, EventArgs e)
        {
            if (PlayerInput == true)
            {
                // if direction equals left
                if (HeroDirection == Direction.Left)
                {
                    _PbSpriteContainer.Left -= _SpriteSpeed; // move hero towards the left of the screen
                    _PbSpriteContainer.Image = (Properties.Resources.Nleft);
                }
                // if direction equals right
                else if (HeroDirection == Direction.Right)
                {
                    _PbSpriteContainer.Left += _SpriteSpeed; // move hero towards the right of the screen
                    _PbSpriteContainer.Image = (Properties.Resources.Nright);
                }
                // if direction is up
                else if (HeroDirection == Direction.Down)
                {
                    _PbSpriteContainer.Top += _SpriteSpeed; // move the hero to  bottom of the screen
                }
                // if direction is down
                else if (HeroDirection == Direction.Up)
                {
                    _PbSpriteContainer.Top -= _SpriteSpeed;// move the bullet bottom of the screen
                }
            }
        }
    }
}