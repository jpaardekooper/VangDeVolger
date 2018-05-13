/***
 * A Winning game has a Highscore 
 * */
using System;
using System.IO;
using System.Text;

namespace VangDeVolgerSetup
{
    class Highscore
    {
        private string _fileName { get; set; }
        private string _filePath { get; set; } 

        /// <summary>
        /// Highscore constructor
        /// default constructore of Highscore
        /// defining the filename and path
        /// </summary>
        public Highscore()
        {
            //defining the fileName highscore.Txt
            _fileName = "..\\..\\Highscore\\Highscore.txt";
            //highscore.txt is located at the _filePath location
            _filePath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Highscore\Highscore.txt");
        }

        /// <summary>
        /// this constructor needs the levelmodus, playersname and score in order to fill the screen       
        /// </summary>
        /// <param name="mapname"></param>
        /// <param name="playername"></param>
        /// <param name="score"></param>
        public void showAllHighScores(string mapname, string playername, string score)
        {
            //adding parameters to the file 
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName),
                //adding tabs in the textfile in order to fill it out
                    mapname + "\t" + playername + "\t  " + score + "\t " + DateTime.Now.ToString() + Environment.NewLine);
            

            TextWriter tw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName), true);
            // close the stream
            tw.Close();
        }

        public void ReadAllHighScores(Game gameplatform)
        {
            //using filestream in order to open the file and read the data
            using (FileStream readscores = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                //setting the data to a byte array
                byte[] fileScores = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                //reading all data out and but them on a RichTextBox
                while (readscores.Read(fileScores, 0, fileScores.Length) > 0)
                {
                    //the richttextbox from form Game will get the data from _filename (highscore.txt)
                    gameplatform.boxAllHighScores.Text = temp.GetString(fileScores);
                }
            }
            //let the highscore (richtextbox) show
            gameplatform.boxAllHighScores.Visible = true;
        }

    }
}
