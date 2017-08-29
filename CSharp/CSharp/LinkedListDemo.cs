using System;

namespace CSharp
{
    internal class LinkedListDemo
    {
        LinkedLists ll = new LinkedLists();
        public LinkedListDemo()
        {
        }

        internal void process()
        {
            
                        
            //palindrome();

            //Remove Duplicates
            //ll.Add("D"); ll.Add("B"); ll.Add("A"); ll.Add("C"); ll.Add("A"); ll.Add("C"); ll.Add("B"); ll.Add("D");
            //ll.PrintNodes();
            //var newll = removeDuplicates(ll);
            //newll.PrintNodes();

            //Find 2 Linked Lists INTERSECTION
            LinkedLists ll1 = new LinkedLists();
            LinkedLists ll2 = new LinkedLists();
            createDataforIntersection(out ll1,out ll2);
            findIntersection(ll1.head,ll2.head);



        }


        #region Intersection point of two Linked Lists.

        private void createDataforIntersection(out LinkedLists ll1, out LinkedLists ll2)
        {
            ll1 = new LinkedLists();
            ll2 = new LinkedLists();

            Node n1 = new Node("3");
            Node n2 = new Node("6");
            Node n3 = new Node("9");
            Node n4 = new Node("15");
            Node n5 = new Node("30");
            Node n6 = new Node("10");

            ll1.head = n1;
            n1.nextNode = n2;
            n2.nextNode = n3;
            n3.nextNode = n4;
            n4.nextNode = n5;

            ll2.head = n6;
            n6.nextNode = n4;
        }
        private void findIntersection(Node head1, Node head2)
        {
            int count1 = getCount(head1);
            int count2 = getCount(head2);
            Node shorter, longer = null;

            shorter = count1 < count2 ? head1 : head2;
            longer = count1 > count2 ? head1 : head2;
            var diff = Math.Abs(count1 - count2);

            for (int i = 0; i < diff; i++)
            {
                longer = longer.nextNode;
            }

            while (longer != shorter)
            {
                longer = longer.nextNode;
                shorter = shorter.nextNode;
            }

            Console.WriteLine("Intersection Node : {0}", longer.value);
        }

        private int getCount(Node current)
        {
            int size = 0;
            while (current!= null)
            {
                size++;
                current = current.nextNode;
            }
            return size;
        }



        #endregion

        #region Write code to remove duplicates from an unsorted linked list
        private LinkedLists removeDuplicates(LinkedLists ll)
        {
            Node current = ll.head;
            Node runner = null;

            while (current != null)
            {
                runner = current;
                while (runner.nextNode != null)
                {
                    if (runner.nextNode.value == current.value)
                        runner.nextNode = runner.nextNode.nextNode;
                    else
                        runner = runner.nextNode;
                }
                current = current.nextNode;
            }

            return ll;
        }
        #endregion

        #region List is PALINDROME
        private void palindrome()
        {
            LinkedLists ll = new LinkedLists();
            ll.Add("0");
            ll.Add("1");
            ll.Add("2");
            ll.Add("3");
            ll.Add("0");

            LinkedLists revll = reverseList(ll.head);

            var result = compareLists(ll, revll);

            Console.WriteLine("Is Lists equal : {0}", result.ToString());
        }

        private bool compareLists(LinkedLists ll, LinkedLists revll)
        {
            Node n1 = ll.head;
            Node n2 = revll.head;

            while (n1 != null || n2 != null)
            {
                if (n1.value!= n2.value)
                {
                    return false;
                }

                n1 = n1.nextNode;
                n2 = n2.nextNode;
            }
            return n1 == null && n2 == null;
        }

        public LinkedLists reverseList(Node node)
        {
            LinkedLists revList = new LinkedLists();
            while (node != null)
            {
                //n = new Node(node.value); //Clone the node
                revList.Add_at_Beggining(node.value);
                node = node.nextNode;
            }

            return revList;
        }

        #endregion
    }
}