using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{


    class Hero : Sprite
    {
        public PictureBox _spriteHero = new PictureBox(); // create a picture box    
        public SpriteDirection HeroDirection { get; set; } // creating a public string called direction
       


        public Hero() : base()
        {
            _SpriteSpeed = 10;
            _SpriteName = "player";
            _SpriteTag = _SpriteName;
            //x is already 0 so that's correct
            // _StartLocationY = 100;

            //testing
            _StartLocationY = 11*40;
            _StartLocationX = 11 * 40;

            //Move.Interval = 20; // set the timer interval to speed    
            //Move.Tick += new EventHandler(Move_Tick); // assignment the timer with an event
            //Move.Start(); // start the timer   

            _SpriteImage = Properties.Resources.Nright;
        }

        public void CreateHeroInstance(Form form)
        {
            _spriteHero.Image = _SpriteImage;
            _spriteHero.Tag = _SpriteTag;
            _spriteHero.Name = _SpriteName;
            _spriteHero.Left = _StartLocationX;
            _spriteHero.Height = _SpriteHeight;
            _spriteHero.Width = _SpriteWidth;
            _spriteHero.Top = _StartLocationY;
            _spriteHero.SizeMode = PictureBoxSizeMode.Zoom;
            form.Controls.Add(_spriteHero); // add the bullet to the screen
            _spriteHero.BringToFront(); // bring the bullet to front of other objects
            //Console.WriteLine(_hero.Size);
        }

        // public void Move_Tick(object sender, EventArgs e)
        public void Move_Tick()
        {
            // if direction equals to left

            if (HeroDirection == SpriteDirection.Left)
            {
                _spriteHero.Left -= _SpriteSpeed; // move bullet towards the left of the screen
                _spriteHero.Image = (Properties.Resources.Nleft);
            }
            // if direction equals right
            if (HeroDirection == SpriteDirection.Right)
            {
                _spriteHero.Left += _SpriteSpeed; // move bullet towards the right of the screen
                _spriteHero.Image = (Properties.Resources.Nright);

            }
            // if direction is up
            if (HeroDirection == SpriteDirection.Up)
            {
                _spriteHero.Top -= _SpriteSpeed; // move the bullet towards top of the screen
                                                 //_hero.Image = (Properties.Resources.Nright);
            }
            // if direction is down
            if (HeroDirection == SpriteDirection.Down)
            {
                _spriteHero.Top += _SpriteSpeed; // move the bullet bottom of the screen
                                                 //_hero.Image = (Properties.Resources.Nleft);
            }
            if (HeroDirection == SpriteDirection.None)
            {
                _SpriteSpeed = 0;
            }


            //stop hero from moving against walls of canvas
            //moving to left
            if (_spriteHero.Left < 0)
            {
                _spriteHero.Left += _SpriteSpeed;
            }
            //moving to Right
            if (_spriteHero.Left > (12 * 40 - _spriteHero.Width))
            {
                _spriteHero.Left -= _SpriteSpeed;
            }
            //moving to top
            if (_spriteHero.Top < 100)
            {
                _spriteHero.Top += _SpriteSpeed;
            }
            //moving to bottom
            if (_spriteHero.Top > (12 * 40 - _spriteHero.Height / 2 + 80))
            {
                _spriteHero.Top -= _SpriteSpeed;
            }

        }
    }
}