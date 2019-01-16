using System;
namespace BinarySearchTree
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
    }
    class Tree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }
            return root;
        }
        public void Search(Node root, int key)
        {
            while (root != null)
            {
                if (key == root.value)
                {
                    Console.Write("Key Found");
                    return;
                }
                else if (key < root.value)
                {
                    root = root.left;
                }
                else if (key > root.value)
                {
                    root = root.right;
                }
            }
            Console.Write("Key Not Found");
        }
        public void Ascending(Node root)
        {
            if (root == null)
            {
                return;
            }
            Ascending(root.left);
            Console.Write(root.value + " ");
            Ascending(root.right);
        }
        public void Desending(Node root)
        {
            if (root == null)
            {
                return;
            }
            Desending(root.right);
            Console.Write(root.value + " ");
            Desending(root.left);
        }
    }
    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            int Number = new int();
            Node root = null;
            Tree bst = new Tree();
            while (true)
            {
                Console.WriteLine("\n1.Insert\n2.Search\n3.Ascending\n4.Desending\n5.Exit");
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Enter Number");
                        Number = Int32.Parse(Console.ReadLine());
                        root = bst.insert(root, Number);
                        break;
                    case 2:
                        Console.WriteLine("Enter Key to search");
                        Number = Int32.Parse(Console.ReadLine());
                        bst.Search(root, Number);
                        break;
                    case 3:
                        Console.WriteLine();
                        bst.Ascending(root);
                        break;
                    case 4:
                        Console.WriteLine();
                        bst.Desending(root);
                        break;
                    case 5: return;
                }
            }
        }
    }
}