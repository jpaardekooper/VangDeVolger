using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{
    public partial class Form2 : Form
    {
        public int levelmodus;
        public string MapName;
        public List<PictureBox> AllPictureBoxesOnTheField = new List<PictureBox>();

       
        public GenerateLevel Generatelevel = new GenerateLevel();

        public Form2()
        {
            InitializeComponent();
            
            label2.Text = Form1.MyTextBoxValue;

            MapName = label2.Text.ToString();

            //use private function _startGame to start the game
            _startGame();
            _initializePictureList();
            
        }

        private void _startGame()
        {
            Generatelevel.Name = MapName;

      //      Console.WriteLine(Generatelevel.Name);

            Generatelevel.ReadMyTextLevelFile(this, MapName);
            
         

        }

        private void _initializePictureList()
        {
            foreach (PictureBox x in Controls.OfType<PictureBox>())
            {
                AllPictureBoxesOnTheField.Add(x);
            }
            foreach(PictureBox s in AllPictureBoxesOnTheField)
            {
                Console.WriteLine(s.Name + s.Tag);
            }
        }
        


    }
}
