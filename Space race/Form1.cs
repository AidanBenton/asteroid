using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
//please be carfull with the audio I wasnt able to find a solutuin to change the volume levels of the sounds so some of them are 
//louded then I would have liked them to, So just be carfull 
//in addition there was a startup sound that I wasnt able fix although it does kind of fit
namespace Space_race
{
    public partial class Form1 : Form
    {
        //input variables
        bool wDown;
        bool sDown;
        bool enter;
        bool Esc;

        bool upArrowDown;
        bool downArrowDown;

        //player stats
        int playerspeed = 5;

        int player1score = 0;
        int player2score = 0;

        //used to start game
        string gamestate = "title";

        //lists for astroid data storage 
        List<Rectangle> leftAstroids = new List<Rectangle>();
        List<int> leftAstroidsSpeeds = new List<int>();

        List<Rectangle> rightAstroids = new List<Rectangle>();
        List<int> rightAstroidsSpeeds = new List<int>();

        List<int> twentyCheck = new List<int>(20);

        bool check = false;

        //used for random astroid creation 
        Random randGen = new Random();
        int randValue = 0;

        //used for painting screen 
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //player rectangles 
        Rectangle player1 = new Rectangle(143, 345, 10, 10);
        Rectangle player2 = new Rectangle(452, 345, 10, 10);

        //sound media players
        System.Windows.Media.MediaPlayer menuSound = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer background = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer scoreSound = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer gameOver = new System.Windows.Media.MediaPlayer();


        public Form1()
        {
            InitializeComponent();

            //needed for sound media players to function
            menuSound.Open(new Uri(Application.StartupPath + "/Resources/Clink.wav"));

            scoreSound.Open(new Uri(Application.StartupPath + "/Resources/Score.wav"));

            gameOver.Open(new Uri(Application.StartupPath + "/Resources/gameOver.wav"));

            background.Open(new Uri(Application.StartupPath + "/Resources/Background.wav"));
            background.MediaEnded += new EventHandler(background_MediaEnded);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // player inputs 
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Enter:
                    enter = true;
                    break;
                case Keys.Escape:
                    Esc = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //player inputs 
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Enter:
                    enter = false;
                    break;
                case Keys.Escape:
                    Esc = false;
                    break;
            }

        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //I know its inefficiant to have the astroids running during times they arnt needed but this way when the player
            //starts the game the astoid feild is already full
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

            if (randValue < 10)
            {
                int y = randGen.Next(20, this.Height - 50);
                leftAstroids.Add(new Rectangle(-20, y, 20, 20));
                leftAstroidsSpeeds.Add(randGen.Next(2, 6));
            }

            if (randValue > 20 && randValue < 30)
            {
                int y = randGen.Next(20, this.Height - 50);
                rightAstroids.Add(new Rectangle(this.Width, y, 20, 20));
                rightAstroidsSpeeds.Add(randGen.Next(2, 6));
            }

            //checks to see if new astroids need to be created
            for (int i = 0; i < leftAstroids.Count; i++)
            {
                if (leftAstroids[i].X + 20 > this.Width)
                {
                    leftAstroids.RemoveAt(i);
                    leftAstroidsSpeeds.RemoveAt(i);
                    break;

                }

            }

            //checks to see if new astroids need to be created
            for (int i = 0; i < rightAstroids.Count; i++)
            {
                if (rightAstroids[i].X + 10 < 0)
                {
                    rightAstroids.RemoveAt(i);
                    rightAstroidsSpeeds.RemoveAt(i);
                    break;
                }

            }

            //checks the specific gamestate that is running
            if (gamestate == "title")
            {
                if (enter == true)
                {
                    gamestate = "running";
                    textLabel.Text = "";
                    menuSound.Stop();
                    menuSound.Play();
                    background.Play();
                }

                if (Esc == true)
                {
                    menuSound.Stop();
                    menuSound.Play();
                    this.Close();
                }
            }

            //game state check 
            if (gamestate == "running")
            {
                if (wDown == true)
                {
                    player1.Y -= playerspeed;
                }
                //was having trouble with the plus value as it doesnt make sence as my rectangle width
                //is only 20 pixels so im not sure why this was happening but I just guessed and checked
                if (sDown == true && player1.Y < this.Height - player1.Height - 5)
                {
                    player1.Y += playerspeed;
                }

                if (upArrowDown == true)
                {
                    player2.Y -= playerspeed;
                }
                //was having trouble with the plus value as it doesnt make sence as my rectangle width
                //is only 20 pixels so im not sure why this was happening but I just guessed and checked
                if (downArrowDown == true && player2.Y < this.Height - player2.Height - 5)
                {
                    player2.Y += playerspeed;
                }


                //Checks for player intercection with astroids 
                for (int i = 0; i < leftAstroids.Count; ++i)
                {
                    if (player1.IntersectsWith(leftAstroids[i]))
                    {
                        gameOver.Stop();
                        gameOver.Play();
                        player1.Y = 340;
                    }

                    if (player2.IntersectsWith(leftAstroids[i]))
                    {
                        gameOver.Stop();
                        gameOver.Play();
                        player2.Y = 340;
                    }
                }

                for (int i = 0; i < rightAstroids.Count; ++i)
                {
                    if (player1.IntersectsWith(rightAstroids[i]))
                    {
                        gameOver.Stop();
                        gameOver.Play();
                        player1.Y = 340;
                    }

                    if (player2.IntersectsWith(rightAstroids[i]))
                    {
                        gameOver.Stop();
                        gameOver.Play();
                        player2.Y = 340;
                    }
                }
                //player scoreing 
                if (player1.Y < 0)
                {
                    player1.Y = 340;
                    player1score++;
                    scoreSound.Stop();
                    scoreSound.Play();
                }

                if (player2.Y < 0)
                {
                    player2.Y = 340;
                    player2score++;
                    scoreSound.Stop();
                    scoreSound.Play();
                }

                //player score being displayed
                if (player1score > 0)
                {
                    playerOneLabel.Text = $"{player1score}";
                }

                if (player2score > 0)
                {
                    playerTwoLabel.Text = $"{player2score}";
                }

                //changing game state
                if (player1score == 3)
                {
                    background.Stop();
                    gamestate = "End";
                    Refresh();

                }
                if (player2score == 3)
                {
                    background.Stop();
                    gamestate = "End";
                    Refresh();

                }
            }

            //The end game state
            if (gamestate == "End")
            {
                if (enter == true)
                {
                    menuSound.Stop();
                    menuSound.Play();
                    background.Play();
                    gamestate = "running";
                    textLabel.Text = "";
                    player1score = 0;
                    player2score = 0;
                    Refresh();
                }
                if (Esc == true)
                {
                    menuSound.Stop();
                    menuSound.Play();
                    this.Close();
                }
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //graphics used for the boarder
            e.Graphics.FillRectangle(whiteBrush, 0, 0, this.Width, 5);
            e.Graphics.FillRectangle(whiteBrush, 0, 0, 5, this.Height);
            e.Graphics.FillRectangle(whiteBrush, this.Width - 5, 0, 5, this.Height);
            e.Graphics.FillRectangle(whiteBrush, 0, this.Height - 5, this.Width, 5);

            //Gamestate chek 
            if (gamestate == "title")
            {
                textLabel.Text = $"SPACE RACE\n\n\nEnter: Play\nEsc: Exit";
            }

            else if (gamestate == "running")
            {
                //paints players and astroids 
                e.Graphics.FillRectangle(whiteBrush, player1);
                e.Graphics.FillRectangle(whiteBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, 295, 0, 5, 400);
                for (int i = 0; i < leftAstroids.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, leftAstroids[i]);
                }

                for (int i = 0; i < rightAstroids.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, rightAstroids[i]);
                }

            }

            //game has ended 
            else
            {
                if (player1score == 3)
                {
                    textLabel.Text = $"PLAYER ONE WINS\n\nEnter: Play\nEsc: Exit";
                }

                if (player2score == 3)
                {
                    textLabel.Text = $"PLAYER TWO WINS\n\nEnter: Play\nEsc: Exit";
                }

                playerOneLabel.Text = "";
                playerTwoLabel.Text = "";
            }
        }


        //used for looping back sound
        private void background_MediaEnded(object sender, EventArgs e)

        {
            background.Stop();
            background.Play();
        }
    }
}
