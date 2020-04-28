using System;
using System.IO;

namespace K2Factory
{
    public interface IBeneath<T>
    {
        /// <summary>
        /// Indicates whether the value of the certain property of the current instance is
        /// less than certain value passed by parameter.
        /// </summary>
        /// <param name="data">The value to compare against.</param>
        /// <returns>true if current instance is less than data; otherwise, 
        /// false</returns>
        bool LessThan(T data);
        /// <summary>
        /// Indicates whether the value of the certain property of the current instance is
        /// less than or equal to certain value passed by parameter.
        /// </summary>
        /// <param name="data">The value to compare against.</param>
        /// <returns>true if current instance is less than or equal to data;
        /// otherwise, false</returns>
        bool LessThanOrEqual(T data);
    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of an operation data
    /// and manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Operation : IComparable<Operation>, IBeneath<int>, IBeneath<string>
    {
        public int Day { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }


        public Operation (int day, string fullName, string code, int amount, decimal cost)
        {
            this.Day = day;
            this.FullName = fullName;
            this.Code = code;
            this.Amount = amount;
            this.Cost = cost;
        }

        public int CompareTo(Operation other)
        {
            if (this.FullName.CompareTo(other.FullName) != 0)
            {
                return this.FullName.CompareTo(other.FullName);
            }
            else
            {
                return this.Amount.CompareTo(other.Amount) * -1;
            }
        }

        public bool LessThan(int data)
        {
            return this.Amount < data;
        }

        public bool LessThanOrEqual(int data)
        {
            return this.Amount <= data;
        }

        public bool LessThan(string data)
        {
            return this.Code.CompareTo(data) < 0;
        }

        public bool LessThanOrEqual(string data)
        {
            return this.Code.CompareTo(data) < 1;
        }

    }

    /// <summary>
    /// Provides generic container where the data are stored in the linked list.
    /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
    /// IF THE IMPLEMENTATION OF ANY METHOD REQUIRES IT.
    /// </summary>
    /// <typeparam name="T">The type of the data to be stored in the list. Data 
    /// class should implement some interfaces.</typeparam>
    public class LinkList<T> where T :IComparable<T>
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
        /// All the time should point to the last element of the list.
        /// </summary>
        private Node end;
        /// <summary>
        /// Shouldn't be used in any other methods except Begin(), Next(), Exist() and Get().
        /// </summary>
        private Node current;

        /// <summary>
        /// Initializes a new instance of the LinkList class with empty list.
        /// </summary>
        public LinkList()
        {
            begin = current = end = null;
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
        /// Removes the element that is pointed by the internal pointer and advances the internal
        /// pointer to the next element. The method should be used in a combination with the methods
        /// Begin(), Next(), Exist().
        /// If the last element of the list is removed, the internal pointer is assigned null.
        /// </summary>
        public void RemoveCurrent()
        {
            if (current is null)
                return;
            if (current == begin)
            {
                begin = begin.Next;
                if (begin is null)
                    end = null;
                current.Next = null;
                current = begin;
            }
            else
            {
                Node prev = begin;
                while (prev.Next != current)
                    prev = prev.Next;
                prev.Next = current.Next;
                if (current == end)
                    end = prev;
                current.Next = null;
                current = prev.Next;
            }
        }

        /// <summary>
        /// Method appends new node to the end of the list and saves in it <paramref name="data"/>
        /// passed by the parameter.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="data">The data to be stored in the list.</param>
        public void Add(T data)
        {
            if (begin == null)
            {
                begin = new Node(data, null);

                end = begin;
            }
            else
            {
                Node temp = new Node(data, null);

                end.Next = temp;
                end = temp;

            }
        }

        /// <summary>
        /// Method sorts data in the list. The data object class should implement IComparable
        /// interface though defining sort order.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        public void Sort()
        {
            if (begin == null)
            {
                return;
            }

            bool done = true;

            while (done)
            {
                done = false;

                for (Node d = begin; d != null && d.Next != null; d = d.Next)
                {
                    if (d.Data.CompareTo(d.Next.Data) > 0)
                    {
                        T temp = d.Data;

                        d.Data = d.Next.Data;

                        d.Next.Data = temp;

                        done = true;
                    }
                }
            }
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
        public static LinkList<Operation> ReadFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            LinkList<Operation> operations = new LinkList<Operation>();

            string text = reader.ReadToEnd();
            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] data = line.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 5)
                {

                    Operation Operation = new Operation(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]), decimal.Parse(data[4]));

                    operations.Add(Operation);
                }
            }

            return operations;
        }

        /// <summary>
        /// Appends the table, built from data contained in the list and preceded by the header,
        /// to the end of the text file.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="fileName">The name of the text file</param>
        /// <param name="header">The header of the table</param>
        /// <param name="list">The list from which the table to be formed</param>
        public static void PrintToFile(string fileName, string header, LinkList<Operation> list)
        {
            if (!File.Exists(fileName)) File.Create(fileName).Close();

            list.Begin();

            if (list.Exist())
            {
                using (var writer = new StreamWriter(fileName, true)) // True means Append text to file
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(new string('-', 73));
                    writer.WriteLine(string.Format("| {0,-69} |", header));
                    writer.WriteLine(new string('-', 73));
                    writer.WriteLine(string.Format("| {0,5} | {1,-30} | {2,-10} | {3, 6} | {4, 6} |", "Diena", "Vardas Pavarde", "Kodas", "Kiekis", "Kaina"));
                    writer.WriteLine(new string('-', 73));

                    for (list.Begin(); list.Exist(); list.Next())
                    {
                        Operation operation = list.Get();

                        writer.WriteLine(string.Format("| {0,5} | {1,-30} | {2,-10} | {3, 6} | {4, 6} |", operation.Day, operation.FullName, operation.Code, operation.Amount, operation.Cost));
                    }

                    writer.WriteLine(new string('-', 73));
                    writer.Dispose();
                    writer.Close();
                }
            }
        }
    }

    public static class Task
    {
        /// <summary>
        /// Finds the smallest quantity value in the list.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="list">The data for the calculation.</param>
        /// <returns>The smallest quantity value.</returns>
        public static int MinQuantity(LinkList<Operation> list)
        {
            int min = 99999;

            for (list.Begin(); list.Exist(); list.Next())
            {
                Operation temp = list.Get();

                if (temp.Amount < min)
                {
                    min = temp.Amount;
                }
            }

            return min;
        }

        /// <summary>
        /// Removes objects, those certain property value is less than or equal to 
        /// <paramref name="value"/>, from the list. 
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULDN'T CHANGE THE SIGNATURE OF THE METHOD!
        /// </summary>
        /// <typeparam name="TData">The type of the data objects stored in the list</typeparam>
        /// <typeparam name="TCriterion">The type of the criterion</typeparam>
        /// <param name="source">The list to be modified</param>
        /// <param name="value">The upper bound of the property value for objects to be removed
        /// form the list. </param>
        public static void Remove<TData, TCriterion>(LinkList<TData> source, TCriterion value) where TData : IComparable<TData>, IBeneath<TCriterion>
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
            const string BalFile = "Balandis.txt";
            const string KovFile = "Kovas.txt";
            const string CRF = "Rezultatai.txt";

            if (File.Exists(CRF))
            {
                File.Delete(CRF);
            }

            LinkList<Operation> BalOperations = InOut.ReadFromFile(BalFile);
            LinkList<Operation> KovOperations = InOut.ReadFromFile(KovFile);

            InOut.PrintToFile(CRF, "Balandzio duom", BalOperations);
            InOut.PrintToFile(CRF, "Kovo duom", KovOperations);


            BalOperations.Sort();
            KovOperations.Sort();

            InOut.PrintToFile(CRF, "Rikiuoti Balandzio duom", BalOperations);
            InOut.PrintToFile(CRF, "Rikiuoti Kovo duom", KovOperations);

        }
    }
}

