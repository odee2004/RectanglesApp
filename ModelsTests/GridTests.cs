using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Models.Tests;

[TestClass()]
public class GridTests
{
    [DataRow(5, 5)]
    [DataRow(12, 8)]
    [DataRow(15, 10)]
    [DataRow(25, 25)]
    [TestMethod()]
    public void Create_Grid_Success(int width, int height)
    {
        var grid = new Grid(width, height);

        Assert.IsNotNull(grid);
    }

    /// <summary>
    /// A grid must have a width and height of no less than 5 and no greater than 25
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    [DataRow(4, 5)]
    [DataRow(26, 25)]
    [DataRow(12, 1)]
    [DataRow(9, 30)]
    [DataRow(1, 100)]
    [TestMethod()]
    public void Create_Grid_Constraint_Exception(int width, int height)
    {
        Assert.ThrowsException<ArgumentException>(() => new Grid(width, height));
    }

    [DataRow(1, 1, 3, 4, "Red")]
    [DataRow(2, 6, 7, 5, "Green")]
    [DataRow(9, 0, 6, 3, "Blue")]
    [TestMethod()]
    public void AddRectangle_Success_One_Rectangle(int x1, int y1, int x2, int y2, string color)
    {
        var grid = new Grid(12, 8);

        var result = grid.AddRectangle(new Point(x1, y1), new Point(x2, y2), color);

        Assert.IsTrue(result);
    }

    /// <summary>
    /// Add 2 rectangles with different location/position successfully
    /// </summary>
    /// <param name="r1x1">Rectangle1 x1</param>
    /// <param name="r1y1">Rectangle1 x2</param>
    /// <param name="r1x2">Rectangle1 y1</param>
    /// <param name="r1y2">Rectangle1 y2</param>
    /// <param name="r2x1">Rectangle2 x1</param>
    /// <param name="r2y1">Rectangle2 x2</param>
    /// <param name="r2x2">Rectangle2 y1</param>
    /// <param name="r2y2">Rectangle2 y2</param>
    [DataRow(1, 1, 3, 4, 2, 5, 7, 6)]
    [DataRow(2, 5, 7, 6, 6, 0, 9, 3)]
    [DataRow(6, 0, 9, 3, 1, 1, 3, 4)]
    [TestMethod()]
    public void AddRectangle_Success_Two_Rectangle(int r1x1, int r1y1, int r1x2, int r1y2,
        int r2x1, int r2y1, int r2x2, int r2y2)
    {
        var grid = new Grid(12, 8);

        var result1 = grid.AddRectangle(new Point(r1x1, r1y1), new Point(r1x2, r1y2), Color.Beige);

        Assert.IsTrue(result1);

        var result2 = grid.AddRectangle(new Point(r2x1, r2y1), new Point(r2x2, r2y2), Color.Maroon);

        Assert.IsTrue(result2);
    }

    [DataRow(0, 0, 2, 2)]
    [DataRow(1, 1, 3, 4)]
    [DataRow(1, 4, 3, 1)]
    [TestMethod()]
    public void AddRectangle_Overlaps_Same_Position(int x1, int y1, int x2, int y2)
    {
        var grid = new Grid(5, 5);

        var result1 = grid.AddRectangle(new Point(x1, y1), new Point(x2, y2), Color.Beige);

        Assert.IsTrue(result1);

        var result2 = grid.AddRectangle(new Point(x1, y1), new Point(x2, y2), Color.Beige);

        Assert.IsFalse(result2, "Rectangle overlaps.");
    }

    /// <summary>
    /// Add 2 rectangles with different location/position that overlaps each other
    /// </summary>
    /// <param name="r1x1">Rectangle1 x1</param>
    /// <param name="r1y1">Rectangle1 x2</param>
    /// <param name="r1x2">Rectangle1 y1</param>
    /// <param name="r1y2">Rectangle1 y2</param>
    /// <param name="r2x1">Rectangle2 x1</param>
    /// <param name="r2y1">Rectangle2 x2</param>
    /// <param name="r2x2">Rectangle2 y1</param>
    /// <param name="r2y2">Rectangle2 y2</param>
    [DataRow(1, 1, 3, 4, 2, 5, 7, 4)]
    [DataRow(6, 0, 9, 3, 3, 2, 7, 5)]
    [DataRow(3, 0, 4, 3, 2, 1, 5, 5)]
    [TestMethod()]
    public void AddRectangle_Overlaps_Different_Position(int r1x1, int r1y1, int r1x2, int r1y2,
        int r2x1, int r2y1, int r2x2, int r2y2)
    {
        var grid = new Grid(12, 8);

        var result1 = grid.AddRectangle(new Point(r1x1, r1y1), new Point(r1x2, r1y2), Color.Beige);

        Assert.IsTrue(result1);

        var result2 = grid.AddRectangle(new Point(r2x1, r2y1), new Point(r2x2, r2y2), Color.Maroon);

        Assert.IsFalse(result2, "Rectangle overlaps.");
    }

    [DataRow(9, 3, 12, 6)]
    [DataRow(0, 8, 4, 0)]
    [DataRow(5, 3, 12, 8)]
    [TestMethod()]
    public void AddRectangle_Beyond_Edge(int x1, int y1, int x2, int y2)
    {
        var grid = new Grid(12, 8);

        var result = grid.AddRectangle(new Point(x1, y1), new Point(x2, y2), Color.Beige);

        Assert.IsFalse(result);
    }

    [DataRow(6, 0, true)]
    [DataRow(9, 3, true)]
    [DataRow(7, 2, true)]
    [DataRow(8, 1, true)]
    [DataRow(0, 7, false)]
    [DataRow(11, 0, false)]
    [DataRow(5, 4, false)]
    [DataRow(10, 3, false)]
    [TestMethod()]
    public void RemoveRectangle(int x, int y, bool success)
    {
        var grid = new Grid(12, 8);

        var rec = grid.AddRectangle(new Point(6, 3), new Point(9, 0), Color.Beige);

        Assert.IsTrue(rec);

        var result = grid.RemoveRectangle(new Point(x, y));

        Assert.AreEqual(success, result);
    }

    [DataRow(2, 2, "Yellow")]
    [DataRow(3, 1, "Yellow")]
    [DataRow(2, 6, "Green")]
    [DataRow(6, 5, "Green")]
    [DataRow(7, 1, "Red")]
    [DataRow(9, 2, "Red")]
    [DataRow(11, 7, "White")]
    [DataRow(5, 3, "White")]
    [TestMethod]
    public void GetColor_Success(int x, int y, string colorName)
    {
        var grid = new Grid(12, 8);
        grid.AddRectangle(new Point(1, 1), new Point(3, 4), Color.Yellow);
        grid.AddRectangle(new Point(7, 5), new Point(2, 6), Color.Green);
        grid.AddRectangle(new Point(6, 3), new Point(9, 0), Color.Red);

        var result = grid.GetColor(new Point(x, y));

        Assert.AreEqual(colorName, result);
    }
}