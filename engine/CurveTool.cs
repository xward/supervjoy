using NsSupervJoy.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NsSupervJoy.Engine.SuperVJoy;

namespace NsSupervJoy.engine
{
    public static class CurveTool
    {

        public static void SetValue(OutAxis outputAxis, double percX1, double percX2, double value)
        {
            for(int v  = ValOfPerc(percX1); v < ValOfPerc(percX2); v++)
            {
                SuperVJoy.outputCurves[outputAxis.ToString()][v] = ValOfPerc(value);
            }
        }

        public static void SetLinear(OutAxis outputAxis, double percX1, double percY1, double percX2, double percY2)
        {
            double coef = (percY2 - percY1) / (percX2 - percX1);
            for (int v = ValOfPerc(percX1); v < ValOfPerc(percX2); v++)
            {
                SuperVJoy.outputCurves[outputAxis.ToString()][v] = (int) (ValOfPerc(percY1) + coef * (v- ValOfPerc(percX1)));
            }
        }

        public static void SetLinears(OutAxis outputAxis, double[] percsX, double[] percsY)
        {
            for(int i = 0; i<percsX.Length - 1;++i)
            {
                SetLinear(outputAxis, percsX[i], percsY[i], percsX[i+1], percsY[i+1]);
            }
        }

        public static void Invert(OutAxis outputAxis)
        {
            for (int v = 0; v < SuperVJoy.MAX_RANGE; v++)
            {
                SuperVJoy.outputCurves[outputAxis.ToString()][v] = SuperVJoy.MAX_RANGE - SuperVJoy.outputCurves[outputAxis.ToString()][v];
            }
        }

        public static void SetSymetrical(OutAxis outputAxis)
        {
            for (int v = 0; v < SuperVJoy.MID_RANGE - 1; v++)
            {
                SuperVJoy.outputCurves[outputAxis.ToString()][v] = SuperVJoy.MAX_RANGE - 1 - SuperVJoy.outputCurves[outputAxis.ToString()][SuperVJoy.MAX_RANGE - 1 - v];
            }
        }

        /// wip
        private static void SetBezier(OutAxis outputAxis, double percX1, double percY1, double percX2, double percY2, double coefStart, double mouStart, double coefEnd, double mouEnd)
        {
            double t = 0.0, x0, y0, x1, y1, dt = 0.00001;
            // x1 = bezierX(t, percX1, percX2, )
        }

        // Parametric functions for drawing a degree 3 Bezier curve.
        private static double bezierX(double t, double x0, double x1, double x2, double x3)
        {
            return x0 * Math.Pow((1 - t), 3) +
                   x1 * 3 * t * Math.Pow(1 - t, 2) +
                   x2 * 3 * t * t * (1 - t) +
                   x3 * t * t * t;
        }
        private static double bezierY(double t, double y0, double y1, double y2, double y3)
        {
            return y0 * Math.Pow((1 - t), 3) +
                   y1 * 3 * t * Math.Pow(1 - t, 2) +
                   y2 * 3 * t * t * (1 - t) +
                   y3 * t * t * t;
        }

        //Private Sub setBezier(pStart As PointF, pEnd As PointF, coefStart As Double, coefEnd As Double, mouStart As Integer, mouEnd As Integer, ByRef axis As JoyAxis)
        //    Dim pt0 As New PointF(percToRaw(pStart.X, axis), percToRaw(pStart.Y, axis))
        //    Dim pt3 As New PointF(percToRaw(pEnd.X, axis), percToRaw(pEnd.Y, axis))
        //    Dim pt1 As New PointF(percToRaw(pStart.X + mouStart, axis), percToRaw(pStart.Y + coefStart* mouStart, axis))
        //    Dim pt2 As New PointF(percToRaw(pEnd.X - mouEnd, axis), percToRaw(pEnd.Y - coefEnd* mouEnd, axis))

        //    Dim t, x0, y0, x1, y1, dt As Single
        //    dt = 0.00001
        //    t = 0.0
        //    x1 = BezierX(t, pt0.X, pt1.X, pt2.X, pt3.X)
        //    y1 = BezierY(t, pt0.Y, pt1.Y, pt2.Y, pt3.Y)
        //    Do While t< 1.0
        //        x0 = x1
        //        y0 = y1
        //        x1 = BezierX(t, pt0.X, pt1.X, pt2.X, pt3.X)
        //        y1 = BezierY(t, pt0.Y, pt1.Y, pt2.Y, pt3.Y)
        //        t += dt
        //        axis.responseCurve(x0) = y0
        //        axis.responseCurve(x1) = y1
        //    Loop
        //End Sub




        public static int ValOfPerc(double perc)
        {
            return (int) Math.Floor(perc / 100.0 * SuperVJoy.MAX_RANGE);
        }



        private static int curveScale = 256;
        public static Bitmap generateBitmapCurveAllAxis()
        {

            int pad = SuperVJoy.MAX_RANGE / curveScale;
            int axisCount = SuperVJoy.maxOutputAxisCountIWantToUse;

            int wid = 3;
            int hei = (int) Math.Ceiling (1.0 * axisCount / wid);

            Bitmap img = new Bitmap((pad + 2) * wid, (pad + 2) * hei);
            Graphics g = Graphics.FromImage(img);

            // paint it black
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, img.Width, img.Height));

            for (int w = 0; w < wid ; ++w)
            {
                g.DrawLine(new Pen(Color.Gray, 1), new Point(w * pad + pad/2, 0), new Point(w * pad + pad/2, img.Height - 1));
            }
            for (int h = 0; h < hei ; ++h)
            {
                g.DrawLine(new Pen(Color.Gray, 1), new Point(0, h * pad + 1 + pad/2), new Point(img.Width - 1, h * pad + 1 + pad/2));
            }


            int axisIndex = 0;
            foreach (OutAxis axe in (OutAxis[])Enum.GetValues(typeof(OutAxis)))
            {
                int y = (int)(1.0 * axisIndex / 3);
                int x = (int)(1.0 * axisIndex - y * 3);

                g.DrawString(axe.ToString(), new Font(FontFamily.GenericMonospace, 60), new SolidBrush(Color.Gray), new Point(x * pad, y*pad));
                for (int i = 0; i < SuperVJoy.MAX_RANGE / curveScale; ++i)
                {
                    int value = (int)(SuperVJoy.outputCurves[axe.ToString()][i * curveScale]);
                    g.DrawRectangle(new Pen(Color.DeepSkyBlue), new Rectangle(x * pad + i - 1, y * pad + pad - value / curveScale - 1, 3, 3));
                }
                axisIndex++;
                if (axisIndex == SuperVJoy.maxOutputAxisCountIWantToUse) break;
            }

            for(int w = 1; w< wid;++w)
            {
                g.DrawLine(new Pen(Color.White, 3), new Point(w * pad + 1, 0), new Point(w * pad + 1, img.Height - 1));
            }
            for (int h = 1; h < hei; ++h)
            {
                g.DrawLine(new Pen(Color.White, 3), new Point(0, h * pad + 1), new Point(img.Width -1, h * pad + 1));
            }

            return img;
        }

        // unused
        public static Bitmap generateBitmapCurve(OutAxis axis)
        {
            Bitmap img = new Bitmap(SuperVJoy.MAX_RANGE / curveScale, SuperVJoy.MAX_RANGE / curveScale);
            Graphics g = Graphics.FromImage(img);

            // paint it black
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, img.Width , img.Height ));
            for(int i=0; i < SuperVJoy.MAX_RANGE / curveScale; ++i)
            {
                int value = (int) (SuperVJoy.outputCurves[axis.ToString()][i * curveScale]);
     
                g.DrawRectangle(new Pen(Color.Red), new Rectangle(i, img.Height - value / curveScale, 3, 3));
            }
            return img;
        }
    }
}
