// initialising collection
MovieCollection collection = new MovieCollection();
bool staffkey = false; // checks if staff has been logged in before

void Header()
{
    Console.Clear();
    Console.WriteLine("============================================================");
    Console.WriteLine("  Welcome to Community Library Movie DVD Management System");
    Console.WriteLine("============================================================");
    Console.WriteLine();
}

// Returns int corresponding to choice
// Makes sure user returns valid input
int CreateMenu(string title, string[] options)
{
    Header();
    string titleLines = new string('=', (60 - title.Length) / 2);
    Console.WriteLine(titleLines + title + titleLines);
    Console.WriteLine();
    string choices = "";
    for (int i = 0; i < options.Length; i++)
    {
        Console.WriteLine($"{i}. {options[i]}");
        choices += $" {i}";
    }
    Console.WriteLine();
    Console.WriteLine($"Enter your choice ==>{choices}");
    string input = Console.ReadLine();
    int choice;
    bool isNumeric = int.TryParse(input, out choice);
    if (isNumeric && 0 <= choice && choice < options.Length)
    {
        return choice; // Return user input
    }
    Console.WriteLine();
    Console.Write("Invalid input. Press enter to try again");
    Console.ReadKey();
    return CreateMenu(title, options); // Make user try again
}

void MainMenu()
{
    string title = "Main Menu";
    string[] options =
    {
        "Staff Login",
        "Member Login",
        "Exit"
    };
    int choice = CreateMenu(title, options);

    switch (choice)
    {
        case 0:
            StaffMenu();
            break;
        case 1:
            MemberMenu();
            break;
        case 2:
            Exit();
            break;
    }
}

void Exit()
{
    Environment.Exit(0);
}

void StaffMenu()
{
    string title = "Staff Menu";
    string[] options =
    {
        "Add new DVDs of a new movie to the system",
        "Remove DVDs of a movie from the system",
        "Register a new member with the system",
        "Remove a registered member from the system",
        "Display a member's contact phone number, given the member's name",
        "Display all members who are currently renting a particular movie",
        "Return to the main menu",

    };

    if (!staffLogin())
    {
        Console.WriteLine("Incorrect Login Details");
        Console.WriteLine("Please try again or type 0 to return to the main menu");
        Console.WriteLine();
        StaffMenu();
    }

    int choice = CreateMenu(title, options);

    switch (choice)
    {
        case 0:
            AddDVDs();
            break;
        case 1:
            RemoveDVDs();
            break;
        case 2:
            RegisterMember();
            break;
        case 3:
            RemoveMember();
            break;
        case 4:
            DisplayMember();
            break;
        case 5:
            DisplayMovieBorrowers();
            break;
        case 6:
            staffkey = false;
            MainMenu();
            break;
    }
}

bool staffLogin() 
{
    if(staffkey) return true;
    Header();
    Console.WriteLine("Staff Username: ");
    string user = Console.ReadLine();
    if(user.CompareTo("0") == 0)
    {
        staffkey = false;
        MainMenu();
    }
    Console.WriteLine("Staff Password: ");
    string password = Console.ReadLine();
    if (user.CompareTo("staff") == 0 && password.CompareTo("today123") == 0)
    {
        staffkey = true;
        return true;
    }
    Console.Clear();
    Header();
    return false;
}

void AddDVDs()
{
    Header();
    Console.WriteLine("Adding movie to collection");
    Console.WriteLine("Movie Name: ");
    string movie_name = Console.ReadLine();
    IMovie movie = collection.Search(movie_name);
    // checking if movie exits
    if(!collection.Search(movie))
    {
        // movie does not exist
        Console.WriteLine("Movie genre (Action = 1, Comedy = 2, History = 3, Drama = 4, Western = 5): ");
        MovieGenre genre = (MovieGenre)Int32.Parse(Console.ReadLine());
        Console.WriteLine("Movie classification (G = 1, PG = 2, M = 3, M15+ = 4): ");
        MovieClassification classification = (MovieClassification)Int32.Parse(Console.ReadLine());
        Console.WriteLine("Movie duration: ");
        int duration = Int32.Parse(Console.ReadLine());
        IMovie new_movie = (IMovie)new Movie(movie_name, genre, classification, duration, 1);
        collection.Insert(new_movie);
        Console.WriteLine("Movie Has been added!");
        Console.ReadLine();
        // testing code
        IMovie[] colArray1 = collection.ToArray();
        Console.WriteLine(string.Join(',', (object[])colArray1));
        Console.ReadLine();
        // end test code
        Console.Clear();
        StaffMenu();
    }
    // if movie does exist
    IMovie exist_movie = collection.Search(movie_name);
    exist_movie.AvailableCopies++;
    exist_movie.TotalCopies++;
    Console.WriteLine("Number of copies has been increased!");
    Console.ReadLine();
    // testing code
    IMovie[] colArray = collection.ToArray();
    Console.WriteLine(string.Join(',', (object[])colArray));
    Console.ReadLine();
    // end test code
    Console.Clear();
    StaffMenu();
}

void RemoveDVDs()
{
    Header();
    Console.WriteLine("Removing movie from collection");
    Console.WriteLine("Movie Name: ");
    string movie_name = Console.ReadLine();
    if (collection.Search(collection.Search(movie_name)))
    {
        //movie is in collection
        IMovie movie = collection.Search(movie_name);
        if(movie.TotalCopies == 1)
        {
            // only 1 copy left
            collection.Delete(movie);
            Console.WriteLine("Movie has been deleted from collection");
            // testing code
            IMovie[] colArray0 = collection.ToArray();
            Console.WriteLine(string.Join(',', (object[])colArray0));
            Console.ReadLine();
            // end test code
            Console.ReadLine();
            Console.Clear();
            StaffMenu();
        }
        movie.TotalCopies--;
        movie.AvailableCopies--;
        Console.WriteLine("One of the movies had been removed from collection");
        // testing code
        IMovie[] colArray1 = collection.ToArray();
        Console.WriteLine(string.Join(',', (object[])colArray1));
        Console.ReadLine();
        // end test code
        Console.ReadLine();
        Console.Clear();
        StaffMenu();
    }
    Console.WriteLine("Movie is not in collection");
    // testing code
    IMovie[] colArray2 = collection.ToArray();
    Console.WriteLine(string.Join(',', (object[])colArray2));
    Console.ReadLine();
    // end test code
    Console.ReadLine();
    Console.Clear();
    StaffMenu();
}

void RegisterMember() { }
void RemoveMember() { }
void DisplayMember() { }
void DisplayMovieBorrowers() { }

void MemberMenu()
{
    string title = "Member Menu";
    string[] options =
    {
        "Browse all the movies",
        "Display all the information about a movie, given the title of the movie",
        "Borrow a movie DVD",
        "Return a movie DVD",
        "List current borrowing movies",
        "Display the top 3 movies rented by the members",
        "Return to the main menu",
    };
    int choice = CreateMenu(title, options);

    switch (choice)
    {
        case 0:
            BrowseMovies();
            break;
        case 1:
            DisplayMovieInfo();
            break;
        case 2:
            BorrowDVD();
            break;
        case 3:
            ReturnDVD();
            break;
        case 4:
            DisplayBorrowedMovies();
            break;
        case 5:
            DisplayTop3Movies();
            break;
        case 6:
            MainMenu();
            break;
    }
}

void BrowseMovies() { }
void DisplayMovieInfo() { }
void BorrowDVD() { }
void ReturnDVD() { }
void DisplayBorrowedMovies() { }
void DisplayTop3Movies() { }

MainMenu();
