using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Edge
    {
        public SKPoint Point1 { get; set; }
        public SKPoint Point2 { get; set; }
        public SKPath EdgePath { get; set; }

        public Edge(SKPoint point1, SKPoint point2, float xDirection)
        {
            Point1 = point1;
            Point2 = point2;
            EdgePath = GetEdgePath(xDirection);
        }

        private SKPath GetEdgePath(float xDirection)
        {
            SKPath path = new SKPath();
            path.MoveTo(Point1.X , Point1.Y);
            path.LineTo(Point2.X, Point2.Y);
            float y = GetYCoordinate(Point1, Point2, xDirection);
            path.LineTo(Point2.X + xDirection, y);
            y = GetYCoordinate(Point2 , Point1, xDirection);
            path.LineTo(Point1.X + xDirection, y);
            path.LineTo(Point1.X, Point1.Y);
            path.Close();
            return path;
        }

        private float GetYCoordinate(SKPoint Point1, SKPoint Point2, float xDirection)
        {
            float steigung = -(Point2.X - Point1.X) / (Point2.Y - Point1.Y);
            float b1 = Point2.Y - steigung * Point2.X;
            float y = steigung * (Point2.X + xDirection) + b1;
            return y;
        }
    }
}
