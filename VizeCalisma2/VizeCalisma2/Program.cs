using System;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            stack s = new stack();
            s.smash(new node(8));
            s.smash(new node(5));
            s.smash(new node(4));
            s.smash(new node(2));
            s.printStack();
            s.smash(new node(10));
            s.printStack();
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

    class stack
    {
        public node bas;
        public node son;

        public stack()
        {
            this.bas = null;
            this.son = null;
        }

        public void push(node node)
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

        public int pop()
        {
            if (this.size() == 1)
            {
                int val = this.son.veri;
                this.bas = null;
                this.son = null;
                return val;
            }
            else if (this.size() > 0)
            {
                int val = this.son.veri;
                this.son = this.son.geri;
                this.son.ileri = null;
                return val;
            }
            else
            {
                this.bas = null;
                this.son = null;
                Console.WriteLine("Listede silmek için eleman yok.");
                return -1;
            }
        }

        public void printStack()
        {
            node temp = this.son;
            while (temp != null)
            {
                Console.WriteLine(" | " + temp.veri + " | ");
                temp = temp.geri;
            }
            Console.WriteLine();
        }

        public void smash(node n)
        {
            if (this.size() == 0)
            {
                this.push(n);
            }
            else
            {
                if (n.veri < this.peek())
                {
                    this.push(n);
                }
                else
                {
                    while (this.peek() < n.veri)
                    {
                        this.pop();
                    }
                    this.push(n);
                }
            }
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

        public int peek()
        {
            if (this.size() > 0)
                return this.son.veri;
            return '0';
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