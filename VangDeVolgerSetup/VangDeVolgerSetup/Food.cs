//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace VangDeVolgerSetup
//{
//    public class Food
//    {
//        public PictureBox[,] FoodImage = new PictureBox[30, 27];
//        public int Amount = 0;

//        private const int FoodScore = 10;
//        private const int SuperFoodScore = 13;

//        public void CreateFoodImages(Form formInstance)
//        {
//            for (int y = 0; y < 30; y++)
//            {
//                for (int x = 0; x < 27; x++)
//                {
//                    if (Form2.gameboard.Matrix[y, x] == 1 || Form2.gameboard.Matrix[y, x] == 2)
//                    {
//                        FoodImage[y, x] = new PictureBox();
//                        FoodImage[y, x].Name = "FoodImage" + Amount.ToString();
//                        FoodImage[y, x].SizeMode = PictureBoxSizeMode.StretchImage;
//                        FoodImage[y, x].Location = new Point(x * 16, y * 16);
//                        if (Form2.gameboard.Matrix[y, x] == 1)
//                        {
//                   //         FoodImage[y, x].Image = Properties.Resources.Block_1;
//                            FoodImage[y, x].BackColor = Color.Pink;
//                            Amount++;
//                        }
//                        else
//                        {
//                    //        FoodImage[y, x].Image = Properties.Resources.Block_2;
//                            FoodImage[y, x].BackColor = Color.Blue;
//                        }
//                        formInstance.Controls.Add(FoodImage[y, x]);
//                        FoodImage[y, x].BringToFront();

//                    }
//                }
//            }
//        }

//        public void EatFood(int x, int y)
//        {
//            // Eat food
//            FoodImage[x, y].Visible = false;
//            Form2.gameboard.Matrix[x, y] = 0;
//        //    Form2.player.UpdateScore(FoodScore);
//            Amount--;
//        //    if (Amount < 1) { Form2.player.LevelComplete(); }
//            //Form1.audio.Play(1);
//        }

//        public void EatSuperFood(int x, int y)
//        {
//            // Eat food
//            FoodImage[x, y].Visible = false;
//            Form2.gameboard.Matrix[x, y] = 0;
//           // Form1.player.UpdateScore(SuperFoodScore);
//         //   Form1.ghost.ChangeGhostState();
//        }
//    }
//}
