var path = File.ReadAllLines("./input.txt")[0].Split(',');
var dict = new Dictionary<string, int>();
var directions = new string[]{"nw", "n", "ne", "se", "s", "sw"};
foreach (var d in directions)
{
    dict.Add(d, 0);
}

var furthest = 0;
foreach (var step in path)
{
    dict[step]++;

var north = dict["n"] + 0.5*dict["nw"] + 0.5*dict["ne"] - dict["s"] - 0.5*dict["se"] - 0.5*dict["sw"];
var east = dict["ne"] + dict["se"] - dict["nw"] - dict["sw"];
furthest = Math.Max(furthest, (int)(Math.Abs(north) + 0.5*Math.Abs(east)));
}

// var north = dict["n"] + 0.5*dict["nw"] + 0.5*dict["ne"] - dict["s"] - 0.5*dict["se"] - 0.5*dict["sw"];
// var east = dict["ne"] + dict["se"] - dict["nw"] - dict["sw"];
// Console.WriteLine(Math.Abs(north) + 0.5*Math.Abs(east));

Console.WriteLine(furthest);