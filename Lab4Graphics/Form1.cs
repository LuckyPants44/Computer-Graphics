using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab4Graphics
{
    public partial class Form1 : Form
    {
        int scale = 40;
        Bitmap bmp;
        Point[] line = new Point[2];
        Point[] screen = new Point[2];

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
            DrawGrid();
        }

        private void DrawGrid()
        {
            Graphics gr = Graphics.FromImage(bmp);
            Pen axesPen = new Pen(Brushes.Blue, 2);
            //Axes
            gr.DrawLine(axesPen, new Point(0, pictureBox.Height / 2), new Point(pictureBox.Width, pictureBox.Height / 2));
            gr.DrawLine(axesPen, new Point(pictureBox.Width / 2, 0), new Point(pictureBox.Width / 2, pictureBox.Height));
            //Grid
            for (int i = scale; i < pictureBox.Width / 2; i += scale)
            {
                gr.DrawLine(Pens.Black, new Point(pictureBox.Width / 2 + i, 0), new Point(pictureBox.Width / 2 + i, pictureBox.Height));
                gr.DrawLine(Pens.Black, new Point(pictureBox.Width / 2 - i, 0), new Point(pictureBox.Width / 2 - i, pictureBox.Height));
            }
            for (int i = scale; i < pictureBox.Height / 2; i += scale)
            {
                gr.DrawLine(Pens.Black, new Point(0, pictureBox.Height / 2 + i), new Point(pictureBox.Width, pictureBox.Height / 2 + i));
                gr.DrawLine(Pens.Black, new Point(0, pictureBox.Height / 2 - i), new Point(pictureBox.Width, pictureBox.Height / 2 - i));
            }
            pictureBox.Image = bmp;
        }

        private void textBoxKSX1_Enter(object sender, EventArgs e)
        {
            textBoxKSX1.Text = null;
            textBoxKSX1.ForeColor = Color.Black;
        }
        private void textBoxKSX2_Enter(object sender, EventArgs e)
        {
            textBoxKSX2.Text = null;
            textBoxKSX2.ForeColor = Color.Black;
        }
        private void textBoxKSY1_Enter(object sender, EventArgs e)
        {
            textBoxKSY1.Text = null;
            textBoxKSY1.ForeColor = Color.Black;
        }
        private void textBoxKSY2_Enter(object sender, EventArgs e)
        {
            textBoxKSY2.Text = null;
            textBoxKSY2.ForeColor = Color.Black;
        }

        private void textBoxKSX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[0].X = Convert.ToInt32(textBoxKSX1.Text);
            }
            catch { }
        }
        private void textBoxKSX2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[1].X = Convert.ToInt32(textBoxKSX2.Text);
            }
            catch { }
        }
        private void textBoxKSY1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[0].Y = Convert.ToInt32(textBoxKSY1.Text);
            }
            catch { }
        }
        private void textBoxKSY2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[1].Y = Convert.ToInt32(textBoxKSY2.Text);
            }
            catch { }
        }

        private void CohenSutherland_Click(object sender, EventArgs e)
        {
            Graphics gr = Graphics.FromImage(bmp);
            double[] vector = new double[2];
            bool[] location = new bool[4];
            double[] currentPoint = new double[2];
            //Screen
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(0, pictureBox.Height / 2 - screen[0].Y * scale), new Point(pictureBox.Width, pictureBox.Height / 2 - screen[0].Y * scale));
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(0, pictureBox.Height / 2 - screen[1].Y * scale), new Point(pictureBox.Width, pictureBox.Height / 2 - screen[1].Y * scale));
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(pictureBox.Width / 2 + screen[0].X * scale, 0), new Point(pictureBox.Width / 2 + screen[0].X * scale, pictureBox.Height));
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(pictureBox.Width / 2 + screen[1].X * scale, 0), new Point(pictureBox.Width / 2 + screen[1].X * scale, pictureBox.Height));
            //Algorithm
            DPoint[] r = CohenSutherland_Algorithm(new DPoint(line[0]), new DPoint(line[1]));
            gr.DrawLine(new Pen(Brushes.Green, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[1].Y * scale)));
            gr.DrawLine(new Pen(Brushes.Yellow, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + r[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - r[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + r[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - r[1].Y * scale)));
            pictureBox.Image = bmp;
        }

        DPoint[] CohenSutherland_Algorithm(DPoint A, DPoint B)
        {
            DPoint[] result = new DPoint[2] { A, B };
            string[] code = new string[2];
            bool[,] location = new bool[2, 4];
            double[] vector = new double[2] { B.X - A.X, B.Y - A.Y };
            double error = 0.1;

            if ((A.X <= screen[0].X) || (B.X <= screen[0].X))
            {
                if (A.X <= screen[0].X)
                    location[0, 3] = true;
                if (B.X <= screen[0].X)
                    location[1, 3] = true;
            }
            if ((A.X >= screen[1].X) || (B.X >= screen[1].X))
            {
                if (A.X >= screen[1].X)
                    location[0, 2] = true;
                if (B.X >= screen[1].X)
                    location[1, 2] = true;
            }
            if ((A.Y <= screen[0].Y) || (B.Y <= screen[0].Y))
            {
                if (A.Y <= screen[0].Y)
                    location[0, 1] = true;
                if (B.Y <= screen[0].Y)
                    location[1, 1] = true;
            }
            if ((A.Y >= screen[1].Y) || (B.Y >= screen[1].Y))
            {
                if (A.Y >= screen[1].Y)
                    location[0, 0] = true;
                if (B.Y >= screen[1].Y)
                    location[1, 0] = true;
            }

            for (int t = 0; t < 4; t++)
            {
                if ((location[0, t]) && (location[1, t]))    //Если выполнится, то на одной стороне(^)\
                {
                    result[0] = A;
                    result[1] = A;
                    return result;                           //2
                }
                else
                {
                    if (location[0, t])
                        code[0] += 1;
                    else code[0] += 0;

                    if (location[1, t])
                        code[1] += 1;
                    else code[1] += 0;
                }
            }
            if ((code[0] == code[1]) && (code[0] == "0000"))
                return result;                               //1
            else
            {
                if (code[0] != "0000")
                {
                    A.X = A.X + vector[0] * error;
                    A.Y = A.Y + vector[1] * error;
                }
                if (code[1] != "0000")
                {
                    B.X = B.X - vector[0] * error;
                    B.Y = B.Y - vector[1] * error;
                }
                return CohenSutherland_Algorithm(A, B);           //3
            }
        }

        private void CyrusBeck_Click(object sender, EventArgs e)
        {
            string[] buf;
            Graphics gr = Graphics.FromImage(bmp);
            List<Point> points = new List<Point>();
            //Reading dots
            try
            {
                FileStream file = new FileStream("C:\\Users\\1\\Documents\\Visual Studio 2015\\Projects\\Lab4Graphics\\Lab4Graphics\\Points.txt", FileMode.Open);
                StreamReader sr = new StreamReader(file);
                buf = sr.ReadToEnd().Split(' ', '\n', '\r');
                sr.Close();
                for (int i = 0; i < buf.Length - 1; i += 3)
                {
                    points.Add(new Point(Convert.ToInt32(buf[i]), Convert.ToInt32(buf[i + 1])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия файла!" + ex.Message);
            }
            //Drawing points
            for (int i = 0; i < points.Count; i++)
            {
                if (i != points.Count - 1)
                {
                    gr.DrawLine(new Pen(Brushes.Red, 2), new Point(pictureBox.Width / 2 + points[i].X * scale, pictureBox.Height / 2 - points[i].Y * scale), new Point(pictureBox.Width / 2 + points[i + 1].X * scale, pictureBox.Height / 2 - points[i + 1].Y * scale));
                }
                else
                {
                    gr.DrawLine(new Pen(Brushes.Red, 2), new Point(pictureBox.Width / 2 + points[0].X * scale, pictureBox.Height / 2 - points[0].Y * scale), new Point(pictureBox.Width / 2 + points[i].X * scale, pictureBox.Height / 2 - points[i].Y * scale));
                }
                pictureBox.Image = bmp;
            }
            //Algorithm
            DPoint[] result = new DPoint[2];
            result = CyrusBeck_Algorithm(new DPoint(line[0]), new DPoint(line[1]), points);
            gr.DrawLine(new Pen(Brushes.Green, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[1].Y * scale)));
            gr.DrawLine(new Pen(Brushes.Yellow, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + result[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - result[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + result[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - result[1].Y * scale)));
            pictureBox.Image = bmp;
        }

        DPoint[] CyrusBeck_Algorithm(DPoint A, DPoint B, List<Point> points)
        {
            DPoint[] result = new DPoint[2] { new DPoint(), new DPoint() };
            double[] normal = new double[2];
            double[] edgeV = new double[2];
            double[] line = new double[2] { B.X - A.X, B.Y - A.Y };
            DPoint potential = new DPoint();
            double step = 0.1;
            List<double> t = new List<double>();
            List<DPoint> r = new List<DPoint>();
            double pt;

            for (int i = 0; i < points.Count; i++)
            {
                if (i != points.Count - 1)
                {
                    normal[0] = points[i + 1].Y - points[i].Y;
                    normal[1] = points[i].X - points[i + 1].X;
                    edgeV[0] = points[i + 1].X - points[i].X;
                    edgeV[1] = points[i + 1].Y - points[i].Y;
                }
                else
                {
                    normal[0] = points[0].Y - points[i].Y;
                    normal[1] = points[i].X - points[0].X;
                    edgeV[0] = points[0].X - points[i].X;
                    edgeV[1] = points[0].Y - points[i].Y;
                }
                for (int j = 1; j < 1 / step; j++)
                {
                    //Перебираем точки лежащие на ребре
                    potential.X = points[i].X + edgeV[0] * step * j;
                    potential.Y = points[i].Y + edgeV[1] * step * j;

                    //(E-P0,N)=0
                    if (((points[i].X - potential.X) * normal[0] + (points[i].Y - potential.Y) * normal[1]) == 0)
                    {
                        pt = -(((A.X - potential.X) * normal[0] + (A.Y - potential.Y) * normal[1]) / ((B.X - A.X) * normal[0] + (B.Y - A.Y) * normal[1]));
                        if ((pt < 1) && (pt > 0))
                        {
                            r.Add(new DPoint(A.X + (B.X - A.X) * pt, A.Y + (B.Y - A.Y) * pt));
                            t.Add(pt);
                        }
                    }
                }
            }
            pt = 0;
            //ВЫБОР НУЖНЫХ ТОЧЕК tmin = вход
            for (int j = 0; j < t.Count; j++)
            {
                if (t.Min() == t[j])
                    result[0] = r[j];
                if (t.Max() == t[j])
                    result[1] = r[j];
            }
            return result;
        }

        private void textBoxLineX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[0].X = Convert.ToInt32(textBoxLineX1.Text);
            }
            catch { }
        }
        private void textBoxLineY1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[0].Y = Convert.ToInt32(textBoxLineY1.Text);
            }
            catch { }
        }
        private void textBoxLineX2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[1].X = Convert.ToInt32(textBoxLineX2.Text);
            }
            catch { }
        }
        private void textBoxLineY2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[1].Y = Convert.ToInt32(textBoxLineY2.Text);
            }
            catch { }
        }
    }
}
