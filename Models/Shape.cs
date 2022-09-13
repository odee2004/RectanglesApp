namespace Models;

public abstract class Shape
{
    public abstract int Area();    
    public abstract int Perimeter();

    public abstract bool ContainsPoint(int x, int y);
}
