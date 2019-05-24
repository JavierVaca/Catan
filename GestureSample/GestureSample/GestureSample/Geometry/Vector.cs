using System;
using System.Collections.Generic;
using System.Text;

namespace GestureSample
{
    public class Vector
    {
        private float length;
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float point_x1, float point_y1, float point_x2, float point_y2)
        {
            X = point_x2 - point_x1;
            Y = point_y2 - point_y1;
            length = (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public Vector()
        {
        }

        public Vector GetNextVector()
        {
            Vector result = new Vector
            {
                X = GetNextPointX(this),
                Y = GetNextPointY(this)
            };
            return result;
        }

        /* Returns the Y cordinate of a vector 
        * of the same length as vector a with 60 degrees separation,
        * by using the a vector and the normal vector to a
        */
        private float GetNextPointY(Vector a)
        {
            double result = a.Y * Math.Cos(1.0472) + a.X * Math.Sin(1.0472);
            return (float)result;
        }

        /* Returns the Y cordinate of a vector 
       * of the length and angle specified,
       * by using the a vector and the normal vector to a
       */
        public float GetNextPointY(Vector a, float angle, float length)
        {
            double result = a.length/length * (a.Y * Math.Cos((angle * Math.PI)/180) + a.X * Math.Sin(angle * Math.PI) / 180);
            return (float)result;
        }

        /* Returns the X cordinate of a vector 
         * of the same length as vector a with 60 degrees separation,
         * by using the a vector and the normal vector to a
         */
        private float GetNextPointX(Vector a)
        {
            float result = a.X * (float)Math.Cos(1.0472) + (-a.Y * (float)Math.Sin(1.0472));
            return result;
        }

        /* Returns the Y cordinate of a vector 
       * of the length and angle specified,
       * by using the a vector and the normal vector to a
       */
        public float GetNextPointX(Vector a, float angle, float length)
        {
            double radians = (angle * Math.PI) / 180;
            double result = (a.X * Math.Cos(radians) + (-a.Y * Math.Sin(radians)));
            return (float)result;
        }
    }
}
