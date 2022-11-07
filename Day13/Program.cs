var input = File.ReadAllLines("./input.txt")
            .Select(x => x.Split(": ", StringSplitOptions.RemoveEmptyEntries))
            .Select(x => x.Select(y => int.Parse(y)).ToList()).ToList();
var severity = 10;
var offset = 0;
while (severity > 0)
{
    severity = 0;
    offset++;
    foreach (var line in input)
    {
        if (line[0]+offset == 0) continue;
        if ((line[0]+offset) % ((line[1] - 1) * 2) == 0)
        {
            // severity += line[0] * line[1];
            severity = 100;
            break;
            // Console.WriteLine($"{line[0]} {line[1]}");
        }
    }
}
// Console.WriteLine(severity);
Console.WriteLine(offset);