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

    public partial class Form2 : Form
    {
        Server server;

        String username;

        List<Client> remoteClients = new List<Client>();

        int nbPlayersReady = 0;
        int nbPlayers = 0;
        int nbPerdants = 0;

        bool gameStarted = false ;
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            server = new Server("127.0.0.1", 9999);
            server.ClientAccepted += Server_ClientAccepted;
            server.Start();
            
        }

        private void Server_ClientAccepted(Client client)
        {
            /* Lorse qu'un client se connecte au serveur, on s'abonne au events et on garde une référence dans la liste remoteClients.
             * Ensuite on met à jour le nombre de clients connectés, on l'affiche dans la listBoxConnectedClients (addClientToListBox)
             * et on affiche un message dans la zone de monitoring.
             */
            Client remoteClient = client;
            client.username = textBox1.Text;
            remoteClient.DataReceived += RemoteClient_DataReceived;
            remoteClient.ClientDisconnected += RemoteClient_ClientDisconnected;
            remoteClients.Add(client);
            //updateClientCount();
            addClientToListBox(client);
        }

        private void addClientToListBox(Client client)
        {
            /* On affiche le nom du joueur connecté dans la listbox
             */
            listBox1.Items.Add(client.username);
        }

        private void removeClientFromListBox(Client client)
        {
            /* La listBoxConnectedClients ne contient pas à proprement parlé les références vers les clients connectés,
             * mais uniquement une liste de string qui représente les clients. Pour supprimer un client de cette liste,
             * il faut trouver l'indice du string correspondant au client à supprimer. On retourve cet indice en cherchant
             * le string qui commence par l'adresse ip et le numéro de port du client à supprimer. 
             */
            int clientToRemoveIndex = listBox1.FindString(client.username);
            listBox1.Items.RemoveAt(clientToRemoveIndex);
        }

        private void RemoteClient_ClientDisconnected(Client client, String message)
        {
            remoteClients.Remove(client);
            removeClientFromListBox(client);
            //updateClientCount();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Client client in remoteClients)
            {
                client.ClientDisconnected -= RemoteClient_ClientDisconnected;
                client.Disconnect();
            }
            server.Stop();
        }

        private void RemoteClient_DataReceived(Client client, object data)
        {

            String zebi = (String)data;
            //label1.Text = zebi;
            if (zebi == "start")
            {
                nbPlayersReady++;
            }else
            {
                // ici sinon il recoit le blase des perdants
                nbPerdants++;
                listBoxClassement.Items.Add(nbPerdants+ " "+zebi);
            }

            if (nbPlayersReady > 1 && nbPlayersReady == remoteClients.Count)
            {
                for(int i = 0; i < remoteClients.Count; i++)
                {
                    remoteClients[i].Send("GO");
                    gameStarted = true;
                    nbPlayersReady = 0;

                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void StartGame(object sender, EventArgs e)
        {
            if(textBox1.Text ==  "" || textBox1.Text == " ")
            {
                MessageBox.Show(" Vous devez entrer un nom d'utilisateur");
            }
            else if(textBox1.Text.Length > 0 && textBox1.Text != " ")
            {
                
                listBox1.Items.Add(textBox1.Text);
                nbPlayers++;
                //remoteClients[nbPlayers-1].Send(textBox1.Text);

                Form1 form1 = new Form1("127.0.0.1", 9999, textBox1.Text);
                form1.Show();
                Console.WriteLine("nb de joueur present {0}",remoteClients.Count);
                textBox1.Clear();
            }

        }
    }
}
