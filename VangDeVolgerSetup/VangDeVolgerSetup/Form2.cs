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
      
        private Block[,] myBlock = new Block[15, 15];

        public GenerateLevel _generatelevel = new GenerateLevel();

        public Form2()
        {
            InitializeComponent();
            
            label2.Text = Form1.MyTextBoxValue;

            MapName = label2.Text.ToString();

            //use private function _startGame to start the game
            _startGame();

        }

        private void _startGame()
        {
            _generatelevel.Name = MapName;

            Console.WriteLine(_generatelevel.Name);

            _generatelevel.LoadMyTextLevel(this, MapName);

        }
        


    }
}
