using System;
using System.Xml.Linq;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tree = new tree(new node(10));
            tree.InsertNode(5);
            tree.InsertNode(15);
            tree.InsertNode(12);
            tree.InsertNode(18);
            tree.inorder(tree.root);
            Console.WriteLine("\n==============");
            tree.preorder(tree.root);
            Console.WriteLine("\n==============");
            tree.postorder(tree.root);
            Console.WriteLine();
            Console.WriteLine(tree.nodeCount());
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

        public void InsertNode(int data)
        {
            node newNode = new node(data);

            if (root == null) //First node insertion  
                root = newNode;
            else
            {
                node current = root;

                while (true)
                {
                    node tempParent = current;
                    if (Convert.ToInt32(newNode.data) < Convert.ToInt32(current.data))
                    {
                        current = current.left;
                        if (current == null)
                        {
                            tempParent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            tempParent.right = newNode;
                            return;
                        }
                    }
                }
            }
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

        public int nodeCount()
        {
            int count = 0;
            void helper(node x)
            {
                if (this.root == null)
                {
                    return;
                }
                count++;
                if (x.left != null)
                    helper(x.left);
                if (x.right != null)
                    helper(x.right);
            }
            helper(this.root);
            return count;
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