using System;
using System.Collections;

namespace Program
{
    class Sample
    {
        static void Main(string[] args)
        {
            List list = new List(new Node(10));
            list.AddHead(new Node(5));
            list.AddHead(new Node(4));
            list.AddTail(new Node(6));
            list.AddTail(new Node(8));
            list.PrintList();
            list.SortList();
            list.PrintList();
        }
    }

    class Node
    {
        public Node next;
        public Node tail;
        public int data;

        public Node(int x)
        {
            this.data = x;
            this.tail = null;
            this.next = null;
        }
    }

    class List
    {
        public Node head;
        public Node tail;
        private Node temp;

        public List(Node head)
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
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
                this.head.tail = this.tail;
            }
            node.tail = this.tail;
            Node temp1 = this.head;
            this.head = node;
            this.head.next = temp1;
        }

        public void AddTail(Node node)
        {
            node.tail = node;
            this.tail.next = node;
            this.tail.tail = node;
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

        public void SortList()
        {
            ArrayList array= new ArrayList();
            Node temp = this.head;
            for (int i = 0; i < this.Size(); i++)
            {
                array.Add(temp.data);
                temp = temp.next;
            }
            array.Sort();
            int j = 0;
            temp = this.head;
            while (temp != null)
            {
                temp.data = (int)array[j];
                temp = temp.next;
                j++;
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
