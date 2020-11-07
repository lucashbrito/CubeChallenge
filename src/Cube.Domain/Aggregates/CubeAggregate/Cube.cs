namespace Cube.Domain.Aggregates.CubeAggregate
{
    public class Cube : AggregateRoot
    {
        private Border Width;
        private Border Height;
        private Border Depth;

        public Cube(Point center, double coordinate)
        {
            Width = new Border(center.Width, coordinate);
            Height = new Border(center.Height, coordinate);
            Depth = new Border(center.Depth, coordinate);
        }

        public double IntersectionVolumeWith(Cube otherCube)
        {
            return Width.Overlap(otherCube.Width)
                   * Height.Overlap(otherCube.Height)
                   * Depth.Overlap(otherCube.Depth);
        }

        public bool CollidesWith(Cube otherCube)
        {
            return Width.Collides(otherCube.Width)
                   || Height.Collides(otherCube.Height)
                   || Depth.Collides(otherCube.Depth);
        }
    }
}
