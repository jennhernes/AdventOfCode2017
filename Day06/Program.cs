using System.Text;

var mem = new List<int> { 2, 8, 8, 5, 4, 2, 3, 1, 5, 5, 1, 2, 15, 13, 5, 14 };
// var mem = new List<int>{0,2,7,0};

var states = new List<string>();
states.Add(GenerateStateString(mem));
while (true)
{
    var max = mem.Max();
    var i = mem.FindIndex(x => x == max);
    mem[i] = 0;
    while (max > 0)
    {
        i = (i + 1) % mem.Count;
        mem[i]++;
        max--;
    }
    var state = GenerateStateString(mem);
    if (states.Contains(state))
    {
        Console.WriteLine(states.Count);
        break;
    }
    states.Add(state);
}
var inf = GenerateStateString(mem);
states.Clear();
states.Add(inf);
while (true)
{
    var max = mem.Max();
    var i = mem.FindIndex(x => x == max);
    mem[i] = 0;
    while (max > 0)
    {
        i = (i + 1) % mem.Count;
        mem[i]++;
        max--;
    }
    var state = GenerateStateString(mem);
    if (state == inf)
    {
        Console.WriteLine(states.Count);
        break;
    }
    states.Add(state);
}

string GenerateStateString(List<int> mem)
{
    var sb = new StringBuilder();
    foreach (var i in mem)
    {
        sb.Append(i.ToString());
    }

    return sb.ToString();
}