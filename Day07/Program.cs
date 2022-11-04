var input = File.ReadAllLines("./input.txt")
            .Select(x => x.Split(new string[] { " (", ") -> ", ")", ", " }, StringSplitOptions.RemoveEmptyEntries));

var nodes = new List<Node>();

foreach (var prog in input)
{
    var children = new List<string>();
    for (int i = 2; i < prog.Length; i++)
    {
        children.Add(prog[i]);
    }
    nodes.Add(new Node(prog[0], int.Parse(prog[1]), children.ToArray()));
}

foreach (var node in nodes)
{
    foreach (var child in node.childrenNames)
    {
        var c = nodes.FirstOrDefault(x => x.name == child, null);
        if (c != null)
        {
            node.children.Add(c);
            c.root = false;
        }
    }
}

var root = nodes.Find(x => x.root);
Console.WriteLine(root.name);

var fail = root;
while (true)
{
    var old = fail;
    var weights = new List<int>();
    foreach (var c in fail.children)
    {
        Console.Write($"{c.name} {c.weight}; ");
        weights.Add(TotalWeight(c));
        if (!Balanced(c))
        {
            fail = c;
        }
    }
    Console.WriteLine();
    if (old.name == fail.name)
    {
        Console.WriteLine($"{fail.name} {fail.weight}");
        foreach (var c in fail.children)
        {
            Console.WriteLine($"{c.name} {TotalWeight(c)}");
        }
        break;
    }
}

bool Balanced(Node node)
{
    var weights = new List<int>();
    foreach (var child in node.children)
    {
        weights.Add(TotalWeight(child));
    }
    foreach (var w in weights)
    {
        if (w != weights[0])
        {
            return false;
        }
    }
    return true;
}

int TotalWeight(Node node)
{
    if (node.children.Count == 0)
    {
        return node.weight;
    }
    else
    {
        var w = node.weight;
        foreach (var c in node.children)
        {
            w += TotalWeight(c);
        }
        return w;
    }
}

public class Node
{
    public string name;
    public bool root = true;
    public int weight;
    public string[] childrenNames;
    public List<Node> children;

    public Node(string name, int weight, string[] childrenNames)
    {
        this.name = name;
        this.weight = weight;
        this.childrenNames = childrenNames;
        this.children = new List<Node>();
    }
}
