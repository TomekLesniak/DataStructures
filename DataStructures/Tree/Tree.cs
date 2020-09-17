using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class Tree
    {
        private Node root;

        public Tree()
        {
            root = null;
        }

        public void Insert(int value)
        {
            var node = new Node(value, null, null);

            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;
            while (current != null)
            {
                if (current.Value == value)
                    return;

                if (value > current.Value)
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                    }
                    else
                    {
                        current = current.RightChild;
                    }
                }
                else
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                    }
                    else
                    {
                        current = current.LeftChild;
                    }
                }
            }

        }

        public bool Find(int value)
        {
            var current = root;

            while (current != null)
            {
                if (current.Value == value)
                    return true;

                current = (value > current.Value) ? current.RightChild : current.LeftChild;

            }

            return false;

        }

        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;


            Console.WriteLine(root.Value);
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);

        }

        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.LeftChild);
            Console.WriteLine(root.Value);
            TraverseInOrder(root.RightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeafNode(root))
                return 0;

            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }

        public int Min()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.LeftChild;
            }

            return last.Value;
        }


        //O(N)
        private int Min(Node root)
        {
            if (IsLeafNode(root))
                return root.Value;

            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);

        }

        public int CountLeaves()
        {
            return CountLeaves(root);

        }

        private int CountLeaves(Node root)
        {
            var count = 0;
            if (root == null)
                return 0;

            if (IsLeafNode(root))
                count++;

            count += CountLeaves(root.LeftChild);
            count += CountLeaves(root.RightChild);

            return count;

        }

        private bool IsLeafNode(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.Value < min || root.Value > max)
                return false;


            return IsBinarySearchTree(root.LeftChild, min, root.Value - 1)
                       && IsBinarySearchTree(root.RightChild, root.Value + 1, max);
        }

        public void NodesAtDistance(int distance)
        {
            NodesAtDistance(distance, root);
        }

        private void NodesAtDistance(int distance, Node root)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                Console.WriteLine(root.Value);
                return;
            }


            distance--;
            NodesAtDistance(distance, root.LeftChild);
            NodesAtDistance(distance, root.RightChild);
        }

        public void TreverseLevelOrder()
        {
            for (var i = 0; i <= Height(); i++)
            {
                NodesAtDistance(i);
            }
        }

        public bool Equals(Tree secondTree)
        {
            if (secondTree == null)
                return false;

            return Equals(root, secondTree.root);
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;
            if (first.Value != second.Value)
                return false;
            if (first.LeftChild == null && second.LeftChild != null)
                return false;
            if (first.LeftChild != null && second.LeftChild == null)
                return false;

            if (first.RightChild == null && second.RightChild != null)
                return false;
            if (first.RightChild != null && second.RightChild == null)
                return false;



            var left = Equals(first.LeftChild, second.LeftChild);
            var right = Equals(first.RightChild, second.RightChild);

            return left == right;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(Node root)
        {
            if (root == null)
                return 0;


            if (IsLeafNode(root))
                return 1;

            return 1 + Size(root.LeftChild) + Size(root.RightChild);
        }

        public int Max()
        {
            return Max(root, root.Value);
        }

        private int Max(Node root, int currentMax)
        {
            if (root == null)
                return currentMax;

            if (root.Value > currentMax)
                currentMax = root.Value;

            var maxLeft = Max(root.LeftChild, currentMax);
            var maxRight = Max(root.RightChild, currentMax);
            return (maxRight > maxLeft) ? maxRight : maxLeft;

        }

        public bool Contains(int value)
        {
            return Contains(value, root);
        }

        private bool Contains(int value, Node root)
        {
            if (root == null)
                return false;

            if (value == root.Value)
                return true;

            return Contains(value, root.LeftChild) || Contains(value, root.RightChild);
        }

        public List<int> GetAncestors(int value)
        {
            return GetAncestors(value, root);
        }

        private List<int> GetAncestors(int value, Node node)
        {
            if (!Contains(value))
                return null;

            var ancestors = new List<int>();

            while (node != null)
            {
                if (node.Value == value)
                    break;

                if (value > node.Value)
                {
                    ancestors.Add(node.Value);
                    node = node.RightChild;
                }
                else
                {
                    ancestors.Add(node.Value);
                    node = node.LeftChild;
                }
            }

            return ancestors;
        }
    }
}
