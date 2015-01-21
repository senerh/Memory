using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void btn_classique_Click(object sender, EventArgs e)
        {

        }

        private void btn_simple_Click(object sender, EventArgs e)
        {
            memory memo = new memory();
            memo.Show();
            //this.Hide();
        }
    }
}
