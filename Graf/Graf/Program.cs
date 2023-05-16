using System;

namespace Program
{
    class Prog
    {
        static void Main(string[] args)
        {
            GrafArr grafArr = new GrafArr(10);
            grafArr.AddEdge(3, 6, 4);
            grafArr.AddEdge(3, 8, 1);
            grafArr.AddEdge(5, 8, 2);
            grafArr.AddEdge(5, 1, 4);
            for (int i = 0; i < grafArr.arr.Length; i++)
            {
                if (grafArr.arr[i].Size() != 0)
                {
                    Console.Write(i+ " ");
                    grafArr.arr[i].PrintList();
                }
                else
                {
                    Console.WriteLine(i+" -----");
                }
            }
        }
    }

    class Node
    {
        public Node next;
        public int weight;
        public int start;
        public int end;

        public Node(int baslangic,int bitis,int agirlik)
        {
            this.start = baslangic;
            this.end = bitis;
            this.weight = agirlik;
            this.next = null;
        }
    }

    class GrafArr
    {
        public List[] arr;
        int n;

        public GrafArr(int n)
        {
            arr = new List[n];
            this.n = n;
            for (int i = 0; i < n; i++)
            {
                arr[i] = new List();
            }
        }

        public void AddEdge(int start,int end, int weight)
        {
            Node node = new Node(start, end, weight);
            this.arr[start].AddTail(node);
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

        public List()
        {
            this.head = null;
            this.tail = null;
        }

        public void PrintList()
        {
            temp = head;
            while (this.temp != null)
            {
                Console.Write(temp.end + " --["+temp.weight+"]--> ");
                temp = temp.next;
            }
            Console.Write("\n");
        }

        public void AddHead(Node node)
        {
            if (this.head== null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                Node temp1 = this.head;
                this.head = node;
                this.head.next = temp1;
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