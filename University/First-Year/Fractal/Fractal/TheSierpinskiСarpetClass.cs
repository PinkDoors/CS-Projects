using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal
{
    class TheSierpinskiСarpetClass : Fractal
    {
        /// <summary>
        /// Данный метод рисует ковер Серпинского.
        /// </summary>
        /// <param name="gObject"></param>
        /// <param name="length">Длинна стороны.</param>
        /// <param name="step">Номер итерации.</param>
        /// <param name="defaultX">Начальная точка по x.</param>
        /// <param name="defaultY">Начальная точка по y.</param>
        public static void Draw(Graphics gObject, int length, int step, int defaultX, int defaultY)
        {
            if (step <= NumberOfSteps)
            {
                // Берем цвет для текущей итерации из градиента.
                SolidBrush myBrush = new SolidBrush(ColorSet[step - 1]);
                // Берем цвет фона для последующего выделения младшего квадрата внутри старшего.
                SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);
                // Рисуем старший квадрат.
                gObject.FillRectangle(myBrush, new Rectangle(defaultX, defaultY, length, length));
                // Внутри старшего рисуем младший.
                gObject.FillRectangle(whiteBrush, new Rectangle(defaultX + length / 3, defaultY + length / 3, length / 3, length / 3));
                // Повторяем данное действие для 8 точек внутри старшего квадрата.
                Draw(gObject, length / 3, step + 1, defaultX, defaultY);
                Draw(gObject, length / 3, step + 1, defaultX + length / 3, defaultY);
                Draw(gObject, length / 3, step + 1, defaultX + length * 2 / 3, defaultY);
                Draw(gObject, length / 3, step + 1, defaultX, defaultY + length / 3);
                Draw(gObject, length / 3, step + 1, defaultX + length * 2 / 3, defaultY + length / 3);
                Draw(gObject, length / 3, step + 1, defaultX, defaultY + length * 2 / 3);
                Draw(gObject, length / 3, step + 1, defaultX + length / 3, defaultY + length * 2 / 3);
                Draw(gObject, length / 3, step + 1, defaultX + length * 2 / 3, defaultY + length * 2 / 3);
            }
        }
    }
}
