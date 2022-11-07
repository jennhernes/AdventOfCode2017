var input = File.ReadAllLines("./input.txt")[0];
// var input = "<{o\"i!a,<{i<a>";
var score = 0;
var currentgroup = 0;
var ingarbage = false;
var removed = 0;
for (int i = 0; i < input.Length; i++)
{
    var c = input[i];

    switch (c)
    {
        case '!':
            if (ingarbage)
            {
                i++;
            }
            break;
        case '{':
            if (!ingarbage)
            {
                currentgroup++;
            }
            else
            {
                removed++;
            }
            break;
        case '}':
            if (!ingarbage)
            {
                score += currentgroup;
                currentgroup--;
            }
            else
            {
                removed++;
            }
            break;
        case '<':
            if (!ingarbage)
            {
                ingarbage = true;
            }
            else
            {
                removed++;
            }
            break;
        case '>':
            if (ingarbage)
            {
                ingarbage = false;
            }
            break;
        default:
            if (ingarbage)
            {
                removed++;
            }
            break;
    }
}

// Console.WriteLine(score);
Console.WriteLine(removed);
