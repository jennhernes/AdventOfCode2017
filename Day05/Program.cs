var input = File.ReadAllLines("./input.txt");

var jumps = input.Select(x => int.Parse(x)).ToList();

var i = 0;
long steps = 0;
while (i > -1 && i < jumps.Count)
{
    var offset = jumps[i];
    if (offset >= 3)
    {
        jumps[i]--;
    }
    else
    {
        jumps[i]++;
    }
    i += offset;
    steps++;
}

Console.WriteLine(steps);