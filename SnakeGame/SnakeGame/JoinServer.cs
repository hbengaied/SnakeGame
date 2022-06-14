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
        public JoinServer()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoinServer_FormClosing);

        }

        private void RemoteClient_ClientDisconnected(Client client, String message)
        {
            remoteClients.Remove(client);
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
                form = new Form1(textBoxIp.Text, Int32.Parse(textBoxPort.Text), textBox1.Text);
                form.Show();
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
