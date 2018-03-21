using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolgerSetup
{
    abstract class Sprite
    {
        protected int _SpriteSpeed { get; set; } // creating a integer called speed    
        protected string _SpriteName { get; set; } 
        protected string _SpriteTag { get; set; }

        protected int _StartLocationX { get; set; }
        protected int _StartLocationY { get; set; }

        protected int _SpriteWidth { get; set; }
        protected int _SpriteHeight { get; set; }

        protected Image _SpriteImage { get; set; }

        public Sprite()
        {
            _SpriteSpeed = 0;
            _StartLocationX = 0;
            _StartLocationY = 0;
            _SpriteWidth = 40;
            _SpriteHeight = 40;
        }

    }
}
