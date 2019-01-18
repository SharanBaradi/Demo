using System;
namespace BinarySearchTree
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }
    class Tree
    {
        public Node Insert(Node Root, int Number)
        {
            //Inserting a Node to the Binary search tree
            if (Root == null)
            {
                Root = new Node();
                Root.Value = Number;
            }
            else if (Number < Root.Value)
            {
                Root.Left = Insert(Root.Left, Number);
            }
            else
            {
                Root.Right = Insert(Root.Right, Number);
            }
            return Root;
        }

        public void Search(Node Root, int Key)
        {
            //Searching A Node in BST
            while (Root != null)
            {
                if (Key == Root.Value)
                {
                    Console.Write("Key Found");
                    return;
                }
                else if (Key < Root.Value)
                {
                    Root = Root.Left;
                }
                else if (Key > Root.Value)
                {
                    Root = Root.Right;
                }
            }
            Console.Write("Key Not Found");
        }
        public void Ascending(Node Root)
        {
            //Printing BST in Ascending Order
            if (Root == null)
            {
                return;
            }
            Ascending(Root.Left);
            Console.Write(Root.Value + " ");
            Ascending(Root.Right);
        }
        public void Desending(Node Root)
        {
            //Printing BST in Descending Order
            if (Root == null)
            {
                return;
            }
            Desending(Root.Right);
            Console.Write(Root.Value + " ");
            Desending(Root.Left);
        }
    }
    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            int Number = new int();
            Node Root = null;
            Tree bst = new Tree();
            while (true)
            {
                Console.WriteLine("\n1.Insert\n2.Search\n3.Ascending\n4.Desending\n5.Exit");
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        /*Console.WriteLine("Enter Number");
                        Number = Int32.Parse(Console.ReadLine());
                        Root = bst.Insert(Root, Number);
                        */
                        Root = bst.Insert(Root, 7);
                        Root = bst.Insert(Root, 3);
                        Root = bst.Insert(Root, 11);
                        Root = bst.Insert(Root, 1);
                        Root = bst.Insert(Root, 5);
                        Root = bst.Insert(Root, 9);
                        Root = bst.Insert(Root, 13);
                        Root = bst.Insert(Root, 4);
                        Root = bst.Insert(Root, 6);
                        Root = bst.Insert(Root, 8);
                        Root = bst.Insert(Root, 12);
                        Root = bst.Insert(Root, 14);
                        break;
                    case 2:
                        Console.WriteLine("Enter Key to search");
                        Number = Int32.Parse(Console.ReadLine());
                        bst.Search(Root, Number);
                        break;
                    case 3:
                        Console.WriteLine();
                        bst.Ascending(Root);
                        break;
                    case 4:
                        Console.WriteLine();
                        bst.Desending(Root);
                        break;
                    case 5: return;
                }
            }
        }
    }
}