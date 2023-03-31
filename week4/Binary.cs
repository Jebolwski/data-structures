using System;
using System.Collections.Generic;

namespace Program
{
    class Sample
    {
        static void Main(string[] args)
        {
            liste list = new liste();
            Console.Write("Ne kadar uzunlukta liste oluşsun : ");
            int length = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                int sayi = rnd.Next(0,100);
                list.addsorted(new node(sayi));
            }
            list.printList();
            Console.Write("Aramak istediğin eleman : ");
            int index = Convert.ToInt32(Console.ReadLine());
            list.binarysearch(index);
            
        }

    }

    class node
    {
        public int veri;
        public node ileri;
        public node geri;

        public node(int x)
        {
            veri = x;
            ileri = null;
            geri = null;
        }
    }

    class liste
    {
        public node bas;
        public node son;

        public liste()
        {
            this.bas = null;
            this.son = null;
        }

        public void printList()
        {
            node temp = this.bas;
            while (temp != null)
            {
                Console.Write(temp.veri + " <--> ");
                temp = temp.ileri;
            }
            Console.WriteLine("NULL");
        }

        public void printListReverse()
        {
            node temp = this.son;
            while (temp != null)
            {
                Console.Write(temp.veri + " <--> ");
                temp = temp.geri;
            }
            Console.WriteLine("NULL");
        }

        public int size()
        {
            int count = 0;
            node temp = this.bas;
            while (temp != null)
            {
                count++;
                temp = temp.ileri;
            }
            return count;
        }


        public void addtohead(node node)
        {
            if (bas == null)
            {
                this.bas = node;
                this.son = node;
            }
            else
            {
                node.ileri = this.bas;
                this.bas.geri = node;
                this.bas = node;
            }
        }

        public void addtoend(node node)
        {
            if (bas == null)
            {
                this.bas = node;
                this.son = node;
            }
            else
            {
                node.geri = this.son;
                this.son.ileri = node;
                this.son = node;
            }
        }

        public void addtomiddle(node node)
        {
            if (this.size() > 2)
            {
                node temp = this.bas;
                for (int i = 0; i < this.size() / 2 - 1; i++)
                {
                    temp = temp.ileri;
                }
                node.geri = temp;
                node.ileri = temp.ileri;
                temp.ileri = node;
            }
            else
            {
                Console.WriteLine("Ortaya eklemek için listenin uzunluğu en az 3 olmalıdır.");
            }
        }

        public void addsorted(node node)
        {
            node temp = this.bas;
            if (this.son == null)
            {
                this.bas = node;
                this.son = node;
                return;
            }
            else if (temp.veri > node.veri)
            {
                node.ileri = this.bas;
                this.bas.geri = node;
                this.bas = node;
            }
            else
            {
                while (temp.ileri!=null && node.veri > temp.ileri.veri)
                {
                    temp = temp.ileri;
                }
                if (temp.ileri != null)
                {
                    temp.ileri.geri = node;
                }
                node.ileri = temp.ileri;
                node.geri = temp;
                temp.ileri = node;
            }
        }

        public void removefrommiddle()
        {
            if (this.size() > 2)
            {
                node temp = this.bas;
                for (int i = 0; i < this.size() / 2 - 1; i++)
                {
                    temp = temp.ileri;
                }
                temp.ileri.ileri.geri = temp;
                temp.ileri = temp.ileri.ileri;
            }
            else
            {
                Console.WriteLine("Ortadan silmek için listenin uzunluğu en az 3 olmalıdır.");
            }
        }

        public void removefromhead()
        {
            if (this.size() > 0)
            {
                this.bas = this.bas.ileri;
                this.bas.geri = null;
            }
            else
            {
                Console.WriteLine("Listede silmek için eleman yok.");
            }
        }

        public void removefromend()
        {
            if (this.size() > 0)
            {
                this.son = this.son.geri;
                this.son.ileri = null;
            }
            else
            {
                Console.WriteLine("Listede silmek için eleman yok.");
            }
        }

        public void binarysearch(int x) {
            int left = 0;
            int right = this.size() - 1;
            int count = 0;
            while (left <= right)
            {
                count++;
                int orta = (left+right)/2;
                node ortanode = this.getbyindex(orta); 
                if (ortanode.veri == x)
                {
                    Console.WriteLine(orta+" indisinde bulundu.");
                    Console.WriteLine(count+" iterasyonda bulundu.");
                    return;
                }
                else if (ortanode.veri > x)
                {
                    right = orta - 1;
                }
                else if (ortanode.veri< x)
                {
                    left = orta + 1;
                }
            }
            Console.WriteLine(x+" listede bulunamadı.");
        }
    
        public node getbyindex(int index)
        {
            node temp = this.bas;
            for (int i = 0; i < index; i++)
            {
                temp = temp.ileri;
            }
            return temp;
        }
    }

}
