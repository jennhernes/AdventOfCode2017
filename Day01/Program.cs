var input = File.ReadAllLines("./input.txt").First();

var sum = 0;
var length = input.Length;
var halflen = length / 2;

for (int i = 0; i < length; i++)
{
    //if (input[i] == input[(i + 1) % length])
    if (input[i] == input[(i + halflen) % length])
    {
        sum += input[i] - '0';
    }
}

Console.WriteLine(sum);
