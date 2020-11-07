using System;

namespace Cube.Domain.Aggregates.CubeAggregate
{
    public class Border : ValueObject<Border>
    {
        private double Start { get; }
        private double End { get; }

        public Border(double center, double coordinate)
        {
            Start = center - coordinate / 2.0;
            End = center + coordinate / 2.0;
        }

        public double Overlap(Border edge)
        {
            return Math.Max(0, Difference(edge));
        }

        public bool Collides(Border edge)
        {
            return Difference(edge) >= 0;
        }

        private double Difference(Border edge)
        {
            return Math.Min(End, edge.End) - Math.Max(Start, edge.Start);
        }

        protected override bool EqualsCore(Border other)
        {
            return Math.Abs(Start - other.Start) < 1
                   && Math.Abs(End - other.End) < 1;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Convert.ToInt32(Start);
                hashCode = (hashCode * 397) ^ Convert.ToInt32(End);
                return hashCode;
            }
        }
    }
}
