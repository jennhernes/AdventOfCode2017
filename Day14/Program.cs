var input = "hxtvlmkl";
// var input = "flqrgnkx";
var disk = new List<List<char>>();
for (int i = 0; i < 128; i++)
{
    var key = input + "-" + i.ToString();
    var hex = CalculateKnotHash(key);
    var bin = String.Join(String.Empty,
                hex.Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')));
    disk.Add(bin.Select(x =>
    {
        if (x == '1') return '#';
        else return '.';
    }).ToList());
    if (i < 8)
    {
        Console.WriteLine(bin[0..8]);
    }
}

// var used = 0;
// foreach (var row in disk)
// {
//     used += row.Where(x => x == '#').Count();
// }
// Console.WriteLine(used);

var count = 0;
for (int i = 0; i < disk.Count; i++)
{
    for (int j = 0; j < disk[i].Count; j++)
    {
        if (disk[i][j] == '#')
        {
            disk = FillRegion(disk, i, j);
            count++;
        }
    }
}
Console.WriteLine(count);

List<List<char>> FillRegion(List<List<char>> disk, int starti, int startj)
{
    var update = new List<List<int>>();
    update.Add(new List<int> { starti, startj });
    disk[starti][startj] = 'R';
    var u = 0;
    while (u < update.Count)
    {
        var i = update[u][0];
        var j = update[u][1];
        if (i > 0 && disk[i - 1][j] == '#' && !update.Any(x => x[0] == i - 1 && x[1] == j))
        {
            update.Add(new List<int> { i - 1, j });
            disk[i - 1][j] = 'R';
        }
        if (i < disk.Count - 1 && disk[i + 1][j] == '#' && !update.Any(x => x[0] == i + 1 && x[1] == j))
        {
            update.Add(new List<int> { i + 1, j });
            disk[i + 1][j] = 'R';
        }
        if (j > 0 && disk[i][j - 1] == '#' && !update.Any(x => x[0] == i && x[1] == j - 1))
        {
            update.Add(new List<int> { i, j - 1 });
            disk[i][j - 1] = 'R';
        }
        if (j < disk[i].Count - 1 && disk[i][j + 1] == '#' && !update.Any(x => x[0] == i && x[1] == j + 1))
        {
            update.Add(new List<int> { i, j + 1 });
            disk[i][j + 1] = 'R';
        }
        u++;
    }

    return disk;
}


string CalculateKnotHash(string key)
{
    var templen = new List<int>();
    foreach (var c in key)
    {
        templen.Add(c);
    }
    templen.Add(17);
    templen.Add(31);
    templen.Add(73);
    templen.Add(47);
    templen.Add(23);

    var lengths = templen.ToArray();
    var list = new int[256];
    for (int i = 0; i < list.Length; i++)
    {
        list[i] = i;
    }

    var position = 0;
    var listlen = list.Length;
    for (int k = 0; k < 64; k++)
    {
        for (int i = 0; i < lengths.Length; i++)
        {
            int half = lengths[i] / 2;
            for (int j = 0; j < half; j++)
            {
                var temp = list[(position + j) % listlen];
                list[(position + j) % listlen] = list[(position + lengths[i] - 1 - j) % listlen];
                list[(position + lengths[i] - 1 - j) % listlen] = temp;
            }

            position = (position + lengths[i] + k * lengths.Length + i) % listlen;
        }
    }

    var output = "";
    for (int i = 0; i < 16; i++)
    {
        var xor = list[i * 16];
        for (int j = 1; j < 16; j++)
        {
            xor = xor ^ list[i * 16 + j];
        }
        output += xor.ToString("X2");
    }
    return output;
}