using System;
using System.Collections;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tree = new tree(new node(8));
            tree.addToTree(new node(10));
            tree.addToTree(new node(3));
            tree.addToTree(new node(1));
            tree.addToTree(new node(6));
            tree.addToTree(new node(4));
            tree.addToTree(new node(7));
            tree.addToTree(new node(14));
            tree.addToTree(new node(13));
            // 0(1)  1(2)   2(4)       3(8)
            // 8     3 10   1 6 - 14   - - 4 7 - - 13 -
            Console.WriteLine(tree.find_data(3, 2));
        }
    }

    class node
    {
        public int data;
        public node left;
        public node right;
        public node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }

    class tree
    {
        public node root;

        public tree(node root)
        {
            this.root = root;
        }

        public void addToTree(node node)
        {
            if (this.root == null)
            {
                this.root = node;
                return;
            }
            node tmp = this.root;
            while (tmp != null)
            {
                if (node.data > tmp.data)
                {
                    if (tmp.right != null)
                    {

                        tmp = tmp.right;
                    }
                    else
                    {
                        tmp.right = node;
                        return;
                    }
                }
                else
                {
                    if (tmp.left != null)
                    {
                        tmp = tmp.left;
                    }
                    else
                    {
                        tmp.left = node;
                        return;
                    }
                }
            }
        }

        public node searchNode(int x)
        {
            if (this.root == null)
            {
                Console.WriteLine("Agac bos.");
            }
            node temp = this.root;
            while (temp != null)
            {
                if (temp.data == x)
                {
                    Console.WriteLine(x + " agacta bulundu.");
                    return temp;
                }
                else
                {
                    if (temp.data > x)
                    {
                        temp = temp.left;
                    }
                    else
                    {
                        temp = temp.right;
                    }
                }
            }
            Console.WriteLine("Aranan deger (" + x + ") agacta yok.");
            return null;
        }

        public void preorder(node x)
        {

            if (this.root == null)
            {
                return;
            }
            Console.Write(x.data + " ");
            if (x.left != null)
                preorder(x.left);
            if (x.right != null)
                preorder(x.right);
        }
        // 0(1) 1(2)   2(4)
        // 10   6 16   4 8 12 18
        // 0(1) 1(2)   2(4)
        // 5    3 7    1 9 2 4 

        public int find_data(int depth,int index)
        {
            int output = 0;
            for (int i = 0; i < depth-1; i++)
            {
                output+=(int)Math.Pow(2, i);
            }
            int[] arr = treeToArray();
            return arr[output + index];
        }

        private int factorial(int x)
        {
            int res = 1;
            for (int i = 1; i < x+1; i++)
            {
                res *= i;
            }
            return res;
        }

        public void postorder(node x)
        {

            if (this.root == null)
            {
                return;
            }
            if (x.left != null)
                preorder(x.left);
            if (x.right != null)
                preorder(x.right);
            Console.Write(x.data + " ");
        }

        public void inorder(node x)
        {

            if (this.root == null)
            {
                return;
            }
            if (x.left != null)
                preorder(x.left);
            Console.Write(x.data + " ");
            if (x.right != null)
                preorder(x.right);
        }

        public void remove(int key)
        {
            if (searchNode(key) != null)
            {
                RemoveHelper(this.root, key);
            }
            else
            {
                Console.WriteLine("Aradığınız eleman ağaçta yok.");
            }
        }

        public int height(node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(height(node.right), height(node.left));
            }
        }

        private node RemoveHelper(node root, int key)
        {


            if (root == null)
                return root;
            //if key is less than the root node,recurse left subtree
            if (key < root.data)
                root.left = RemoveHelper(root.left, key);
            // if key is more than the root node,recurse right subtree
            else if (key > root.data)
            {
                root.right = RemoveHelper(root.right, key);
            }

            //else we found the key
            else
            {
                //case 1: Node to be deleted has no children
                if (root.left == null && root.right == null)
                {
                    //update root to null
                    root = null;
                }
                //case 2 : node to be deleted has two children
                else if (root.left != null && root.right != null)
                {
                    node maxNode = this.maxNode(root.right);
                    //copy the value
                    root.data = maxNode.data;
                    root.right = RemoveHelper(root.right, maxNode.data);
                }
                //node to be deleted has one children
                else
                {
                    var child = root.left != null ? root.left : root.right;
                    root = child;
                }

            }


            return root;

        }

        public int[] treeToArray() {
            int len = factorial(this.height(this.root));
            int[] arr = new int[len];
            Queue<node> queue = new Queue<node>();
            void helper(node x,int i)
            {
                if (this.root == null)
                {
                    return;
                }
                if (x.left != null)
                {
                    queue.Enqueue(x.left);
                }
                if (x.right != null)
                {
                    queue.Enqueue(x.right);
                }
                if (queue.Any())
                {
                    helper(queue.Dequeue(),i+1);
                }
                arr[i]=x.data;
            }
            helper(this.root,0);
            return arr;
        }

        node minNode(node node)
        {
            if (node == null)
            {
                Console.Write("Agacin koku bos.\n");
            }
            node temp = node;
            while (temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }

        node maxNode(node node)
        {

            if (node == null)
            {
                Console.Write("Agacin rootu bos.\n");
                return null;
            }
            node temp = node;
            while (temp.right != null)
            {
                temp = temp.right;
            }
            return temp;
        }

        public bool isBST(node node)
        {
            if (node == null)
                return true;

            // nodun solundaki ağacın en büyük elemanının
            // nodun değerinden büyükse ikili arama ağacı değildir.
            if (node.left != null
                && maxNode(node.left).data > node.data)
                return false;

            // nodun sağdaki ağacın en küçük elemanının
            // nodun değerinden küçükse ikili arama ağacı değildir.
            if (node.right != null
                && minNode(node.right).data < node.data)
                return false;

            // Özyinelemeli olarak bakıyor.
            if (isBST(node.left) == false || isBST(node.right) == false)
                return false;

            //bütün doğrulamalardan geçerse doğrudur.
            return true;
        }
    }

}