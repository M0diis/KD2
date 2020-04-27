using System;
using System.Collections.Generic;
using System.IO;

namespace K2
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method sorts data in the list. The data object class should implement IComparable
        /// interface though defining sort order.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        public void Sort()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Provides properties and interface implementations the storing and manipulating of cars data.
        /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
        /// </summary>
        public class Car : IComparable<Car>
        {


            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public int Cost { get; set; }


            public Car(string manufacturer, string model, int cost)
            {
                this.Manufacturer = manufacturer;
                this.Model = model;
                this.Cost = cost;
            }

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
                if (other == null)
                {
                    return 1;
                }
                else if (this.Cost.CompareTo(other.Cost) == 0)
                {
                    return this.Model.CompareTo(other.Model);
                }
                else return this.Cost.CompareTo(other.Cost);
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                    throw new NotImplementedException();
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
    }
}