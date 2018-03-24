using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolgerSetup
{

    public class GenerateLevel
    {
        //creating a private _name instance to set the game modus of the game (easy, hard, crazy)
        private string _name { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }    

        //basic information of the picturebox (pb) width, height and position 
        private int _pbHeight = 40;
        private int _pbWidth = 40;
        private int _currentPositionX = 0;
        private int _currentPositionY = 0;
        private int _placement = 0;
        private string _levelModus = string.Empty;

        public void ReadMyTextLevelFile(Form2 Form2, string Name)
        {
            //if we get an error show it
            if (Name.Equals(""))
            {
                MessageBox.Show("no level found");
            }

            //filling the levelModus          
            switch (Name)
            {
                case "easy":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\easy.txt");
                    //    Console.WriteLine(_levelModus);
                    break;

                case "hard":
                    _levelModus = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\hard.txt");
                    //   Console.WriteLine(_levelModus);
                    break;
            }
            using (StreamReader strReader = new StreamReader(_levelModus))
            {

                string strLine = string.Empty;
                while ((strLine = strReader.ReadLine()) != null)
                {
                    string[] stringLineArray = strLine.Split(' ');
                    foreach (string c in stringLineArray)
                    {
                        Button tile3 = new Button
                        {
                            Size = new Size(_pbHeight, _pbWidth)
                        };
                        switch (c)
                        {
                            case "D":                              
                                Box Box = new Box(_currentPositionX, _currentPositionY + 100);
                                Form2.Controls.Add(Box.spriteBox);  //adding the tile to Form2 so we can see it   
                                Box.spriteBox.BringToFront();
                              
                                break;
                            case "V":
                                Wall Wall = new Wall(_currentPositionX, _currentPositionY + 100);
                                Form2.Controls.Add(Wall.spriteWall);  //adding the tile to Form2 so we can see it   
                                Wall.spriteWall.BringToFront();
                                break;
                            case "N":
                                tile3.Name = "empty";
                                tile3.Tag = "empty";

                                break;
                                //catching the error
                            case "?":

                                tile3.Name = "empty";
                                tile3.Tag = "empty";
                                break;

                        }
                        //default background ( a grey tile)
                        tile3.Enabled = false;                       
                        tile3.Image = Properties.Resources.empty;
                        tile3.Location = new Point(_currentPositionX, _currentPositionY + 100);

                        Form2.Controls.Add(tile3);  //adding the tile to Form2 so we can see it  
                        //its not a bug but a feature
                        if (Name.Equals("crazy"))
                        {
                            Console.WriteLine("crazy");
                            tile3.BringToFront();
                        }                          
                        _currentPositionX += _pbWidth;  //while we are in the loop we place the tiles on the form2 we increase the positionX + 1 
                    }             
                    _currentPositionX = _placement;
                    _currentPositionY += _pbHeight;   //adding small margin between each tile
                }
                strReader.Close();
            }
        }
    }
}
