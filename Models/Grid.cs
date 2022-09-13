using System.Drawing;

namespace Models;

public class Grid : Rectangle, IGrid
{
    private readonly List<Rectangle> _rectangles;
    private readonly List<string> _errors;

    public Grid(int width, int height)
        : base(new Point(0, 0), new Point(width - 1, height - 1))
    {
        _rectangles = new();
        _errors = new();

        if (width < 5 || height < 5 || width > 25 || height > 25)
        {
            throw new ArgumentException("A grid must have a width and height of no less than 5 and no greater than 25.");
        }
    }

    public bool AddRectangle(Point left, Point right, Color color)
    {
        _errors.Clear();

        Rectangle rectangle;

        try
        {
            rectangle = new Rectangle(left, right, color);

            var isValid = IsValid(rectangle);

            if (isValid)
            {
                _rectangles.Add(rectangle);

                return true;
            }
        }
        catch (Exception ex)
        {
            _errors.Add(ex.Message);
        }

        return false;
    }

    public bool AddRectangle(Point left, Point right, string color)
    {
        return AddRectangle(left, right, Color.FromName(color));
    }

    public bool RemoveRectangle(Point point)
    {
        _errors.Clear();

        foreach (var item in _rectangles)
        {
            if (item.ContainsPoint(point.X, point.Y))
            {
                _rectangles.Remove(item);
                return true;
            }
        }

        return false;
    }

    public string GetColor(Point point)
    {
        foreach (var item in _rectangles)
        {
            if (item.ContainsPoint(point.X, point.Y))
            {
                return item.Color.ToKnownColor().ToString();
            }
        }

        return Color.White.ToKnownColor().ToString();
    }

    public List<string> GetErrors()
    {
        return _errors;
    }

    private bool IsValid(Rectangle rectangle)
    {
        if (IsBeyondEdge(rectangle))
        {
            _errors.Add("Rectangle is beyond the edge.");
            return false;
        }

        if (rectangle.Area() == 0 || rectangle.Width == 1 || rectangle.Height == 1)
        {
            _errors.Add("It's not a Rectangle.");
            return false;
        }

        // If this is the first rectangle then we don't
        // need to check if it overlaps another rectangle
        if (_rectangles.Count == 0)
        {
            return true;
        }

        if (IsOverlap(rectangle))
        {
            _errors.Add("Rectangle overlaps another rectangle.");
            return false;
        }

        return true;
    }

    private bool IsBeyondEdge(Rectangle rectangle)
    {
        if (rectangle.Y2 >= Height || rectangle.X2 >= Width)
        {
            return true;
        }

        return false;
    }

    private bool IsOverlap(Rectangle rectangle)
    {
        foreach (var rec in _rectangles)
        {
            if ((rec.X1 <= rectangle.X2) && (rec.X2 >= rectangle.X1) &&
                    (rec.Y1 <= rectangle.Y2) && (rec.Y2 >= rectangle.Y1))
            {
                return true;
            }
        }

        return false;
    }
}
