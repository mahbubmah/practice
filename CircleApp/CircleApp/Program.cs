using System;

namespace CircleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle aCircle = new Circle();
            aCircle.radius = 100;
            Console.WriteLine("Perimeter: " + aCircle.GetPerimeter());
            Console.WriteLine("Diameter: " + aCircle.GetDiameter());
            Console.WriteLine("Area: " + aCircle.GetArea());
            Console.ReadLine();
        }
    }
}
