/*
 * On this form the user will be able to change the map to his design
 * in order to change the map we need the mapValue data from StartGame.
 * if we correctly recieved the data we will load the selected data in a RichTextBox.
 * clicking on the save button will save the changes
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VangDeVolgerSetup
{
    public partial class ChangeMap : Form
    {
        //obtaining data from start screen
        private string _mapValue { get; set; }
        //assigning the path to load the txt filer
        private string _levelModusPath { get; set; }     
        //basic filter to show when you save the filer
        private string _filter { get; set; }

        public ChangeMap()
        {
            InitializeComponent();

            lblMapName.Text = StartScreen.MyMapValue;
            _mapValue = lblMapName.Text.ToString();

            loadData(_mapValue);          
            _filter = "Map difficulty |*.txt";
        }

        private void loadData(string levelmodus)
        {
            //switching between easy, hard and crazy if we picked for 
            //example easy _levelModusPath will be filled with the easy path
            switch (levelmodus)
            {
                case "easy":
                    _levelModusPath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Levels\easy.txt");
                    break;
                case "hard":
                    _levelModusPath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Levels\hard.txt");
                    break;
                case "crazy":
                    _levelModusPath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Levels\crazy.txt");
                    break;
            }
            //using FileStream to read the txt file out in a richTextBox
            using (FileStream filestream = File.Open(_levelModusPath, FileMode.Open, FileAccess.Read))
            {
                //setting the chars to a byte array
                byte[] filetext = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                //while the file is not empty we put it on a RichTextBox
                while (filestream.Read(filetext, 0, filetext.Length) > 0)
                {                    
                    changeMapBox.Text = temp.GetString(filetext);
                }
            }
        } 

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile.DefaultExt = "*.txt";
            saveFile.FileName = _mapValue;
            saveFile.Filter = _filter;

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile.ShowDialog() == DialogResult.OK &&
               saveFile.FileName.Length >= 0)
            {
                // Save the contents of the RichTextBox into the file.
                changeMapBox.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
            }

            this.Close();
        }
    }
}
