/*
 * This is the parent class of the following classes: Hero, Box, Wall and Enemy
 * it has 1 method in order to keep them on the screen
 */
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    abstract public class Sprite
    {
        public enum Direction
        {
            Left, Right, Up, Down
        }
        public Direction SpriteDirection { get; set; }
        protected int _SpriteWidth { get; set; }
        protected int _SpriteHeight { get; set; }
        public int _SpriteSpeed { get; set; } // creating a integer called speed    
        protected PictureBox _PbSpriteContainer { get; set; } //creatnig a picturebox for all sprites
        protected int _MaxGameWidth { get; set; }
        protected int _MaxGameHeight { get; set; }
        
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
            ////stop sprite from moving against going out of the screen
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
