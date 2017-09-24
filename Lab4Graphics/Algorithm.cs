using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab4Graphics
{
    class Algorithm
    {
        public string CohenSutherland(Point[] screen, DPoint A, DPoint B)
        {
            string result = "";

            bool[,] location = new bool[2, 4];
            double[] vector = new double[2] { B.X - A.X, B.Y - A.Y };
            int zeroCounter = 0;
            //Определяем расположение точек
            if ((A.X < screen[0].X) || (B.X < screen[0].X))
            {
                if (A.X < screen[0].X)
                    location[0, 3] = true;
                if (B.X < screen[0].X)
                    location[1, 3] = true;
            }
            if ((A.X > screen[1].X) || (B.X > screen[1].X))
            {
                if (A.X > screen[1].X)
                    location[0, 2] = true;
                if (B.X > screen[1].X)
                    location[1, 2] = true;
            }
            if ((A.Y < screen[0].Y) || (B.Y < screen[0].Y))
            {
                if (A.Y < screen[0].Y)
                    location[0, 1] = true;
                if (B.Y < screen[0].Y)
                    location[1, 1] = true;
            }
            if ((A.Y > screen[1].Y) || (B.Y > screen[1].Y))
            {
                if (A.Y > screen[1].Y)
                    location[0, 0] = true;
                if (B.Y > screen[1].Y)
                    location[1, 0] = true;
            }

            for (int t = 0; t < 4; t++)
            {
                if ((location[0, t]) && (location[1, t]))               //2
                {
                    result = " ";
                    return result;
                }
                if ((location[0, t] == location[1, t]) && (!location[0, t]))
                {
                    zeroCounter++;
                }
            }
            if (zeroCounter == 4)                                          //1
            {
                result = A.X + " " + A.Y + " " + B.X + " " + B.Y + " ";
                return result;
            }
            else
            {
                result = MiddlePoint(screen, A, B);                      //3
                return result;
            }
        }

        public string MiddlePoint(Point[] screen, DPoint A, DPoint B)
        {
            double eps = 0.001;
            string result = "";
            if (Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2)) < eps)
            {
                result = A.X + " " + A.Y + " " + B.X + " " + B.Y + "!!! ";
                return result;
            }
            DPoint M = new DPoint();
            M.X = A.X - (A.X - B.X) / 2;
            M.Y = A.Y - (A.Y - B.Y) / 2;
            result += CohenSutherland(screen, A, M);
            result += CohenSutherland(screen, B, M);
            return result;
        }

        private double ScalarMult(DPoint p1, DPoint p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }

        public List<DPoint> CyrusBeck(DPoint A, DPoint B, List<Point> points)
        {
            List<DPoint> result = new List<DPoint>();
            double tmax = Single.MinValue;
            double tmin = Single.MaxValue;
            DPoint v2 = new DPoint(B.X - A.X, B.Y - A.Y);
            for (int i = 0; i < points.Count; i++)
            {
                double t;
                if (i != points.Count - 1)
                {
                    DPoint N = new DPoint(points[i + 1].Y - points[i].Y, points[i].X - points[i + 1].X);
                    DPoint v1 = new DPoint(A.X - points[i].X, A.Y - points[i].Y);
                    t = -ScalarMult(v1, N) / ScalarMult(v2, N);
                    if (ScalarMult(v2, N) < 0 && t > tmax)
                        tmax = t;
                    if (ScalarMult(v2, N) > 0 && t < tmin)
                        tmin = t;
                }
                else
                {
                    DPoint N = new DPoint(points[0].Y - points[points.Count - 1].Y, points[points.Count - 1].X - points[0].X);
                    DPoint v1 = new DPoint(A.X - points[points.Count - 1].X, A.Y - points[points.Count - 1].Y);
                    if ((ScalarMult(v2, N) != 0)&&(Math.Abs(ScalarMult(v1, N)) < 10000000))
                    {
                        t = -ScalarMult(v1, N) / ScalarMult(v2, N);

                        if (ScalarMult(v2, N) < 0 && t > tmax)
                            tmax = t;
                        if (ScalarMult(v2, N) > 0 && t < tmin)
                            tmin = t;
                    }
                    else continue;
                }
                result.Add(new DPoint(A.X + t * (B.X - A.X), A.Y + t * (B.Y - A.Y)));
            }
            if (tmax > tmin)
            {
                //Лежит вне
                result.Add(new DPoint(-100, -100));
                result.Add(new DPoint(-100, -100));
            }
            else
            {
                if (tmax > 0 && tmin < 1)
                {
                    result.Add(A);
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmax, A.Y + (B.Y - A.Y) * tmax));
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmin, A.Y + (B.Y - A.Y) * tmin));
                    result.Add(B);

                    //Пересекает
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmax, A.Y + (B.Y - A.Y) * tmax));
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmin, A.Y + (B.Y - A.Y) * tmin));
                }
                else if (tmax <= 0 && tmin < 1)
                {
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmin, A.Y + (B.Y - A.Y) * tmin));
                    result.Add(B);

                    //Внутри
                    result.Add(A);
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmin, A.Y + (B.Y - A.Y) * tmin));
                }
                else if (tmin >= 1 && tmax > 0)
                {
                    result.Add(A);
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmax, A.Y + (B.Y - A.Y) * tmax));

                    //Изнутри
                    result.Add(new DPoint(A.X + (B.X - A.X) * tmax, A.Y + (B.Y - A.Y) * tmax));
                    result.Add(B);
                }
                else
                {
                    //Полностью внутри
                    result.Add(A);
                    result.Add(B);
                }
            }
            return result;
        }
    }
}