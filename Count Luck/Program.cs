var matrix = new List<string>() { ".X.X......X", ".X*.X.XXX.X", ".XX.X.XM...", "......XXXX." };

var result = countLuck(matrix, 3);

Console.WriteLine(result);

string countLuck(List<string> matrix, int k)
{
    Dictionary<(int, int), int> wayCountDict = new Dictionary<(int, int), int>();
    int[,] arr = new int[matrix.Count()+2, matrix[0].Length+2];

    List<(int, int)> points = new List<(int, int)>() { (-1, 0), (0, -1), (1, 0), (0, 1) };

    (int, int) m = (0, 0);
    (int, int) portKey = (0, 0);

    for (int i = 0; i < matrix.Count(); i++)
    {
        for (int j = 0; j < matrix[0].Length; j++)
        {
            if (matrix[i][j].Equals('X'))
                arr[i+1, j+1] = 0;
            else if (matrix[i][j].Equals('.'))
                arr[i+1, j+1] = 1;
            else if (matrix[i][j].Equals('M'))
            {
                arr[i+1, j+1] = 0;
                m = (i+1, j+1);
            }
            else
            {
                arr[i+1, j+1] = 1;
                portKey = (i+1, j+1);
            }
        }
    }

    var stack = new Stack<(int, int)>();
    stack.Push(m);

    bool control = true;

    while (stack.Count() > 0 && control)
    {
        var point = stack.Pop();

        stack.Push(point);

        if (!wayCountDict.ContainsKey(point))
            wayCountDict[point] = wayCount(point.Item1, point.Item2, arr, points);

        bool control1 = true;

        foreach(var i in points)
        {
            if (!isOkey(point.Item1, point.Item2, arr, i))
                continue;

            arr[point.Item1 + i.Item1, point.Item2 + i.Item2] = 0;
            point = (point.Item1 + i.Item1, point.Item2 + i.Item2);
            stack.Push(point);

            if ((point.Item1 == portKey.Item1) && (point.Item2 == portKey.Item2))
                control = false;

            control1 = false;
            break;
        }

        if (control1)
            stack.Pop();
    }

    int count = 0;

    while (stack.Count() > 0)
    {
        var point = stack.Pop();

        if (!wayCountDict.ContainsKey(point))
            continue;

        if (wayCountDict[point] > 1)
            count += 1;
    }

    return count == k ? "Impressed" : "Oops!";
}

bool isOkey(int row,int column, int[,] arr,(int,int) point)
{
    if (arr[row + point.Item1, column + point.Item2] == 1)
        return true;

    return false;
}

int wayCount(int row, int column, int[,] arr, List<(int,int)> points)
{
    int count = 0;

    foreach (var i in points)
    {
        if (isOkey(row, column, arr, i))
            count += 1;
    }

    return count;
}