var input = File.ReadAllLines("./input.txt");

var registers = new Dictionary<string, int>();
var currentMax = 0;
foreach (var instruction in input)
{
    var tokens = instruction.Split(' ');
    if (!registers.ContainsKey(tokens[0]))
    {
        registers.Add(tokens[0], 0);
    }

    if (tokens.Length > 3 && !registers.ContainsKey(tokens[4]))
    {
        registers.Add(tokens[4], 0);
    }

    if (tokens.Length > 4)
    {
        var limit = int.Parse(tokens[6]);
        if ((registers[tokens[4]] == limit 
            && (tokens[5] == "==" || tokens[5] == ">=" || tokens[5] == "<="))
            || (registers[tokens[4]] > limit
            && (tokens[5] == ">" || tokens[5] == ">="))
            || (registers[tokens[4]] < limit
            && (tokens[5] == "<" || tokens[5] == "<="))
            || (registers[tokens[4]] != limit
            && (tokens[5] == "!=")))
        {
            if (tokens[1] == "inc")
            {
                registers[tokens[0]] += int.Parse(tokens[2]);
            }
            else 
            {
                registers[tokens[0]] -= int.Parse(tokens[2]);
            }
        }
    }
    currentMax = Math.Max(currentMax, registers.Values.Max());
}

Console.WriteLine(currentMax);