using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal
{
    class TheCantorSetClass : Fractal
    {
        /// <summary>
        /// Данный метод рисует последующие итерации множества Кантора.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="cantorLength">Расстояние между итерациями множества Кантора.</param>
        /// <param name="length">Длинна начальной линии множества Кантора.</param>
        /// <param name="step">Количество итераций.</param>
        /// <param name="defaultX">Начальная точка отрезка по x.</param>
        /// <param name="defaultY">Начальная точка отрезка по y.</param>
        public static void DrawTheFollowingSteps(Graphics gObject, int cantorLength, int length, int step, int defaultX, int defaultY)
        {
            // Проверяем количество итераций.
            if (step <= NumberOfSteps)
            {
                // Берем цвет для текущей итерации из градиента.
                SolidBrush myBrush = new SolidBrush(ColorSet[step - 1]);
                Pen linGrPen = new Pen(myBrush, 4);
                // Находим начальную и конечную точки отрезка по следующим формулам.
                var point1 = new PointF(defaultX, defaultY);
                var point2 = new PointF(defaultX + length, defaultY);
                gObject.DrawLine(linGrPen, point1, point2);
                // Рисуем следующие два отрезка.
                DrawTheFollowingSteps(gObject, cantorLength, length / 3, step + 1, defaultX, defaultY + cantorLength);
                DrawTheFollowingSteps(gObject, cantorLength, length / 3, step + 1, defaultX + length * 2 / 3, defaultY + cantorLength);
            }
        }

        /// <summary>
        /// Данный метод рисует первую ступень множества Кантора.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="cantorLength">Расстояние между итерациями множества Кантора.</param>
        /// <param name="length">Длинна начальной линии множества Кантора.</param>
        /// <param name="step">Количество итераций.</param>
        /// <param name="defaultX">Начальная точка отрезка по x.</param>
        /// <param name="defaultY">Начальная точка отрезка по y.</param>
        public static void Draw(Graphics gObject, int cantorLength, int length, int step, int defaultX, int defaultY)
        {
            // Берем цвет для текущей итерации из градиента.
            SolidBrush myBrush = new SolidBrush(ColorSet[step - 1]);
            Pen linGrPen = new Pen(myBrush, 4);
            // Находим начальную и конечную точки отрезка по следующим формулам.
            var point1 = new PointF(defaultX, defaultY);
            var point2 = new PointF(defaultX + length, defaultY);
            gObject.DrawLine(linGrPen, point1, point2);
            // Проверяем количество итераций.
            if (NumberOfSteps > 1)
            {
                // Рисуем следующие два отрезка.
                DrawTheFollowingSteps(gObject, cantorLength, length / 3, 2, defaultX, defaultY + cantorLength);
                DrawTheFollowingSteps(gObject, cantorLength, length / 3, 2, defaultX + length * 2 / 3, defaultY + cantorLength);
            }
        }
    }
}
