using System;

abstract class Figure
{
    public abstract double Area();
    public override abstract string ToString();
}

class Rect : Figure, IPrint
{
    public double W { get; set; }
    public double H { get; set; }

    public Rect(double w, double h)
    {
        W = w; H = h;
    }

    public override double Area() => W * H;

    public override string ToString()
    {
        return $"Прямоугольник: ширина={W}, высота={H}, площадь={Area()}";
    }

    public void Print() => Console.WriteLine(ToString());
}

class Square : Rect
{
    public Square(double a) : base(a, a) { }

    public override string ToString()
    {
        return $"Квадрат: сторона={W}, площадь={Area()}";
    }
}

class Circle : Figure, IPrint
{
    public double R { get; set; }
    public Circle(double r) => R = r;

    public override double Area() => Math.PI * R * R;

    public override string ToString()
    {
        return $"Круг: радиус={R}, площадь={Area():F2}";
    }

    public void Print() => Console.WriteLine(ToString());
}

interface IPrint
{
    void Print();
}

class Program
{
    static void Main()
    {
        IPrint[] arr =
        {
            new Rect(5, 3),
            new Square(4),
            new Circle(2.5)
        };

        foreach (var f in arr)
            f.Print();
    }
}
