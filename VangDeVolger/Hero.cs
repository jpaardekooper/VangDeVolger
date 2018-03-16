using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    class Hero : Tile
    {
        PictureBox _hero = new PictureBox(); // create a picture box 
        Timer Move = new Timer();
        public string Direction { get; set; } // creating a public string called direction
        public bool PlayerInput { get; set; } // creating a public string called direction


        public Hero() : base()
        {
            Name = "player";
            Tag = Name;
            Speed = 10;
            Y = 100;

            Move.Interval = 20; // set the timer interval to speed    
            Move.Tick += new EventHandler(Move_Tick); // assignment the timer with an event
            Move.Start(); // start the timer   

            Sprite = Properties.Resources.Nright;


        }

        public void mkHero(Form form)
        {
            _hero.Image = Sprite;
            _hero.Tag = Tag;
            _hero.Name = Name;
            _hero.Left = X;
            _hero.Top = Y;
            _hero.SizeMode = PictureBoxSizeMode.AutoSize;
            form.Controls.Add(_hero); // add the bullet to the screen
            _hero.BringToFront(); // bring the bullet to front of other objects
            //Console.WriteLine(_hero.Size);
        }

        public void Move_Tick(object sender, EventArgs e)
        {
            // if direction equals to left
            if (PlayerInput == true)
            {
                if (Direction == "left")
                {
                    _hero.Left -= Speed; // move bullet towards the left of the screen
                    _hero.Image = (Properties.Resources.Nleft);
                }
                // if direction equals right
                if (Direction == "right")
                {
                    _hero.Left += Speed; // move bullet towards the right of the screen
                    _hero.Image = (Properties.Resources.Nright);
                    
                }
                // if direction is up
                if (Direction == "up")
                {
                    _hero.Top -= Speed; // move the bullet towards top of the screen
                    //_hero.Image = (Properties.Resources.Nright);
                }
                // if direction is down
                if (Direction == "down")
                {
                    _hero.Top += Speed; // move the bullet bottom of the screen
                    //_hero.Image = (Properties.Resources.Nleft);
                }


                //stop hero from moving against walls of canvas
                //moving to right
                if (_hero.Left < 0)
                {
                    _hero.Left += Speed;
                }
                //moving to left
                if (_hero.Left > (1060 - _hero.Width))
                {
                    _hero.Left -= Speed;
                }
                //moving to top
                if (_hero.Top < 100)
                {
                    _hero.Top += Speed;
                }
                //moving to bottom
                if (_hero.Top > (458 - _hero.Width))
                {
                    _hero.Top -= Speed;
                }
            }
        }
    }
}