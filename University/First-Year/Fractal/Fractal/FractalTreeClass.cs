using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Fractal
{
    class FractalTreeClass : Fractal
    {

        /// <summary>
        /// Данный метод рисует фрактальное дерево.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="step">Номер итерации.</param>
        /// <param name="x1">Начальная точка отрезка по x.</param>
        /// <param name="y1">Начальная точка отрезка по y.</param>
        /// <param name="Length">Длинна отрезка</param>
        /// <param name="angle">Угол наклона.</param>
        /// <param name="width">Ширина отрезка.</param>
        public static void Draw(Graphics gObject, int step, double x1, double y1, double Length, int angle, float width)
        {
            double x2, y2;
            // Находим конечные точки отрезка по следующим формулам.
            x2 = x1 - Length * Math.Sin(angle * Math.PI / 180);
            y2 = y1 - Length * Math.Cos(angle * Math.PI / 180);
            // Берем цвет для текущей итерации из градиента.
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point((int)x1, (int)y1),
                new Point((int)x2, (int)y2),
                ColorSet[step],
                ColorSet[step]);
            Pen linGrPen = new Pen(linGrBrush, width);
            gObject.DrawLine(linGrPen, (int)x1, (int)y1, (int)x2, (int)y2);
            // Проверяем количество итераций.
            if (step < NumberOfSteps)
            {
                // Рисуем два новых отрезка, выходящих из конца предыдущего.
                Draw(gObject, step + 1, x2, y2, Length * Coefficient, angle + FirstAngle, width / 2);
                Draw(gObject, step + 1, x2, y2, Length * Coefficient, angle - SecondAngle, width / 2);
            }
        }

    }
}
