using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсовойПроект
{
    public partial class Face : Form
    {
        public Face()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Glavnaya g = new Glavnaya();
            g.Show();
            this.Hide();
        }
    }
}
