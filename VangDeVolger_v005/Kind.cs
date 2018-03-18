using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{
    class Kind : Mens
    {
        public Mens Enemy { get; set; }


        public Kind(Mens Enemy)
        {
            PictureBox computer = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(40 * 4, 40 * 4),
                Name = "pc",
                Tag = "pc",
                BackColor = Color.Red
            };
            computer.BringToFront();

            Name = "enemy";
            lastname = "test";

            this.Enemy = Enemy;
           
           
           

        }


    }
}
