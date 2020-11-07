using Cube.Domain.Core;

namespace Cube.Domain.Aggregates.CubeAggregate
{
    public readonly struct Point
    {
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }

        public Point(double width, double height, double depth)
        {
            //I was considering a 0 as Invalid. Because they will multiple during of the process. 
            if (width==0 )
                throw new DomainException("The Width field can't be zero");

            if (height == 0)
                throw new DomainException("The Height field can't be zero");

            if (depth == 0)
                throw new DomainException("The Depth field can't be zero");

            Width = width;
            Height = height;
            Depth = depth;
        }
    }
}
