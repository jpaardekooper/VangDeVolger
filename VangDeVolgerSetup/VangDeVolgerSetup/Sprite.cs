using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        None
    }

    public enum SpriteType
    {
        empty,
        wall,
        box,
        enemy,
        player,
    }

    public abstract class Sprite
    {      
        protected int _SpriteWidth { get; set; }
        protected int _SpriteHeight { get; set; }    
        public int _SpriteSpeed { get; set; } // creating a integer called speed    
        protected PictureBox _PbSpriteContainer { get; set; }
        protected int _MaxGameWidth { get; set; }
        protected int _MaxGameHeight { get; set; }
        public SpriteType _SpriteType { get; set; }

        public Sprite()
        {
            _SpriteSpeed = 0;           
            _SpriteWidth = 40;
            _SpriteHeight = 40;
            _MaxGameWidth = 11 * 40;
            _MaxGameHeight = 12 * 40 + 60;
        }

        public void CheckForOutOfBounds()
        {
            ////stop hero from moving against walls of canvas
            ////moving to left
            if (_PbSpriteContainer.Left < 0)
            {
                _PbSpriteContainer.Left += _SpriteSpeed;
            }
            //moving to Right
            if (_PbSpriteContainer.Left > _MaxGameWidth)
            {
                _PbSpriteContainer.Left -= _SpriteSpeed;
            }
            //moving to top
            if (_PbSpriteContainer.Top < 100)
            {
                _PbSpriteContainer.Top += _SpriteSpeed;
            }
            //moving to bottom
            if (_PbSpriteContainer.Top > _MaxGameHeight)
            {
                _PbSpriteContainer.Top -= _SpriteSpeed;
            }
        }


    }
}
