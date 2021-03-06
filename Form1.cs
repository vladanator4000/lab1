﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ochko
{
    public partial class Form1 : Form
    {
        Bitmap   img;
        Graphics imgBuffer;
        Image[] cards = new Image[52];
        
        Image backcard;
        Image background;

        int[] myhand = new int[52];
        int[] ophand = new int[52];
        int countmyCard;
        int countopCard;
        bool mystep;
        int opstep = 0;
        Random randomNum = new Random(DateTime.Now.Millisecond);
        int countmyscore;
        int countopscore;
        int globalScoreMy = 0;
        int globalScoreOp = 0;
        bool gameover;

        public Form1()
        {
            InitializeComponent();
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            imgBuffer = Graphics.FromImage(img);
            //Загрузка изображений колод B,C,P,K
            for (int i = 1; i <= 13; i++)
            {
                cards[i - 1]      = Image.FromFile(Application.StartupPath + "\\cards\\d (" + i.ToString() + ").png");
                cards[i + 13 - 1] = Image.FromFile(Application.StartupPath + "\\cards\\h (" + i.ToString() + ").png");
                cards[i + 26 - 1] = Image.FromFile(Application.StartupPath + "\\cards\\s (" + i.ToString() + ").png");
                cards[i + 39 - 1] = Image.FromFile(Application.StartupPath + "\\cards\\c (" + i.ToString() + ").png");
            }
            //Загрузка сторонних ресурсов
            backcard   = Image.FromFile(Application.StartupPath + "\\cards\\backcard.png");
            background = Image.FromFile(Application.StartupPath + "\\cards\\background.jpg");
            imgBuffer.DrawImage(background, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            randomNum.Next(52);
            mystep = true;
            opstep = 0;
            gameover = false;
            countmyCard = 2;
            countopCard = 0;
            countmyscore = 0;
            countopscore = 0;

            for (int i = 0; i < 52; i++)
            {
                myhand[i] = 0;
                ophand[i] = 0;
            }
            myhand[0] = randomNum.Next(52);
            myhand[1] = randomNum.Next(52);
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int step = (int)pictureBox1.Width / 52;
            for (int i = 0; i < countopCard; i++)
            {
                imgBuffer.DrawImage(cards[ophand[i]], new Rectangle((i + 1) * step, 0, 64, 96));
            }
            for (int i = 0; i < countmyCard; i++) {
                imgBuffer.DrawImage(cards[myhand[i]], new Rectangle((i + 1) * step, pictureBox1.Height - 96, 64, 96));                
            }
            countmyscore = 0;
            for (int i = 0; i < countmyCard; i++)
            {
                if (myhand[i] == 0  || myhand[i] == 13 || myhand[i] == 26 || myhand[i] == 39) countmyscore += 11;
                if (myhand[i] == 1  || myhand[i] == 14 || myhand[i] == 27 || myhand[i] == 40) countmyscore += 2;
                if (myhand[i] == 2  || myhand[i] == 15 || myhand[i] == 28 || myhand[i] == 41) countmyscore += 3;
                if (myhand[i] == 3  || myhand[i] == 16 || myhand[i] == 29 || myhand[i] == 42) countmyscore += 4;
                if (myhand[i] == 4  || myhand[i] == 17 || myhand[i] == 30 || myhand[i] == 43) countmyscore += 5;
                if (myhand[i] == 5  || myhand[i] == 18 || myhand[i] == 31 || myhand[i] == 44) countmyscore += 6;
                if (myhand[i] == 6  || myhand[i] == 19 || myhand[i] == 32 || myhand[i] == 45) countmyscore += 7;
                if (myhand[i] == 7  || myhand[i] == 20 || myhand[i] == 33 || myhand[i] == 46) countmyscore += 8;
                if (myhand[i] == 8  || myhand[i] == 21 || myhand[i] == 34 || myhand[i] == 47) countmyscore += 9;
                if (myhand[i] == 9  || myhand[i] == 22 || myhand[i] == 35 || myhand[i] == 48) countmyscore += 10;
                if (myhand[i] == 10 || myhand[i] == 23 || myhand[i] == 36 || myhand[i] == 49) countmyscore += 10;
                if (myhand[i] == 11 || myhand[i] == 24 || myhand[i] == 37 || myhand[i] == 50) countmyscore += 10;
                if (myhand[i] == 12 || myhand[i] == 25 || myhand[i] == 38 || myhand[i] == 51) countmyscore += 10;
            }
            if (countmyscore > 21)
            {
                if (!gameover)
                {
                    gameover = true;
                    globalScoreOp++;
                    mystep = false;
                         MessageBox.Show("Вы проиграли!");
                }
            }

            countopscore = 0;
            for (int i = 0; i < countopCard; i++)
            {
                if (ophand[i] == 0 || ophand[i] == 13 || ophand[i] == 26 || ophand[i] == 39) countopscore += 11;
                if (ophand[i] == 1 || ophand[i] == 14 || ophand[i] == 27 || ophand[i] == 40) countopscore += 2;
                if (ophand[i] == 2 || ophand[i] == 15 || ophand[i] == 28 || ophand[i] == 41) countopscore += 3;
                if (ophand[i] == 3 || ophand[i] == 16 || ophand[i] == 29 || ophand[i] == 42) countopscore += 4;
                if (ophand[i] == 4 || ophand[i] == 17 || ophand[i] == 30 || ophand[i] == 43) countopscore += 5;
                if (ophand[i] == 5 || ophand[i] == 18 || ophand[i] == 31 || ophand[i] == 44) countopscore += 6;
                if (ophand[i] == 6 || ophand[i] == 19 || ophand[i] == 32 || ophand[i] == 45) countopscore += 7;
                if (ophand[i] == 7 || ophand[i] == 20 || ophand[i] == 33 || ophand[i] == 46) countopscore += 8;
                if (ophand[i] == 8 || ophand[i] == 21 || ophand[i] == 34 || ophand[i] == 47) countopscore += 9;
                if (ophand[i] == 9 || ophand[i] == 22 || ophand[i] == 35 || ophand[i] == 48) countopscore += 10;
                if (ophand[i] == 10 || ophand[i] == 23 || ophand[i] == 36 || ophand[i] == 49) countopscore += 10;
                if (ophand[i] == 11 || ophand[i] == 24 || ophand[i] == 37 || ophand[i] == 50) countopscore += 10;
                if (ophand[i] == 12 || ophand[i] == 25 || ophand[i] == 38 || ophand[i] == 51) countopscore += 10;
            }
            label5.Text = countmyscore.ToString();
            label6.Text = countopscore.ToString();
            pictureBox1.Image = img;
            if (mystep)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            if (countopscore < 17 && opstep == 1)
            {
                if (!mystep && countmyCard < 52)
                {
                    bool was = true;
                    while (was)
                    {
                        was = false;
                        ophand[countopCard] = randomNum.Next(52);
                        for (int i = 0; i < countmyCard; i++)
                        {
                            if (myhand[i] == ophand[countmyCard])
                                was = true;
                        }
                        for (int i = 0; i < countopCard; i++)
                        {
                            if (ophand[i] == ophand[countopCard])
                                was = true;
                        }
                    }
                    countopCard++;
                }
            }
            else
            {
                if(!mystep && opstep == 1)
                    opstep = -1;
            }
            if (this.opstep == -1)
            {
                opstep = -2;
                if (countopscore <= 21 && countmyscore <= 21)
                {
                    if (countopscore > countmyscore)
                    {
                        MessageBox.Show("Вы проиграли!");
                        globalScoreOp++;
                    }
                    else if (countopscore < countmyscore)
                    {
                        MessageBox.Show("Вы победили!");
                        globalScoreMy++;
                    }
                    else
                    {
                        MessageBox.Show("Ничья!");
                        opstep = 0;
                    }
                }
                else if (countmyscore <= 21 && countopscore > 21)
                {
                    MessageBox.Show("Вы победили!");
                    globalScoreMy++;
                }
            }
            label4.Text = globalScoreMy.ToString() + "/" + globalScoreOp.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (mystep && countmyCard < 52)
            {
                bool was = true;
                while (was)
                {
                    was = false;
                    myhand[countmyCard] = randomNum.Next(52);
                    for (int i = 0; i < countmyCard; i++)
                    {
                        if (myhand[i] == myhand[countmyCard])
                            was = true;
                    }
                }
                countmyCard++;
            }
            else
                button1.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mystep = false;
            opstep = 1;

        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgBuffer.DrawImage(background, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            randomNum.Next(52);
            mystep = true;
            opstep = 0;
            gameover = false;
            countmyCard = 2;
            countopCard = 0;
            countmyscore = 0;
            countopscore = 0;
            
            for(int i = 0; i < 52; i++)
            {
                myhand[i] = 0;
                ophand[i] = 0;
            }
            myhand[0] = randomNum.Next(52);
            myhand[1] = randomNum.Next(52);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void помощьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Блэкджек - азартная игра, также известная как двадцать одно. Игроки в блэкджек соревнуются не друг с другом, а с дилером. Цель игры заключается в том, чтобы собрать комбинацию карт, имеющую более высокую стоимость, нежели у дилера, но при этом не перейти рубеж в 21 очко. Если сумма ваших очков больше 21, то это называется перебор и вы автоматически проигрываете, независимо от комбинации карт у дилера. Значение руки в блэкджеке определяется путем сложения всех карт игрока. Стоимость каждой карты определяется ее числовым значением, а карты с лицами (валет, дама, король) приносят 10 очков, туз считается за 11. В начале игры пользователь получает 2 карты. Кнопка 'Взять' - игрок просит у дилера дополнительную карту. Можно взять сколько угодно карт, пока сумма очков не будет равна 21 или не будет перебор. Кнопка 'Хватит' - игрок дает дилеру понять, что предпочитает остаться с той рукой, которую имеет.");
        }
    }
}
