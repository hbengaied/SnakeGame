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
    public partial class OnlineOrLocal : Form
    {
        public OnlineOrLocal()
        {
            InitializeComponent();
        }

        private void JouerOnline(object sender, EventArgs e)
        {
            CreateOrJoinServer form = new CreateOrJoinServer();
            form.Show();
        }

        private void JouerLocal(object sender, EventArgs e)
        {
            LocalGame local = new LocalGame();
            local.Show();
        }
    }
}
