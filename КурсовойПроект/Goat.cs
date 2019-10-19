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
    public partial class Goat : Form
    {
        public Goat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Height = 163;
            richTextBox1.Visible = true;
            groupBox1.Visible = true;
            button8.Visible = false;
            label2.Visible = true;
        }


    }
}
