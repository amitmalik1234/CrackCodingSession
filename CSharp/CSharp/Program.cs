using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedListDemo obj = new LinkedListDemo();
            //obj.process();
            Console.WriteLine("String is Palindrome {0}", isPalindrom("abcdcba"));
            Console.WriteLine("String is Palindrome {0}", isPalindrom("abcdssdafdcba"));
            Graph<string> g = CreateGraph();
            TreeNode tn = CreateTreeNode();

            //var res = createLevelList(tn);
            //var res = createLevelLinkedList(tn);

            //result = isBalanced2(tn);
            //var result = checkBST(tn);
            //int lastV = -1;
            //var result = checkBST2(tn, ref lastV);

            var result = allSequences(tn);

            Console.WriteLine("Result: " + result);

            //bool searchPath = g.searchDFS_B("A", "E");
            //Console.WriteLine("Path exists {0}", searchPath);
            //searchPath = g.searchDFS("A", "E");
            //searchPath = g.searchBFS("A", "E");
            //Console.WriteLine("Path exists {0}", searchPath);



        }

        #region Get the Ancestor of nodes

        #region Solution 1
        //static TreeNode commonAncestor(TreeNode root, TreeNode a, TreeNode b)
        //{
        //    if (!containsNode(root, a) || !containsNode(root, b)) return null;

        //    return getAncestor(root,a , b);
        //}

        //static TreeNode getAncestor(TreeNode root, TreeNode a, TreeNode b)
        //{
        //    if (root == null || root == a || root == b)
        //    {
        //        return root;
        //    }

        //    Boolean aOnLeft = containsNode(root.left, a);
        //    Boolean bOnLeft = containsNode(root.left, b);

        //    if (aOnLeft != bOnLeft) /// Nodes are on different side
        //        return root;

        //    TreeNode childSide = aOnLeft ? root.left : root.right;

        //    return getAncestor(childSide, a, b);

        //}

        //static Boolean containsNode(TreeNode root, TreeNode n)
        //{
        //    if (root == null) return false;
        //    if (root == n) return true;

        //    return containsNode(root.left, n) || containsNode(root.right, n);
        //}
        #endregion

        #region Solution 2

        //static TreeNode commonAncestor(TreeNode root, TreeNode a, TreeNode b)
        //{
        //    if (root == null) return null;
        //    if (root == a && root == b) return root;

        //    TreeNode x = commonAncestor(root.left, a, b);
        //    if (x != null && x != a && x != b)
        //        return x;

        //    TreeNode y = commonAncestor(root.right, a, b);
        //    if (y != null && y != a && y != b)
        //        return y;

        //    if (x != null && y != null)
        //    {
        //        return root;
        //    }
        //    else if (root == a || root == b)
        //        return root;
        //    else
        //        return x == null ? y : x;
        //}


        TreeNode commonAncestor(TreeNode root, TreeNode a, TreeNode b)
        {
            Result r = commonAncestorHelper(root, a, b);

            if (r.isAncestor)
                return r.node;

            return null;
        }

        Result commonAncestorHelper(TreeNode root, TreeNode a, TreeNode b)
        {
            if (root == null) return new Result(null, false);

            if (root == a && root == b)
            {
                return new Result(root, true);
            }

            Result rx = commonAncestorHelper(root.left, a, b);
            if (rx.isAncestor)
                return rx;

            Result ry = commonAncestorHelper(root.right, a, b);
            if (ry.isAncestor)
                return ry;

            if (rx.node != null && ry.node != null)
                return new Result(root, true);
            else if (root == a || root == b)
            {
                Boolean isanc = rx.node != null || ry.node != null;
                return new Result(root, isanc);
            }
            else
                return new Result(rx.node != null ? rx.node : ry.node, false);
        }
        #endregion

        #endregion

        #region Successor of TreeNode

        static TreeNode inOrderSuccessor(TreeNode node)
        {
            if (node == null) return null;

            if (node.right != null)
            {
                return leftMostChild(node.right);
            }
            else
            {
                TreeNode q = node;
                TreeNode x = q.parent;

                while (x != null && x.left != q)
                {
                    q = x;
                    x = x.parent;
                }
                return x;
            }
        }

        static TreeNode leftMostChild(TreeNode node)
        {
            if (node == null) return null;

            while (node.left != null)
            {
                node = node.left;
            }

            return node;
        }

        #endregion

        #region Is Binary Tree Balanced

        static Boolean isBalanced(TreeNode root)
        {
            if (root == null) return true;

            int heightDiff = getHeight(root.left) - getHeight(root.right);
            if (Math.Abs(heightDiff) > 1)
                return false;
            else
                return isBalanced(root.left) && isBalanced(root.right);

        }

        static private int getHeight(TreeNode node)
        {
            if (node == null) return -1;
            return Math.Max(getHeight(node.left), getHeight(node.right)) + 1;
        }


        //*******************************//

        static private int checkHeight(TreeNode node)
        {
            if (node == null) return -1;

            int leftheight = checkHeight(node.left);
            if (leftheight == int.MinValue)
                return int.MinValue;

            int rightHeight = checkHeight(node.right);
            if (rightHeight == int.MinValue)
                return int.MinValue;

            int heightDiff = leftheight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
                return int.MinValue;
            else
                return Math.Max(leftheight, rightHeight) + 1;
        }

        static Boolean isBalanced2(TreeNode root)
        {
            return checkHeight(root) != int.MinValue;
        }

        #endregion

        #region Binary tree is Binary Search Tree


        //static int index = 0;
        static void copyBST(TreeNode root, int[] array, ref int index)
        {
            if (root == null) return;

            copyBST(root.left, array, ref index);
            array[index] = root.data;
            index++;
            copyBST(root.right, array, ref index);
        }

        static Boolean checkBST(TreeNode root)
        {
            int[] arr = new int[7];
            int idx = 0;
            copyBST(root, arr, ref idx);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] <= arr[i - 1])
                    return false;
            }

            return true;
        }

        static Boolean checkBST2(TreeNode root, ref int LastVisited) {
            if (root == null) return true;

            if (!checkBST2(root.left, ref LastVisited)) return false;
            if (LastVisited != -1 && root.data <= LastVisited) { return false; }

            LastVisited = root.data;

            if (!checkBST2(root.right, ref LastVisited)) return false;

            return true;

        }

        static Boolean checkBST3(TreeNode root, int min, int max)
        {
            if (root == null) return true;

            if (root.data <= min && root.data > max)
            {
                return false;
            }

            if (!checkBST3(root.left, min, root.data) || !checkBST3(root.right, root.data, max))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Create list of each depth of a tree

        static void createLevelLinkedList(TreeNode root, List<LinkedList<TreeNode>> lists, int level)
        {
            if (root == null) return;

            LinkedList<TreeNode> list = null;

            if (lists.Count == level)
            {
                list = new LinkedList<TreeNode>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }

            list.AddLast(root);

            createLevelLinkedList(root.left, lists, level + 1);
            createLevelLinkedList(root.right, lists, level + 1);
        }

        static List<LinkedList<TreeNode>> createLevelLinkedList(TreeNode root)
        {
            List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
            createLevelLinkedList(root, lists, 0);
            return lists;
        }

        private static List<List<TreeNode>> createLevelList(TreeNode root)
        {
            List<List<TreeNode>> result = new List<List<TreeNode>>();
            List<TreeNode> current = new List<TreeNode>();
            if (root != null)
            {
                current.Add(root);
            }

            while (current.Count > 0)
            {
                result.Add(current);
                List<TreeNode> parents = current;
                current = new List<TreeNode>();
                foreach (TreeNode parent in parents)
                {
                    if (parent.left != null)
                    {
                        current.Add(parent.left);
                    }
                    if (parent.right != null)
                    {
                        current.Add(parent.right);
                    }
                }
            }
            return result;
        }

        #endregion

        private static TreeNode CreateTreeNode()
        {
            //TreeNode tn = new CSharp.TreeNode(13);

            //tn.left = new CSharp.TreeNode(4);
            //tn.left.left = new TreeNode(1);
            //tn.left.right = new TreeNode(6);

            //tn.right = new CSharp.TreeNode(20);
            //tn.right.left = new CSharp.TreeNode(15);
            //tn.right.right = new CSharp.TreeNode(24);

            TreeNode tn = new TreeNode(2);
            tn.left = new TreeNode(1);
            tn.right = new TreeNode(3);

            return tn;
        }

        private static Graph<string> CreateGraph()
        {
            Graph<string> g = new Graph<string>();
            g.addNodes("A");
            g.addNodes("B");
            g.addNodes("C");
            g.addNodes("D");
            g.addNodes("E");
            g.addNodes("F");
            g.addNodes("G");

            g.addEdges("A", "B");
            g.addEdges("B", "C");
            g.addEdges("C", "D");
            g.addEdges("C", "E");
            g.addEdges("D", "B");
            g.addEdges("D", "E");
            g.addEdges("E", "F");
            g.addEdges("F", "G");

            return g;
        }

        public static bool search(Graph<string> g, Graph<string>.GNode start, Graph<string>.GNode end)
        {
            if (start == end) return true;
            Queue<string> nextToVisit = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            nextToVisit.Enqueue(start.id);
            while (nextToVisit.Count > 0)
            {
                Graph<string>.GNode n = g.getNode(nextToVisit.Dequeue());
                if (n.id == end.id)
                {
                    return true;
                }

                if (visited.Contains(n.id))
                    continue;
                visited.Add(n.id);

                foreach (Graph<string>.GNode an in n.adjacentNode)
                {
                    nextToVisit.Enqueue(an.id);
                }
            }
            return false;
        }

        public static Boolean isPalindrom(string str)
        {
            int begIdx = 0;
            int endIdx = str.Length - 1;

            while (endIdx > 0) {
                if (str[begIdx] != str[endIdx])
                    return false;
                begIdx++;
                endIdx--;
            }
            return true;
        }



        #region BST Sequence to arrray list

        static List<LinkedList<int>> allSequences(TreeNode node)
        {
            List<LinkedList<int>> result = new List<LinkedList<int>>();

            if (node == null)
            {
                result.Add(new LinkedList<int>());
                return result;
            }

            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddLast(node.data);

            List<LinkedList<int>> leftSeq = allSequences(node.left);
            List<LinkedList<int>> rightSeq = allSequences(node.right);

            foreach (LinkedList<int> left in leftSeq)
            {
                foreach (LinkedList<int> right in rightSeq)
                {
                    List<LinkedList<int>> weaved = new List<LinkedList<int>>();
                    weavedList(left, right, weaved, prefix);

                    result.AddRange(weaved);
                }
            }

            return result;

        }

        private static void weavedList(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results, LinkedList<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                LinkedList<int> result = new LinkedList<int>();
                copyLinkedList(result, prefix);
                copyLinkedList(result, first);
                copyLinkedList(result, second);
                results.Add(result);
                return;
            }

            int headFirst = first.First();
            first.RemoveFirst();
            prefix.AddLast(headFirst);
            weavedList(first, second, results, prefix);
            prefix.RemoveLast();
            first.AddFirst(headFirst);

            int headSecond = second.First();
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            weavedList(first, second, results, prefix);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }

        private static void copyLinkedList(LinkedList<int> result, int[] res)
        {
            foreach (var item in res)
            {
                result.AddLast(item);
            }
        }
        private static void copyLinkedList(LinkedList<int> to, LinkedList<int> from)
        {
            if (from.Count > 0)
            {
                int[] arr = new int[from.Count];
                from.CopyTo(arr, 0);
                foreach (var item in arr)
                {
                    to.AddLast(item);
                }
            }
        }


        #endregion

        #region Tree is subtree of Another Tree ( T2 is subtree of T1)
        static Boolean containsTree(TreeNode t1, TreeNode t2)
        {
            if (t2 == null)
                return true;

            return subTree(t1, t2);
        }

        private static bool subTree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return false;
            else if (t1.data == t2.data && matchTree(t1, t2))
                return true;

            return subTree(t1.left, t2) || subTree(t1.right, t2);
        }

        static Boolean matchTree(TreeNode t1, TreeNode t2)
        {
            if(t1 == null && t2 == null) // both trees are null
            {
                return true; 
            }
            else if(t1 == null || t2 == null)
            {
                return false;
            }
            else if(t1.data != t2.data)
            {
                return false;
            }
            else
            {
                return matchTree(t1.left, t2.left) && matchTree(t1.right, t2.right);
            }

        }

        #endregion

    }

    class Result
    {
        public TreeNode node;
        public Boolean isAncestor;
        public Result(TreeNode n, Boolean isAnc)
        {
            this.node = n;
            this.isAncestor = isAnc;
        }
    }
}
