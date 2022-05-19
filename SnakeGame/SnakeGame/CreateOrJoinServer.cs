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
    public partial class CreateOrJoinServer : Form
    {
        public CreateOrJoinServer()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void Join_Click(object sender, EventArgs e)
        {
            JoinServer form = new JoinServer();
            form.Show();

        }
    }
}
