using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    public partial class Platform : Form
    {
        // public string facing;
        Hero player = new Hero(); //creates a new instance of the hero class
        Enemy enemy = new Enemy();
        private bool space;


        public Platform()
        {
            InitializeComponent();

            StartGame();
        //    Console.WriteLine(player.Width + "breedte\n" + player.Height);
        }

        private void StartGame()
        {
            //  player.direction = direct; //assignment the direction to the bullet
            player.mkHero(this); //run the function mkHero from the Hero.cs class
            enemy.mkEnemy(this);//run the function mkEnemy from the Enemy.cs class
            GenerateWalls(10);

        }

        private void GenerateWalls(int walls)
        {
            for (int i = 0; i < walls; ++i)
            {
                Wall wall = new Wall();
                wall.mkWall(this);

                Box box = new Box();
                box.mkBox(this);
            }
        }

        //when the Keys are UP
        private void Platform_KeyUp(object sender, KeyEventArgs e)
        {
            player.PlayerInput = false;
            space = false;
        }

        //when the Keys are Down
        private void Platform_KeyDown(object sender, KeyEventArgs e)
        {
            player.PlayerInput = true;

            //if we pressed left arrow
            if (e.KeyCode == Keys.Left)
            {
                player.Direction = "left";
            }
            //if we pressed left arrow
            if (e.KeyCode == Keys.Right)
            {
                player.Direction = "right";
            }
            if (e.KeyCode == Keys.Down)
            {
                player.Direction = "down";
            }
            if (e.KeyCode == Keys.Up)
            {
                player.Direction = "up";
            }


            if (e.KeyCode == Keys.Space) //if the pushing is higher than 0 we continue
            {
                space = true;
               
            }
        }

        private void GameEngine(object sender, EventArgs e)
        {

            //we check what variable x is doing 
            foreach (Control x in this.Controls)
            {
                //second for loop                
                //we can determine if they hit eachother
                foreach (Control j in this.Controls)
                {
                    //walll interaction
                    if ((j is PictureBox && j.Tag == "player") && (x is PictureBox && x.Tag == "wall"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width && player.Direction == "left")
                        {
                            ((PictureBox)j).Left += player.Speed;
                            if (space == true)
                            {
                                ((PictureBox)x).Left -= 50;                               
                            }
                        }
                        else if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width && player.Direction == "right")
                        {
                            ((PictureBox)j).Left -= player.Speed;
                            if (space == true)
                            {
                                ((PictureBox)x).Left += 50;
                            }
                        }
                        else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top && player.Direction == "down")
                        {
                            ((PictureBox)j).Top -= player.Speed;
                            if (space == true)
                            {
                                ((PictureBox)x).Top += 50;
                            }
                        }
                        else if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top && player.Direction == "up")
                        {
                            ((PictureBox)j).Top += player.Speed;
                            if (space == true)
                            {
                                ((PictureBox)x).Top -= 50;
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
                            ((PictureBox)j).Left += player.Speed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
                        {
                            ((PictureBox)j).Left -= player.Speed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
                        {
                            ((PictureBox)j).Top -= player.Speed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
                        {
                            ((PictureBox)j).Top += player.Speed;
                        }

                    }

                    //noy pushable boxes
                    if ((j is PictureBox && j.Tag == "enemy") && (x is PictureBox && x.Tag == "box"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left < x.Left + x.Width)
                        {
                            ((PictureBox)j).Left += player.Speed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Left > x.Left - x.Width)
                        {
                            ((PictureBox)j).Left -= player.Speed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top < x.Top)
                        {
                            ((PictureBox)j).Top -= player.Speed;
                        }
                        if (j.Bounds.IntersectsWith(x.Bounds) && j.Top > x.Top)
                        {
                            ((PictureBox)j).Top += player.Speed;
                        }

                    }

                    if ((j is PictureBox && j.Tag == "enemy") && (x is PictureBox && x.Tag == "player"))
                    {
                        //checking if the X loop is touching the J loop
                        //moving to the left of the wall
                        if (j.Left < x.Left + (x.Width / 3))
                        {
                            ((PictureBox)j).Left += enemy.Speed;
                        }
                        if (j.Left > x.Left - (x.Width / 3))
                        {
                            ((PictureBox)j).Left -= enemy.Speed;
                        }
                        if (j.Top < x.Top + (x.Height / 3))
                        {
                            ((PictureBox)j).Top += enemy.Speed;
                        }
                        if (j.Top > x.Top - (x.Width / 3))
                        {
                            ((PictureBox)j).Top -= enemy.Speed;
                        }

                    }
                }
            }
        }

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();

        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //     Graphics g = e.Graphics;

        //    int numOfCells = 1;
        //         int cellSize = 50;
        //      Pen p = new Pen(Color.Black);          

        //    for (int y = 0; y < numOfCells; ++y)
        //    {
        //           g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
        //        //Wall wall = new Wall();
        //        //wall.mkWall(this);
        //    }

        //    for (int x = 0; x < numOfCells; ++x)
        //    {
        //           g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
        //        //Wall wall = new Wall();
        //        //wall.mkWall(this);
        //    }
        //}

    }
}
