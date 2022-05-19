// initialising collection
MovieCollection collection = new MovieCollection();
MemberCollection users = new MemberCollection(10);
bool staffkey = false; // checks if staff has been logged in before
bool memkey = false; // checks if staff has been logged in before
IMember testuser = new Member("Reggie", "OOF");
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
    Console.Write("Staff Username: ");
    string user = Console.ReadLine();
    if(user.CompareTo("0") == 0)
    {
        staffkey = false;
        MainMenu();
    }
    Console.Write("Staff Password: ");
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
    Console.Write("Movie Name: ");
    string movie_name = Console.ReadLine();
    Movie movie = new Movie(movie_name);
    // checking if movie exits
    if(!collection.Search((IMovie)movie))
    {
        // movie does not exist
        Console.Write("Movie genre (Action = 1, Comedy = 2, History = 3, Drama = 4, Western = 5): ");
        MovieGenre genre = (MovieGenre)Int32.Parse(Console.ReadLine());
        Console.Write("Movie classification (G = 1, PG = 2, M = 3, M15+ = 4): ");
        MovieClassification classification = (MovieClassification)Int32.Parse(Console.ReadLine());
        Console.Write("Movie duration: ");
        int duration = Int32.Parse(Console.ReadLine());
        IMovie new_movie = (IMovie)new Movie(movie_name, genre, classification, duration, 1);
        collection.Insert(new_movie);
        Console.WriteLine("Movie Has been added!");
        Console.ReadLine();
        // testing code
        IMovie[] colArray1 = collection.ToArray();
        Console.WriteLine(string.Join(',', (object[])colArray1));
        // end test code
        Console.WriteLine("Press Enter to return to staff menu");
        Console.ReadLine();
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
        Console.WriteLine("Press Enter to return to staff menu");
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
    Console.WriteLine("Press Enter to return to staff menu");
    Console.ReadLine();
    Console.Clear();
    StaffMenu();
}

void RegisterMember() 
{
    Header();
    Console.WriteLine("Registering a new member");
    Console.Write("Member First Name: ");
    string MemberFirstName = Console.ReadLine();
    Console.Write("Member Last Name: ");
    string MemberLastName = Console.ReadLine();
    string MemberNumber = RequestNumber(0);
    string MemberPin = RequestNumber(1);
    //Member
    Member NewMember = new Member(MemberFirstName, MemberLastName, MemberNumber, MemberPin);
    MemberCollection.Add((IMember)NewMember);
    // Test Code
    /*Console.WriteLine("Member has been added");
    Console.WriteLine(MemberCollection.ToString());
    Console.ReadLine();*/
    // End of test code
    Console.WriteLine("Press Enter to return to staff menu");
    Console.ReadLine();
    StaffMenu();
}

string RequestNumber(int reqType)
{
    bool valid = false;
    string Number = "";
    while(!valid)
    {
        if (reqType == 0) Console.Write("Please insert a valid phone number: ");
        else Console.Write("Please insert a valid pin: ");
        Number = Console.ReadLine(); 
        if(reqType == 0)
        {
            if (IMember.IsValidContactNumber(Number)) valid = true;
            else
            {
                Console.WriteLine("This is not a valid phone number please try again");
            }
        }
        else
        {
            if (IMember.IsValidPin(Number)) valid = true;
            else
            {
                Console.WriteLine("This is not a valid pin please try again");
            }
        }
    }
    return Number;
}

void RemoveMember() 
{
    Header();
    Console.WriteLine("Removing a member");
    Console.Write("Member First Name: ");
    string MemberFirstName = Console.ReadLine();
    Console.Write("Member Last Name: ");
    string MemberLastName = Console.ReadLine();
    Member RemoveMember = new Member(MemberFirstName, MemberLastName);
    MemberCollection.Delete((IMember) RemoveMember);
    // Test Code
    Console.WriteLine(MemberCollection.ToString());
    Console.ReadLine();
    // End of Test Code
    Console.WriteLine("Press Enter to return to staff menu");
    StaffMenu();
}

void DisplayMember() 
{
    Header();
    Console.WriteLine("Search a member's details");
    Console.Write("Member First Name: ");
    string MemberFirstName = Console.ReadLine();
    Console.Write("Member Last Name: ");
    string MemberLastName = Console.ReadLine();
    Member SearchMember = new Member(MemberFirstName, MemberLastName);
    if(MemberCollection.Search((IMember) SearchMember))
    {
        Console.WriteLine("Member Details: ");
        IMember member = MemberCollection.Find((IMember)SearchMember);
        Console.WriteLine(member.ToString());
    }
    Console.WriteLine("Press Enter to return to staff menu");
    Console.ReadLine();
    StaffMenu();

}

void DisplayMovieBorrowers()
{
    Header();
    Console.WriteLine("Members who have borrowed a particular movie: ");
    Console.Write("Movie Name: ");
    string MovieName = Console.ReadLine();
    IMovie MovieObj = collection.Search(MovieName);
    Console.WriteLine(MovieObj.Borrowers.ToString());
    Console.WriteLine("Press Enter to return to staff menu");
    Console.ReadLine();
    StaffMenu();
}

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

    if (!memberLogin())
    {
        Console.WriteLine("Incorrect Login Details");
        Console.WriteLine("Please try again or type 0 to return to the main menu");
        Console.WriteLine();
        MemberMenu();
    }
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
            memkey = false;
            MainMenu();
            break;
    }
}

bool memberLogin()
{
    if (memkey) return true;
    Header();
    Console.WriteLine("Username: ");
    string user = Console.ReadLine();
    Console.WriteLine("Password: ");
    string pin = Console.ReadLine();
    IMember member = new Member("", "", user, pin);
    if (user.CompareTo("0") == 0)
    {
        memkey = false;
        MainMenu();
    }
    if (users.Search(member))
    {
        memkey = true;
        return true;
    }
    Console.Clear();
    Header();
    return false;
}

void BrowseMovies() {
    Header();
    Console.WriteLine("Available Movies: ");
    if (collection.ToArray() != null)
    {
        IMovie[] availmovies = collection.ToArray();
        Console.WriteLine(availmovies);
        Console.Clear();
        MainMenu();
    }
    else { Console.WriteLine("There are no available movies.");  }
}
void DisplayMovieInfo()
{
    Header();
    Console.WriteLine("Enter Movie: ");
    string movietitle = Console.ReadLine();
    Console.WriteLine("Finding: " + movietitle);
    if (collection.Search(collection.Search(movietitle)))
    {
        IMovie movie = collection.Search(movietitle);
        Console.WriteLine(movie.ToString());
        Console.ReadKey();
        Console.Clear();
        MemberMenu();
    }
    else
    {
        Console.WriteLine("This movie doesn't exist in our library please try again or press 0 to return to main menu");
        Console.ReadKey();
        Console.Clear();
        MemberMenu();
    }
}
void BorrowDVD() {
    Header();
    Console.WriteLine("Enter title of movie you want to borrow: ");
    string movietitle = Console.ReadLine();
    if (collection.Search(collection.Search(movietitle)))
    {
        IMovie movie = collection.Search(movietitle);
        Console.WriteLine("Borrowing: " + movie.ToString());
        movie.AddBorrower(testuser); //Figure out how to initialise user collection
        Console.ReadKey();
        Console.Clear();
        MemberMenu();
    }
    else
    {
        Console.WriteLine("This movietitle is invalid or not available");
        Console.WriteLine("Please try again");
        Console.ReadKey();
        Console.Clear();
        MemberMenu();
    }
    Console.ReadKey();
    Console.Clear();
    MemberMenu();
}
void ReturnDVD() {
    Header();
    Console.WriteLine("Enter title of movie you want to return: ");
    string movietitle = Console.ReadLine();
    if (collection.Search(collection.Search(movietitle)))
    {
        IMovie movie = collection.Search(movietitle);
        Console.WriteLine("Returning: " + movie.ToString());
        movie.RemoveBorrower(testuser); //Figure out how to initialise user collection
        Console.ReadKey();
        Console.Clear();
        MemberMenu();
    }
    else
    {
        Console.WriteLine("This movietitle is invalid or not available");
        Console.WriteLine("Please try again or press 0 to return to MainMenu");
        Console.ReadKey();
        Console.Clear();
        MemberMenu();
    }
    Console.ReadKey();
    Console.Clear();
    MemberMenu();
}
void DisplayBorrowedMovies() {
    Header();
    //Search through all movies in collection and subsequent member collection borrowers for if the user is in them
    IMovie[] searcharray = collection.ToArray();
    IMovie[] borrowedmovies = { };
    int j = 0;
    for (int i = 0; i < searcharray.Length; i++)
    {
        if (searcharray[i].Borrowers == testuser)
        {
            borrowedmovies[j] = searcharray[i];
            j++;
        }
    }
    if (borrowedmovies != null)
    {
        Console.WriteLine(borrowedmovies);
    }
    else
    {
        Console.WriteLine("There are no movies borrowed under your account");
    }
    Console.ReadKey();
    Console.Clear();
    MemberMenu();
}
void DisplayTop3Movies() {
    Header();
    //find the 3 movies with highest borrowcount
    IMovie[] searcharray = collection.ToArray();
    IMovie[] recommendedmovies = { null, null, null };
    Console.WriteLine("Top 3 Movies: ");
    Console.WriteLine(recommendedmovies);
    Console.ReadKey();
    Console.Clear();
    MemberMenu();
}

Movie[] ThreeLargest(MovieCollection movieCollection)
{
    // Create empty movie with -infinity borrows
    Movie emptyMovie = new Movie(String.Empty);
    emptyMovie.NoBorrowings = -Int32.MaxValue;

    Movie[] L = { emptyMovie, emptyMovie, emptyMovie };
    foreach (Movie movie in movieCollection.ToArray())
    {
        if (movie.NoBorrowings > L[0].NoBorrowings)
        {
            L[2] = L[1];
            L[1] = L[0];
            L[0] = movie;
        }
        else if (movie.NoBorrowings > L[1].NoBorrowings)
        {
            L[2] = L[1];
            L[1] = movie;
        }
        else if (movie.NoBorrowings > L[2].NoBorrowings)
        {
            L[2] = movie;
        }
    }
    return L;
}

// Liam's algo
void DisplayTop3Movies() {
    if (collection.Number <= 0)
    {
        Console.WriteLine("There are no movies in the collection!");
        Console.ReadKey();
        MemberMenu();
    }

    Console.WriteLine("\nThe most popular movies are:");
    Movie[] mostPopular = ThreeLargest(collection);
    for (int i = 0; i < mostPopular.Length; i++)
    {
        if (mostPopular[i].NoBorrowings >= 0)
        {
            Console.WriteLine($"{i+1}. {mostPopular[i].Title} has been borrowed {mostPopular[i].NoBorrowings} time(s)");
        }
    }

    Console.ReadKey();
    MemberMenu();
}

MainMenu();
