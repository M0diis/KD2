using System;
using System.IO;

namespace K2Basketball
{
    public interface IParsable
    {
        /// <summary>
        /// Initializes properties of the current instance with the data, extracted from
        /// string type parameter.
        /// </summary>
        /// <param name="data">The data passed as string</param>
        void ParseFromString(string data);
    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a team data and
    /// manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Team
    {

    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a player data and
    /// manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Player
    {

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
            throw new NotImplementedException();
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
        /// THE STUDENT SHOULD IMPLEMENT THIS GENERIC METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULDN'T CHANGE THE SIGNATURE OF THE METHOD!
        /// </summary>
        /// <typeparam name="T">The type of the data objects in the returning list.</typeparam>
        /// <param name="fileName">The name of the text file</param>
        /// <returns>List with data from file</returns>
        public static LinkList<T> ReadFromFile<T>(string fileName) where T : IComparable<T>, IParsable, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Appends CSV formatted rows from the data contained in the <paramref name="list"/>
        /// to the end of the text file.
        /// THE STUDENT SHOULD IMPLEMENT THIS GENERIC METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
        /// IF THE IMPLEMENTATION REQUIRES IT.
        /// </summary>
        /// <typeparam name="T">The type of the data objects stored in the list</typeparam>
        /// <param name="fileName">The name of the text file</param>
        /// <param name="list">The list of the data to be stored in the file.</param>
        public static void PrintToFile<T>(string fileName, LinkList<T> list)
        {
            throw new NotImplementedException();
        }
    }

    public static class Task
    {
        /// <summary>
        /// The method finds the largest count of victories in the given list.
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        /// <param name="list">The data list to be searched.</param>
        /// <returns>The highest number of victories.</returns>
        public static int MaxVictories(LinkList<Team> list)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Filters data from the source list that meets filtering criterion and writes them
        /// into the new list.
        /// THE STUDENT SHOULD IMPLEMENT THIS GENERIC METHOD ACCORDING THE TASK.
        /// THE STUDENT SHOULDN'T CHANGE THE SIGNATURE OF THE METHOD!
        /// </summary>
        /// <typeparam name="TData">The type of the data objects stored in the list</typeparam>
        /// <typeparam name="TCriterion">The type of criteria</typeparam>
        /// <param name="source">The source list from which the result would be created</param>
        /// <param name="criterion">Criterion that the object from source list should meet in 
        /// order to fall in result list</param>
        /// <returns>The list that contains filtered data</returns>
        public static LinkList<TData> Filter<TData, TCriterion>(LinkList<TData> source, TCriterion criterion) where TData : IComparable<TData>, IEquatable<TCriterion>
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
