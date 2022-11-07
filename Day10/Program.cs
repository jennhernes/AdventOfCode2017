var input = "76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229";
// var input = "The empty string";
var templen = new List<int>();
foreach (var c in input)
{
    templen.Add(c);
}
templen.Add(17);
templen.Add(31);
templen.Add(73);
templen.Add(47);
templen.Add(23);

var lengths = templen.ToArray();
// var lengths = new int[]{76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229};
// var lengths = new int[] { 3, 4, 1, 5 };
var list = new int[256];
// var list = new int[5];
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
        // Console.WriteLine($"half {half}");
        for (int j = 0; j < half; j++)
        {
            var temp = list[(position + j) % listlen];
            list[(position + j) % listlen] = list[(position + lengths[i] - 1 - j) % listlen];
            list[(position + lengths[i] - 1 - j) % listlen] = temp;
        }

        position = (position + lengths[i] + k*lengths.Length + i) % listlen;
        // foreach (var l in list)
        // {
        //     Console.Write(l + " ");
        // }
        // Console.WriteLine();
    }
}

// foreach (var i in list)
// {
//     Console.Write(i + " ");
// }
// Console.WriteLine();
// Console.WriteLine(list[0] * list[1]);

for (int i = 0; i < 16; i++)
{
    var xor = list[i*16];
    for (int j = 1; j < 16; j++)
    {
        xor = xor ^ list[i*16+j];
    }
    Console.Write(xor.ToString("X") + " ");
}
Console.WriteLine();
