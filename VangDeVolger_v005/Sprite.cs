using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger_v005
{

    public class Sprite
    {
        public List<PictureBox> Items { get; set; }

        public PictureBox[,] GameSpriteBoxes;

        public int Speed { get; set; }

        public static int SpriteSize { get; set; }
        public static int GridSize { get; set; }


        protected Random rng = new Random();



        public Sprite()
        {
            Items = new List<PictureBox>();


            SpriteSize = 40;
            GridSize = 12;

            GameSpriteBoxes = new PictureBox[GridSize, GridSize];
            // initialize the "chess board"         

            // double for loop to handle all rows and columns
            for (int i = 0; i < Items.Count; i++)
            {
                // form.Controls.Add(Items[i]);
                Items[i].BringToFront();
            }
            foreach (PictureBox item in Items)
            {
                Console.Write(item.Name + " ");
            }



        }
    }
}