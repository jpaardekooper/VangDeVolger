using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger_v005
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public class Settings
    {
      
        public static Direction direction { get; set; }

        public Settings()
        {
           
            direction = Direction.Down;
        }
    }
}
