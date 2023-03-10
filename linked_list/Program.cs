using System;

namespace Program
{
    class Sample
    {
        static void Main(string[] args)
        {
            Node node = new Node(2);
            node.next = new Node(4);
            node.next.next = new Node(98);

            List list = new List(node);

            list.PrintList();

            list.AddHead(new Node(32));

            list.PrintList();

            list.AddHead(new Node(12));

            list.PrintList();

            list.AddTail(new Node(92));

            list.PrintList();

            list.AddMiddle(new Node(83));

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
            while (this.temp!=null)
            {
                Console.Write(temp.data+" --> ");
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
            this.tail.next=node;
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

    }
}
