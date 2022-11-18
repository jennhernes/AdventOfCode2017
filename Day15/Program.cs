var genA = 277L;
var genB = 349L;
// var genA = 65L;
// var genB = 8921L;
var fa = 16807L;
var fb = 48271L;

var lista = new List<long>();
var listb = new List<long>();
var count = 0L;
for (long i = 0L; i < 40000000L; i++)
{
    genA = (genA * fa) % 2147483647L;
    genB = (genB * fb) % 2147483647L;
    // if ((genA & 0xffff) == (genB & 0xffff))
    // {
    //     count++;
    // }
    if (genA % 4 == 0)
    {
        lista.Add(genA);
    }
    if (genB % 8 == 0)
    {
        listb.Add(genB);
    }
}

var len = Math.Min(lista.Count, listb.Count);
len = Math.Min(len, 5000000);
for (int i = 0; i < len; i++)
{
    if ((lista[i] & 0xffff) == (listb[i] & 0xffff))
    {
        count++;
    }
}

Console.WriteLine(count);