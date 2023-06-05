using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IT391U3B
{
    class U3PartB
    {
        static void Main(string[] args)
        {
            //*********************************************************
            //****Assignment 3, Part B, Section 1
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine("**********Section 1 **********");
            Console.WriteLine();

            //Loading array
            String[] mammals = new string[] { "Bear", "Gorilla", "Tiger", "Polar Bear", "Lion", "Monkey" };

            //Set implementation populated by array
            HashSet<String> setMammals = new HashSet<String>();
            try
            {
                for (int i = 0; i <= mammals.GetUpperBound(0); i++)
                {
                    setMammals.Add(mammals[i]);
                }
                Console.WriteLine("Contents of the set are: "); //Displaying contents in set with for loop
                Console.Write("[");
                for (int i = 0; i <= mammals.GetUpperBound(0); i++)
                {
                    Console.Write(mammals[i]);
                    if (i == mammals.GetUpperBound(0))
                    {
                        Console.Write("]");
                    }
                    else
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Contents of the sorted set are: ");
                SortedSet<String> sortedMammals = new SortedSet<string>(setMammals); //Sorting Set
                Console.Write("[");
                int j = 0;
                foreach (string job in sortedMammals)
                {
                    Console.Write(job);
                    if (j != sortedMammals.Count() - 1)
                        Console.Write(", ");
                    j++;
                }
                Console.Write("]");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("The first item in the set is " + sortedMammals.First()); //First mammal in set
                Console.WriteLine("The last item in the set is " + sortedMammals.Last()); //Last mammal in set

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }


            //*********************************************************
            //****Assignment 3, Part B, Section 2
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********Section 2 **********");
            Console.WriteLine();

            //loading list
            List<String> myFriends = new List<String>();
            myFriends.Add("Fred 602-299-3300");
            myFriends.Add("Ann 602-555-4949");
            myFriends.Add("Grace 520-544-9898");
            myFriends.Add("Sam 602-343-8723");
            myFriends.Add("Dorothy 520-689-9745");
            myFriends.Add("Susan 520-981-8745");
            myFriends.Add("Bill 520-456-9823");
            myFriends.Add("Mary 520-788-3457");

            Console.WriteLine("The content of my friends list: ");
            DisplayList(myFriends);
            Console.WriteLine();

            myFriends.Sort(); //sort the friends list

            Console.WriteLine("Sorted friends List: ");
            DisplayList(myFriends);
            Console.WriteLine();

            myFriends.RemoveAt(1);//remove bill from sorted list
            myFriends.RemoveAt(0); //remove first friend from sorted list
            myFriends.RemoveAt(myFriends.Count() - 1);//remove last friend from sorted list

            Console.WriteLine("The updated contents of my friends list: ");
            DisplayList(myFriends);
            Console.WriteLine();

            Console.Write("The number of friends in my list is: " + myFriends.Count + "\n");
            Console.WriteLine();

            int index = myFriends.IndexOf("Fred 602-299-3300"); //look for this friend in the list
            if (index != -1)
            {
                Console.WriteLine("Fred is in the list.");
            }
            else
            {
                Console.WriteLine("Fred is not in the list.");
            }

            //*********************************************************
            //****Assignment 3, Part B, Section 3
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********Section 3 **********");
            Console.WriteLine();

            //creates a new binary tree object which will initialize itself and print its contents
            new BinaryTree().create();

            Console.ReadKey();

        }

        static void DisplayList(List<String> lst)
        {
            Console.Write("[");
            for (int i = 0; i < lst.Count(); i++)
            {
                Console.Write(lst[i]);
                if (i != lst.Count() - 1)
                    Console.Write(", ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }

    public class Node
    {
        public Node left;
        public Node right;
        public int value;
        public Node(int value)
        { this.value = value; }
    }

    public class BinaryTree
    {
        public void create()
        {
            Node rootnode = new Node(50);
            insert(rootnode, 30);
            insert(rootnode, 45);
            insert(rootnode, 12);
            insert(rootnode, 29);
            Console.WriteLine("The three different traversing orders: ");
            traverse(rootnode);
        }

        public void traverse(Node rootnode)
        {
            Console.WriteLine("Traversing the binary tree in order");
            printInOrder(rootnode); // printInOrder uses recursion to traverse the tree
            Console.WriteLine();
            Console.WriteLine("Traversing the binary tree in pre-order");
            printPreOrder(rootnode); // printPreOrder uses recursion to traverse the tree
            Console.WriteLine();
            Console.WriteLine("Traversing the binary tree in post-order");
            printPostorder(rootnode); // printPostOrder uses recursion to traverse the tree
            Console.WriteLine();

        }

        public void insert(Node node, int value)
        {
            if (value < node.value)
            {
                if (node.left != null)
                {
                    insert(node.left, value);
                }
                else
                {
                    //Console.WriteLine(" Inserted " + value + " to left of node " + node.value);
                    node.left = new Node(value);
                }
            }
            else if (value > node.value)
            {
                if (node.right != null) { insert(node.right, value); }
                else
                {
                    //Console.WriteLine(" Inserted " + value + " to right of node " + node.value);
                    node.right = new Node(value);
                }
            }
        }
        
        public void printInOrder(Node node) //In-order traversal method
        {
            if (node != null)
            {
                printInOrder(node.left); 
                Console.WriteLine(" Traversed " + node.value);
                printInOrder(node.right);
            }
        }

        public void printPreOrder(Node node) //Pre-Order traversal method
        {
            if (node != null)
            {
                Console.WriteLine(" Traversed " + node.value);
                printPreOrder(node.left);
                printPreOrder(node.right);
            }
        }

        public void printPostorder(Node node) //Post-Order traversal method
        {
            if (node != null)
            {
                printPostorder(node.left);
                printPostorder(node.right);
                Console.WriteLine(" Traversed " + node.value);
            }
        }
    }
}
