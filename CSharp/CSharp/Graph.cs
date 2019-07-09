using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    //class Graph
    //{
    //    private List<int>[] childNodes;

    //    public Graph(int size)
    //    {
    //        this.childNodes = new List<int>[size];
    //        for (int i = 0; i < size; i++)
    //        {
    //            this.childNodes[i] = new List<int>();
    //        }
    //    }

    //    public Graph(List<int>[] childNodes)
    //    {
    //        this.childNodes = childNodes;
    //    }

    //    public int Size
    //    {
    //        get { return this.childNodes.Length; }
    //    }

    //    public void AddEdge(int u, int v)
    //    {
    //        childNodes[u].Add(v);
    //    }
    //    public void RemoveEdge(int u, int v)
    //    {
    //        childNodes[u].Remove(v);
    //    }

    //    public bool HasEdge(int u, int v)
    //    {
    //        bool hasEdge = childNodes[u].Contains(v);
    //        return hasEdge;
    //    }
    //    public IList<int> GetSuccessors(int v)
    //    {
    //        return childNodes[v];
    //    }
    //}

    class Graph<T>
    {
        public Dictionary<T, GNode> graphNodes = new Dictionary<T, GNode>();

        public class GNode
        {
            public T id;
            public List<GNode> adjacentNode = new List<GNode>();
            public string state;

            public GNode(T id)
            {
                this.id = id;
            }
        }

        public void addNodes(T id)
        {
            GNode n = new GNode(id);
            graphNodes.Add(id, n);
        }

        public GNode getNode(T id)
        {
            return graphNodes[id];
        }

        public void addEdges(T begin, T end)
        {
            GNode beginN = getNode(begin);
            GNode endN = getNode(end);
            beginN.adjacentNode.Add(endN);
            //endN.adjacentNode.Add(beginN);
        }


        public Boolean searchDFS(T begin, T end)
        {
            Stack<GNode> nextToVisited = new Stack<GNode>();
            HashSet<T> visited = new HashSet<T>();
            nextToVisited.Push(getNode(begin));
            while (nextToVisited.Count > 0)
            {
                GNode n = nextToVisited.Pop();
                if (n.id.ToString() == end.ToString())
                    return true;
                if (visited.Contains(n.id))
                    continue;
                visited.Add(n.id);

                foreach (GNode aN in n.adjacentNode)
                {
                    nextToVisited.Push(aN);
                }

            }
            return false;
        }

        HashSet<T> visited = new HashSet<T>();

        public Boolean searchDFS_B(T begin, T end)
        {
            if (visited.Contains(begin))
                return false;

            visited.Add(begin);

            if (begin.ToString() == end.ToString())
                return true;

            foreach (GNode an in getNode(begin).adjacentNode)
            {
                if (searchDFS_B(an.id, end))
                    return true;
            }

            return false;
        }

        public Boolean searchBFS(T begin, T end)
        {
            Queue<GNode> nextToVisit = new Queue<GNode>();
            HashSet<T> visited = new HashSet<T>();

            nextToVisit.Enqueue(getNode(begin));

            while (nextToVisit.Count() > 0)
            {
                GNode n = nextToVisit.Dequeue();

                if (n.id.ToString() == end.ToString())
                    return true;

                if (visited.Contains(n.id))
                    continue;

                visited.Add(n.id);

                foreach (GNode an in n.adjacentNode)
                {
                    nextToVisit.Enqueue(an);
                }

            }

            return false;
        }
    }

    class TreeNode
    {
        public int data;
        public TreeNode left, right;
        public TreeNode parent;

        public TreeNode(int data)
        {
            this.data = data;
        }
    }
}
