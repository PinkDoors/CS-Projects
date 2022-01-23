using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Fractal
{
    class TheKochCurveClass : Fractal
    {
        /// <summary>
        /// Данный метод рисует следующие итерации кривой Коха.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <param name="step">Номер итерации.</param>
        static void DrawTheFollowingSteps(Graphics gObject, PointF point1, PointF point2, PointF point3, int step)
        {
            // Проверяем количество итераций.
            if (step <= NumberOfSteps)
            {
                // Честно говоря, без понятия как тут точки ищутся.
                var point4 = new PointF((point2.X + 2 * point1.X) / 3, (point2.Y + 2 * point1.Y) / 3);
                var point5 = new PointF((2 * point2.X + point1.X) / 3, (point1.Y + 2 * point2.Y) / 3);
                var ps = new PointF((point2.X + point1.X) / 2, (point2.Y + point1.Y) / 2);
                var pn = new PointF((4 * ps.X - point3.X) / 3, (4 * ps.Y - point3.Y) / 3);
                // Берем цвет для текущей итерации из градиента.
                Pen linGrPen = new Pen(ColorSet[step], 4);
                gObject.DrawLine(linGrPen, point4, pn);
                gObject.DrawLine(linGrPen, point5, pn);
                // Закрашиваем нижнюю сторону треугольника цветом фона.
                gObject.DrawLine(new Pen(Color.WhiteSmoke, 4), point4, point5);
                step += 1;
                // Рисуем следующие итерации.
                DrawTheFollowingSteps(gObject, point4, pn, point5, step);
                DrawTheFollowingSteps(gObject, pn, point5, point4, step);
                DrawTheFollowingSteps(gObject, point1, point4, new PointF((2 * point1.X + point3.X) / 3, (2 * point1.Y + point3.Y) / 3), step);
                DrawTheFollowingSteps(gObject, point5, point2, new PointF((2 * point2.X + point3.X) / 3, (2 * point2.Y + point3.Y) / 3), step);
            }
        }
        /// <summary>
        /// Данный метод рисует первую итерацию кривой Коха.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="width">Ширина панели.</param>
        /// <param name="height">Высота панели.</param>
        /// <param name="length">Длинна изначальной линии.</param>
        public static void Draw(Graphics gObject, int width, int height, int length)
        {
            var point1 = new PointF(width / 2 - length / 2, height / 2);
            var point2 = new PointF(width / 2 + length / 2, height / 2);
            var point3 = new PointF(width / 2, (int)(height / 2 + length * Math.Sqrt(3) / 3));
            Pen linGrPen = new Pen(ColorSet[0], 4);
            // Рисуем изначальную линию.
            gObject.DrawLine(linGrPen, point1, point2);
            // Проверяем количество итераций.
            if (NumberOfSteps > 1)
                DrawTheFollowingSteps(gObject, point1, point2, point3, 2);
        }

    }
}
