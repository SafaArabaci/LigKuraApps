using Project_120723.Classes;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_120723
{
    class Program
    {
        static void Main(string[] args)
        {
            #region değişken ve listeler
            Random r = new Random();
            List<int> seciliSayilar = new List<int>();
            List<Takim> takimlar = new List<Takim>() { new Takim("Trabzon Spor"), new Takim("Galatasaray"), new Takim("Beşiktaş"),
            new Takim("Adana Demir Spor"),new Takim("Medipol Başakşehir"),new Takim("Giresun Spor"), new Takim("Sivas Spor"),
            new Takim("Alanya Spor") };
            List<Takim> grup01 = new List<Takim>();
            List<Takim> grup02 = new List<Takim>();
            List<Takim> grup03 = new List<Takim>();
            List<Takim> grup04 = new List<Takim>();
            List<Takim> grup11 = new List<Takim>();
            List<Takim> grup12 = new List<Takim>();
            List<Takim> grup21 = new List<Takim>();
            #endregion
            #region numaralandırma
            foreach (Takim t in takimlar)
            {
            geriNum:
                int rNo = r.Next(1, 9);
                foreach (int s in seciliSayilar)
                {
                    if (s == rNo)
                    {
                        goto geriNum;
                    }
                }
                seciliSayilar.Add(rNo);
                t.No = rNo;
                Console.WriteLine($"{t.GetAd()} takımının numarası {t.No}.");
            }
            Console.WriteLine("");
            seciliSayilar.Clear();
            #endregion
            #region gruplandırma
            for (int i = 0; i <= takimlar.Count() - 1; i++)
            {
                if (takimlar[i].No == 1 || takimlar[i].No == 2)
                {
                    grup01.Add(takimlar[i]);
                }
                else if (takimlar[i].No == 3 || takimlar[i].No == 4)
                {
                    grup02.Add(takimlar[i]);
                }
                else if (takimlar[i].No == 5 || takimlar[i].No == 6)
                {
                    grup03.Add(takimlar[i]);
                }
                else if (takimlar[i].No == 7 || takimlar[i].No == 8)
                {
                    grup04.Add(takimlar[i]);
                }
            }
            #endregion
            #region maclar1
            MacYap(Tur.CeyrekFinal, r.Next(0, 4), r.Next(0, 4), grup01, grup11);
            MacYap(Tur.CeyrekFinal, r.Next(0, 4), r.Next(0, 4), grup02, grup11);
            MacYap(Tur.CeyrekFinal, r.Next(0, 4), r.Next(0, 4), grup03, grup12);
            MacYap(Tur.CeyrekFinal, r.Next(0, 4), r.Next(0, 4), grup04, grup12);
            Console.WriteLine("");
            #endregion
            #region maclar2
            MacYap(Tur.YarıFinal, r.Next(0, 4), r.Next(0, 4), grup11, grup21);
            MacYap(Tur.YarıFinal, r.Next(0, 4), r.Next(0, 4), grup12, grup21);
            Console.WriteLine("");
            #endregion
            #region maclar3
            MacYap(Tur.Final, r.Next(0, 4), r.Next(0, 4), grup21, null);
            Console.WriteLine("");
            #endregion
            Console.ReadLine();
        }

        #region MacYap()
        static public void MacYap(Tur tur, int gol1, int gol2,List<Takim> grup, List<Takim> yenıGrup)
        {
            if (tur == Tur.CeyrekFinal)
            {
                int tGol1 = gol1, tGol2 = gol2;
                if (tGol1 > tGol2)
                {
                    grup[0].YarıFinal = true;
                    Console.WriteLine($"{grup[0].GetAd()} takımı {grup[1].GetAd()} takımını {tGol1} - {tGol2} yenerek yarı finale çıkmıştır.");
                    yenıGrup.Add(grup[0]);
                }
                else if (tGol2 > tGol1)
                {
                    grup[1].YarıFinal = true;
                    Console.WriteLine($"{grup[1].GetAd()} takımı {grup[0].GetAd()} takımını {tGol2} - {tGol1} yenerek yarı finale çıkmıştır.");
                    yenıGrup.Add(grup[1]);
                }
                else
                {
                    Random r = new Random();
                    bool a = Convert.ToBoolean(r.Next(0,2));
                    if(a == true)
                    {
                        tGol1++;
                        grup[0].YarıFinal = true;
                        Console.WriteLine($"{grup[0].GetAd()} takımı {grup[1].GetAd()} takımını {tGol1} - {tGol2} yenerek yarı finale çıkmıştır.");
                        yenıGrup.Add(grup[0]);
                    }
                    else if(a == false)
                    {
                        tGol2++;
                        grup[1].YarıFinal = true;
                        Console.WriteLine($"{grup[1].GetAd()} takımı {grup[0].GetAd()} takımını {tGol2} - {tGol1} yenerek yarı finale çıkmıştır.");
                        yenıGrup.Add(grup[1]);
                    }
                }
            }
            else if (tur == Tur.YarıFinal)
            {
                int tGol1 = gol1, tGol2 = gol2;
                if (tGol1 > tGol2)
                {
                    grup[0].Final = true;
                    Console.WriteLine($"{grup[0].GetAd()} takımı {grup[1].GetAd()} takımını {tGol1} - {tGol2} yenerek finale çıkmıştır.");
                    yenıGrup.Add(grup[0]);
                }
                else if (tGol2 > tGol1)
                {
                    grup[1].Final = true;
                    Console.WriteLine($"{grup[1].GetAd()} takımı {grup[0].GetAd()} takımını {tGol2} - {tGol1} yenerek finale çıkmıştır.");
                    yenıGrup.Add(grup[1]);
                }
                else
                {
                    Random r = new Random();
                    bool a = Convert.ToBoolean(r.Next(0, 2));
                    if(a == true)
                    {
                        tGol1++;
                        grup[0].Final = true;
                        Console.WriteLine($"{grup[0].GetAd()} takımı {grup[1].GetAd()} takımını {tGol1} - {tGol2} yenerek finale çıkmıştır.");
                        yenıGrup.Add(grup[0]);
                    }
                    else if (a == false)
                    {
                        tGol2++;
                        grup[1].Final = true;
                        Console.WriteLine($"{grup[1].GetAd()} takımı {grup[0].GetAd()} takımını {tGol2} - {tGol1} yenerek finale çıkmıştır.");
                        yenıGrup.Add(grup[1]);
                    }
                }
            }
            else if (tur == Tur.Final)
            {
                int tGol1 = gol1, tGol2 = gol2;
                if (tGol1 > tGol2)
                {
                    grup[0].Sampiyon = true;
                    Console.WriteLine($"{grup[0].GetAd()} takımı {grup[1].GetAd()} takımını {tGol1} - {tGol2} yenerek şampiyon olmuştur.");
                }
                else if (tGol2 > tGol1)
                {
                    grup[1].Sampiyon = true;
                    Console.WriteLine($"{grup[1].GetAd()} takımı {grup[0].GetAd()} takımını {tGol2} - {tGol1} yenerek şampiyon olmuştur.");
                }
                else
                {
                    Random r = new Random();
                    bool a = Convert.ToBoolean(r.Next(0, 2));
                    if (a == true)
                    {
                        tGol1++;
                        grup[0].Sampiyon = true;
                        Console.WriteLine($"{grup[0].GetAd()} takımı {grup[1].GetAd()} takımını {tGol1} - {tGol2} yenerek şampiyonolmuştur.");
                    }
                    else if (a == false)
                    {
                        tGol2++;
                        grup[1].Sampiyon = true;
                        Console.WriteLine($"{grup[1].GetAd()} takımı {grup[0].GetAd()} takımını {tGol2} - {tGol1} yenerek şampiyonolmuştur.");
                    }
                }
            }
        }
        #endregion
    }
}