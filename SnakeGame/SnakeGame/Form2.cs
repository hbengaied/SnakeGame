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
        Form1 form;
        bool Create = false;

        List<Client> remoteClients = new List<Client>();

        int nbPlayersReady = 0;
        int nbPerdants = 0;
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
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


        //si un joueur se deco on le supprime de la list des clients
        private void RemoteClient_ClientDisconnected(Client client, String message)
        {
            remoteClients.Remove(client);
            removeClientFromListBox(client);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Client client in remoteClients)
            {
                client.ClientDisconnected -= RemoteClient_ClientDisconnected;
                client.Disconnect();
            }
            if(Create == true)
            {

                server.Stop();
            }
        }

        private void RemoteClient_DataReceived(Client client, object data)
        {
            String zebi = (String)data;

            //Le serveur recoit que 2 informations des clients; lorsqu'un joueur clic sur start

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

            //si nb de joueur pret == nb de client alors gooo 
            if (nbPlayersReady > 1 && nbPlayersReady == remoteClients.Count)
            {
                nbPerdants = nbPlayersReady;
                for(int i = 0; i < remoteClients.Count; i++)
                {
                    //serveur envoi le message go aux client et le timer se met a true et le jeu commence
                    remoteClients[i].Send("GO");
                    nbPlayersReady = 0;

                }
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || listBox1.Items.Contains(textBox1.Text))
            {
                MessageBox.Show(" Vous devez entrer un nom d'utilisateur valide ou qui ne soit pas déjà utilisé");
            }else if (String.IsNullOrEmpty(textBoxIp.Text) && String.IsNullOrEmpty(textBoxPort.Text))
            {
                MessageBox.Show("Merci de renseigner un port ouune adress IP");
            }
            else if(textBox1.Text.Length > 0 && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBoxIp.Text) && !String.IsNullOrEmpty(textBoxPort.Text))
            {
                
                //listBox1.Items.Add(textBox1.Text);
                form = new Form1(textBoxIp.Text, Int32.Parse(textBoxPort.Text), textBox1.Text);
                form.Show();
                textBox1.Clear();
            }

        }

        private void CreateServer(object sender, EventArgs e)
        {
            if((textBoxIp.Text == "" || textBoxIp.Text == " ") && (textBoxPort.Text == "" || textBoxPort.Text == " "))
            {
                MessageBox.Show("Merci de mettre une adresse un port valide et un Pseudo valide");
            }
            else
            {
                server = new Server(textBoxIp.Text, Int32.Parse(textBoxPort.Text));
                server.ClientAccepted += Server_ClientAccepted;
                server.Start();
                buttonServeur.Visible = false;
                Create = true;
            }
        }
    }
}
