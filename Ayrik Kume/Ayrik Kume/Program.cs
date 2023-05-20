using System;
using System.Runtime.CompilerServices;

namespace Program
{
    class Prog
    {
        static void Main(string[] args)
        {
            AyrikKume ayrikKume = new AyrikKume(10);
            ayrikKume.kumeleriBirlestir(1, 2);
            ayrikKume.kumeleriBirlestir(2, 4);
            ayrikKume.kumeleriBirlestir(4, 3);
            ayrikKume.kumeleriBirlestir(7, 8);
            ayrikKume.kumeleriBirlestir(8, 6);
            Console.WriteLine(ayrikKume.kumeBul(6));
        }
    }

    class Oge
    {
        public int icerik,ebeveyn,derinlik;

        public Oge(int icerik)
        {
            ebeveyn = icerik;
            derinlik = 1;
            this.icerik = icerik;
        }
    }

    class AyrikKume
    {
        Oge[] kumeler;
        int kactane;

        public AyrikKume(int n)
        {
            this.kactane = n;
            this.kumeler = new Oge[n];
            for (int i = 0; i < n; i++)
            {
                kumeler[i] = new Oge(i);
            }
        }

        public int kumeBul(int n)
        {
            if (kumeler[n].ebeveyn != n)
            {
                return kumeBul(kumeler[n].ebeveyn);
            }
            return kumeler[n].ebeveyn;
        }

        public void kumeleriBirlestir(int sira1,int sira2)
        {
            int x, y;
            x = kumeBul(sira1);
            y = kumeBul(sira2);
            if (kumeler[x].derinlik < kumeler[y].derinlik)
            {
                kumeler[x].ebeveyn = y;
            }
            else
            {
                kumeler[y].ebeveyn = x;
                if (kumeler[x].derinlik == kumeler[y].derinlik)
                {
                    kumeler[x].derinlik++;
                }
            }
        }
    }
}