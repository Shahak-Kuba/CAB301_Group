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
            MainMenu();
            break;
    }
}

void AddDVDs() { }
void RemoveDVDs() { }
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
