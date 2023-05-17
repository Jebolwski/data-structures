using System;
using System.Collections;

namespace Program
{
    class Prog
    {
        static void Main(string[] args)
        {
            GrafArr grafArr = new GrafArr(6);
            grafArr.AddEdge(1, 2, 1);
            grafArr.AddEdge(1, 4, 1);
            grafArr.AddEdge(2, 1, 1);
            grafArr.AddEdge(2, 4, 1);
            grafArr.AddEdge(2, 3, 1);
            grafArr.AddEdge(3, 2, 1);
            grafArr.AddEdge(3, 5, 1);
            grafArr.AddEdge(4, 1, 1);
            grafArr.AddEdge(4, 2, 1);
            grafArr.AddEdge(4, 5, 1);
            grafArr.AddEdge(5, 4, 1);
            grafArr.AddEdge(5, 3, 1);
            for (int i = 0; i < grafArr.arr.Length; i++)
            {
                if (grafArr.arr[i].Size() != 0)
                {
                    Console.Write(i+ " --[1]--> ");
                    grafArr.arr[i].PrintList();
                }
                else
                {
                    Console.WriteLine("-----");
                }
            }
            grafArr.BFS(3);
            Console.WriteLine("\n==========");
            grafArr.DFS(3);
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

        public void BFS(int s)
        {

            // Mark all the vertices as not
            // visited(By default set as false)
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
                visited[i] = false;

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as
            // visited and enqueue it
            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {

                // Dequeue a vertex from queue
                // and print it
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                // Get all adjacent vertices of the
                // dequeued vertex s. If a adjacent
                // has not been visited, then mark it
                // visited and enqueue it
                List list = arr[s];

                foreach (Node val in list)
                {
                    if (!visited[val.end])
                    {
                        visited[val.end] = true;
                        queue.AddLast(val.end);
                    }
                }
            }
        }

        void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited
            // and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices
            // adjacent to this vertex
            List vList = arr[v];
            foreach (Node n in vList)
            {
                if (!visited[n.end])
                    DFSUtil(n.end, visited);
            }
        }

        // The function to do DFS traversal.
        // It uses recursive DFSUtil()
        public void DFS(int v)
        {
            // Mark all the vertices as not visited
            // (set as false by default in c#)
            bool[] visited = new bool[n];

            // Call the recursive helper function
            // to print DFS traversal
            DFSUtil(v, visited);
        }
    }

    class List : IEnumerable
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

        public IEnumerator GetEnumerator()
        {
            ArrayList arrlist = new ArrayList();
            Node temp = this.head;
            while (temp != null) {
                arrlist.Add(temp);
                temp = temp.next;
            }
            return arrlist.GetEnumerator();
        }
    }

}