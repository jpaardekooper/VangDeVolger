using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{
    class Hero : Sprite
    {
       
        public Hero(Form form) : base() 
        {
            PictureBox player = new PictureBox
            {
                Size = new Size(SpriteSize, SpriteSize),
                Location = new Point(SpriteSize * 0, SpriteSize * 0),
                Name = "player",
                Tag = "player",
                BackColor = Color.Blue
                
            };
            form.Controls.Add(player);
            Items.Add(player);
            player.BringToFront();



            foreach (PictureBox item in Items)
            Console.WriteLine(item.Name);
           
        }


    }
}
