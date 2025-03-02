 namespace BTREE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<char> tree = new BinaryTree<char>();
            tree.Insert('A');
            tree.Insert('B');
            tree.Insert('C');
            tree.Insert('D');
            tree.Insert('E');
            tree.Insert('F');
            tree.Insert('G');
            tree.Insert('H');
            tree.Insert('I');
            tree.Print();
        }
    }
}
