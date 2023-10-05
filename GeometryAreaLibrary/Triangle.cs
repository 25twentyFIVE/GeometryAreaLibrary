using System.Runtime.CompilerServices;

namespace GeometryAreaLibrary
{
    public class Triangle : IFigure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;
        private double _epsilon = Constants.Epsilon;
        private bool _isRight;
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < _epsilon) 
                throw new ArgumentException("Incorrect input", nameof(sideA)); 
            if (sideB < _epsilon) 
                throw new ArgumentException("Incorrect input", nameof(sideB)); 
            if (sideC < _epsilon) 
                throw new ArgumentException("Incorrect input", nameof(sideC)); 

            double biggestSide = Math.Max(sideA, Math.Max(sideB, sideC));
            double perimeter = sideA + sideB + sideC;
            if ((perimeter - biggestSide) - biggestSide < _epsilon)
                throw new ArgumentException("The biggest side must be less than the sum of other's");

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;

            _isRight = IsRight();
        }

        public double GetPerimeter()
        {
            return _sideA + _sideB + _sideC;
        }
        public double GetArea()
        {
            double semiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt((semiPerimeter) * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
        }
        
        public bool IsRight()
        {
            double biggestSide = _sideA, sideB = _sideB, sideC = _sideC;
            if(sideB > biggestSide)
            {
                Extras.Swap(ref biggestSide, ref sideB);
            }
            if(sideC > biggestSide)
            {
                Extras.Swap(ref biggestSide, ref sideC);
            }

            double pifagorTheorem = biggestSide * biggestSide - sideB * sideB - sideC * sideC;
            return Math.Abs(pifagorTheorem) < Constants.Epsilon;
        }
    }
}