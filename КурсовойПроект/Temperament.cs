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
    public partial class Temperament : Form
    {
        int ii = 0;
        int jj = 0;

        int pozition = 0;
        //массив вопросов
        string[,] temp = new string[20, 4];
        //массив ответов
        int[,] answer = new int[20, 4];

        public Temperament()
        {
            InitializeComponent();
            try
            { 
            int ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки темперамент сангвиник.txt"))
            {
                temp[ii, 0] = line;
                ii++;
            }
            ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки темперамент холерик.txt"))
            {
                temp[ii, 1] = line;
                ii++;
            }
            ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки темперамент меланхолик.txt"))
            {
                temp[ii, 2] = line;
                ii++;
            }
            ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки темперамент флегматик.txt"))
            {
                temp[ii, 3] = line;
                ii++;
            }
            richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Темперамент.rtf");
            }
            catch (Exception)
            { }
        }
        bool bilo = false;
        private void next(object sender, EventArgs e)
        {
            try
            {
                
                if (pozition < 79)  //подсчет отвеченных вопросов
                {
                    Button b = sender as Button;    //определение места откуда берется ответ
                    answer[ii, jj] = Convert.ToInt16((b.Tag).ToString());   //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                    if (!bilo) { jj++; bilo = true; }
                    richTextBox1.Text = "Вопрос № " + (pozition + 1).ToString() + " " + temp[ii, jj];    //вывод след вопроса
                    pozition++; //след вопрос
                    if (jj < 3) { jj++; } else { jj = 0; ii++; }

                }
                else
                {
                    int sang = 0;
                    int holer = 0;
                    int melan = 0;
                    int fleg = 0;

                    for (int i = 0; i < 20; i++)
                    {
                        sang += answer[i, 0];
                        holer += answer[i, 1];
                        melan += answer[i, 2];
                        fleg += answer[i, 3];
                    }
                    int summ = sang + holer + melan + fleg;
                    string[] sss = new string[4];

                    sang *= 100;
                    sang /= summ;
                    holer *= 100;
                    holer /= summ;
                    melan *= 100;
                    melan /= summ;
                    fleg *= 100;
                    fleg /= summ;

                    int[] s = new int[4] { sang, holer, melan, fleg };

                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (s[j] <= 19) { sss[j] = "черты данного типа темперамента у Вас выражены слабо"; }
                            if ((s[j] >= 20) & (s[j] <= 29)) { sss[j] = "уровень выраженности характерных для этого типа темперамента черт у Вас средний"; }
                            if ((s[j] >= 30) & (s[j] <= 39)) { sss[j] = "черты, характерные для этого типа, выражены у Вас достаточно ярко"; }
                            if (s[j] >= 40) { sss[j] = "данный тип темперамента у Вас является доминирующим"; }
                        }
                    }


                    richTextBox1.Text = Environment.NewLine + "Ваши баллы темпераметра(%):" + Environment.NewLine +
                        "Сангвиник: " + sang.ToString() + "% ," + sss[0].ToString() + Environment.NewLine +
                        "Холерик: " + holer.ToString() + "% ," + sss[1].ToString() + Environment.NewLine +
                        "Меланхолик: " + melan.ToString() + "% ," + sss[2].ToString() + Environment.NewLine +
                        "Флегматик: " + fleg.ToString() + "% ," + sss[3].ToString() + Environment.NewLine;

                    foreach (string line in File.ReadLines(@"Materials/Ответы темперамент.txt"))
                    {
                        richTextBox1.Text += Environment.NewLine + line;
                    }

                    richTextBox1.Height = 483;
                    label2.Visible = false;
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
            richTextBox1.Height = 113;
            richTextBox1.Visible = true;
            richTextBox2.Visible = false;
            groupBox1.Visible = true;
            button8.Visible = false;
            label2.Visible = true;
            richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + temp[pozition,0];
            pozition++;
            }
            catch (Exception)
            { }
        }
    }
}
