using System;

namespace CircleApp
{
    class Circle
    {
        public double radius;

        public double GetDiameter()
        {
            return 2*radius;
        }

        public double GetPerimeter()
        {
            return 2*Math.PI*radius;
        }

        public double GetArea()
        {
            return Math.PI*radius*radius;
        }
    }
}
