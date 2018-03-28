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
        private string _mapValue;
        private string _levelModusPath;
        private string filelocation = string.Empty;
        OpenFileDialog openFile1 = new OpenFileDialog();



        public ChangeMap()
        {
            InitializeComponent();

            mapName.Text = StartScreen.myMapValue;
            _mapValue = mapName.Text.ToString();            

            loadData(_mapValue);

        }

        private void loadData(string levelmodus)
        {
           
            switch (levelmodus)
            {
                case "easy":
                    _levelModusPath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Levels\easy.txt");
                    //    Console.WriteLine(_levelModus);
                    break;

                case "hard":
                    _levelModusPath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Levels\hard.txt");
                    //   Console.WriteLine(_levelModus);
                    break;
            }

            // Initialize the filter to look for text files.
            openFile1.Filter = "Text Files|*.txt";

            //string text =Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Levels\\Easy.txt")


            using (FileStream fs = File.Open(_levelModusPath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                  //  Console.WriteLine(temp.GetString(b));
                    richTextBox1.Text = temp.GetString(b);
                }            
              
            }
        }

        private void ChangeMap_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.FileName = _mapValue;
            saveFile1.Filter = "txt Files|*.txt";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == DialogResult.OK &&
               saveFile1.FileName.Length >= 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }

            this.Close();
        }
    }
}
