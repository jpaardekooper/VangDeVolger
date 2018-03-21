using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public enum HeroDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    class Hero : Sprite
    {
        private PictureBox _spriteHero = new PictureBox(); // create a picture box 
                                                           // Timer Move = new Timer();

        public HeroDirection HeroDirection { get; set; } // creating a public string called direction
        public bool PlayerInput { get; set; } // creating a public string called direction


        public Hero() : base()
        {

            _SpriteName = "player";
            _SpriteTag = _SpriteName;
            _SpriteSpeed = 10;
            //x is already 0 so that's correct
            _StartLocationY = 100;

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
            if (PlayerInput)
            {
                if (HeroDirection == HeroDirection.Left)
                {
                    _spriteHero.Left -= _SpriteSpeed; // move bullet towards the left of the screen
                    _spriteHero.Image = (Properties.Resources.Nleft);
                }
                // if direction equals right
                else if (HeroDirection == HeroDirection.Right)
                {
                    _spriteHero.Left += _SpriteSpeed; // move bullet towards the right of the screen
                    _spriteHero.Image = (Properties.Resources.Nright);

                }
                // if direction is up
                else if (HeroDirection == HeroDirection.Up)
                {
                    _spriteHero.Top -= _SpriteSpeed; // move the bullet towards top of the screen
                    //_hero.Image = (Properties.Resources.Nright);
                }
                // if direction is down
                else if (HeroDirection == HeroDirection.Down)
                {
                    _spriteHero.Top += _SpriteSpeed; // move the bullet bottom of the screen
                    //_hero.Image = (Properties.Resources.Nleft);
                }


                //stop hero from moving against walls of canvas
                //moving to right
                if (_spriteHero.Left < 0)
                {
                    _spriteHero.Left += _SpriteSpeed;
                }
                //moving to left
                if (_spriteHero.Left > (1060 - _spriteHero.Width))
                {
                    _spriteHero.Left -= _SpriteSpeed;
                }
                //moving to top
                if (_spriteHero.Top < 100)
                {
                    _spriteHero.Top += _SpriteSpeed;
                }
                //moving to bottom
                if (_spriteHero.Top > (700 - _spriteHero.Width))
                {
                    _spriteHero.Top -= _SpriteSpeed;
                }
            }
        }
    }
}