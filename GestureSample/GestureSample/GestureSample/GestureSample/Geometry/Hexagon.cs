using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Hexagon
    {
        public float Center_x;
        public float Center_y;
        private readonly float Radius;
        public SKPath NumberCircle { get; set; }
        public SKPath HexPath { get; set; }
        public SKPath[] Edges { get; set; }
        public Vertex[] Vertices { get; set; }
        public SKPaint CenterPaint { get; set; }
        public SKPaint TextPaint { get; set; }
        public SKPaint HexPaint { get; set; }
        public string Id { get; set; }
        private string number;

        private TileType tileType;

        public TileType GetTileType()
        {
            return tileType;
        }

        public void SetTileType(TileType value)
        {
            tileType = value;
            Vertices = GetVertices(1 / 4f * Radius, 1 / 4f * Radius,
                int.Parse(number), GetTileType());
        }    

        public Hexagon(float center_x, float center_y, float radius)
        {
            this.Center_x = center_x;
            this.Center_y = center_y;
            this.Radius = radius;
            HexPath = GetHexPath();
            Edges = GetEdges();
            CenterPaint = new SKPaint() { Color = SKColors.White };
        }

        public string GetNumber()
        {
            return number;
        }

        public void SetNumber(string value)
        {
            if (value == "6" || value == "8")
            {
                TextPaint = new SKPaint()
                {
                    Color = SKColors.Red,
                    TextSize = Radius / 3
                };
            }
            else
            {
                TextPaint = new SKPaint()
                {
                    Color = SKColors.Black,
                    TextSize = Radius/3
                };
            }
            NumberCircle = GetNumberCircle();
            Id = value; 
            number = value;
        }

        public void SetThief()
        {
            number = "Thief";
            for (int i = 0; i < 6; i++)
            {
                Vertices[i].Thief = true;
            }
        }

        public void UnsetThief()
        {
            for (int i = 0; i < 6; i++)
            {
                Vertices[i].Thief = false;
            }
        }

        private SKPath GetNumberCircle()
        {
            SKPath resultPath = new SKPath();
            resultPath.AddCircle(Center_x, Center_y, Radius/3);
            return resultPath;
        }

        private SKPath GetHexPath()
        {
            SKPath resultPath = new SKPath();
            SKPoint[] points = GetHexPathPoints(Radius);
            resultPath.MoveTo(points[0]);
            for (int i = 1; i < 6; i++)
            {
                resultPath.LineTo(points[i]);
            }
            resultPath.Close();

            return resultPath;
        }

        private SKPoint[] GetVerticesPoints()
        {
            return GetHexPathPoints(Radius + 5);
        }

        private Vertex[] GetVertices(float height, float width, int number, TileType tileType)
        {
            Vertex[] result = new Vertex[6];
            SKPoint[] points = GetVerticesPoints();
            for (int i = 0; i < 6; i++)
            {
                result[i] = new Vertex()
                {
                    Path = new Square(points[i], height, width).SquarePath,
                    Point = points[i],
                    ID = number,
                    Radius = height,
                    resourceType = tileType
                };
            }
            return result;
        }

        private SKPoint[] GetHexPathPoints(float radius)
        {
            SKPoint[] result = new SKPoint[6];
            float a_y = Center_y - radius;
            float a_x = Center_x;
            result[0] = new SKPoint(a_x, a_y);
            Vector a = new Vector(Center_x, Center_y, a_x, a_y);
            Vector midresultvector = new Vector();
            for (int i = 1; i < 6; i++)
            {
                a = a.GetNextVector();
                result[i] = new SKPoint(Center_x + a.X, Center_y + a.Y);
            }
            return result; 
        }

        private SKPath[] GetEdges()
        {
            var result = new SKPath[6];
            Edge midresult;
            for (int i=0; i < 6; i++)
            {
                SKPoint Point1 = HexPath.GetPoint(i);
                SKPoint Point2 = HexPath.GetPoint((i + 1) % 6);
                
                if (i == 4)
                {
                    midresult = new Edge(Point2, Point1, -20);
                }
                else if (i == 1)
                {
                    midresult = new Edge(Point2, Point1, 20);
                }
                else if (i > 2)
                {
                    midresult = new Edge(Point2, Point1, -10);
                }
                else 
                {
                    midresult = new Edge(Point1, Point2, 10);
                }

                result[i] = midresult.EdgePath;
            }
            return result;
        }

        
    }
}
