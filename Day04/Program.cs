var input = File.ReadAllLines("./input.txt");
int valid = 0;
foreach (var line in input)
{
    var words = line.Split(' ');
    var dict = new Dictionary<string, int>();
    foreach (var word in words)
    {
        var arr = word.ToArray();
        Array.Sort(arr);
        var sorted = new string(arr);
        // if (dict.ContainsKey(word))
        if (dict.ContainsKey(sorted))
        {
            valid++;
            break;
        }
        else
        {
            // dict.Add(word, 1);
            dict.Add(sorted, 1);
        }
    }
}

Console.WriteLine(input.Length-valid);