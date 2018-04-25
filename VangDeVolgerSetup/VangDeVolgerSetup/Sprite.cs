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
        protected const int _SpriteSize = 40;       
        public int _SpriteSpeed { get; set; } // creating a integer called speed    
        protected PictureBox _PbSpriteContainer { get; set; } //creatnig a picturebox for all sprites
        protected const int _MaxGameWidth =  11 * 40;
        protected const int _MaxGameHeight = 12 * 40 + 60;

        public Sprite()
        {
            _SpriteSpeed = 0;
         
           
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
