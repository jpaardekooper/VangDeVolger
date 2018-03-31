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
        private string _mapValue { get; set; }
        private string _levelModusPath { get; set; }     
        private string _filter { get; set; }

        public ChangeMap()
        {
            InitializeComponent();

            mapName.Text = StartScreen.myMapValue;
            _mapValue = mapName.Text.ToString();

            loadData(_mapValue);          
            _filter = "Map difficulty |*.txt";
        }

        private void loadData(string levelmodus)
        {

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

            using (FileStream filestream = File.Open(_levelModusPath, FileMode.Open, FileAccess.Read))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (filestream.Read(b, 0, b.Length) > 0)
                {
                    //  Console.WriteLine(temp.GetString(b));
                    richTextBox1.Text = temp.GetString(b);
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
                richTextBox1.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
            }

            this.Close();
        }
    }
}
