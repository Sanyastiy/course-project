using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсовойПроект
{
    public partial class Glavnaya : Form
    {
        bool raz = false;
            bool dva = false;
        string[] mat = new string[9];
        
        public Glavnaya()
        {
            InitializeComponent();
            int ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Краткое описание.txt"))
            {                
                mat[ii] = line;
                ii++;
            }
        }   
       

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            switch (listBox1.SelectedIndex)
            {
                case 0: richTextBox1.Text = mat[0]; break;
                case 1: richTextBox1.Text = mat[2]; break;
                case 2: richTextBox1.Text = mat[3]; break;
                case 3: richTextBox1.Text = mat[5]; break;
                case 4: richTextBox1.Text = mat[6]; break;
                case 5: richTextBox1.Text = mat[7]; break;
                case 6: richTextBox1.Text = mat[8]; break;
                default: break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(raz&!dva)
            {
                MessageBox.Show("Сегодня вы уже проходили тестирование. Обратите внимание, что прохождение более одного теста оказывает нагрузку на психику.");
                dva = true;
            }
            raz = true;
            Locus f1 = new Locus();
            Glavnaya f2 = new Glavnaya();
            Stress f3 = new Stress();
            Goat f4 = new Goat();
            Accentuation f5 = new Accentuation();
            Conflict f6 = new Conflict();
            Diagnostika f7 = new Diagnostika();
            Temperament f8 = new Temperament();
            Delo f9 = new Delo();
            kot f10 = new kot();

            switch (listBox1.SelectedIndex)
            {
                case 0: f1.ShowDialog(); break;
                case 1: f5.ShowDialog(); break;
                case 2: f10.ShowDialog(); break;
                case 3: f6.ShowDialog(); break;
                case 4: f9.ShowDialog(); break;
                case 5: f8.ShowDialog(); break;
                default: break;
            }
        }
    }
}
