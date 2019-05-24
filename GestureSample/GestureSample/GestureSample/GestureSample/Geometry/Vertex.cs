using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Vertex
    {
        public Vertex()
        {
            Thief = false;
        }

        public SKPoint Point { get; set; }
        public SKPath Path { get; set; }
        public float Radius { get; set; }
        public bool Thief { get; set; }
        public TileType resourceType { get; set; }
        public int ID { get; set; }
    }
}
