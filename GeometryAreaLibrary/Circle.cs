using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAreaLibrary
{
    public class Circle : IFigure
    {
        private double _radius;
        private double _epsilon = Constants.Epsilon;
        public Circle(double radius)
        {
            if(radius < _epsilon) 
                throw new ArgumentException("Incorrect input", nameof(radius));
            _radius = radius;
        }
        public double GetArea() 
        {
            return Math.PI * _radius * _radius;
        }
        public double GetPerimeter() 
        {
            return 2 * Math.PI * _radius;
        }
    }
}
