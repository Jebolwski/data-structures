using System;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            tree t = new tree(new node(13));
            t.addToTree(new node(3));
            t.addToTree(new node(4));
            t.addToTree(new node(12));
            t.addToTree(new node(14));
            t.addToTree(new node(10));
            t.addToTree(new node(5));
            t.addToTree(new node(1));
            t.addToTree(new node(8));
            t.addToTree(new node(2));
            t.addToTree(new node(7));
            t.addToTree(new node(9));
            t.addToTree(new node(11));
            t.addToTree(new node(6));
            t.addToTree(new node(18));

            t.preorder(t.root);
            Console.WriteLine();
            t.inorder(t.root);
            Console.WriteLine();
            t.postorder(t.root);

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