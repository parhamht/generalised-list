using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalised_list
{
    public class node
    {
        public int tag; // 0 or 1.
        public int data;
        public node dlink;
        public node link;
        public node(int tag, int data = 0, node dlink = null, node link = null)
        {
            this.tag = tag;
            this.data = data;
            this.dlink = dlink;
            this.link = link;
        }
    }
    public class Genlist
    {
        public node head;
        public void CustomDisplay(node start) // Display from everywhere you want.
        {
            Console.Write("<");
            while(start != null)
            {
                if (start.tag == 0)
                {
                    Console.Write(start.data);
                    if (start.link != null)
                        Console.Write(",");
                }
                else
                    CustomDisplay(start.dlink);
                start = start.link;
            }
            Console.Write(">");
        }
        public void Display() // Display all of the genlist.
        {
            CustomDisplay(head);
            Console.WriteLine();
        }
        public int sum(node start)
        {
            int s = 0;
            while (start != null)
            {
                if (start.tag == 0)
                    s += start.data;
                else
                    s += sum(start.dlink);
                start = start.link;
            }
            return s;
        }
        public int depth(node start)
        {
            if (start == null)
                return 0;
            node s = start;
            int m = 0;
            while (s != null)
            {
                if (s.tag == 1)
                {
                    int n = depth(s.dlink);
                    if (m < n)
                        m = n;
                }
                s = s.link;
            }
            return m + 1;
        }
    } 
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                node f = new node(0, 4);
                node e = new node(1, dlink: f);
                node d = new node(0, 3, link: e);
                node c = new node(0, 2, link: d);
                node b = new node(1, dlink: c);
                node a = new node(0, 1, link: b);
                Genlist g = new Genlist();
                g.head = a;
                g.Display();
                Console.WriteLine(g.sum(a));
                Console.WriteLine(g.depth(a));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
