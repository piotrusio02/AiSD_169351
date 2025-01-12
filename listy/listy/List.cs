using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listy
{
    internal class List
    {
        public Node head;
        public Node tail;
        public int count = 0;

        public void AddFirst(int data) // dodawanie liczby na początku listy
        {
            Node node = new Node(data);

            if(head == null)
            {
                head = node;
                tail = node;
                count++;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
                count++;
            }
        }

        public void RemoveFirst() // usuwanie liczby na początku listy
        {
            if (head == tail)
            {
                head = null;
                tail = null;
                count--;
            }
            else
            {
                head = head.next;
                head.prev = null;
                count--;
            }

        }

        public void AddLast(int data) // dodawanie liczby na końcu listy
        {
            Node node = new Node(data);

            if(tail == null)
            {
                head = node;
                tail = node;
                count++;
            }
            else
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
                count++;
            }
        }

        public void RemoveLast()  // usuwanie liczby na końcu listy
        {
            if (head == tail)
            {
                head = null;
                tail = null;
                count--;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
                count--;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public int Znajdz(int index) // znajdowanie liczby po indexie
        {
            Node temp = head;
            for (int i = 0; i < index && temp.next != null; i++)
            {
                temp = temp.next;
            }

            return temp.data;
        }



    }

}
