using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ButtonMax
{
    public class ButtonMax : Button
    {
        // Поля класса, которые хранят информацию о размере границы, радиусе углов и цвете границы
        private int borderSize = 0;
        private int borderRadius = 50;
        private Color borderColor = Color.DodgerBlue;

        // Кэш для хранения графического пути, чтобы избежать повторных вычислений при каждом перерисовывании
        private GraphicsPath? cachedPath;
        // Хранит последний размер кнопки для определения необходимости пересчета пути
        private Size lastSize;

        private GraphicsPath GetCachedPath(RectangleF rectangle, float radius)
        {
            if (cachedPath == null || lastSize != Size)
            {
                cachedPath = GetFigurePath(rectangle, radius);
                lastSize = Size;
            }
            return cachedPath;
        }

        // Свойства для получения и установки значений полей
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                // Invalidate() вызывает перерисовку кнопки при изменении размера границы
                Invalidate();
            }
        }

        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = Math.Min(value, Height);
                // Invalidate() вызывает перерисовку кнопки при изменении радиуса границы
                Invalidate();
            }
        }

        public Color BackgroundColor
        {
            get => BackColor;
            set { BackColor = value; }
        }

        public Color TextColor
        {
            get => ForeColor;
            set { ForeColor = value; }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                // Invalidate() вызывает перерисовку кнопки при изменении цвета границы
                Invalidate();
            }
        }

        // Конструктор, инициализирует начальные значения и параметры кнопки
        public ButtonMax()
        {
            Size = new Size(200, 100); // Задает начальный размер кнопки
            FlatAppearance.BorderSize = 0; // Убирает стандартную границу кнопки
            FlatStyle = FlatStyle.Flat; // Устанавливает стиль кнопки в плоский
            BackColor = Color.DodgerBlue; // Устанавливает начальный цвет фона
            ForeColor = Color.White; // Устанавливает начальный цвет текста
            Resize += new EventHandler(Button_Resize); // Добавляет обработчик события изменения размера
        }

        // Обработчик события изменения размера кнопки
        private void Button_Resize(object? sender, EventArgs e)
        {
            if (borderRadius > Height) borderRadius = Height; // Ограничивает радиус углов высотой кнопки
        }

        // Метод для создания графического пути с закругленными углами
        private GraphicsPath GetFigurePath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        // Переопределенный метод OnPaint для перерисовки кнопки с учетом пользовательских настроек
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent); // Вызов базового метода OnPaint
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Устанавливает режим сглаживания
            RectangleF rectangleSurface = new RectangleF(0, 0, Width, Height); // Определяет область для поверхности кнопки
            RectangleF rectangleBorder = new RectangleF(1, 1, Width - 0.5F, Height - 1); // Определяет область для границы кнопки

            if (borderRadius > 1) // Если радиус границы больше 1, то используем закругленные углы
            {
                using (GraphicsPath graphicsPathSurface = GetFigurePath(rectangleSurface, borderRadius))
                using (GraphicsPath graphicsPathBorder = GetFigurePath(rectangleBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(Parent.BackColor, 2)) // Карандаш для рисования поверхности
                using (Pen penBorder = new Pen(borderColor, borderSize)) // Карандаш для рисования границы
                {
                    penBorder.Alignment = PenAlignment.Inset; // Устанавливает выравнивание границы
                    Region = new Region(graphicsPathSurface); // Устанавливает регион (область) кнопки
                    pevent.Graphics.DrawPath(penBorder, graphicsPathSurface); // Рисует поверхность кнопки

                    if (borderSize >= 1) // Если размер границы больше или равен 1, рисуем границу
                        pevent.Graphics.DrawPath(penBorder, graphicsPathBorder);
                }
            }
            else // Если радиус границы меньше или равен 1, используем прямоугольную форму
            {
                Region = new Region(rectangleSurface); // Устанавливает регион (область) кнопки
                if (borderSize >= 1) // Если размер границы больше или равен 1, рисуем границу
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset; // Устанавливает выравнивание границы
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1); // Рисует прямоугольную границу
                    }
            }
        }

        // Переопределенный метод OnHandleCreated для обработки события создания дескриптора
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e); // Вызов базового метода OnHandleCreated
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged); // Добавляет обработчик события изменения цвета фона родительского контейнера
        }

        // Обработчик события изменения цвета фона родительского контейнера
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode) Invalidate(); // Вызывает перерисовку кнопки в режиме дизайна
        }
    }
}