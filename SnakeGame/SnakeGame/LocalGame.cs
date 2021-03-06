using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class LocalGame : Form
    {
        Client remoteServer;
        String serverIp;
        int serverPort;

        Random rand;
        enum GameFields
        {
            Free,
            Snake,
            Food
        };

        enum Directions
        {
            Up,
            Down,
            Left,
            Right
        };

        struct SnakeCoord
        {
            public int x;
            public int y;
        }

        int point;
        int highScore;
        GameFields[,] gameFields;
        SnakeCoord[] snakeCoord;
        int SnakeLenght;
        Directions directions;
        Graphics graphics;

        public LocalGame()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (directions != Directions.Down)
                        directions = Directions.Up;
                    break;
                case Keys.Down:
                    if (directions != Directions.Up)
                        directions = Directions.Down;
                    break;
                case Keys.Left:
                    if (directions != Directions.Right)
                        directions = Directions.Left;
                    break;
                case Keys.Right:
                    if (directions != Directions.Left)
                        directions = Directions.Right;
                    break;

                case Keys.Z:
                    if (directions != Directions.Down)
                        directions = Directions.Up;
                    break;
                case Keys.S:
                    if (directions != Directions.Up)
                        directions = Directions.Down;
                    break;
                case Keys.Q:
                    if (directions != Directions.Right)
                        directions = Directions.Left;
                    break;
                case Keys.D:
                    if (directions != Directions.Left)
                        directions = Directions.Right;
                    break;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {

            if (remoteServer != null)
            {
                if (remoteServer.ClientSocket.Connected)
                {
                    remoteServer.Send("start");
                }
            }
            point = 0;
            Score.Text = "Score :" + point;
            gameFields = new GameFields[20, 20];
            snakeCoord = new SnakeCoord[361];
            rand = new Random();
            pictureBox.Image = new Bitmap(600, 600);
            graphics = Graphics.FromImage(pictureBox.Image);
            for (int i = 0; i < 20; i++)
            {
                graphics.DrawImage(imageList.Images[3], i * 30, 0);
                graphics.DrawImage(imageList.Images[3], i * 30, 570);
            }

            for (int i = 1; i < 19; i++)
            {
                graphics.DrawImage(imageList.Images[3], 0, i * 30);
                graphics.DrawImage(imageList.Images[3], 570, i * 30);
            }

            snakeCoord[0].x = 10;
            snakeCoord[0].y = 10;
            snakeCoord[1].x = 10;
            snakeCoord[1].y = 11;
            snakeCoord[2].x = 10;
            snakeCoord[2].y = 12;

            graphics.DrawImage(imageList.Images[2], snakeCoord[0].x * 30, snakeCoord[0].y * 30);
            graphics.DrawImage(imageList.Images[0], snakeCoord[1].x * 30, snakeCoord[1].y * 30);
            graphics.DrawImage(imageList.Images[0], snakeCoord[2].x * 30, snakeCoord[0].y * 30);

            gameFields[10, 10] = GameFields.Snake;
            gameFields[10, 11] = GameFields.Snake;
            gameFields[10, 12] = GameFields.Snake;

            directions = Directions.Up;
            SnakeLenght = 3;

            for (int i = 0; i < 4; i++)
            {
                Food();
            }

            timer.Enabled = true;
            LevelOne.Enabled = false;
            LevelTwo.Enabled = false;
            LevelThree.Enabled = false;
            StartButton.Enabled = false;
            GodMod.Enabled = false;

        }

        private void LevelLent(object sender, EventArgs e)
        {
            timer.Interval = 300;
            LevelOne.Enabled = false;
            LevelTwo.Enabled = true;
            LevelThree.Enabled = true;
            GodMod.Enabled = true;
            PickDifficult.Text = "Difficulté : " + "Lent";

        }

        private void LevelRapide(object sender, EventArgs e)
        {
            timer.Interval = 100;
            LevelOne.Enabled = true;
            LevelTwo.Enabled = false;
            LevelThree.Enabled = true;
            GodMod.Enabled = true;
            PickDifficult.Text = "Difficulté : " + "Rapide";

        }

        private void LevelUltraRapide(object sender, EventArgs e)
        {
            timer.Interval = 50;
            LevelOne.Enabled = true;
            LevelTwo.Enabled = true;
            LevelThree.Enabled = false;
            GodMod.Enabled = true;
            PickDifficult.Text = "Difficulté : " + "Ultra Rapide";

        }

        private void LevelGodMod(object sender, EventArgs e)
        {
            timer.Interval = 30;
            LevelOne.Enabled = true;
            LevelTwo.Enabled = true;
            LevelThree.Enabled = true;
            GodMod.Enabled = false;
            PickDifficult.Text = "Difficulté : " + "Dod Mod";
        }



        private void GameTimer(object sender, EventArgs e)
        {
            graphics.FillRectangle(Brushes.Lime, snakeCoord[SnakeLenght - 1].x * 30, snakeCoord[SnakeLenght - 1].y * 30, 30, 30);
            gameFields[snakeCoord[SnakeLenght - 1].x, snakeCoord[SnakeLenght - 1].y] = GameFields.Free;

            for (int i = SnakeLenght; i >= 1; i--)
            {
                snakeCoord[i].x = snakeCoord[i - 1].x;
                snakeCoord[i].y = snakeCoord[i - 1].y;
            }

            graphics.DrawImage(imageList.Images[0], snakeCoord[0].x * 30, snakeCoord[0].y * 30);

            switch (directions)
            {
                case Directions.Up:
                    snakeCoord[0].y = snakeCoord[0].y - 1;
                    break;

                case Directions.Down:
                    snakeCoord[0].y = snakeCoord[0].y + 1;
                    break;

                case Directions.Right:
                    snakeCoord[0].x = snakeCoord[0].x + 1;
                    break;
                case Directions.Left:
                    snakeCoord[0].x = snakeCoord[0].x - 1;
                    break;
            }

            if (snakeCoord[0].x < 1 || snakeCoord[0].x > 18 || snakeCoord[0].y < 1 || snakeCoord[0].y > 18)
            {
                GameOver();
                pictureBox.Refresh();
                return;
            }

            if (gameFields[snakeCoord[0].x, snakeCoord[0].y] == GameFields.Snake)
            {
                GameOver();
                pictureBox.Refresh();
                Console.WriteLine("je me suis mangé");
                return;
            }


            //check eat 
            if (gameFields[snakeCoord[0].x, snakeCoord[0].y] == GameFields.Food)
            {
                graphics.DrawImage(imageList.Images[0], snakeCoord[SnakeLenght].x * 30, snakeCoord[SnakeLenght].y * 30);
                gameFields[snakeCoord[SnakeLenght].x, snakeCoord[SnakeLenght].y] = GameFields.Snake;
                SnakeLenght++;
                point++;
                Score.Text = "Score : " + point;

                if (SnakeLenght < 350)
                    Food();

            }

            //draw head head c'est 2 body 0
            graphics.DrawImage(imageList.Images[2], snakeCoord[0].x * 30, snakeCoord[0].y * 30);
            gameFields[snakeCoord[0].x, snakeCoord[0].y] = GameFields.Snake;

            pictureBox.Refresh();

        }
        private void Food()
        {
            int x, y;

            do
            {
                x = rand.Next(1, 18);
                y = rand.Next(1, 18);
            } while (gameFields[x, y] != GameFields.Free);

            gameFields[x, y] = GameFields.Food;
            graphics.DrawImage(imageList.Images[1], x * 30, y * 30);
        }

        private void GameOver()
        {
            timer.Enabled = false;
            MessageBox.Show("Game Over you noob");
            LevelOne.Enabled = true;
            LevelTwo.Enabled = true;
            LevelThree.Enabled = true;
            StartButton.Enabled = true;
            GodMod.Enabled = true;
            if (point > highScore)
            {
                highScore = point;
                HighScore.Text = "High Score : " + highScore;
            }
        }
    }
}
