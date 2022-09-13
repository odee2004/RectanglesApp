using System.Drawing;

namespace Models;

public interface IGrid
{
    bool AddRectangle(Point left, Point right, Color color);
    bool AddRectangle(Point left, Point right, string color);
    bool RemoveRectangle(Point point);
    string GetColor(Point point);
    List<string> GetErrors();
}

