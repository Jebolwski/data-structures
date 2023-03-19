using System;

namespace Program
{
    class One
    {
        static void Main(string[] args)
        {
            liste list = new liste();
            while (true)
            {
                Console.WriteLine("-----İşlemler------");
                Console.WriteLine("Ekle (e)");
                Console.WriteLine("Sil (s)");
                Console.WriteLine("Çıkış (q)");
                Console.Write("Hangisini istersiniz : ");
                string input = Console.ReadLine();
                if (input == "q")
                {
                    Console.WriteLine("Listenin son hali : ");
                    list.printList();
                    Console.WriteLine("İşlem bitti.");
                    break;
                }
                if (input == "e") {
                    Console.WriteLine("----EKLEME----");
                    Console.WriteLine("Seçenekleriniz");
                    Console.WriteLine("Başa ekle (b)");
                    Console.WriteLine("Sona ekle (s)");
                    Console.WriteLine("Ortaya ekle (o)");
                    Console.Write("Hangisini istersiniz : ");
                    string input1 = Console.ReadLine();
                    if (input1 == "b")
                    {
                        Console.Write("Eklenecek elemanın değeri : ");
                        int inputint = Convert.ToInt32(Console.ReadLine());
                        list.addtohead(new node(inputint));
                    }
                    else if (input1 == "s")
                    {
                        Console.Write("Eklenecek elemanın değeri : ");
                        int inputint = Convert.ToInt32(Console.ReadLine());
                        list.addtoend(new node(inputint));
                    }
                    else if (input1 == "o")
                    {
                        Console.Write("Eklenecek elemanın değeri : ");
                        int inputint = Convert.ToInt32(Console.ReadLine());
                        list.addtomiddle(new node(inputint));
                    }
                    Console.WriteLine("Listenin hali : ");
                    list.printList();
                }
                else if (input == "s")
                {
                    Console.WriteLine("----SİLME----");
                    Console.WriteLine("Seçenekleriniz");
                    Console.WriteLine("Baştan sil(b)");
                    Console.WriteLine("Sondan sil (s)");
                    Console.WriteLine("Ortadan sil (o)");
                    Console.Write("Hangisini istersiniz : ");
                    string input1 = Console.ReadLine();
                    if (input1 == "b")
                    {
                        list.removefromhead();
                    }
                    else if (input1 == "s")
                    {
                        list.removefromend();
                    }
                    else if (input1 == "o")
                    {
                        list.removefrommiddle();
                    }
                    list.printList();
                }
            }
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

    }

}