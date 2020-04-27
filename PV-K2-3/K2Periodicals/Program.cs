
using System;
using System.IO;

namespace K2Periodicals
{
    public interface ICount<T>
    {
        /// <summary>
        /// Indicates whether some properties of the <paramref name="data"/> are the same
        /// as properties of the current instance.
        /// </summary>
        /// <param name="data">The data which similarity with current instance is 
        /// checked.</param>
        /// <returns>true, if <paramref name="data"/> similarity with the current instance
        /// is found; otherwise, false.</returns>
        bool Same(T data);
        /// <summary>
        /// Counts or accumulates values of the <paramref name="data"/> properties into the
        /// current instance.
        /// </summary>
        /// <param name="data">The data to be counted or accumulated.</param>
        void Calculate(T data);
    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a subscription 
    /// data and manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Subscription
    {
        public string SubName { get; set; }
        public decimal Price { get; set; }
        public Subscriber Subscriber { get; set; }
        public Periodical Periodical { get; set; }

        public Subscription(string subName, decimal price, string name, string surname, string address, int time)
        {
            SubName = subName;
            Price = price;

            Subscriber = new Subscriber(name, surname, address);
            Periodical = new Periodical(time);
            Subscriber.Name = name;
            Subscriber.Surname = surname;
            Subscriber.Address = address;
            Periodical.Time = time;

        }
    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a subscriber 
    /// data and manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Subscriber
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public Subscriber(string name, string surname, string address)
        {
            Name = name;
            Surname = surname;
            Address = address;
        }

    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a periodical 
    /// data and manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Periodical
    {
        public int Time { get; set; }
        public Periodical(int time)
        {
            Time = time;

        }
    }

    /// <summary>
    /// Provides generic container where the data are stored in the linked list.
    /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
    /// IF THE IMPLEMENTATION OF ANY METHOD REQUIRES IT.
    /// </summary>
    /// <typeparam name="T">The type of the data to be stored in the list. Data 
    /// class should implement some interfaces.</typeparam>
    public class LinkList<T>
    {
        class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        /// <summary>
        /// All the time should point to the first element of the list.
        /// </summary>
        private Node begin;
        /// <summary>
        /// Shouldn't be used in any other methods except Begin(), Next(), Exist() and Get().
        /// </summary>
        private Node current;


        /// <summary>
        /// Initializes a new instance of the LinkList class with empty list.
        /// </summary>
        public LinkList()
        {
            begin = current = null;
        }
        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to move internal pointer to the first element of the list.
        /// </summary>
        public void Begin()
        {
            current = begin;
        }
        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to move internal pointer to the next element of the list.
        /// </summary>
        public void Next()
        {
            current = current.Next;
        }
        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to check whether the internal pointer points to the element of the list.
        /// </summary>
        /// <returns>true, if the internal pointer points to some element of the list; otherwise,
        /// false.</returns>
        public bool Exist()
        {
            return current != null;
        }
        /// <summary>
        /// One of four interface methods devoted to loop through a list and get value stored in it.
        /// Method should be used to get the value stored in the node pointed by the internal pointer.
        /// </summary>
        /// <returns>the value of the element that is pointed by the internal pointer.</returns>
        public T Get()
        {
            return current.Data;
        }

        /// <summary>
        /// Method appends new node to the beginning of the list and saves in it <paramref name="data"/>
        /// passed by the parameter.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="data">The data to be stored in the list.</param>
        public void Add(T data)
        {
            if (begin == null)
            {
                begin = new Node(data, null);
            }
            else
            {
                Node temp = new Node(data, null);
                temp.Next = begin;
                begin = temp;
            }
        }

        /// <summary>
        /// Method sorts data in the list. The data object class should implement IComparable&lt;T&gt;
        /// interface though defining sort order.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        public void Sort()
        {
            throw new NotImplementedException();
        }
    }



    public static class InOut
    {
        /// <summary>
        /// Creates the list containing data read from the text file.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="fileName">The name of the text file</param>
        /// <returns>List with data from file</returns>
        public static LinkList<Subscription> ReadFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            LinkList<Subscription> subscriptions = new LinkList<Subscription>();
            string text = reader.ReadToEnd();
            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] data = line.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                Subscription subscription = new Subscription(data[0], decimal.Parse(data[1]), data[2], data[3], data[4], int.Parse(data[5]));

                subscriptions.Add(subscription);
            }

            return subscriptions;
        }

        /// <summary>
        /// Appends CSV formatted rows from the data contained in the <paramref name="list"/>
        /// to the end of the text file.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
        /// IF THE IMPLEMENTATION REQUIRES IT.
        /// </summary>
        /// <typeparam name="T">The type of the data objects stored in the list</typeparam>
        /// <param name="fileName">The name of the text file</param>
        /// <param name="list">The list of the data to be stored in the file.</param>
        public static void PrintToFile<T>(string fileName, LinkList<T> list)
        {
            if (!File.Exists(fileName)) File.Create(fileName);
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.AutoFlush = true;

                    writer.WriteLine(new string('-', 76));
                    writer.WriteLine(string.Format("| {0,-30} | {1,-20} | {2,10} |", "Prenumeratas", "Laikas", "Pavadinimas"));
                    writer.WriteLine(new string('-', 76));

                    for (list.Begin(); list.Exist(); list.Next())
                    {
                        Subscription subscription = null;

                        writer.WriteLine(string.Format("| {0,-30} | {1,-20} | {2,10} |", subscription.Subscriber, subscription.Price, subscription.Periodical));
                    }

                    writer.WriteLine(new string('-', 76));
                    writer.WriteLine("");

                    writer.Dispose();
                    writer.Close();

                }
            }
        }
    }

    public static class Task
    {
        /// <summary>
        /// Counts the number of subscriptions that should be delivered in given month.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="list">The subscriptions data.</param>
        /// <param name="month">The month of delivery.</param>
        /// <returns>The count of subscriptions</returns>
        public static int DeliveryCount(LinkList<Subscription> list, int month)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates similar members of the<paramref name="source"/> list into a result list 
        /// according to the implementation of ICount interface in the
        /// <typeparamref name="TResult"/> type class.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULDN'T CHANGE THE SIGNATURE OF THE METHOD!
        /// </summary>
        /// <typeparam name="TResult">The type of the data objects stored in the returned list</typeparam>
        /// <typeparam name="TData">The type of the data objects stored in the <paramref name="source"/></typeparam>
        /// <param name="source">The source list which data would be grouped.</param>
        /// <returns>The list that contains summarized data.</returns>
        public static LinkList<TResult> Calculate<TResult, TData>(LinkList<TData> source) where TResult : IComparable<TResult>, ICount<TData>, new() where TData : IComparable<TData>
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        /// <summary>
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        static void Main()
        {
            throw new NotImplementedException();
        }
    }
}
