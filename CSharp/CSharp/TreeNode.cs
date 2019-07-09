using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTesting

{

    class Tree
    {
        TreeNode root = null;
        public int size()
        {
            return root == null ? 0 : root.size;
        }

        public TreeNode getRandomNode()
        {
            if (root == null) return null;

            Random rand = new Random();
            int i =rand.Next(size());

            return root.getNthNode(i);
        }

        public void insert(int val)
        {
            if(root == null)
            {
                root = new CSharpTesting.TreeNode(val);
            }
            else
            {
                root.insertInOrder(val);
            }
        }
    }
    class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public int size = 0;

        public TreeNode(int d)
        {
            this.data = d;
            this.size= 1;
        }

        public TreeNode getRandomNode()
        {
            int leftSize = left == null ? 0 : left.size;

            Random random = new Random();
            int index = random.Next(size);

            if (index < leftSize)
            {
                return left.getRandomNode();
            }
            else if (index == leftSize)
            {
                return this;
            }
            else
                return right.getRandomNode();
        }



        public void insertInOrder(int d)
        {
            if (d <= data)
            {
                if (this.left == null)
                    this.left = new TreeNode(d);
                else
                    insertInOrder(d);
            }
            else
            {
                if (this.right == null)
                    this.right = new TreeNode(d);
                else
                    insertInOrder(d);
            }
            size++;
        }

        public TreeNode find(int d)
        {
            if (d == this.data)
                return this;
            else
            {
                if (d <= this.data)
                    if (this.left != null)
                        return left.find(d);
                    else
                        return null;
                else if (d > this.data)
                    if (this.right != null)
                        return right.find(d);
                    else
                        return null;
            }
            return null;
        }

        public void delete(int d)
        {
            if(this == null)
            {
                return;
            }
            else
            {
                if(this.data == d)
                {

                }
            }
        }

        internal TreeNode getNthNode(int i)
        {
            int leftSize = left == null ? 0 : left.size;
            if (i < leftSize)
            {
                return left.getNthNode(i);
            }
            else if (i == leftSize)
                return this;
            else
                return right.getNthNode(i - (leftSize + 1));
        }
    }
}
