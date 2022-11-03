var input = 289326;
// var input = 12;

var spiral = new int[1000, 1000];
var x = 500;
var y = 500;
spiral[x, y] = 1;
x++;
spiral[x, y] = 1;
var direction = 0;
for (int i = 3; i < input + 1; i++)
{
    if (direction == 0)
    {
        y++;
        if (spiral[x - 1, y] == 0)
        {
            direction = 1;
        }
    }
    else if (direction == 1)
    {
        x--;
        if (spiral[x, y - 1] == 0)
        {
            direction = 2;
        }
    }
    else if (direction == 2)
    {
        y--;
        if (spiral[x + 1, y] == 0)
        {
            direction = 3;
        }
    }
    else
    {
        x++;
        if (spiral[x, y + 1] == 0)
        {
            direction = 0;
        }
    }
    // spiral[x,y] = i;
    spiral[x,y] = spiral[x - 1, y] + spiral[x - 1, y - 1] + spiral[x, y - 1] + spiral[x + 1, y - 1] + spiral[x + 1, y] + spiral[x + 1, y + 1] + spiral[x, y + 1] + spiral[x - 1, y + 1];
    if (spiral[x,y] > input)
    {
        break;
    }
}

Console.WriteLine(spiral[x, y]);
Console.WriteLine(Math.Abs(x - 500) + Math.Abs(y - 500));