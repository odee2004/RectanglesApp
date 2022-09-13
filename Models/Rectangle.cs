using System.Drawing;

namespace Models;

public class Rectangle : Shape
{
    private readonly Point _left;
    private readonly Point _right;
    private readonly Color _color;

    public Rectangle(Point left, Point right)
    {
        _left = left;
        _right = right;
        _color = Color.Black;

        if (HasNegative())
        {
            throw new ArgumentException("Rectangle is out of bounds of the grid.");
        }
    }

    public Rectangle(Point left, Point right, Color color)
    {
        _left = left;
        _right = right;
        _color = color;
    }

    public Color Color { get { return _color; } }
    public Point Left { get { return new Point(X1, Y1); } }
    public Point Right { get { return new Point(X2, Y2); } }

    /// <summary>
    /// The x-coordinate of the left side of the rectangle
    /// </summary>
    public int X1
    {
        get
        {
            if (_left.X < _right.X)
            {
                return _left.X;
            }

            return _right.X;
        }
    }

    /// <summary>
    /// The x-coordinate of the right side the rectangle
    /// </summary>
    public int X2
    {
        get
        {
            if (_left.X > _right.X)
            {
                return _left.X;
            }

            return _right.X;
        }
    }

    /// <summary>
    /// The y-coordinate of the left side of the rectangle
    /// </summary>
    public int Y1
    {
        get
        {
            if (_left.Y < _right.Y)
            {
                return _left.Y;
            }

            return _right.Y;
        }
    }

    /// <summary>
    /// The y-coordinate of the right side of the rectangle
    /// </summary>
    public int Y2
    {
        get
        {
            if (_left.Y > _right.Y)
            {
                return _left.Y;
            }

            return _right.Y;
        }
    }

    public int Width
    {
        get
        {
            return Math.Abs(_left.X - _right.X) + 1;
        }
    }

    /// <summary>
    /// Height or Lenght of the Rectangle
    /// </summary>
    /// <returns></returns>
    public int Height
    {
        get
        {
            return Math.Abs(_right.Y - _left.Y) + 1;
        }
    }

    public override int Area()
    {
        return Width * Height;
    }

    public override int Perimeter()
    {
        throw new NotImplementedException();
    }

    public override bool ContainsPoint(int x, int y)
    {
        return X1 <= x
            && x < X1 + Width
            && Y1 <= y
            && y < Y1 + Height;
    }

    private bool HasNegative()
    {
        if (_left.X < 0 || _left.Y < 0 || _right.X < 0 || _right.Y < 0)
        {
            return true;
        }

        return false;
    }
}