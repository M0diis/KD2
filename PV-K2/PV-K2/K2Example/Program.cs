using System;
using System.Collections.Generic;
using System.IO;

namespace K2Example
{
    public interface IBetween<T>
    {
        /// <summary>
        /// Indicates wether the value of the certain property of the current instance is in
        /// [<paramref name="from"/>, <paramref name="to"/>] range including range marginal values.
        /// <paramref name="from"/> should always precede <paramref name="to"/> in default sort order.
        /// </summary>
        /// <param name="from">The starting value of the range</param>
        /// <param name="to">The ending value of the range</param>
        /// <returns>true if the value of the current object property is in range; otherwise,
        /// false.</returns>
        bool MutuallyInclusiveBetween(T from, T to);

        /// <summary>
        /// Indicates wether the value of the certain property of the current instance is in
        /// [<paramref name="from"/>, <paramref name="to"/>] range excluding range marginal values.
        /// <paramref name="from"/> should always precede <paramref name="to"/> in default sort order.
        /// </summary>
        /// <param name="from">The starting value of the range</param>
        /// <param name="to">The ending value of the range</param>
        /// <returns>true if the value of the current object property is in range; otherwise,
        /// false.</returns>
        bool MutuallyExclusiveBetween(T from, T to);
    }

    /// <summary>
    /// Provides generic container where the data are stored in the linked list.
    /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
    /// IF THE METHOD IMPLEMENTATION REQUIRES IT.
    /// </summary>
    /// <typeparam name="T">The type ot the data to be stored in the list. Data 
    /// class should implement some interfaces.</typeparam>
    public class LinkList<T> where T : IComparable<T>
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


        // Selection Sort
        public void SelectionSort()
        {
            for (Node d1 = begin; d1.Next != null; d1 = d1.Next)
            {
                Node minv = d1;

                for (Node d2 = d1; d2.Next != null; d2 = d2.Next)
                {
                    if (d2.Data.CompareTo(minv.Data) < 0) minv = d2;
                }

                T temp = d1.Data;
                d1.Data = minv.Data;
                minv.Data = temp;
            }
        }

        /// <summary>
        /// Method sorts data in the list. The data object class should implement IComparable
        /// interface though defining sort order.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        public void BubbleSort()
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

    /// <summary>
    /// Provides properties and interface implementations the storing and manipulating of cars data.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Car : IComparable<Car>, IBetween<double>, IBetween<string>
    {
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer
        /// that indicates whether the current instance precedes, follows, or occurs in the same 
        /// position in the sort order as the other object.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The 
        /// return value has these meanings: -1 when this instance precedes other in the sort order;
        /// 0 when this instance occurs in the same position in the sort order as other;
        /// 1 when this instance follows other in the sort order.</returns>
        public int CompareTo(Car other)
        {
            if (other == null) return 1;

            if (this.Price == other.Price)
            {
                return this.Model.CompareTo(other.Model);
            }

            return other.Price.CompareTo(this.Price);

        }

        public bool MutuallyInclusiveBetween(double from, double to)
        {
            return (this.Price >= from && this.Price <= to);
        }

        public bool MutuallyExclusiveBetween(double from, double to)

        {
            return (this.Price > from && this.Price < to);
        }

        public bool MutuallyInclusiveBetween(string from, string to)
        {
            return (this.Manufacturer == from && this.Manufacturer == to);
        }

        public bool MutuallyExclusiveBetween(string from, string to)
        {
            return (this.Manufacturer == from || this.Manufacturer == to);
        }

        public static bool operator >(Car lhs, Car rhs)
        {
            if (lhs.Price.CompareTo(rhs.Price) < 0)
            {
                return true;
            }
            else if (lhs.Price == rhs.Price)
            {
                if (lhs.Model.CompareTo(rhs.Model) > 0)
                    return true;
            }

            return false;
        }

        public static bool operator <(Car lhs, Car rhs)
        {
            return !(lhs > rhs);
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; } // Price has to be decimal
        public Car(string manuf, string model, double price)
        {
            this.Manufacturer = manuf;
            this.Model = model;
            this.Price = price;
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
        public static LinkList<Car> ReadFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            LinkList<Car> cars = new LinkList<Car>();

            foreach (var line in lines)
            {
                string[] data = line.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(data[0], data[1], double.Parse(data[2]));

                cars.Add(car);
            }

            return cars;
        }

        // Read From File Using StreamReader
        public static LinkList<Car> ReadFromFileStreamReader(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            LinkList<Car> cars = new LinkList<Car>();

            string text = reader.ReadToEnd();
            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] data = line.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(data[0], data[1], double.Parse(data[2]));

                cars.Add(car);
            }

            return cars;
        }

        /// <summary>
        /// Appends the table, built from data contained in the list and preceded by the header,
        /// to the end of the text file.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="fileName">The name of the text file</param>
        /// <param name="header">The header of the table</param>
        /// <param name="list">The list from which the table to be formed</param>
        public static void PrintToFile(string fileName, string header, LinkList<Car> list)
        {
            if (!File.Exists(fileName)) File.Create(fileName).Close();

            List<string> lines = new List<string>();

            list.Begin();

            if (list.Exist())
            {
                lines.Add(new string('-', 70));
                lines.Add(string.Format("| {0,-66} |", header));
                lines.Add(new string('-', 70));
                lines.Add(string.Format("| {0,-30} | {1,-20} | {2,10} |", "Gamintojas", "Modelis", "Kaina"));
                lines.Add(new string('-', 70));

                for (list.Begin(); list.Exist(); list.Next())
                {
                    Car car = list.Get();

                    lines.Add(string.Format("| {0,-30} | {1,-20} | {2,10} |", car.Manufacturer, car.Model, car.Price));
                }

                lines.Add(new string('-', 70));
            }

            File.AppendAllLines(fileName, lines);
        }

        // Printing using StreamWriter
        public static void PrintToFileStreamWriter(string fileName, string header, LinkList<Car> list)
        {
            if (!File.Exists(fileName)) File.Create(fileName).Close();

            list.Begin();

            if (list.Exist())
            {
                using (var writer = new StreamWriter(fileName, true)) // True means Append text to file
                {
                    writer.WriteLine(new string('-', 70));
                    writer.WriteLine(string.Format("| {0,-66} |", header));
                    writer.WriteLine(new string('-', 70));
                    writer.WriteLine(string.Format("| {0,-30} | {1,-20} | {2,10} |", "Gamintojas", "Modelis", "Kaina"));
                    writer.WriteLine(new string('-', 70));

                    for (list.Begin(); list.Exist(); list.Next())
                    {
                        Car car = list.Get();

                        writer.WriteLine(string.Format("| {0,-30} | {1,-20} | {2,10} |", car.Manufacturer, car.Model, car.Price));
                    }

                    writer.WriteLine(new string('-', 70));
                }
            }
        }
    }

    public static class Task
    {
        /// <summary>
        /// The method finds the biggest price value in the given list.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="list">The data list to be searched.</param>
        /// <returns>The biggest price value.</returns>
        public static double MaxPrice(LinkList<Car> list)
        {
            double max = 0;

            for (list.Begin(); list.Exist(); list.Next())
            {
                var temp = list.Get();

                if (temp.Price > max) max = temp.Price;
            }

            return max;
        }

        /// <summary>
        /// Filters data from the source list that meets filtering criteria and writes them
        /// into the new list.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULDN'T CHANGE THE SIGNATURE OF THE METHOD!
        /// </summary>
        /// <typeparam name="TData">The type of the data objects stored in the list</typeparam>
        /// <typeparam name="TCriteria">The type of criteria</typeparam>
        /// <param name="source">The source list from which the result would be created</param>
        /// <param name="from">Lower bound of the interval</param>
        /// <param name="to">Upper bound of the interval</param>
        /// <returns>The list that contains filtered data</returns>
        public static LinkList<TData> Filter<TData, TCriteria>(LinkList<TData> source, TCriteria from, TCriteria to) where TData : IComparable<TData>, IBetween<TCriteria>
        {
            LinkList<TData> temp = new LinkList<TData>();

            for (source.Begin(); source.Exist(); source.Next())
            {
                var car = source.Get();

                if (car.MutuallyInclusiveBetween(from, to))
                {
                    temp.Add(car);
                }
            }

            return temp;
        }

    }

    class Program
    {
        /// <summary>
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        static void Main()
        {
            // Define file paths
            const string datafile = "Duomenys.txt";
            const string resultfile = "Rezultatai.txt";

            // First, initial data car list
            LinkList<Car> cars = InOut.ReadFromFile(datafile);


            // Delete Data File
            if (File.Exists(resultfile)) File.Delete(resultfile);


            // Find Max car price from all car list
            double maxCarPrice = Task.MaxPrice(cars);


            // Manufacturers to filter by entered by keyboard
            Console.WriteLine("Enter First Manufacturer Name: ");
            string manufFirst = Console.ReadLine();
            Console.WriteLine("Enter Second Manufacturer Name: ");
            string manufSecond = Console.ReadLine();


            //
            // Initial Data Printing (I)
            // 
            Console.WriteLine();
            Console.WriteLine("Initial Data: ");

            // Print to File
            InOut.PrintToFile(resultfile, "Initial Data", cars);

            // Print to Console
            for (cars.Begin(); cars.Exist(); cars.Next())
            {
                Car car = cars.Get();

                Console.WriteLine(string.Format("| {0,-26} | {1,-18} | {2,10}", car.Manufacturer, car.Model, car.Price));
            }


            //
            // Cars Filtered by First Manufacturer entered (II)
            //
            Console.WriteLine();
            Console.WriteLine("Filtered by First Manufacturer: ");

            // List
            LinkList<Car> filteredByFirstManuf = Task.Filter<Car, string>(cars, manufFirst, manufFirst);

            // Print To File
            InOut.PrintToFile(resultfile, "Cars Filtered by First Manufacturer", filteredByFirstManuf);

            // Print to Console
            for (filteredByFirstManuf.Begin(); filteredByFirstManuf.Exist(); filteredByFirstManuf.Next())
            {
                Car car = filteredByFirstManuf.Get();

                Console.WriteLine(string.Format("| {0,-26} | {1,-18} | {2,10}", car.Manufacturer, car.Model, car.Price));
            }

            //
            // Cars Filtered by Second Manufacturer entered (III)
            //
            Console.WriteLine();
            Console.WriteLine("Cars Filtered by Second Manufacturer: ");

            // List
            LinkList<Car> filteredBySecondManuf = Task.Filter<Car, string>(cars, manufSecond, manufSecond);

            // Print To File
            InOut.PrintToFile(resultfile, "Cars Filtered by Second Manufacturer", filteredBySecondManuf);

            // Print to Console
            for (filteredBySecondManuf.Begin(); filteredBySecondManuf.Exist(); filteredBySecondManuf.Next())
            {
                Car car = filteredBySecondManuf.Get();

                Console.WriteLine(string.Format("| {0,-26} | {1,-18} | {2,10}", car.Manufacturer, car.Model, car.Price));
            }


            //
            // Cars Filtered by +-25% from Max Price Printing and First Manufacturer (IV)
            // 
            Console.WriteLine();
            Console.WriteLine("Filtered by Max Price +-25%, First Manufacturer: ");

            int percentage = 4;

            // List
            LinkList<Car> filteredByMaxPriceFirstManuf = Task.Filter<Car, double>(filteredByFirstManuf, maxCarPrice - maxCarPrice / percentage, maxCarPrice + maxCarPrice / percentage);

            // Sort by Bubble Algorithm
            filteredByMaxPriceFirstManuf.BubbleSort();

            // Print To File
            InOut.PrintToFile(resultfile, "Filtered by Max Price +-25%, First Manufacturer", filteredByMaxPriceFirstManuf);

            // Print To Console
            for (filteredByMaxPriceFirstManuf.Begin(); filteredByMaxPriceFirstManuf.Exist(); filteredByMaxPriceFirstManuf.Next())
            {
                Car car = filteredByMaxPriceFirstManuf.Get();

                Console.WriteLine(string.Format("| {0,-26} | {1,-18} | {2,10}", car.Manufacturer, car.Model, car.Price));
            }

            //
            // Cars Filtered by +-25% from Max Price Printing and Second Manufacturer (V)
            //
            Console.WriteLine();
            Console.WriteLine("Filtered by Max Price +-25%, Second Manufacturer: ");

            // List
            LinkList<Car> filteredByMaxPriceSecondManuf = Task.Filter<Car, double>(filteredBySecondManuf, maxCarPrice - maxCarPrice / percentage, maxCarPrice + maxCarPrice / percentage);

            // Sort by Bubble Algorithm
            filteredByMaxPriceSecondManuf.BubbleSort();

            // Print To File
            InOut.PrintToFile(resultfile, "Filtered by Max Price +-25%, Second Manufacturer", filteredByMaxPriceSecondManuf);

            for (filteredByMaxPriceSecondManuf.Begin(); filteredByMaxPriceSecondManuf.Exist(); filteredByMaxPriceSecondManuf.Next())
            {
                Car car = filteredByMaxPriceSecondManuf.Get();

                Console.WriteLine(string.Format("| {0,-26} | {1,-18} | {2,10}", car.Manufacturer, car.Model, car.Price));
            }


            //
            // Bubble Algorithm Sorting | Method for Testing
            //
            Console.WriteLine();
            Console.WriteLine("Selection Sorted List: ");

            // List
            LinkList<Car> sortedList = cars;

            // Sorting
            sortedList.SelectionSort();

            // Print To File
            InOut.PrintToFile(resultfile, "Selection Sorted Initial Data Cars List (TEST PURPOSES)", sortedList);

            // Print to Console
            for (sortedList.Begin(); sortedList.Exist(); sortedList.Next())
            {
                Car car = sortedList.Get();

                Console.WriteLine(string.Format("| {0,-26} | {1,-18} | {2,10}", car.Manufacturer, car.Model, car.Price));
            }
        }
    }
}