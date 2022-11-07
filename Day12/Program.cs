var input = File.ReadAllLines("./input.txt")
            .Select(x => x.Split(new string[] { " <-> ", ", ", " " }, StringSplitOptions.RemoveEmptyEntries))
            .Select(x => x.Select(y => int.Parse(y)).ToList()).ToList();

var pipes = new Dictionary<int, List<int>>();
foreach (var line in input)
{
    if (!pipes.ContainsKey(line[0]))
    {
        pipes.Add(line[0], new List<int>());
    }

    for (int i = 1; i < line.Count; i++)
    {
        pipes[line[0]].Add(line[i]);
    }
}

var programs = pipes.Keys.ToList();
var numGroups = 0;
while (programs.Count > 0)
{
    numGroups++;
    var group = new List<int>();
    group.Add(programs[0]);
    programs.RemoveAt(0);
    var firstnew = 0;
    while (firstnew < group.Count)
    {
        var start = firstnew;
        firstnew = group.Count;
        for (int i = start; i < firstnew; i++)
        {
            foreach (var c in pipes[group[i]])
            {
                if (!group.Contains(c))
                {
                    group.Add(c);
                    programs.Remove(c);
                }
            }
        }
    }
}

// Console.WriteLine(group.Count);
Console.WriteLine(numGroups);