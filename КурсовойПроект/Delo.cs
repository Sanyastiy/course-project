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
    public partial class Delo : Form
    {

        int pozition = 0;
        //массив вопросов
        string[] liri = new string[128];
        //массив ответов
        bool[] answer = new bool[128];
        int[] rez = new int[8];
        string[] otvet=new string[32];
        string[] otv = new string[8] { "1. Властный-лидирующий (автократически властвующий)", "2. Независимый-доминирующий (эксплуатирующий-соревнующийся)", "3. Прямолинейно-агрессивный", "4. Скептически-недоверчивый", "5. Скромно-стушевывающийся (покорно-застенчивый)", "6. Зависимый-послушный", "7. Конвенциально-сотрудничающий", "8. Ответственно-великодушный" };

        public Delo()
        {
            InitializeComponent();
            try
            { 
            int ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Строки дело.txt"))
            {
                liri[ii] = line;
                ii++;
            }

            ii = 0;
            foreach (string line in File.ReadLines(@"Materials/Ответы дело.txt"))
            {
                otvet[ii] = line;
                ii++;
            }
            richTextBox2.Rtf = File.ReadAllText(@"Materials/Теория/Дело.rtf");
            }
            catch (Exception)
            { }
        }

        private void next(object sender, EventArgs e)
        {
            try
            {
            if (pozition < 127)  //подсчет отвеченных вопросов
            {
                Button b = sender as Button;    //определение места откуда берется ответ
                answer[pozition] = Convert.ToBoolean((b.Tag).ToString());   //запись в результ. массив ТЭГа кнопки, в котором записан ответ
                pozition++; //след вопрос
                richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + liri[pozition];    //вывод след вопроса
            }
            else
            {
                richTextBox1.Clear();
                int god = 0;
                int q = 0;
                for (int h = 0; h < 8; h++)//цикл блоков ответов
                {
                    for (int i = 0; i < 4; i++)//цикл столбцов блока
                    {
                        for (int j = 0; j < 4; j++)//цикл ячеек блока
                        {
                            rez[h] += Convert.ToInt16(answer[q]);//сложна индексаутофрендж
                            q++;
                        }
                        q += 28;//ячейки для блока чередуются, каждые 4 ячейки через 29 пунктов
                    }
                    q = h + 5;//сложна
                    
                    //rez[h].ToString()+
                    richTextBox1.Text +=  "Ваши баллы по шкалам:" + Environment.NewLine + otv[h] + Environment.NewLine;

                    if (rez[h] > 1 & rez[h] < 5)
                    {
                        richTextBox1.Text += rez[h].ToString() + Environment.NewLine + otvet[god];
                    }
                    else if (rez[h] > 5 & rez[h] < 9)
                    {
                        richTextBox1.Text += rez[h].ToString() + Environment.NewLine + otvet[god + 1];
                    }
                    else if (rez[h] > 9 & rez[h] < 13)
                    {
                        richTextBox1.Text += rez[h].ToString() + Environment.NewLine + otvet[god + 2];
                    }
                    else if (rez[h] > 13 & rez[h] < 17)
                    {
                        richTextBox1.Text += rez[h].ToString() + Environment.NewLine + otvet[god + 3];
                    }
                    god += 4;
                }
                richTextBox1.Height = 483;
                groupBox1.Visible = false;
            }
            }
            catch (Exception)
            { }
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
            richTextBox1.Text = "Вопрос №" + (pozition + 1).ToString() + ": " + liri[pozition];
            }
            catch (Exception)
            { }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
