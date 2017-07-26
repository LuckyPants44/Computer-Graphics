using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab4Graphics
{
    class DPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public DPoint(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public DPoint()
        {
            this.X = 0;
            this.Y = 0;
        }

        public DPoint(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
    }
}
