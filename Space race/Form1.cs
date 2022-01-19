using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_race
{
    public partial class Form1 : Form
    {
        bool wDown;
        bool sDown;
        bool aDown;
        bool dDown;

        bool upArrowDown;
        bool downArrowDown;
        bool leftArrowDown;
        bool rightArrowDown;

        int playerspeed = 5;
        int playersize = 10;

        List<Rectangle> leftAstroids = new List<Rectangle>();
        List<int> leftAstroidsSpeeds = new List<int>();

        List<Rectangle> rightAstroids = new List<Rectangle>();
        List<int> rightAstroidsSpeeds = new List<int>();

        List<int> twentyCheck = new List<int>(20);

        bool check = false;

        Random randGen = new Random();
        int randValue = 0; 

        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Rectangle player1 = new Rectangle(143, 340, 10, 10);
        Rectangle player2 = new Rectangle(427, 340, 10, 10); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }

        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (wDown == true && player1.Y >= 0)
            {
                player1.Y -= playerspeed;
            }
            //was having trouble with the plus value as it doesnt make sence as my rectangle width
            //is only 20 pixels so im not sure why this was happening but I just guessed and checked
            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerspeed;
            }
            if (aDown == true && player1.X >= 0)
            {
                player1.X -= playerspeed;
            }
            if (dDown == true && player1.X <this.Width - player1.Width)
            {
                player1.X += playerspeed;
            }

            if (upArrowDown == true && player2.Y >= 0)
            {
                player2.Y -= playerspeed;
            }
            //was having trouble with the plus value as it doesnt make sence as my rectangle width
            //is only 20 pixels so im not sure why this was happening but I just guessed and checked
            if (downArrowDown == true && player2.Y + 65 <= this.Height)
            {
                player2.Y += playerspeed;
            }
            if (leftArrowDown == true && player2.X >= 0)
            {
                player2.X -= playerspeed;
            }
            if (rightArrowDown == true && player2.X + 40 <= this.Width)
            {
                player2.X += playerspeed;
            }

            //moves astroids
            for (int i = 0; i < leftAstroids.Count(); i++)
            {
                //usings astroidspeed variable to make the astroids move at differant speeds
                int x = leftAstroids[i].X + leftAstroidsSpeeds[i];
                leftAstroids[i] = new Rectangle(x, leftAstroids[i].Y, 10, 5); 
            }

            for (int i = 0; i < rightAstroids.Count(); i++)
            {
                //usings astroidspeed variable to make the astroids move at differant speeds
                int x = rightAstroids[i].X - rightAstroidsSpeeds[i];
                rightAstroids[i] = new Rectangle(x, rightAstroids[i].Y, 10, 5);
            }

            //creates new astroids 
            randValue = randGen.Next(0, 101); 

            if(randValue < 20)
            {
                int y = randGen.Next(20, this.Height - 20);
                for (int i = 0; i < leftAstroids.Count && check == false; i++)
                {  
                    for (int j = 0; j < twentyCheck.Count; j++)
                    {
                        if (y == leftAstroids[i].X + j && y == rightAstroids[i].X + j)
                        {
                           y = randGen.Next(20, this.Height - 20);
                        }
                    }
                }
                leftAstroids.Add(new Rectangle(-20 , y, 20, 20));
                leftAstroidsSpeeds.Add(randGen.Next(2, 6)); 
            }

            if (randValue > 20 && randValue < 40)
            {
                int y = randGen.Next(20, this.Height - 20);
                for (int i = 0; i < rightAstroids.Count && check == false; i++)
                {
                    for (int j = 0; j < twentyCheck.Count; j++)
                    {
                        if (y == leftAstroids[i].X + j && y == rightAstroids[i].X + j)
                        {
                            y = randGen.Next(20, this.Height - 20);
                        }
                    }
                }
                rightAstroids.Add(new Rectangle(this.Width, y, 20, 20));
                rightAstroidsSpeeds.Add(randGen.Next(2, 6));
            }

            //checks to see if new astroids need to be created
            for (int i = 0; i < leftAstroids.Count; i++)
            {
                if (leftAstroids[i].X + 20 > this.Width)
                {
                    leftAstroids.RemoveAt(i);
                    leftAstroidsSpeeds.Remove(i);
                }

            }

            //checks to see if new astroids need to be created
            for (int i = 0; i < rightAstroids.Count; i++)
            {
                if (rightAstroids[i].X + 10 < 0)
                {
                    rightAstroids.RemoveAt(i);
                    rightAstroidsSpeeds.Remove(i);
                }

            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, player1);
            e.Graphics.FillRectangle(whiteBrush, player2);
            
            for (int i = 0; i < leftAstroids.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, leftAstroids[i]); 
            }

            for (int i = 0; i < rightAstroids.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, rightAstroids[i]);
            }
        }
    }
}
