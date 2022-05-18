void Header()
{
    Console.Clear();
    Console.WriteLine("============================================================");
    Console.WriteLine("  Welcome to Community Library Movie DVD Management System");
    Console.WriteLine("============================================================");
    Console.WriteLine();
}

void CreateMenu(string title, string[] options)
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
    CreateMenu(title, options);
}

MainMenu();

void StaffMenu()
{
    Header();
    Console.WriteLine("========================= Staff Menu =======================");
    Console.WriteLine();
    Console.WriteLine("1. Add new DVDs of a new movie to the system");
    Console.WriteLine("2. Remove DVDs of a movie from the system");
    Console.WriteLine("3. Register a new member with the system");
    Console.WriteLine("4. Remove a registered member from the system");
    Console.WriteLine("5. Display a member's contact phone number, given the member's name");
    Console.WriteLine("6. Display all members who are currently renting a particular movie");
    Console.WriteLine("0. Return to the main menu");
    Console.WriteLine();
    Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0)");
}

void MemberMenu()
{
    Header();
    Console.WriteLine("========================= Member Menu ======================");
    Console.WriteLine();
    Console.WriteLine("1. Browse all the movies");
    Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
    Console.WriteLine("3. Borrow a movie DVD");
    Console.WriteLine("4. Return a movie DVD");
    Console.WriteLine("5. List current borrowing movies");
    Console.WriteLine("6. Display the top 3 movies rented by the members");
    Console.WriteLine("0. Return to the main menu");
    Console.WriteLine();
    Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0)");
}
