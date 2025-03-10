 namespace BTREE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinaryTree<char> tree = new BinaryTree<char>();
            //tree.Insert('A');
            //tree.Insert('B');
            //tree.Insert('C');
            //tree.Insert('D');
            //tree.Insert('E');
            //tree.Insert('F');
            //tree.Insert('G');
            //tree.Insert('H');
            //tree.Insert('I');
            //tree.Print();
            ////Console.WriteLine(tree.Height());
            ////tree.PreOrder();

            ////Console.WriteLine(tree.Find('p'));

            //tree.Delete('G');
            //tree.Print();




            //BinaryTree<int> tree = new BinaryTree<int>();

            // Insert elements
            //tree.Insert(1);
            //tree.Insert(2);
            //tree.Insert(3);
            //tree.Insert(4);
            //tree.Insert(5);
            //tree.Insert(6);
            //tree.Insert(7);
            //tree.Print();
            //Console.WriteLine("Original Tree (InOrder):");
            //tree.InOrder(); // Expected Output: 4 -> 2 -> 5 -> 1 -> 6 -> 3 -> 7 -> 

            //Console.WriteLine("\nDeleting a leaf node (7):");
            //tree.Delete(2);
            //tree.InOrder(); // Expected Output: 4 -> 2 -> 5 -> 1 -> 6 -> 3 -> (7 removed)
            //tree.Print();

            ////Console.WriteLine("\nDeleting a node with one child (3):");
            ////tree.Delete(3);
            ////tree.InOrder(); // Expected Output: 4 -> 2 -> 5 -> 1 -> 6 -> (3 removed)
            ////tree.Print();

            ////Console.WriteLine("\nDeleting a node with two children (1):");
            ////tree.Delete(1);
            ////tree.InOrder(); // Expected Output: Adjusted inorder traversal without 1
            ////tree.Print();

            ////Console.WriteLine("\nDeleting the root node (remaining root):");
            ////tree.Delete(2);
            ////tree.InOrder(); // Expected Output: Remaining tree after removing root
            ////tree.Print();

            ////Console.WriteLine("\nDeleting a non-existent node (100):");
            ////tree.Delete(100);
            ////tree.InOrder(); // Should be the same as previous since 100 does not exist
            ////tree.Print();

            ////Console.WriteLine("\nDeleting from an empty tree:");
            ////tree.Delete(10); // Should handle gracefully
            //tree.Print();

            //Console.WriteLine("Tests completed.");

            BinaryTree<int> tree = new BinaryTree<int>();

            tree.BSInsert(4);
            tree.BSInsert(2);
            tree.BSInsert(1);
            tree.BSInsert(3);
            tree.BSInsert(5);
            tree.BSInsert(6);
            tree.Print();

            tree.BSDelete(2);
            tree.Print();

            tree.BSDelete(5);
            tree.Print();

            tree.BSDelete(1);
            tree.Print();

            //Console.WriteLine( tree.IsExist(3));

            //Console.WriteLine( tree.FindNodeAndPaternt(3));


        }
    }
}
