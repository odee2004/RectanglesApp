using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Models.Tests;

[TestClass()]
public class RectangleTests
{
    [DataRow(0, 0, 1, 1)]
    [DataRow(1, 1, 3, 4)]
    [DataRow(1, 4, 3, 1)]
    [TestMethod()]
    public void Create_Rectangle_Success(int x1, int y1, int x2, int y2)
    {
        var rec = new Rectangle(new Point(x1, y1), new Point(x2, y2));

        Assert.IsNotNull(rec);
        Assert.AreEqual(rec.Area(), rec.Width * rec.Height);
    }

    [DataRow(-1, 0, 3, 2)]
    [DataRow(1, -1, 3, 4)]
    [DataRow(1, 4, -3, 1)]
    [DataRow(1, 4, 4, -2)]
    [TestMethod()]
    public void Create_Rectangle_Negative(int x1, int y1, int x2, int y2)
    {
        Assert.ThrowsException<ArgumentException>(() => new Rectangle(new Point(x1, y1), new Point(x2, y2)));
    }

    [DataRow(0, 0, 1, 1, 4)]
    [DataRow(2, 1, 4, 4, 12)]
    [DataRow(0, 3, 3, 0, 16)]
    [TestMethod()]
    public void Area_Success(int x1, int y1, int x2, int y2, int area)
    {
        var rec = new Rectangle(new Point(x1, y1), new Point(x2, y2), Color.Blue);

        Assert.AreEqual(area, rec.Area());
    }

    [DataRow(0, 0, 1, 1, 2)]
    [DataRow(2, 1, 4, 4, 4)]
    [DataRow(0, 3, 3, 0, 4)]
    [TestMethod()]
    public void Height_Success(int x1, int y1, int x2, int y2, int height)
    {
        var rec = new Rectangle(new Point(x1, y1), new Point(x2, y2));

        Assert.AreEqual(height, rec.Height);
    }

    [DataRow(0, 0, 1, 1, 2)]
    [DataRow(2, 1, 4, 4, 3)]
    [DataRow(0, 3, 3, 0, 4)]
    [DataRow(0, 4, 4, 0, 5)]
    [TestMethod()]
    public void Width_Success(int x1, int y1, int x2, int y2, int width)
    {
        var rec = new Rectangle(new Point(x1, y1), new Point(x2, y2)); ;

        Assert.AreEqual(width, rec.Width);
    }

    [DataRow(1, 0, false)]
    [DataRow(2, 1, true)]
    [DataRow(4, 4, false)]
    [DataRow(3, 2, true)]
    [TestMethod()]
    public void Contains_Success(int x, int y, bool isOverlap)
    {
        var rec = new Rectangle(new Point(2, 1), new Point(4, 3));

        var result = rec.ContainsPoint(x, y);

        Assert.AreEqual(isOverlap, result);
    }

    [DataRow("Black")]
    [DataRow("Red")]
    [DataRow("Green")]
    [DataRow("Blue")]
    [TestMethod()]
    public void Color_Success(string colorName)
    {
        var color = Color.FromName(colorName);

        var rec = new Rectangle(new Point(0, 0), new Point(1, 1), color);

        Assert.AreEqual(rec.Color, color);
    }
}