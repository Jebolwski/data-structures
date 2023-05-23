using System;
using System.Xml.Linq;


namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList(new Node(4));
            list.AddTail(new Node(5));
            list.AddTail(new Node(6));
            list.AddTail(new Node(7));
            list.PrintList();
            list.insertBeginning();
            list.PrintList();

        }
    }

    class Node
    {
        public Node next;
        public int data;

        public Node(int x)
        {
            this.data = x;
            this.next = null;
        }
    }

    class LinkedList
    {
        public Node head;
        public Node tail;
        private Node temp;

        public LinkedList(Node head)
        {
            this.head = head;
            temp = head;
            while (this.temp.next != null)
            {
                temp = temp.next;
            }
            this.tail = temp;
        }

        public void PrintList()
        {
            temp = head;
            while (this.temp != null)
            {
                Console.Write(temp.data + " --> ");
                temp = temp.next;
            }
            Console.Write("\n");
        }

        public void AddHead(Node node)
        {
            Node temp1 = this.head;
            this.head = node;
            this.head.next = temp1;
        }

        public void AddTail(Node node)
        {
            this.tail.next = node;
            this.tail = this.tail.next;
        }

        public int Size()
        {
            Node temp1 = this.head;
            int count = 0;
            while (temp1 != null)
            {
                count++;
                temp1 = temp1.next;
            }
            return count;
        }

        public void insertBeginning()
        {
            if (this.tail != null)
            {
                Node temp = new Node(this.tail.data);
                this.RemoveTail();
                this.AddHead(temp);
            }
            else
            {
                Console.WriteLine("Bağlı liste boş.");
            }
        }

        public void AddMiddle(Node node)
        {
            Node temp1 = this.head;
            for (int i = 0; i < this.Size() / 2 - 1; i++)
            {
                temp1 = temp1.next;
            }
            Node tempo = temp1.next;
            node.next = tempo;
            temp1.next = node;
        }

        public void RemoveHead()
        {
            if (this.head != null)
            {
                this.head = this.head.next;
            }
            else
            {
                Console.WriteLine("Liste boş.");
            }
        }

        public void RemoveTail()
        {
            if (this.head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }
            Node temp = this.head;
            while (temp.next != this.tail)
            {
                temp = temp.next;
            }
            this.tail = temp;
            this.tail.next = null;
        }

        public void RemoveMiddle()
        {
            if (this.head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }
            Node temp = this.head;
            for (int i = 0; i < this.Size() / 2 - 1; i++)
            {
                temp = temp.next;
            }
            temp.next = temp.next.next;
        }
    }

}