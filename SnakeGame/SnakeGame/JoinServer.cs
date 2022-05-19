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

    public partial class JoinServer : Form
    {
        Form1 form;

        List<Client> remoteClients = new List<Client>();

        int nbPlayersReady = 0;
        int nbPlayers = 0;
        int nbPerdants = 0;

        bool gameStarted = false;
        public JoinServer()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoinServer_FormClosing);

        }

        private void RemoteClient_ClientDisconnected(Client client, String message)
        {
            remoteClients.Remove(client);
            //updateClientCount();
        }

        private void RemoteClient_DataReceived(Client client, object data)
        {

            String zebi = (String)data;
            //label1.Text = zebi;
            if (zebi == "start")
            {
                nbPlayersReady++;
            }
            else
            {
                // ici sinon il recoit le blase des perdants
                String place = nbPerdants + " " + zebi;
                nbPerdants--;
                for (int i = 0; i < remoteClients.Count; i++)
                {
                    remoteClients[i].Send(place);
                }
            }

            if (nbPlayersReady > 0 && nbPlayersReady == remoteClients.Count)
            {
                Console.WriteLine("Il y a {0} joueurs", nbPlayersReady);
                nbPerdants = nbPlayersReady;
                for (int i = 0; i < remoteClients.Count; i++)
                {
                    remoteClients[i].Send("GO");
                    gameStarted = true;
                    nbPlayersReady = 0;

                }
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(" Vous devez entrer un nom d'utilisateur valide");
            }
            else if (String.IsNullOrEmpty(textBoxIp.Text) && String.IsNullOrEmpty(textBoxPort.Text))
            {
                MessageBox.Show("Merci de renseigner un port ouune adress IP");
            }
            else if (textBox1.Text.Length > 0 && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBoxIp.Text) && !String.IsNullOrEmpty(textBoxPort.Text))
            {
                nbPlayers++;
                form = new Form1(textBoxIp.Text, Int32.Parse(textBoxPort.Text), textBox1.Text);
                form.Show();
                Console.WriteLine("nb de joueur present {0}", remoteClients.Count);
                textBox1.Clear();
            }

        }

        private void JoinServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Client client in remoteClients)
            {
                client.ClientDisconnected -= RemoteClient_ClientDisconnected;
                client.Disconnect();
            }
        }
    }
}
