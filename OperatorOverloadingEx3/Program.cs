using System;

namespace OperatorOverloadingEx3
{
    public class Library
    {
        public string Title { get; set; }
        public double Movies { get; set; }
        public string? Genre { get; set; }

        // overloaded operator ++ and operator --
        public static Library operator ++(Library lib)
        {
            lib.Movies++;
            return lib;
        }
        public static Library operator --(Library lib)
        {
            lib.Movies--;
            return lib;
        }
        // overloaded operator + and operator -
        public static Library operator +(Library lib, double movie)
        {
            lib.Movies += movie;
            return lib;
        }
        public static Library operator -(Library lib, double movie)
        {
            lib.Movies -= movie;
            return lib;
        }
        // overloaded operator > and operator <
        public static bool operator <(Library lib1, Library lib2)
        {
            bool larger = false;
            if (lib1.Movies < lib2.Movies)
                larger = true;
            return larger;
        }
        public static bool operator >(Library lib1, Library lib2)
        {
            bool larger = false;
            if (lib1.Movies > lib2.Movies)
                larger = true;
            return larger;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library[] myLibrary = new Library[100];
            for (int i = 0; i < myLibrary.Length; i++)
            {
                myLibrary[i] = new Library();  // creates objects
            }
            int selection = library();
            int index = 0, entry = 0;
            string ans = "";
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 100)
                        {
                            Console.Write("Genre (Comedy/Horror/Other): ");
                            myLibrary[index].Genre = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Title: ");
                            myLibrary[index].Title = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Movie Count: ");
                            myLibrary[index].Movies = double.Parse(Console.ReadLine());
                            Console.WriteLine();
                            index++;
                        }
                        else
                            Console.WriteLine("You have too many movie entries - see programming");
                        break;
                    case 2:
                        for (int i = 0; i < myLibrary.Length; i++)
                        {
                            if (myLibrary[i].Title != "" && myLibrary[i].Title != null)
                            {
                                Console.WriteLine($"Genre: {myLibrary[i].Genre}");
                                Console.WriteLine($"Title: {myLibrary[i].Title}");
                                Console.WriteLine($"Movie: {myLibrary[i].Movies}");
                            }
                        }
                        break;
                    case 3:
                        entry = pickEntry(index);
                        Console.Write("Change Genre (Comedy/Horror/Other) Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Genre? ");
                            myLibrary[entry].Genre = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.Write("Change Title Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Title: ");
                            myLibrary[entry].Title = Console.ReadLine();
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        entry = pickEntry(index);

                        Console.Write("Increase movie inventory by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            // calls the operator++ method
                            myLibrary[entry]++;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease movie inventory by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            // calls the operator-- method
                            myLibrary[entry]--;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Increase movies by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the number of movies: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please a number");
                            // calls the operator+ method
                            // the method should receive an 
                            // object and a integer as arguments
                            myLibrary[entry] += hr;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease movie inventor by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the number of movies: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please a number");
                            // calls the operator- method
                            // the method should receive an 
                            // object and a integer as arguments
                            myLibrary[entry] -= hr;
                            Console.WriteLine();
                            break;
                        }

                        break;
                    case 5:
                        Library totalComedy = new Library();
                        totalComedy.Genre = "Comedy Genre";
                        totalComedy.Title = "Total Comedy Movies";
                        Library totalHorror = new Library();
                        totalHorror.Genre = "Horror Genre";
                        totalHorror.Title = "Total Horror Movies";
                        Library totalOther = new Library();
                        totalOther.Genre = "Other Genre";
                        totalOther.Title = "Total Other Movies";
                        for (int i = 0; i < myLibrary.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(myLibrary[i].Title))
                            {
                                break; // Stop when encountering an empty title
                            }

                            switch (myLibrary[i].Genre)
                            {
                                case "Comedy":
                                    totalComedy.Movies += myLibrary[i].Movies;
                                    break;
                                case "Horror":
                                    totalHorror.Movies += myLibrary[i].Movies;
                                    break;
                                default:
                                    totalOther.Movies += myLibrary[i].Movies;
                                    break;
                            }
                        }
                        Console.WriteLine("Total Movies by Genre");
                        // calls operator >
                        if (totalComedy > totalHorror && totalComedy > totalOther)
                        {
                            Console.WriteLine("The largest number of movies is in comedy!");
                            Console.WriteLine($"Your total comedy movies = {totalComedy.Movies}");
                            Console.WriteLine($"Your total horror movies = {totalHorror.Movies}");
                            Console.WriteLine($"Your total other movies = {totalOther.Movies}");
                        }
                        // calls operator >
                        else if (totalHorror > totalComedy && totalHorror > totalOther)
                        {
                            Console.WriteLine("The largest number of movies is in horror");
                            Console.WriteLine($"Your total horror movies = {totalHorror.Movies}");
                            Console.WriteLine($"Your total comedy movies = {totalComedy.Movies}");
                            Console.WriteLine($"Your total other movies = {totalOther.Movies}");
                        }
                        else
                        {
                            Console.WriteLine("The largest number of movies was in a different movie genres");
                            Console.WriteLine($"Your total other movies = {totalOther.Movies}");
                            Console.WriteLine($"Your total horror movies = {totalHorror.Movies}");
                            Console.WriteLine($"Your total comedy movies = {totalComedy.Movies}");
                        }
                        break;
                    default:
                        Console.WriteLine("You made an invalid selection, please try again");
                        break;
                }
                selection = library();
            }
        }
        public static int library()
        {
            int choice = 0;
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("1 - Add a movie");
            Console.WriteLine("2 - Print All");
            Console.WriteLine("3 - Change genre or title");
            Console.WriteLine("4 - Change movie count");
            Console.WriteLine("5 - Total genres movie count");
            Console.WriteLine("6 - Quit");
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Please select 1 - 6");
            return choice;
        }
        public static int pickEntry(int index)
        {
            Console.WriteLine("What entry would you like to change?");
            Console.WriteLine($"1 through {index}");
            int entry;
            while (!int.TryParse(Console.ReadLine(), out entry))
                Console.WriteLine($"Please select 1 - {index}");
            entry -= 1;  // subtract 1 to begin index at 0
            return entry;
        }
    }
}