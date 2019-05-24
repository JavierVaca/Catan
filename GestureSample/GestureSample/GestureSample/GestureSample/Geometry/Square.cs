using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Square
    {
        public SKPath SquarePath { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public SKPoint Center { get; set; }

        public Square(SKPoint center, float height, float width)
        {
            Center = center;
            Height = height;
            Width = width;
            SquarePath = GetSquarePath();
        }

        private SKPath GetSquarePath()
        {
            SKPath path = new SKPath();
            SKPoint[] points = GetSquarePoints();
            path.MoveTo(points[0]);
            for ( int i = 0; i < 4; i++)
            {
                path.LineTo(points[(i + 1) % 4]);
            }
            path.Close();

            return path;
        }

        private SKPoint[] GetSquarePoints()
        {
            SKPoint[] result = new SKPoint[4];
            result[0] = new SKPoint(Center.X - Width, Center.Y - Height);
            result[1] = new SKPoint(Center.X + Width, Center.Y - Height);
            result[2] = new SKPoint(Center.X + Width, Center.Y + Height);
            result[3] = new SKPoint(Center.X - Width, Center.Y + Height);
            return result;
        }
    }
}
