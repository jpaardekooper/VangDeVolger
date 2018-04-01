/*
 * Getting and Setting the data from Game.cs to Highscore RichTextBox
 * We need 3 params: playername, highscore and levelmodus
 */
using System;
using System.IO;
using System.Text;

namespace VangDeVolgerSetup
{
    public class Highscore
    {  
        private string _fileName { get; set; }
        private string _filePath { get; set; }

        private string _levelModus { get; set; }
        public string Levelmodus
        {
            get
            {
                return _levelModus;            
            }
            set
            {
                _levelModus = value;
            }
        }

        private string _highscore { get; set; }
        public string MyScore
        {
            get
            {
                return _highscore;
            }
            set
            {
                _highscore = value;
            }
        }

        private string _playerName { get; set; }
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
            }
        }
       
        public Highscore()
        {
            _fileName = "..\\..\\Highscores\\Highscores.txt";
            _filePath = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\Highscores\Highscores.txt");
        }

        /// <summary>
        /// this constructor needs the levelmodus, playersname and score
        /// in order to fill the screen
        /// </summary>
        /// <param name="lvl"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void showAllHighScores(string lvl, string name, string score)
        {          
            //adding parameters to the file
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName),
                    lvl + "  " + name + "  " + score + "  " + DateTime.Now.ToString() + Environment.NewLine);

            TextWriter tw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName), true);   
            // close the stream
            tw.Close();       
        }

        public void ReadAllHighScores(Game gameplatform)
        {
            using (FileStream readscores = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                //setting the data to a byte array
                byte[] fileScores = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                //reading all data out and but them on a RichTextBox
                while (readscores.Read(fileScores, 0, fileScores.Length) > 0)
                {
                    gameplatform.boxAllHighScores.Text = temp.GetString(fileScores);
                }

            }
            //let the highscore (richtextbox) show
            gameplatform.boxAllHighScores.Visible = true;
        }
      
    }
}
