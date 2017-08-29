using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    class Node
    {
        public Node nextNode { get; set; }
        public object value { get; set; }

        public Node(object data)
        {
            value = data;
        }

    }

    class LinkedLists
    {
        public Node head;
        public Node tail;
        public int size;

        public void Add(object data)
        {
            Node newNode = new Node(data);
            if (tail != null)
            {
                tail.nextNode = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = head;
            }
            size++;
        }

        public void Add_at_Beggining(object data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                newNode.nextNode = head;
                head = newNode;
            }
            size++;
        }

        public void Remove_at_Begginging(object data)
        {
            head = head.nextNode;

            size--;
        }

        public void PrintNodes()
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.Write(currentNode.value);
                Console.Write('-');
                currentNode = currentNode.nextNode;
            }

            Console.Write("NULL");
        }
    }
}
