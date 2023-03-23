using System;

namespace hafta5
{
    class Program
    {
        public class node
        {
            public int operand;
            public int tip;
            public int oncelik;
            public char islem;

            public node(int operand) {
                this.operand = operand;
                this.tip = 0;
            }

            public node(char islem)
            {
                this.tip = 1;
                this.islem = islem;
                switch(islem)
                {
                    case '+':
                    case '-':
                        this.oncelik = 1;
                        break;
                    case '(':
                    case ')':
                        this.oncelik = 0;
                        break;
                    case '*':
                        this.oncelik = 2;
                        break;
                    case '/':
                        this.oncelik = 2;
                        break;
                }
            }
        }

        public class stack
        {
            public int bas;
            public int boyut;
            public node[] dizi;

            public stack(int boyut) {
                this.dizi = new node[boyut];
                this.boyut= boyut;
                this.bas = -1;
            }

            public void push(node yeni)
            {
                if (bas != boyut - 1)
                {
                    bas++;
                    dizi[bas] = yeni;
                }
            }

            public node pop()
            {
                if (bas != -1)
                {
                    bas--;
                    return dizi[bas + 1];
                }
                return null;
            }

            public int hesapla(node[] ifade)
            {
                node x, x1, x2, sonuc;
                stack temp = new stack(100);
                for (int i = 0; i < ifade.Length; i++)
                {
                    x = ifade[i];
                    if (x.tip == 0)
                        temp.push(x);
                    else
                    {
                        x1 = temp.pop();
                        x2 = temp.pop();
                        sonuc = islem(x.islem, x1.operand, x2.operand);
                        temp.push(sonuc);
                    }
                }
                x = temp.pop();
                return x.operand;
            }

            public node islem(char islem, int x1,int x2)
            {
                int sonuc = 0;
                switch (islem)
                {
                    case '+':sonuc = x1 + x2;break;
                    case '-': sonuc = x1 - x2; break;
                    case '*': sonuc = x1 * x2; break;
                    case '/': sonuc = x1 / x2; break;
                }
                return new node(sonuc);
            }

            public void show()
            {
                Console.Write("STACK : ");
                for (int i = 0; i < this.bas; i++)
                {
                    Console.Write(dizi[i].operand+" ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            stack s1 = new stack(10);
            node[] d1 = new node[15];
            d1[0] = new node(8);
            d1[1] = new node(4);
            d1[2] = new node(5);
            d1[3] = new node('+');
            d1[4] = new node('-');
            d1[5] = new node(4);
            d1[6] = new node(9);
            d1[7] = new node(3);
            d1[8] = new node('/');
            d1[9] = new node('+');
            d1[10] = new node('*');
            d1[11] = new node(2);
            foreach (var item in d1)
            {
                s1.push(item);
            }
            s1.show();
            Console.WriteLine(s1.hesapla(d1));
        }
    }
}