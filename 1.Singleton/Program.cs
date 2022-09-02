using _1.Singleton.Models;

class Singleton
{
    static void Main(string[] args)
    {
        var db = SingletonDataContainer.Instance;
        Console.WriteLine(db.GetPopulation("Bulgaria"));
        var db2 = SingletonDataContainer.Instance;
        Console.WriteLine(db2.GetPopulation("America"));
    }
}