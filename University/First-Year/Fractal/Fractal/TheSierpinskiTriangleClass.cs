using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal
{
    class TheSierpinskiTriangleClass : Fractal
    {
        /// <summary>
        /// Данный метод рисует последующие итерации треугольника Серпинского.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="length">Длинна стороны.</param>
        /// <param name="step">Номер итерации.</param>
        /// <param name="defaultX">Начальная точка по x.</param>
        /// <param name="defaultY">Начальная точка по y.</param>
        public static void DrawTheFollowingSteps(Graphics gObject, int length, int step, int defaultX, int defaultY)
        {
            if (step <= NumberOfSteps)
            {
                // Берем цвет для текущей итерации из градиента.
                SolidBrush myBrush = new SolidBrush(ColorSet[step]);
                Pen linGrPen = new Pen(myBrush, 4);
                // Находим точки отрезка по следующим формулам.
                var point1 = new PointF(defaultX, defaultY);
                var point2 = new PointF(defaultX + length, defaultY);
                var point3 = new PointF(defaultX + length / 2, (float)(defaultY + length * Math.Sqrt(3) / 2));
                // Рисуем треугольник.
                gObject.DrawPolygon(linGrPen, new PointF[] { point1, point2, point3 });
                // Рисуем еще 3 треугольника внутри предыдущего.
                DrawTheFollowingSteps(gObject, length / 2, step + 1, defaultX + length / 4, (int)(defaultY - length * Math.Sqrt(3) / 4));
                DrawTheFollowingSteps(gObject, length / 2, step + 1, defaultX - length / 4, (int)(defaultY + length * Math.Sqrt(3) / 4));
                DrawTheFollowingSteps(gObject, length / 2, step + 1, defaultX + length * 3 / 4, (int)(defaultY + length * Math.Sqrt(3) / 4));
            }
        }

        /// <summary>
        /// Данный метод рисует первую итерацию треугольника Серпинского.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="length">Длинна стороны треугольника.</param>
        /// <param name="step">Номер итерации.</param>
        /// <param name="defaultX">Начальная точка по x.</param>
        /// <param name="defaultY">Начальная точка по y.</param>
        public static void Draw(Graphics gObject, int length, int step, int defaultX, int defaultY)
        {
            // Берем цвет для текущей итерации из градиента.
            SolidBrush myBrush = new SolidBrush(ColorSet[step]);
            Pen linGrPen = new Pen(myBrush, 4);
            // Находим точки отрезка по следующим формулам.
            var point1 = new PointF(defaultX, defaultY);
            var point2 = new PointF(defaultX + length, defaultY);
            var point3 = new PointF(defaultX + length / 2, (float)(defaultY - length * Math.Sqrt(3) / 2));
            // Рисуем треугольник
            gObject.DrawPolygon(linGrPen, new PointF[] { point1, point2, point3 });
            // Проверяем количество итераций.
            DrawTheFollowingSteps(gObject, length / 2, 1, defaultX + length / 4, (int)(defaultY - length * Math.Sqrt(3) / 4));
        }
    }
}


