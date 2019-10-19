using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace КурсовойПроект
{
    public partial class Accentuation : Form
    {
        int pozition = 0;
        bool hotodin = false;

        //массив для записи результатов
        int[] result = new int[97];
        bool[] rez = new bool[11];
        int[] glavrez = new int[11];

        //массив вопросов
        string[] accent = new string[97];
        //массив ответов
        string[] otvet = new string[11];

        public Accentuation()
        {
            InitializeComponent();
            try
            {
                for (int g = 0; g < 97; g++)
                {
                    result[g] = 0;
                }


                int ii = 0;
                foreach (string line in File.ReadLines(@"Materials/Строки акцентуация.txt"))
                {
                    accent[ii] = line;
                    ii++;
                }

                ii = 0;
                foreach (string line in File.ReadLines(@"Materials/Ответы акцентуация.txt"))
                {
                    otvet[ii] = line;
                    ii++;
                }
                richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Акцентуация.rtf");
            }
            catch (Exception)
            { }
        }


        private void next(object sender, EventArgs e)
        {
            try
            {
                if (pozition < 96)  //подсчет отвеченных вопросов
                {
                    Button b = sender as Button;    //определение места откуда берется ответ
                    result[pozition] = int.Parse((b.Tag).ToString());   //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                    pozition++; //след вопрос
                    richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + accent[pozition];    //вывод след вопроса
                }
                else
                {
                    //Гипертимность
                    glavrez[0] = (result[0] + result[11] + result[24] + result[35] + result[49] + result[60] + result[74] + result[84]) * 3;
                    //Дистимичность
                    glavrez[1] = (((result[9] + result[22] + result[47] + result[82] + result[95]) * 3) + (result[33] + result[57] + result[72]) * (-3));
                    //Циклотимность
                    glavrez[2] = (result[5] + result[19] + result[30] + result[43] + result[54] + result[69] + result[79] + result[92]) * 3;
                    //Эмоциональность
                    glavrez[3] = (((result[2] + result[13] + result[51] + result[63] + result[76] + result[86]) * 3) + (result[27] + result[38]) * (-3));
                    //Демонстративность
                    glavrez[4] = (((result[6] + result[20] + result[23] + result[31] + result[44] + result[48] + result[70] + result[73] + result[80] + result[93] + result[96]) * 2) + (result[55]) * (-2));
                    //Застревание
                    glavrez[5] = (((result[1] + result[15] + result[25] + result[37] + result[40] + result[61] + result[75] + result[85] + result[89]) * 2) + (result[12] + result[50]) * (-2));
                    //Педантичность
                    glavrez[6] = (((result[3] + result[14] + result[18] + result[28] + result[42] + result[52] + result[64] + result[68] + result[77] + result[88] + result[91]) * 2) + (result[39]) * (-2));
                    //Тревожность
                    glavrez[7] = (((result[16] + result[29] + result[41] + result[53] + result[78] + result[90]) * 3) + (result[4] + result[66]) * (-3));
                    //Возбудимость
                    glavrez[8] = (result[7] + result[21] + result[32] + result[45] + result[56] + result[71] + result[81] + result[94]) * 3;
                    //Экзальтированность
                    glavrez[9] = (result[10] + result[34] + result[59] + result[83]) * 6;
                    //Ложь
                    glavrez[10] = (((result[8] + result[46] + result[58] + result[67] + result[82])) + (result[17] + result[26] + result[36] + result[62]) * (-1));

                    for (int g = 0; g < 11; g++)
                    {
                        if (glavrez[g] > 18) { rez[g] = true; hotodin = true; }
                    }
                    richTextBox1.Height = 483;
                    if (hotodin)
                    {
                        richTextBox1.Text = "В вашей личности преобладают следующие типы акцентуации (баллов больше 18):" + Environment.NewLine;
                        for (int g = 0; g < 11; g++)
                        {
                            if (rez[g])
                            {
                                richTextBox1.Text += "Баллов:" + glavrez[g] + ", тип: " + otvet[g] + Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        richTextBox1.Text = "В вашей личности не преобладают какие-либо типы акцентуации.";
                    }
                    groupBox1.Visible = false;

                }
            }
            catch (Exception)
            { }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Visible = false;
                richTextBox1.Height = 163;
                richTextBox1.Visible = true;
                richTextBox2.Visible = false;
                groupBox1.Visible = true;
                button8.Visible = false;
                label1.Visible = true;

                //
                //вывод первого вопроса
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + accent[pozition];
            }
            catch (Exception)
            { }
        }
    }
}
