using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Contract
{
    public class Canvas : ICanvas
    {
        List<MyPoint> points = new List<MyPoint>();

        public void add(MyPoint p)
        {
            Console.WriteLine("Add");
            points.Add(p);
        }

        
        public void clear()
        {
            Console.WriteLine("Clear");
            points.Clear();
        }


        public MyPoint centerOfGravity()
        {
            Console.WriteLine("Ceneter of Gravity");

            int x = 0;
            int y = 0;
            int n = points.Count;

            if (n == 0)
            {
                
                return new MyPoint(x, y);
            }


            foreach (MyPoint p in points)
            {
                x += p.X;
                y += p.Y;
            }

            x /= n;
            y /= n;

            return new MyPoint(x, y);
        }

        public MyPoint get(int i)
        {
            Console.WriteLine("get");
            return points.ElementAt(i);
        }

        public int size()
        {
            Console.WriteLine("size");
            return points.Count;
        }
    }
}
