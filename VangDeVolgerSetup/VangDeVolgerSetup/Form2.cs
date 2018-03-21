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
        Hero spriteHero = new Hero();
        Enemy spriteEnemy = new Enemy();
        public int levelmodus;
        public string MapName;
        //need to get the current setup game with
       // public int GameWidth;
        private bool _spaceDown;

        

        PictureBox player;
        PictureBox enemy;
        PictureBox wall;
        PictureBox box;
        PictureBox empty;

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

           // GameWidth = AllPictureBoxesOnTheField.Count  40;
         //   Console.WriteLine(GameWidth);


        }

        private void _startGame()
        {
            Generatelevel.Name = MapName;

      //      Console.WriteLine(Generatelevel.Name);

            Generatelevel.ReadMyTextLevelFile(this, MapName);
            _loadsprites();

        }
        private void _loadsprites()
        {
            spriteHero.CreateHeroInstance(this); //run the function CreateHeroInstance from the Hero.cs class
            spriteEnemy.CreateEnemyInstance(this); //run the function CreateEnemyInstance from the Enemy.cs class
        }

        private void _initializePictureList()
        {
            //foreach (PictureBox x in Controls.OfType<PictureBox>())
            //{
            //    AllPictureBoxesOnTheField.Add(x);
            //}
            //for (int i = 0; i < AllPictureBoxesOnTheField.Count; i++)
            //{
            //    if (AllPictureBoxesOnTheField[i].Tag.Equals("player"))
            //    {
            //        player = AllPictureBoxesOnTheField[i];
            //        Console.WriteLine(player.Name);
            //    }
            //    if (AllPictureBoxesOnTheField[i].Tag.Equals("enemy"))
            //    {
            //        enemy = AllPictureBoxesOnTheField[i];
            //        Console.WriteLine(enemy.Name);
            //    }              
            //}
            //foreach (PictureBox w in AllPictureBoxesOnTheField)
            //{
            //    //    Console.WriteLine(s.Name + s.Tag);
            //    if (w.Tag.Equals("wall"))
            //    {
            //        wall = w;
            //        Console.WriteLine(wall.Name + "name");

            //    }            

            //}

            //foreach (PictureBox b in AllPictureBoxesOnTheField)
            //{
            //    if (b.Tag.Equals("box"))
            //    {
            //        box = b;
            //        Console.WriteLine(box.Name);
            //    }
            //}
        }

        private void GameEngine(object sender, EventArgs e)
        {
            //walll interaction
            //if ((player is PictureBox && player.Tag == "player") && (wall is PictureBox && wall.Tag == "wall"))
            //{
            //    //checking if the X loop is touching the J loop
            //    //moving to the left of the wall
            //    if (player.Bounds.IntersectsWith(wall.Bounds) && player.Left < wall.Left + wall.Width && spriteHero.HeroDirection == HeroDirection.Left)
            //    {
            //        ((PictureBox)player).Left += spriteHero._SpriteSpeed;
            //        if (_spaceDown == true)
            //        {
            //            ((PictureBox)wall).Left -= 50;
            //        }
            //    }
            //    else if (player.Bounds.IntersectsWith(wall.Bounds) && player.Left > wall.Left - wall.Width && spriteHero.HeroDirection == HeroDirection.Right)
            //    {
            //        ((PictureBox)player).Left -= spriteHero._SpriteSpeed;
            //        if (_spaceDown == true)
            //        {
            //            ((PictureBox)wall).Left += 50;
            //        }
            //    }
            //    else if (player.Bounds.IntersectsWith(wall.Bounds) && player.Top < wall.Top && spriteHero.HeroDirection == HeroDirection.Down)
            //    {
            //        ((PictureBox)player).Top -= spriteHero._SpriteSpeed;
            //        if (_spaceDown == true)
            //        {
            //            ((PictureBox)wall).Top += 50;
            //        }
            //    }
            //    else if (player.Bounds.IntersectsWith(wall.Bounds) && player.Top > wall.Top && spriteHero.HeroDirection == HeroDirection.Up)
            //    {
            //        ((PictureBox)player).Top += spriteHero._SpriteSpeed;
            //        if (_spaceDown == true)
            //        {
            //            ((PictureBox)wall).Top -= 50;
            //        }
            //    }
            //}
            foreach (PictureBox x in Controls.OfType<PictureBox>())
            {
                //second for loop                
                //we can determine if they hit eachother
                foreach (PictureBox j in Controls.OfType<PictureBox>())
                {
                    //walll interaction
                    if ((j is PictureBox && j.Tag == "player") && (x is PictureBox && x.Tag == "wall"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width && spriteHero.HeroDirection == HeroDirection.Left)
                        {
                            ((PictureBox)j).Left += spriteHero._SpriteSpeed;
                            if (_spaceDown == true)
                            {
                                ((PictureBox)x).Left -= 40;
                            }
                        }
                        else if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width && spriteHero.HeroDirection == HeroDirection.Right)
                        {
                            ((PictureBox)j).Left -= spriteHero._SpriteSpeed;
                            if (_spaceDown == true)
                            {
                                ((PictureBox)x).Left += 40;
                            }
                        }
                        else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top && spriteHero.HeroDirection == HeroDirection.Down)
                        {
                            ((PictureBox)j).Top -= spriteHero._SpriteSpeed;
                            if (_spaceDown == true)
                            {
                                ((PictureBox)x).Top += 40;
                            }
                        }
                        else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top && spriteHero.HeroDirection == HeroDirection.Up)
                        {
                            ((PictureBox)j).Top += spriteHero._SpriteSpeed;
                            if (_spaceDown == true)
                            {
                                ((PictureBox)x).Top -= 40;
                            }
                        }
                    }

                    //Enemy and wall collision

                    if ((j is PictureBox && j.Tag == "enemy") && (x is PictureBox && x.Tag == "wall"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
                        {
                            ((PictureBox)j).Left += spriteHero._SpriteSpeed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
                        {
                            ((PictureBox)j).Left -= spriteHero._SpriteSpeed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
                        {
                            ((PictureBox)j).Top -= spriteHero._SpriteSpeed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
                        {
                            ((PictureBox)j).Top += spriteHero._SpriteSpeed;
                        }

                    }

                    //noy pushable boxes
                    if ((j is PictureBox && j.Tag == "enemy") && (x is PictureBox && x.Tag == "box"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
                        {
                            ((PictureBox)j).Left += spriteHero._SpriteSpeed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
                        {
                            ((PictureBox)j).Left -= spriteHero._SpriteSpeed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
                        {
                            ((PictureBox)j).Top -= spriteHero._SpriteSpeed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
                        {
                            ((PictureBox)j).Top += spriteHero._SpriteSpeed;
                        }

                    }

                    if ((j is PictureBox && j.Tag == "enemy") && (x is PictureBox && x.Tag == "player"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Left < x.Left + (x.Width / 3))
                        {
                            ((PictureBox)j).Left += spriteEnemy._SpriteSpeed;
                        }
                        if (j.Left > x.Left - (x.Width / 3))
                        {
                            ((PictureBox)j).Left -= spriteEnemy._SpriteSpeed;
                        }
                        if (j.Top < x.Top + (x.Height / 3))
                        {
                            ((PictureBox)j).Top += spriteEnemy._SpriteSpeed;
                        }
                        if (j.Top > x.Top - (x.Width / 3))
                        {
                            ((PictureBox)j).Top -= spriteEnemy._SpriteSpeed;
                        }

                    }
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            spriteHero.PlayerInput = true;

            //if we pressed left arrow
            if (e.KeyCode == Keys.Left)
            {
                spriteHero.HeroDirection = HeroDirection.Left;
                spriteHero.Move_Tick();
            }
            //if we pressed left arrow
            else if (e.KeyCode == Keys.Right)
            {
                spriteHero.HeroDirection = HeroDirection.Right;
                spriteHero.Move_Tick();
            }
            else if (e.KeyCode == Keys.Down)
            {
                spriteHero.HeroDirection = HeroDirection.Down;
                spriteHero.Move_Tick();
            }
            else if (e.KeyCode == Keys.Up)
            {
                spriteHero.HeroDirection = HeroDirection.Up;
                spriteHero.Move_Tick();
            }


            else if (e.KeyCode == Keys.Space) //if the pushing is higher than 0 we continue
            {
                _spaceDown = true;

            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            spriteHero.PlayerInput = false;
            _spaceDown = false;
        }
    }
}
