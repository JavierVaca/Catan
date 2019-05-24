using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace GestureSample
{
    public class Star
    {
        public SKPath StarPath { get; set; }
        public SKPoint Center { get; set; }
        public float Radius { get; set; }

        public Star(SKPoint center, float radius)
        {
            Center = center;
            Radius = radius;
            StarPath = GetPath();
        }

        private SKPath GetPath()
        {
            SKPath result = new SKPath();
            result.MoveTo(Center.X, Center.Y - Radius);
            for (int i = 1; i < 5; i++)
            {
                // angle from vertical
                double angle = i * 4 * Math.PI / 5;
                result.LineTo(Center + new SKPoint(Radius * (float)Math.Sin(angle),
                                                -Radius * (float)Math.Cos(angle)));
            }
            result.Close();
            return result;
        }
    }
}
