using System.Text.RegularExpressions;

var sWhitespace = new Regex(@"\s+");

var input = File.ReadAllLines("./input.txt");
var sum = 0;

for (int i = 0; i < input.Length; i++)
{
    var line = input[i];
    var row = line.Trim().Split(null).Select(Int32.Parse).ToList();
    // var min = row[0];
    // var max = row[0];
    // foreach (var val in row)
    // {
    //     if (val < min) min = val;
    //     if (val > max) max = val;
    // }
    // sum += max - min;

    var found = false;
    for (int j = 0; j < row.Count - 1; j++)
    {
        for (int k = j + 1; k < row.Count; k++)
        {
            if (row[j] % row[k] == 0)
            {
                sum += row[j] / row[k];
                found = true;
            }
            else if (row[k] % row[j] == 0)
            {
                sum += row[k] / row[j];
                found = true;
            }
            if (found) break;
        }
        if (found) break;
    }
}

Console.WriteLine(sum);