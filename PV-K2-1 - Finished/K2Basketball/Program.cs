using System;
using System.IO;

// IF9-1 Modestas Kazlauskas P175B123

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
    public class Team : IParsable, IComparable<Team>
    {
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

        public Team(string teamname, int played, int won)
        {
            this.TeamName = teamname;
            this.GamesPlayed = played;
            this.GamesWon = won;
        }

        public Team()
        {

        }

        public int CompareTo(Team other)
        {
            throw new NotImplementedException();
        }

        public void ParseFromString(string data)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,-25} | {2,15} |", TeamName, GamesPlayed, GamesWon);
        }
    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a player data and
    /// manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Player : IComparable<Player>, IEquatable<int>, IEquatable<string>, IParsable
    {
        public string TeamName { get; set; }
        public string SurnameName { get; set; }
        public int BirthYear { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public int PointsScored { get; set; }

        public Player(string team, string surnamename, int year, int height, string position, int gamesplayed, int points)
        {
            this.TeamName = team;
            this.SurnameName = surnamename;
            this.BirthYear = year;
            this.Height = height;
            this.Position = position;
            this.GamesPlayed = gamesplayed;
            this.PointsScored = points;
        }

        public Player()
        {

        }

        public int CompareTo(Player other)
        {
            if (other == null) return 1;

            if (this.PointsScored == other.PointsScored)
            {
                return this.GamesPlayed.CompareTo(other.GamesPlayed);
            }

            return other.PointsScored.CompareTo(this.PointsScored);
        }

        public void ParseFromString(string data)
        {
            throw new NotImplementedException();
        }

        public bool Equals(int other)
        {
            return GamesPlayed.Equals(other);
        }

        public bool Equals(string other)
        {
            return Position.Trim().Equals(other.Trim());
        }

        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,-25} | {2,15} | {3,10} | {4,-20} | {5,15} | {6,15} |", TeamName, SurnameName, BirthYear, Height, Position, GamesPlayed, PointsScored);
        }
    }

    /// <summary>
    /// Provides generic container where the data are stored in the linked list.
    /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
    /// IF THE IMPLEMENTATION OF ANY METHOD REQUIRES IT.
    /// </summary>
    /// <typeparam name="T">The type of the data to be stored in the list. Data 
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
            for (Node d1 = begin; d1 != null; d1 = d1.Next)
            {
                Node minv = d1;

                for (Node d2 = d1.Next; d1 != null; d2 = d2.Next)
                {
                    if (d2.Data.CompareTo(minv.Data) < 0) minv = d2;
                }

                T temp = d1.Data;
                d1.Data = minv.Data;
                minv.Data = temp;
            }
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
            StreamReader reader = new StreamReader(fileName);

            LinkList<T> list = new LinkList<T>();

            string text = reader.ReadToEnd();

            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] data = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if(data.Length > 3)
                {
                    Player player = new Player(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), data[4], int.Parse(data[5]), int.Parse(data[6]));

                    T temp = (T)(object)player;

                    list.Add(temp);
                }
                else
                {
                    Team team = new Team(data[0], int.Parse(data[1]), int.Parse(data[2]));

                    T temp = (T)(object)team;

                    list.Add(temp);
                }

            }

            return list;
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
        public static void PrintToFile<T>(string fileName, LinkList<T> list) where T : IComparable<T>
        {
            if (!File.Exists(fileName)) File.Create(fileName).Close();


            using (var writer = new StreamWriter(fileName, true)) // True means Append text to file
            {
                list.Begin();
                if (list.Exist())
                {   

                    T temp = list.Get();

                    if (temp is Player)
                    {
                        writer.WriteLine(new string('-', 152));
                        writer.WriteLine(string.Format("| {0,-30} | {1,-25} | {2,15} | {3,-10} | {4,-20} | {5,15} | {6,15} |", "Komanda", "Zaidejas", "Gimimo Metai", "Ugis", "Pozicija", "Suzaista", "Imesti Taskai"));
                        writer.WriteLine(new string('-', 152));
                    }
                    else if (temp is Team)
                    {
                        writer.WriteLine(new string('-', 80));
                        writer.WriteLine(string.Format("| {0,-30} | {1,-25} | {2,15} |", "Komanda", "Suzaista", "Laimeta"));
                        writer.WriteLine(new string('-', 80));
                    }

                    for (list.Begin(); list.Exist(); list.Next())
                    {
                        temp = list.Get();

                        writer.WriteLine(temp.ToString());

                    }

                    if (temp is Player)
                    {
                        writer.WriteLine(new string('-', 152));
                    }
                    else if (temp is Team)
                    {
                        writer.WriteLine(new string('-', 80));
                    }
                    writer.WriteLine("");
                }
            }
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
            int maxVictories = 0;

            for(list.Begin(); list.Exist(); list.Next())
            {
                Team team = list.Get();

                if (team.GamesWon > maxVictories) maxVictories = team.GamesWon;
            }

            return maxVictories;
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
            LinkList<TData> list = new LinkList<TData>();

            for (source.Begin(); source.Exist(); source.Next())
            {
                TData temp = source.Get();

                if(temp is Player)
                {
                    Player player = (Player)(object)temp;


                    if(criterion is string)
                    {
                        string criteria = (string)(object)criterion.ToString().Trim();

                        if (player.Equals(criteria))
                        {

                            list.Add(temp);
                        }
                    }

                    if (criterion is int)
                    {
                        int criteria = (int)(object)criterion;

                        if (player.Equals(criteria))
                        {
                            list.Add(temp);
                        }
                    }

                }
            }

            return list;
        }
    }

    class Program
    {
        /// <summary>
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        static void Main()
        {
            //
            // Define File Paths
            //
            const string PlayerDataFile = "Zaidejai.txt";
            const string TeamDataFile = "Komandos.txt";
            const string Results = "Rezultatai.txt";

            //
            // Accept Input
            //
            Console.WriteLine("Enter First Position to filter by: ");
            string firstPosition = Console.ReadLine();
            Console.WriteLine("Enter Second Position to filter by: ");
            string secondPosition = Console.ReadLine();

            //
            // Delete Result File if it exists
            //
            if (File.Exists(Results)) File.Delete(Results);

            //
            // Player Initial Data (I)
            //
            LinkList<Player> players = InOut.ReadFromFile<Player>(PlayerDataFile);

            //
            // Team Initial Data (II)
            //
            LinkList<Team> teams = InOut.ReadFromFile<Team>(TeamDataFile);

            // Find Max Team Victories
            int maxWins = Task.MaxVictories(teams);

            //
            // Filtered by First Position (III)
            //
            LinkList<Player> filteredByFirstPosition = Task.Filter<Player, string>(players, firstPosition);
            // Sorting
            //filteredByFirstPosition.Sort();

            //
            // Filtered by Second Position (IV)
            //
            LinkList<Player> filteredBySecondPosition = Task.Filter<Player, string>(players, secondPosition);
            // Sorting
            //filteredBySecondPosition.Sort();

            //
            // Players that played same amount games as there max victories (V)
            //
            LinkList<Player> filteredByMaxVictory = Task.Filter<Player, int>(players, maxWins);


            //
            // Printing to Rezultatai.CSV
            //

            // Print Player Initial Data to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, players);

            // Print Team Initial Data to Rezultatai.CSV
            InOut.PrintToFile<Team>(Results, teams);using System;
using System.IO;

// IF9-1 Modestas Kazlauskas P175B123

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
    public class Team : IParsable, IComparable<Team>
    {
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

        public Team(string teamname, int played, int won)
        {
            this.TeamName = teamname;
            this.GamesPlayed = played;
            this.GamesWon = won;
        }

        public Team()
        {

        }

        public int CompareTo(Team other)
        {
            throw new NotImplementedException();
        }

        public void ParseFromString(string data)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,-25} | {2,15} |", TeamName, GamesPlayed, GamesWon);
        }
    }

    /// <summary>
    /// Provides properties and interface implementations for the storing of a player data and
    /// manipulating them.
    /// THE STUDENT SHOULD DEFINE THE CLASS ACCORDING THE TASK.
    /// </summary>
    public class Player : IComparable<Player>, IEquatable<int>, IEquatable<string>, IParsable
    {
        public string TeamName { get; set; }
        public string SurnameName { get; set; }
        public int BirthYear { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public int PointsScored { get; set; }

        public Player(string team, string surnamename, int year, int height, string position, int gamesplayed, int points)
        {
            this.TeamName = team;
            this.SurnameName = surnamename;
            this.BirthYear = year;
            this.Height = height;
            this.Position = position;
            this.GamesPlayed = gamesplayed;
            this.PointsScored = points;
        }

        public Player()
        {

        }

        public int CompareTo(Player other)
        {
            if (other == null) return 1;

            if (this.PointsScored == other.PointsScored)
            {
                return this.GamesPlayed.CompareTo(other.GamesPlayed);
            }

            return other.PointsScored.CompareTo(this.PointsScored);
        }

        public void ParseFromString(string data)
        {
            throw new NotImplementedException();
        }

        public bool Equals(int other)
        {
            return GamesPlayed.Equals(other);
        }

        public bool Equals(string other)
        {
            return Position.Trim().Equals(other.Trim());
        }

        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,-25} | {2,15} | {3,10} | {4,-20} | {5,15} | {6,15} |", TeamName, SurnameName, BirthYear, Height, Position, GamesPlayed, PointsScored);
        }
    }

    /// <summary>
    /// Provides generic container where the data are stored in the linked list.
    /// THE STUDENT SHOULD APPEND CONSTRAINTS ON TYPE PARAMETER <typeparamref name="T"/>
    /// IF THE IMPLEMENTATION OF ANY METHOD REQUIRES IT.
    /// </summary>
    /// <typeparam name="T">The type of the data to be stored in the list. Data 
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
            for (Node d1 = begin; d1 != null; d1 = d1.Next)
            {
                Node minv = d1;

                for (Node d2 = d1.Next; d1 != null; d2 = d2.Next)
                {
                    if (d2.Data.CompareTo(minv.Data) < 0) minv = d2;
                }

                T temp = d1.Data;
                d1.Data = minv.Data;
                minv.Data = temp;
            }
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
            StreamReader reader = new StreamReader(fileName);

            LinkList<T> list = new LinkList<T>();

            string text = reader.ReadToEnd();

            string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] data = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if(data.Length > 3)
                {
                    Player player = new Player(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), data[4], int.Parse(data[5]), int.Parse(data[6]));

                    T temp = (T)(object)player;

                    list.Add(temp);
                }
                else
                {
                    Team team = new Team(data[0], int.Parse(data[1]), int.Parse(data[2]));

                    T temp = (T)(object)team;

                    list.Add(temp);
                }

            }

            return list;
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
        public static void PrintToFile<T>(string fileName, LinkList<T> list) where T : IComparable<T>
        {
            if (!File.Exists(fileName)) File.Create(fileName).Close();


            using (var writer = new StreamWriter(fileName, true)) // True means Append text to file
            {
                list.Begin();
                if (list.Exist())
                {   

                    T temp = list.Get();

                    if (temp is Player)
                    {
                        writer.WriteLine(new string('-', 152));
                        writer.WriteLine(string.Format("| {0,-30} | {1,-25} | {2,15} | {3,-10} | {4,-20} | {5,15} | {6,15} |", "Komanda", "Zaidejas", "Gimimo Metai", "Ugis", "Pozicija", "Suzaista", "Imesti Taskai"));
                        writer.WriteLine(new string('-', 152));
                    }
                    else if (temp is Team)
                    {
                        writer.WriteLine(new string('-', 80));
                        writer.WriteLine(string.Format("| {0,-30} | {1,-25} | {2,15} |", "Komanda", "Suzaista", "Laimeta"));
                        writer.WriteLine(new string('-', 80));
                    }

                    for (list.Begin(); list.Exist(); list.Next())
                    {
                        temp = list.Get();

                        writer.WriteLine(temp.ToString());

                    }

                    if (temp is Player)
                    {
                        writer.WriteLine(new string('-', 152));
                    }
                    else if (temp is Team)
                    {
                        writer.WriteLine(new string('-', 80));
                    }
                    writer.WriteLine("");
                }
            }
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
            int maxVictories = 0;

            for(list.Begin(); list.Exist(); list.Next())
            {
                Team team = list.Get();

                if (team.GamesWon > maxVictories) maxVictories = team.GamesWon;
            }

            return maxVictories;
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
            LinkList<TData> list = new LinkList<TData>();

            for (source.Begin(); source.Exist(); source.Next())
            {
                TData temp = source.Get();

                if(temp is Player)
                {
                    Player player = (Player)(object)temp;


                    if(criterion is string)
                    {
                        string criteria = (string)(object)criterion.ToString().Trim();

                        if (player.Equals(criteria))
                        {

                            list.Add(temp);
                        }
                    }

                    if (criterion is int)
                    {
                        int criteria = (int)(object)criterion;

                        if (player.Equals(criteria))
                        {
                            list.Add(temp);
                        }
                    }

                }
            }

            return list;
        }
    }

    class Program
    {
        /// <summary>
        /// THE STUDENT SHOULD IMPLEMENT THIS METHOD ACCORDING THE TASK.
        /// </summary>
        static void Main()
        {
            //
            // Define File Paths
            //
            const string PlayerDataFile = "Zaidejai.txt";
            const string TeamDataFile = "Komandos.txt";
            const string Results = "Rezultatai.txt";

            //
            // Accept Input
            //
            Console.WriteLine("Enter First Position to filter by: ");
            string firstPosition = Console.ReadLine();
            Console.WriteLine("Enter Second Position to filter by: ");
            string secondPosition = Console.ReadLine();

            //
            // Delete Result File if it exists
            //
            if (File.Exists(Results)) File.Delete(Results);

            //
            // Player Initial Data (I)
            //
            LinkList<Player> players = InOut.ReadFromFile<Player>(PlayerDataFile);

            //
            // Team Initial Data (II)
            //
            LinkList<Team> teams = InOut.ReadFromFile<Team>(TeamDataFile);

            // Find Max Team Victories
            int maxWins = Task.MaxVictories(teams);

            //
            // Filtered by First Position (III)
            //
            LinkList<Player> filteredByFirstPosition = Task.Filter<Player, string>(players, firstPosition);
            // Sorting
            //filteredByFirstPosition.Sort();

            //
            // Filtered by Second Position (IV)
            //
            LinkList<Player> filteredBySecondPosition = Task.Filter<Player, string>(players, secondPosition);
            // Sorting
            //filteredBySecondPosition.Sort();

            //
            // Players that played same amount games as there max victories (V)
            //
            LinkList<Player> filteredByMaxVictory = Task.Filter<Player, int>(players, maxWins);


            //
            // Printing to Rezultatai.CSV
            //

            // Print Player Initial Data to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, players);

            // Print Team Initial Data to Rezultatai.CSV
            InOut.PrintToFile<Team>(Results, teams);

            // Print Filtered Players by First position to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, filteredByFirstPosition);

            // Print Filtered Players by Second position to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, filteredBySecondPosition);

            // Print Players that played same amount games as there max victories to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, filteredByMaxVictory);
        }
    }
}


            // Print Filtered Players by First position to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, filteredByFirstPosition);

            // Print Filtered Players by Second position to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, filteredBySecondPosition);

            // Print Players that played same amount games as there max victories to Rezultatai.CSV
            InOut.PrintToFile<Player>(Results, filteredByMaxVictory);
        }
    }
}
