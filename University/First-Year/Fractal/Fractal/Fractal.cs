using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Fractal : Form
    {
        private int currentDrawing = 5;
        public static int FirstAngle { get; set; } = 20;
        public static int SecondAngle { get; set; } = 20;
        public static Color StartColor { get; set; } = Color.Black;
        public static Color EndColor { get; set; } = Color.Black;
        public static int NumberOfSteps { get; set; } = 1;
        public static double Coefficient { get; set; } = 0.7;
        public static int Length { get; set; } = 200;
        public static int CantorLength { get; set; } = 10;

        private bool IsThePictureDrawn = false;
        public int Zoom { get; set; } = 1;
        public static List<Color> ColorSet { get; set; }
        public Graphics gObject { get; set; }

        public Fractal()
        {
            InitializeComponent();
            // Устанавливаем стандартный цвет - черный.
            GetColorGradient();
            colorDialog1.FullOpen = true;
        }

        /// <summary>
        /// Данный метод рисует выбранный фрактал на pictureBox-е.
        /// </summary>
        private void PaintCurrentDrawing()
        {
            // Создаем битмэп с учетом увеличения.
            Bitmap picture = new Bitmap(panel4.Size.Width * Zoom, panel4.Size.Height * Zoom);
            gObject = Graphics.FromImage(picture);
            // Очищаем  pictureBox от раннее нарисованных фракталов.
            gObject.Clear(Color.WhiteSmoke);
            // Рисуем выбранный фрактал.
            try
            {
                switch (currentDrawing)
                {
                    case 0:
                        {
                            DrawFractalTree(picture);
                            break;
                        }
                    case 1:
                        {
                            DrawTheKochCurve(picture);
                            break;
                        }
                    case 2:
                        {
                            DrawTheSierpinskiСarpet(picture);
                            break;
                        }
                    case 3:
                        {
                            DrawTheSierpinskiTriangle(picture);
                            break;
                        }
                    case 4:
                        {
                            DrawTheCantorSet(picture);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (System.OutOfMemoryException)
            {
                MessageBox.Show("Out of Memory");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Данный метод рисует множество Кантора на pictureBox-е.
        /// </summary>
        /// <param name="picture">Битмэп, на котором рисуется дерево.</param>
        private void DrawTheCantorSet(Bitmap picture)
        {
            // Ограничиваем количество рекурсий, чтобы не закончилась память.
            if (RecursionDepth.Value >= 5)
                RecursionDepth.Value = 4;
            // Устанавливаем начальные точки для рисования.
            int defaultX = (panel4.Size.Width * Zoom - Length * Zoom) / 2;
            int defaultY = panel4.Size.Height * Zoom / 3;
            TheCantorSetClass.Draw(gObject, CantorLength * Zoom, Length * Zoom, 1, defaultX, defaultY);
            // Присваиваем pictureBox нарисованное на Bitmap изображение.
            pictureBox.Size = picture.Size;
            pictureBox.Image = picture;
        }

        /// <summary>
        /// Данный метод рисует треугольник Серпинского на pictureBox-е.
        /// </summary>
        /// <param name="picture"></param>
        private void DrawTheSierpinskiTriangle(Bitmap picture)
        {
            // Ограничиваем количество рекурсий, чтобы не закончилась память.
            if (RecursionDepth.Value >= 5)
                RecursionDepth.Value = 4;
            // Устанавливаем начальные точки для рисования.
            int defaultX = (panel4.Size.Width * Zoom - Length * Zoom) / 2;
            int defaultY = panel4.Size.Height * Zoom * 2 / 3;
            TheSierpinskiTriangleClass.Draw(gObject, Length * Zoom, 0, defaultX, defaultY);
            // Присваиваем pictureBox нарисованное на Bitmap изображение.
            pictureBox.Size = picture.Size;
            pictureBox.Image = picture;
        }

        /// <summary>
        /// Данный метод рисует ковер Серпинского на pictureBox-е.
        /// </summary>
        /// <param name="picture"></param>
        private void DrawTheSierpinskiСarpet(Bitmap picture)
        {
            // Ограничиваем количество рекурсий, чтобы не закончилась память.
            if (RecursionDepth.Value >= 5)
                RecursionDepth.Value = 4;
            // Устанавливаем начальные точки для рисования.
            int defaultX = (panel4.Size.Width * Zoom - Length * Zoom) / 2;
            int defaultY = (panel4.Size.Height * Zoom - Length * Zoom) / 2;
            TheSierpinskiСarpetClass.Draw(gObject, Length * Zoom, 1, defaultX, defaultY);
            // Присваиваем pictureBox нарисованное на Bitmap изображение.
            pictureBox.Size = picture.Size;
            pictureBox.Image = picture;
        }

        /// <summary>
        /// Данный метод рисует кривую Коха на pictureBox-е.
        /// </summary>
        /// <param name="picture"></param>
        private void DrawTheKochCurve(Bitmap picture)
        {
            // Ограничиваем количество рекурсий, чтобы не закончилась память.
            if (RecursionDepth.Value >= 5)
                RecursionDepth.Value = 4;
            TheKochCurveClass.Draw(gObject, panel4.Size.Width * Zoom, panel4.Size.Height * Zoom, Length * Zoom);
            // Присваиваем pictureBox нарисованное на Bitmap изображение.
            pictureBox.Size = picture.Size;
            pictureBox.Image = picture;
        }

        /// <summary>
        /// Данный метод рисует фрактальное дерево на pictureBox-е.
        /// </summary>
        /// <param name="picture"></param>
        private void DrawFractalTree(Bitmap picture)
        {
            FractalTreeClass.Draw(gObject, 0, panel4.Size.Width * Zoom / 2, panel4.Size.Height * Zoom - 30, Length * Zoom, 0, 6);
            // Присваиваем pictureBox нарисованное на Bitmap изображение.
            pictureBox.Size = picture.Size;
            pictureBox.Image = picture;
        }

        /// <summary>
        /// Рисует выбранный фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IsThePictureDrawn = true;
            PaintCurrentDrawing();
        }

        /// <summary>
        /// Делает фрактальное дерево текущим фракталом и выделяет его кнопку синим цветом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalTree_Click(object sender, EventArgs e)
        {
            currentDrawing = 0;
            PaintButton();
        }

        /// <summary>
        /// Делает кривую Коха текущим фракталом и выделяет его кнопку синим цветом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TheKochCurve_Click(object sender, EventArgs e)
        {
            currentDrawing = 1;
            PaintButton();
        }

        /// <summary>
        /// Делает ковер Серпинского текущим фракталом и выделяет его кнопку синим цветом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TheSierpinskiCarpet_Click(object sender, EventArgs e)
        {
            currentDrawing = 2;
            PaintButton();
        }

        /// <summary>
        /// Делает треугольник Серпинского текущим фракталом и выделяет его кнопку синим цветом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TheSierpinskiTriangle_Click(object sender, EventArgs e)
        {
            currentDrawing = 3;
            PaintButton();
        }

        /// <summary>
        /// Делает множество Кантора текущим фракталом и выделяет его кнопку синим цветом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TheCantorSet_Click(object sender, EventArgs e)
        {
            currentDrawing = 4;
            PaintButton();
        }

        /// <summary>
        /// Данный метод делает начальным цветом градиента тот, который был выбран пользователем.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartColor_Click(object sender, EventArgs e)
        {
            // При закрытии окна с выбором цвета, завершаем выполнение метода.
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // Выбираем начальный цвет.
            StartColor = colorDialog1.Color;
            // Красим кнопку в выбранный цвет.
            startColor.BackColor = colorDialog1.Color;
        }

        /// <summary>
        /// Данный метод делает конечным цветом градиента тот, который был выбран пользователем.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndColor_Click(object sender, EventArgs e)
        {
            // При закрытии окна с выбором цвета, завершаем выполнение метода.
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // Выбираем конечный цвет.
            EndColor = colorDialog1.Color;
            // Красим кнопку в выбранный цвет.
            endColor.BackColor = colorDialog1.Color;
        }

        /// <summary>
        /// Данный метод сохраняет нарисованный фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePicture_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Данный метод увеличивает масштаб фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Plus_Click(object sender, EventArgs e)
        {
            // Создаем ограничение на зум.
            if (Zoom <= 10)
                Zoom += 1;
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод уменьшает масштаб фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minus_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы зум не был равен нулю.
            if (Zoom >= 2)
                Zoom -= 1;
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод переназначает начальный цвет градиента и перерисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startColor_BackColorChanged(object sender, EventArgs e)
        {
            GetColorGradient();
            if (IsThePictureDrawn)
            {
                PaintCurrentDrawing();
            }
        }

        /// <summary>
        /// Данный метод переназначает конечный цвет градиента и перерисовывает фрактал.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endColor_BackColorChanged(object sender, EventArgs e)
        {
            GetColorGradient();
            if (IsThePictureDrawn)
            {
                PaintCurrentDrawing();
            }
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении размера окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel4_SizeChanged(object sender, EventArgs e)
        {
            if (IsThePictureDrawn)
                if ((panel4.Size.Height != 0) & (panel4.Size.Width != 0))
                    PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении длинны фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarLength_ValueChanged(object sender, EventArgs e)
        {
            // Преписываем текстовому полю под трекбаром его значение.
            Length = trackBarLength.Value;
            lengthVaule.Text = trackBarLength.Value.ToString();
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении угла фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarFirstAngle_ValueChanged(object sender, EventArgs e)
        {
            // Преписываем текстовому полю под трекбаром его значение.
            FirstAngle = trackBarFirstAngle.Value;
            firstAngleValue.Text = trackBarFirstAngle.Value.ToString();
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении угла фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSecondAngle_ValueChanged(object sender, EventArgs e)
        {
            // Преписываем текстовому полю под трекбаром его значение.
            SecondAngle = trackBarSecondAngle.Value;
            secondAngleValue.Text = trackBarSecondAngle.Value.ToString();
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении коэффициента фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarCoefficient_ValueChanged(object sender, EventArgs e)
        {
            // Преписываем текстовому полю под трекбаром его значение.
            Coefficient = trackBarCoefficient.Value * 0.1;
            coefficientValue.Text = $"{trackBarCoefficient.Value * 0.1:0.0}";
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении расстояния между итерациями множества Кантора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarCantorLength_ValueChanged(object sender, EventArgs e)
        {
            // Преписываем текстовому полю под трекбаром его значение.
            CantorLength = trackBarCantorLength.Value;
            cantorLengthValue.Text = $"{trackBarCantorLength.Value}";
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Получает градиент начального и конечного цвета.
        /// </summary>
        public static void GetColorGradient()
        {
            List<Color> result = new List<Color>();
            // Для каждой итерации находим свой цвет.
            for (int i = 0; i <= NumberOfSteps; i++)
            {
                // Находим цвет по следующим формулам.
                var rAdverage = StartColor.R + (int)((EndColor.R - StartColor.R) * i / (NumberOfSteps));
                var gAdverage = StartColor.G + (int)((EndColor.G - StartColor.G) * i / (NumberOfSteps));
                var bAdverage = StartColor.B + (int)((EndColor.B - StartColor.B) * i / (NumberOfSteps));
                result.Add(Color.FromArgb(255, rAdverage, gAdverage, bAdverage));
            }
            ColorSet = result;
        }

        /// <summary>
        /// Данный метод перерисовывает фрактал при изменении глубины рекурсии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecursionDepth_ValueChanged(object sender, EventArgs e)
        {
            // Делаем ограничение на глубину рекурсий для некоторых фракталов.
            if ((currentDrawing != 0) & (RecursionDepth.Value >= 5))
            {
                NumberOfSteps = RecursionDepth.Value + 1;
                label2.Text = $"{RecursionDepth.Value + 1}";
                RecursionDepth.Value = 4;
            }
            else
            {
                NumberOfSteps = RecursionDepth.Value + 1;
                label2.Text = $"{RecursionDepth.Value + 1}";
            }
            GetColorGradient();
            if (IsThePictureDrawn)
                PaintCurrentDrawing();
        }

        /// <summary>
        /// Данный метод выделяет выбранный фрактал синим цветом.
        /// </summary>
        private void PaintButton()
        {
            switch (currentDrawing)
            {
                case 0:
                    FractalTree.BackColor = Color.Blue;
                    TheKochCurve.BackColor = Color.White;
                    TheSierpinskiCarpet.BackColor = Color.White;
                    TheSierpinskiTriangle.BackColor = Color.White;
                    TheCantorSet.BackColor = Color.White;
                    break;
                case 1:
                    FractalTree.BackColor = Color.White;
                    TheKochCurve.BackColor = Color.Blue;
                    TheSierpinskiCarpet.BackColor = Color.White;
                    TheSierpinskiTriangle.BackColor = Color.White;
                    TheCantorSet.BackColor = Color.White;
                    break;
                case 2:
                    FractalTree.BackColor = Color.White;
                    TheKochCurve.BackColor = Color.White;
                    TheSierpinskiCarpet.BackColor = Color.Blue;
                    TheSierpinskiTriangle.BackColor = Color.White;
                    TheCantorSet.BackColor = Color.White;
                    break;
                case 3:
                    FractalTree.BackColor = Color.White;
                    TheKochCurve.BackColor = Color.White;
                    TheSierpinskiCarpet.BackColor = Color.White;
                    TheSierpinskiTriangle.BackColor = Color.Blue;
                    TheCantorSet.BackColor = Color.White;
                    break;
                case 4:
                    FractalTree.BackColor = Color.White;
                    TheKochCurve.BackColor = Color.White;
                    TheSierpinskiCarpet.BackColor = Color.White;
                    TheSierpinskiTriangle.BackColor = Color.White;
                    TheCantorSet.BackColor = Color.Blue;
                    break;
            }
        }
    }
}
