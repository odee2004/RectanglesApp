namespace Models;

public class Point
{
    private readonly int _x = 0;
    private readonly int _y = 0;

    public Point(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int X { get { return _x; } }
    public int Y { get { return _y; } }
}