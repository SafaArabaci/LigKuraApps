using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LigKuraApp.Classes;

namespace LigKuraApp
{
    //sıfırlama butonu eklemeye çalıştım ek olarak ama sıfırlayıp tekrar çalıştırdığımda gTakımlar a değer atamıyor atamadığı için uygulama çöküyor o yüzden o butonu iptal ettim. Uygulama tek seferlik kullanılabiliyor.             (Attığınız videoda sıfırlama butonu yoktu)
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region değişken ve listeler
        List<Takim> takimlar = new List<Takim>()
            {
                new Takim("Milan","İtalya"),
                new Takim("Trabzon Spor","Türkiye"),
                new Takim("Shaktar Donetsik","Ukrayna"),
                new Takim("Benfica","Portekiz"),
                new Takim("Galatasaray","Türkiye"),
                new Takim("Roma","İtalya"),
                new Takim("Bayern Münih","Almanya"),
                new Takim("Manchester City","İngiltere"),
                new Takim("Marsilya","İtalya"),
                new Takim("Victoria Plzen","Çek Cumhuriyeti"),
                new Takim("Olimpyakos","Yunanistan"),
                new Takim("Chelsea","İngiltere"),
                new Takim("Borissia Dortmund","Almanya"),
                new Takim("Paris Saint German","Fransa"),
                new Takim("Atletico Madrid","İspanya"),
                new Takim("CSKA Moskova","Rusya"),
                new Takim("Fenerbahçe","Türkiye"),
                new Takim("Porto","Portekiz"),
                new Takim("Beşiktaş","Türkiye"),
                new Takim("Napoli","İtalya"),
                new Takim("Real Sociedad","İspanya"),
                new Takim("Ajax","Hollanda"),
                new Takim("Celtic","İskoçya"),
                new Takim("Real Madrid","İspanya"),
                new Takim("Arsenal","İngiltere"),
                new Takim("Basel","İsviçre"),
                new Takim("Austria Vieri","Avusturya"),
                new Takim("FC Barcelona","İspanya"),
                new Takim("Zent","Rusya"),
                new Takim("Manchester United","İngiltere"),
                new Takim("Schalke 04","Almanya"),
                new Takim("Juventus","İtalya"),
            };
        List<Takim> Torba1 = new List<Takim>();
        List<Takim> Torba2 = new List<Takim>();
        List<Takim> Torba3 = new List<Takim>();
        List<Takim> Torba4 = new List<Takim>();

        List<int> seciliTakimlar = new List<int>();
        List<Takim> gTakimlar = new List<Takim>();
        List<Takim> gTorba = new List<Takim>();
        Random r = new Random();
        bool x = false, y = false;
        #endregion

        private void btnTorbala_Click(object sender, EventArgs e)
        {
            if(x == false)
            {
                gTakimlar.Clear();
                gTakimlar = takimlar;
                seciliTakimlar.Clear();
                int sayac = 0;
                for (int i = 0; i < 4; i++)
                {                   
                    sayac++;
                    for(int t = 0;t<8;t++)
                    {
                        int randomTakim = r.Next(0, gTakimlar.Count());
                        bool secili = false;
                        for (int s = 0; s < seciliTakimlar.Count - 1; s++)
                        {
                            
                            if(randomTakim == seciliTakimlar[s])
                            {
                                secili = true;
                                seciliTakimlar.Add(randomTakim);
                            }
                        }
                        if(secili == false)
                        {
                            if(sayac == 1)
                            {
                                lbxTorba1.Items.Add(gTakimlar[randomTakim].GetFullName());
                                Torba1.Add(gTakimlar[randomTakim]);
                                gTakimlar.RemoveAt(randomTakim);
                            }
                            else if(sayac == 2)
                            {
                                lbxTorba2.Items.Add(gTakimlar[randomTakim].GetFullName());
                                Torba2.Add(gTakimlar[randomTakim]);
                                gTakimlar.RemoveAt(randomTakim);
                            }
                            else if (sayac == 3)
                            {
                                lbxTorba3.Items.Add(gTakimlar[randomTakim].GetFullName());
                                Torba3.Add(gTakimlar[randomTakim]);
                                gTakimlar.RemoveAt(randomTakim);
                            }
                            else if (sayac == 4)
                            {
                                lbxTorba4.Items.Add(gTakimlar[randomTakim].GetFullName());
                                Torba4.Add(gTakimlar[randomTakim]);
                                gTakimlar.RemoveAt(randomTakim);
                            }
                        }
                        else
                        {
                            t--;
                        }
                    }
                    
                }
                x = true;
            }
        }

        private void btnGrupla_Click(object sender, EventArgs e)
        {
            List<ListBox> torbalar = new List<ListBox>() { lbxTorba1, lbxTorba2, lbxTorba3, lbxTorba4 };
            List<ListBox> gruplar = new List<ListBox>() { lbxGrupA, lbxGrupB, lbxGrupC, lbxGrupD, lbxGrupE, lbxGrupF, lbxGrupG, lbxGrupH };
            if (x == true && y == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    if(i == 0)
                    {
                        gTorba = Torba1;
                    }
                    else if(i == 1)
                    {
                        gTorba = Torba2;
                    }
                    else if(i == 2)
                    {
                        gTorba = Torba3;
                    }
                    else if(i == 3)
                    {
                        gTorba = Torba4;
                    }
                    seciliTakimlar.Clear();
                    for(int a = 0; a < 8; a++)
                    {
                        int seciliTakim = r.Next(0, gTorba.Count());
                        bool secili = false;
                        for(int s = 0; s < seciliTakimlar.Count() - 1; s++)
                        {
                            if(seciliTakim == seciliTakimlar[s])
                            {
                                secili = true;
                                seciliTakimlar.Add(seciliTakim);
                            }
                        }
                        if(secili == false)
                        {
                            gruplar[a].Items.Add(gTorba[seciliTakim].GetFullName());
                            gTorba.RemoveAt(seciliTakim);
                        }
                    }
                }
                y = true;
            }
        }

        private void btnSıfırla_Click(object sender, EventArgs e)
        {
            lbxTorba1.Items.Clear();
            lbxTorba2.Items.Clear();
            lbxTorba3.Items.Clear();
            lbxTorba4.Items.Clear();
            lbxGrupA.Items.Clear();
            lbxGrupB.Items.Clear();
            lbxGrupC.Items.Clear();
            lbxGrupD.Items.Clear();
            lbxGrupE.Items.Clear();
            lbxGrupF.Items.Clear();
            lbxGrupG.Items.Clear();
            lbxGrupH.Items.Clear();
            Torba1.Clear();
            Torba2.Clear();
            Torba3.Clear();
            Torba4.Clear();
            x = false;
            y = false;
        }
    }
}