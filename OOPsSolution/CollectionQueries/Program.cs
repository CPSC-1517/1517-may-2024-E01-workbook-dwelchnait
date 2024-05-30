// See https://aka.ms/new-console-template for more information
using OOPsReview;

Console.WriteLine("Hello, World!");

//List<Employment> employments = new List<Employment>();
//employments = CreateCollection();

List<Employment> employments = CreateCollection();

foreach(var item in employments)
{
    Console.WriteLine($"{item.ToString()}");
}

Console.WriteLine($"\nThe number of items in the collection is {employments.Count}\n");

//locate an item in the collection
Employment employment = null;
//foreach (var item in employments)
//{
//    if(item.Title.Equals("PG II"))
//    {
//        employment = item;
//    }
//}
for (int i = 0; i < employments.Count; i++)
{
    if (employments[i].Title.Equals("PG II"))
    {
        employment = employments[i];
        i = employments.Count; //a quick exit
    }
}
if (employment !=null)
{
    Console.WriteLine($"\n A PG II instance found, {employment.ToString()}, via a loop.\n");
}

// the magic!!!

//locate an item in the collection
employment = null;
//how can one query a collection to find a specific instance?
//use the collection method called .Find(predicate)
//the predicate is the condition you are using as if it was in a loop
//the predicate uses the lamda symbol in it's grammar
//syntax  placeholderid => condition(s)
//employment = employments.Find(e => e.Title.Equals("PG II"));
//if (employment !=null)
//{
//    Console.WriteLine($"\n A PG II instance found, {employment.ToString()}, via a collection method.\n");
//}

//.Equals(string) matches the entire string in your instance
employment = employments.Find(e => e.Title.Equals("PG"));
if (employment !=null)
{
    Console.WriteLine($"\n A PG instance found, {employment.ToString()}, via a collection method.\n");
}
else
{
    Console.WriteLine("No PG instance found using Equals within the Find");
}

//.Contains(string) matches the entire string in your instance
employment = employments.Find(e => e.Title.Contains("PGG"));
if (employment !=null)
{
    Console.WriteLine($"\n A PG instance found, {employment.ToString()}, via a collection method.\n");
}
else
{
    Console.WriteLine("No PGG instance found using Contains within the Find");
}

//There is more software that can be used in a wider range of situations
//This software is called Linq
//these examples will use the method syntax for Linq

//Linq is used against a collection (employments)
//filter method .Where(predicate)
employment = null;
//employment = employments.Where(e => e.Title.Contains("PG"));

//PROBLEM:
//add the Linq conversion method .ToList();
//Linq returns by default one of two generic datatypes: IEnumerable<T> or IQueryable<T>

//employment = employments.Where(e => e.Title.Contains("PG")).ToList();

//PROBLEM
//The Where returns a collection by default
List<Employment> searchEmployments = null;
searchEmployments = employments.Where(e => e.Title.Contains("PGG")).ToList();

if (searchEmployments != null)
{
    Console.WriteLine($"\n A PG instance found, , via a Linq Where method.\n");

}
else
{
    Console.WriteLine("No PGG instance found using Contains within the Where");

}
//PROBLEM
//The Where returns a collection whether a match was found OR NOT
//If NO matches were found then the collection is empty
if (searchEmployments.Count > 0)
{
    Console.WriteLine($"\n A PG instance found via a Linq Where method check by Count\n");

}
else
{
    Console.WriteLine("No PGG instance found using Contains within the Where");

}

//Can we do somethind like a .Where but have only a Yes or No type return
//that is, one does not actually need the data returned

//using the .Any(predicate) Linq method
//returns either a true or false boolean value
//it DOES NOT return a collection
//NO data is actually returned

if (employments.Any(e => e.Title.Contains("PGG")))
{
    Console.WriteLine($"\n A PG instance found via a Linq Any method\n");

}
else
{
    Console.WriteLine("No PGG instance found using Contains within the Linq Any");

}


//Console.WriteLine($"{item.ToString()}");
List<Employment> CreateCollection()
{
    List<Employment> newCollection = new List<Employment>();
    newCollection.Add(new Employment("PG I", SupervisoryLevel.Entry,
                        DateTime.Parse("May 1, 2010"), 0.5));
    newCollection.Add(new Employment("PG II", SupervisoryLevel.TeamMember,
                        DateTime.Parse("Nov 1, 2010"), 3.2));
    newCollection.Add(new Employment("PG III", SupervisoryLevel.TeamLeader,
                        DateTime.Parse("Jan 6, 2014"), 8.6));
    newCollection.Add(new Employment("SP I", SupervisoryLevel.Supervisor,
                        DateTime.Parse("Jul 22, 2022"), 1.8));
    return newCollection;
}
