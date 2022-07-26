using System;
using System.Text;

namespace Algorytms
{
    public class LinkedList
    {
        public LinkedList? Next;
        public int Data { get; set; }

        
        public LinkedList(int data=0)
        {
            Data = data;
        }

        public void appendToTail(int d)
        {
            LinkedList end = new LinkedList(d);
            LinkedList n = this;
            while(n.Next != null)
            {
                n = n.Next;
            }
            n.Next = end;
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            LinkedList? n = this;
            while (n != null)
            {
                Console.Write(n.Data);
                sb.Append($"{n.Data} ");
                n = n.Next;
            }
            Console.WriteLine();
            return sb.ToString();
        }

        public static void RemoveDuplicates(LinkedList head)
        {
            LinkedList? current = head;
            while(current !=null)
            {
                LinkedList runner = current;
                while(runner.Next != null)
                {
                    if(runner.Next.Data == current.Data)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                        runner = runner.Next;
                }
                current = current.Next;
            }
        }
    }

    public static class LinkedListAlgs
    {
        public static void Task_2_4()
        {
            LinkedList head = new LinkedList(3);
            head.appendToTail(5);
            head.appendToTail(8);
            head.appendToTail(5);
            head.appendToTail(9);
            head.appendToTail(2);
            head.appendToTail(1);

            head.Print();
        }

        public static void Task_2_1()
        {
            LinkedList head = new LinkedList(1);
            head.appendToTail(4);
            head.appendToTail(8);
            head.appendToTail(1);
            head.appendToTail(8);
            head.appendToTail(7);
            head.appendToTail(8);
            head.appendToTail(9);
            head.appendToTail(8);
            head.appendToTail(8);
            head.appendToTail(7);
            head.appendToTail(7);
            head.appendToTail(7);
            head.appendToTail(7);

            head.Print();
            LinkedList.RemoveDuplicates(head);
            head.Print();

        }
    }
}

