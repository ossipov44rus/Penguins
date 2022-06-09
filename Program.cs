using System.Globalization;

CultureInfo InvariantCulture = new CultureInfo("en-US");
Thread.CurrentThread.CurrentCulture = InvariantCulture;
string filePath = @"C:/CodeForces/Epic/Penguins/files/penguins.csv";
string[] lines = File.ReadAllLines(filePath);
List<Penguin> myPenguins = new ();
foreach (string line in lines)
{
    string[] columns = line.Split(',');
    Penguin myPenguin = new()
    {
        Species = columns[0],
        Island = columns[1],
        Bill_length_mm = Convert.ToDouble(columns[2]),
        Bill_depth_mm = Convert.ToDouble(columns[3]),
        Flipper_length_mm = Convert.ToInt32(columns[4]),
        Body_mass_g = Convert.ToInt32(columns[5]),
        Sex = columns[6],
        Year = Convert.ToInt32(columns[7])
    };
    myPenguins.Add(myPenguin);
}
var Adelie = from penguin in myPenguins
             where penguin.Species == "Adelie"
             select penguin;
var Gentoo = from penguin in myPenguins
             where penguin.Species == "Gentoo"
             select penguin;
var Chinstrap = from penguin in myPenguins
             where penguin.Species == "Chinstrap"
             select penguin;
var young = from penguin in myPenguins
            where penguin.Year == 2008
            select penguin;
var males = from penguin in myPenguins
            where penguin.Sex == "male"
            select penguin;
var females = from penguin in myPenguins
            where penguin.Sex == "female"
            select penguin;
var islands = myPenguins.Select(p => p.Island).Distinct();
Console.WriteLine(islands.Count());
int penOnIsl = 0;
string isl = string.Empty;
foreach (var a in islands)
{
    var howMuch = from penguin in myPenguins
                  where penguin.Island == a
                  select penguin;
    if (howMuch.Count() > penOnIsl)
    {
        penOnIsl = howMuch.Count();
        isl = a;
    }
}
Console.WriteLine(isl);
if (males.Count() > females.Count())
{
    Console.WriteLine("male");
}
else
{
    Console.WriteLine("females");
}
int numberOfPenguins = myPenguins.Count;
int numberOfAdelies = Adelie.Count();
int numberOfGentoo = Gentoo.Count();
int numberOfChinstrap = Chinstrap.Count();
int numberOfyoung = young.Count();
Console.WriteLine($"Answer to the first question: {numberOfPenguins}");
Console.WriteLine($"Answer to the second question: {numberOfAdelies},{numberOfGentoo},{numberOfChinstrap}");
Console.WriteLine($"Answer to the last question: {numberOfyoung}");
class Penguin
{
    public string? Species { get; set; }
    public string? Island { get; set; }
    public double? Bill_length_mm { get; set; }
    public double? Bill_depth_mm { get; set; }
    public int? Flipper_length_mm { get; set; }
    public int? Body_mass_g { get; set; }
    public string? Sex { get; set; }
    public int? Year { get; set; }
}