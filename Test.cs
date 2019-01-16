using System;
using System.Diagnostics;

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

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.value);

            traverse(root.left);
            traverse(root.right);
        }
    }
    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree bst = new Tree();
            int SIZE = 3;
            int[] a = new int[SIZE];

            Console.WriteLine("Generating random array with {0} values...", SIZE);

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                a[i] = Int32.Parse(Console.ReadLine());
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

            watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                root = bst.insert(root, a[i]);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

            watch = Stopwatch.StartNew();

            bst.traverse(root);

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}