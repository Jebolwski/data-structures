using System;

namespace Prog
{
    class Program
    {
        static void Main()
        {
            List list = new List();
            list.AddTail(new Node(10));
            list.AddTail(new Node(20));
            list.AddTail(new Node(30));
            list.AddTail(new Node(40));
            list.PrintList();
            list.ReverseList();
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

    class List
    {
        public Node head;
        public Node tail;
        private Node temp;

        public List()
        {
            this.head = null;
            this.tail = null;
        }

        public void ReverseList() { 
            if (this.head != null)
            {
                int boyutu = this.Size();
                int[] arr = new int[boyutu];
                Node temp = this.head;
                int i = 0;
                while (temp != null)
                {
                    arr[i] = temp.data;
                    temp = temp.next;
                    i++;
                }
                for (int j = 0; j < Math.Ceiling((float)(boyutu / 2)); j++)
                {
                    int degiscek = boyutu - j - 1;
                    int tempo = arr[degiscek];
                    arr[degiscek] = arr[j];
                    arr[j] = tempo;
                }
                temp = this.head;
                i = 0;
                while (temp != null)
                {
                    temp.data = arr[i];
                    temp=temp.next;
                    i++;
                }

            }
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
            }
            else
            {
                Node temp = this.head;
                this.head = node;
                this.head.next = temp;
            }
        }

        public void AddTail(Node node)
        {
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.next = node;
                this.tail = this.tail.next;
            }
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