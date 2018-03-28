using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolgerSetup
{
    public class Highscore
    {
        public List<string> HighscoresList = new List<string>();   

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

        public void ReadAllHighScores(Game Form2)
        {
            using (FileStream fs = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    //  Console.WriteLine(temp.GetString(b));
                    Form2.boxAllHighScores.Text = temp.GetString(b);
                }

            }
            //let the highscore (richtextbox) show
            Form2.boxAllHighScores.Visible = true;
        }
      
    }
}
