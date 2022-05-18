Console.WriteLine("CAB301 Phase 2 Test Program:\n");

// Creating BST 
MovieCollection collection = new MovieCollection();

IMovie Spiderman = (IMovie) new Movie("Spiderman", MovieGenre.Action, MovieClassification.M, 120, 3 );
IMovie Spiderman2 = (IMovie)new Movie("Spiderman2", MovieGenre.Action, MovieClassification.M, 120, 3);
IMovie Spiderman3 = (IMovie)new Movie("Spiderman3", MovieGenre.Action, MovieClassification.M, 120, 3);
IMovie Calvin = (IMovie)new Movie("Calvin Has COVID", MovieGenre.Action, MovieClassification.M, 120, 3);

Console.WriteLine(Spiderman.ToString());

Console.WriteLine();
Console.WriteLine("Insert Function");
collection.Insert(Spiderman);
collection.Insert(Spiderman2);
Console.WriteLine(collection.Search(Spiderman));
Console.WriteLine(collection.Search(Spiderman2));

Console.WriteLine();
Console.WriteLine("Delete Function");
collection.Delete(Spiderman);
Console.WriteLine(collection.Search(Spiderman));
Console.WriteLine(collection.Search(Spiderman2));


collection.Insert(Spiderman3);
collection.Insert(Spiderman);
collection.Insert(Spiderman2);
collection.Insert(Calvin);

Console.WriteLine();
Console.WriteLine("ToArray Function");
IMovie[] colArray = collection.ToArray();
Console.WriteLine(string.Join(',', (object[]) colArray));
Console.WriteLine();


Console.WriteLine("Search Function");
Console.WriteLine(collection.Search("Spiderman").ToString());

/*
Console.WriteLine();
Console.WriteLine("Clear Function");
collection.Clear();
Console.WriteLine(collection.Search(Spiderman));
Console.WriteLine(collection.Search(Spiderman2));

*/

// testing borrow implementation
// inserting movies
Console.WriteLine();
Console.WriteLine("duplicate test");
collection.Insert(Spiderman);
collection.Insert(Spiderman2);

IMember Steve = new Member("Steve","Jones");
Spiderman.AddBorrower(Steve);
Console.WriteLine(Spiderman.ToString());
Console.WriteLine();
//Spiderman.RemoveBorrower(Steve);
Spiderman.AddBorrower(Steve);
Console.WriteLine(Spiderman.ToString());




