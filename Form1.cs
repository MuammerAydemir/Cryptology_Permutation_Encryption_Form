using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Kriptoloji
{
    public partial class Form1 : Form
    {
        
        String metin = "";   // muammeraydemir
        String sifreliMetin = "";
        String desifreliMetin = "";
        int blokUzunlugu;
        int[] anahtar;
        char ek = 'j';

        String screenAnahtar="";
        
        public Form1()
        {
            InitializeComponent();   
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //ŞİFRELEME
            metin = textBox1.Text.ToLower();
            sifreliMetin = "";
            anahtarOlustur();
            karakterEkle();
            sifrele();
            textBox2.Text = sifreliMetin;
        }

        void sifrele()
        {
            for (int i = 0; i < metin.Length; i += blokUzunlugu)
            {
                for (int j = 0; j < blokUzunlugu; j++)
                {
                    sifreliMetin += metin[i + anahtar[j] - 1];
                };

            };
        }

        void karakterEkle()
        {

            int k = metin.Length % blokUzunlugu;
            if (k != 0)
                {
            int fark = blokUzunlugu - k;
            for (int i = 0; i < fark; i++)
                    {
                        metin += ek;
                    }
                }
        }
        
        void anahtarOlustur()
        {
            blokUzunlugu = int.Parse(numericUpDown1.Value.ToString());
            if (blokUzunlugu == 0)
            {
                MessageBox.Show("Blok Sayısı Giriniz!!!");
                blokUzunlugu = 1;
            }
            anahtar = new int[blokUzunlugu];
            Random random=new Random();
            int i = 0;
            while(i < blokUzunlugu)
            {
                int number =random.Next(blokUzunlugu) +1;
                if (!anahtar.Contains(number))
                {
                    anahtar[i] = number;
                    i++;
                }
            }
            screenAnahtar = string.Join(",", anahtar);
            textBox4.Text = screenAnahtar;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DEŞİFRE
            desifreliMetin = "";
            desifrele();
            textBox3.Text = desifreliMetin;
        }

        void desifrele()
        {
            for (int i = 0; i < sifreliMetin.Length; i += blokUzunlugu)
            {
                for (int j = 0; j < blokUzunlugu; j++)
                {
                    int temp = j + 1;
                    int indis = 0;
                    while (temp != anahtar[indis])
                    {
                        indis++;
                    }
                    desifreliMetin += sifreliMetin[i + indis];

                }

            }
        }
    }
}
