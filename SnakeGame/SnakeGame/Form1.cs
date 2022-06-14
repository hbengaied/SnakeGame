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
    public partial class Form1 : Form
    {
        Client remoteServer;
        String serverIp;
        int serverPort;
        String pseudo;

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

        //Tableau 2 dimensions de type GameFields
        //pour savoir si la coord gameFields[x,y] correspond a un bout du serpent, nourriture ou si c'est libre
        GameFields[,] gameFields;

        //tableau de structure type snakecoord 
        SnakeCoord[] snakeCoord;

        int SnakeLenght;

        // variable directions va pouvoir stocker la direction entre par clavier
        Directions directions;

        //va permettre de dessiner sur la picturebox
        Graphics graphics;

        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        public Form1(String ip, int port, String username) : this()
        {
            remoteServer = new Client();

            remoteServer.DataReceived += RemoteServer_DataReceived;
            remoteServer.ConnectionRefused += RemoteServer_ConnectionRefused;
            remoteServer.username = username;
            pseudo = username;
            serverIp = ip;
            serverPort = port;
        }

        private void RemoteServer_ConnectionRefused(Client client, String message)
        {
            /* Cette fonction sera exécutée si on essaie de se connecter au serveur alors qu'il est éteint.
             * Dans ce cas on affiche le message dans un MessageBox et on ferme la fenêtre.
             * L'objet MessageBox permet d'avoir une fenêtre de dialogue standard utilisées dans toutes
             * les applications windows pour informer l'utilisateur de l'application. On évite ainsi de devoir
             * créer une nouvelle WindowForm pour ce type de tâches très courantes.
             */

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        private void RemoteServer_DataReceived(Client client, object data)
        {
            /* Lorsequ' on recoit des données du serveur, ces données contiennent les informations d'une forme (MovingShapeInfo).
             * On crée une nouvelle forme à partir de ses informations, et on veille à ce que sa position en X soit à 0 (à gauche).
             */

            String message = (String)data;
            //les clients recoivent du serveur le message go lorsque tous les joueurs sont pret !!
            //ainsi le jeu pourra debuter
            if(message == "GO")
            {
                listBoxClassement.Items.Clear();
                timer.Enabled = true;
            }
            else
            //si le serveur recoit un autre message que exit ou go,
            //le client recoit la notification qu'un joueur est mort
            // est affiche sa position dans la listBoxClassement du joueur
            if(message !="exit")
            {
                listBoxClassement.Items.Add(message);
            }
        }

        private void GamePage_FormClosing(object sender, FormClosedEventArgs e)
        {
            remoteServer.Disconnect();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            //direction du serpent gere par un switch 
            switch (e.KeyCode)
            {
                //si la touche pressé est Z ou fleche directionnel du haut
                //on verfie que le serpent est pas entrain d'aller vers le bas car sinon pas possible,
                //il va marche sur lui meme
                //si if respecté alors on stock la direction voulu
                case Keys.Up:
                    if (directions != Directions.Down)
                        directions = Directions.Up;
                    break;

                //meme cas pour toutes les autres directions 
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

                Console.WriteLine(remoteServer.username);
                //Quand un joueur clic sur le btn start, on envoi un msg start au serveur comme ca il sait que
                //un joueur est pret ! Dans la partie serveur on fait a une variable nbplayeready qui est
                //incrementé à chaque clic de start
                if (remoteServer.ClientSocket.Connected)
                {
                    remoteServer.Send("start");
                }
            }
            point = 0;
            Score.Text = "Score :" + point;
            //Notre gamfields est un tableau a 2 dim 20/20
            gameFields = new GameFields[20, 20];
            //le jeu de deroule sur une dimension de 19/19 car il faut prendre en compte les bordures
            //donc le snake peut avoir une longueur max de 19*19= 361
            snakeCoord = new SnakeCoord[361];
            rand = new Random();
            //Notre picture box aura une taille de 600px par 600px car chaque image du jeu fait une taille de 30px
            // donc 20*30
            pictureBox.Image = new Bitmap(600, 600);

            //-------------------------------Dessin des bordures----------------------
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
            //----------------------------Fin dessin bordures--------------------------

            //-------------------------------Position initial du snake ----------------------
            snakeCoord[0].x = 10; // tete
            snakeCoord[0].y = 10;
            snakeCoord[1].x = 10;//milieu
            snakeCoord[1].y = 11;
            snakeCoord[2].x = 10;//queue
            snakeCoord[2].y = 12;


            //-------------------------------Dessin du snake du la picturebox----------------------
            graphics.DrawImage(imageList.Images[2], snakeCoord[0].x * 30, snakeCoord[0].y * 30);
            graphics.DrawImage(imageList.Images[0], snakeCoord[1].x * 30, snakeCoord[1].y * 30);
            graphics.DrawImage(imageList.Images[0], snakeCoord[2].x * 30, snakeCoord[0].y * 30);


            //on specifie dans notre gamefileds les coords du serpents
            gameFields[10, 10] = GameFields.Snake;
            gameFields[10, 11] = GameFields.Snake;
            gameFields[10, 12] = GameFields.Snake;


            //notre serpent ira vers le haut par defaut
            directions = Directions.Up;
            SnakeLenght = 3;


            //On affiche 4 foods sur la picture box 
            for (int i = 0; i < 4; i++)
            {
                Food();
            }

            StartButton.Enabled = false;

        }



        //game timer du jeu, c'est ce qui se passe chaque milli sec specifié !
        private void GameTimer(object sender, EventArgs e)
        {
            //-------------On efface la queue du snake et on specifie que la coord de la queue car le snake se deplace------------
            graphics.FillRectangle(Brushes.Lime, snakeCoord[SnakeLenght - 1].x * 30, snakeCoord[SnakeLenght - 1].y * 30, 30, 30);
            gameFields[snakeCoord[SnakeLenght - 1].x, snakeCoord[SnakeLenght - 1].y] = GameFields.Free;
            //-------------Fin effacement de la queue-------------

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

            //si tete du serpent cogne une bordure gameover 
            if (snakeCoord[0].x < 1 || snakeCoord[0].x > 18 || snakeCoord[0].y < 1 || snakeCoord[0].y > 18)
            {
                GameOver();
                pictureBox.Refresh();
                return;
            }

            //si tete du serpent cogne son corps game over
            if (gameFields[snakeCoord[0].x, snakeCoord[0].y] == GameFields.Snake)
            {
                GameOver();
                pictureBox.Refresh();
                return;
            }


            //check eat 
            if (gameFields[snakeCoord[0].x, snakeCoord[0].y] == GameFields.Food)
            {
                // si serpent a manger; on dessigne sa tete a la place de la bouffe
                graphics.DrawImage(imageList.Images[0], snakeCoord[SnakeLenght].x * 30, snakeCoord[SnakeLenght].y * 30);
                gameFields[snakeCoord[SnakeLenght].x, snakeCoord[SnakeLenght].y] = GameFields.Snake;
                SnakeLenght++;
                point++;
                Score.Text = "Score : " + point;

                if (SnakeLenght < 350)
                    Food();

            }

            //draw head c'est 2 body
            graphics.DrawImage(imageList.Images[2], snakeCoord[0].x * 30, snakeCoord[0].y * 30);
            gameFields[snakeCoord[0].x, snakeCoord[0].y] = GameFields.Snake;

            pictureBox.Refresh();

        }

        //-------------------Fonction gui genee un x et y pour afficher la nourriture
        private void Food()
        {
            int x, y;

            do
            {
                x = rand.Next(1, 18);
                y = rand.Next(1, 18);
                //on verifie que le x et y est un champ libre
            } while (gameFields[x, y] != GameFields.Free);

            // si libre on designe la nourriture
            gameFields[x, y] = GameFields.Food;
            graphics.DrawImage(imageList.Images[1], x * 30, y * 30);
        }

        //--------------Arrete le jeu, envoi le nom du perdant au serveur
        private void GameOver()
        {
            timer.Enabled = false;
            remoteServer.Send(pseudo);
            MessageBox.Show("Game Over you noob");
            StartButton.Enabled = true;
        }


        //-------- Si joueur quitte une partie, on envoi au serveur qu'un joueur a deco et son nom
        // dans le serveur le nbplayer sera --
        private void ExiteGame(object sender, FormClosedEventArgs e)
        {
            remoteServer.Send("exit");
            remoteServer.Send(pseudo);
            remoteServer.Disconnect();
        }



        //-------Au chargement on dessine les bords et le serpents
        private void Form1_Load(object sender, EventArgs e)
        {
            //connection au serveur 
            remoteServer.Connect(serverIp, serverPort);
            NamePlayer.Text ="Pseudo : " + pseudo;
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
        }
    }
}
