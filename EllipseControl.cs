using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EllipseCont
{
    public class EllipseControlMax : Component
    {
        // Импорт функции CreateRoundRectRgn из библиотеки GDI32 для создания закругленного прямоугольника
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nL, int nT, int nR, int nB, int nWidthEllipse, int nHeightEllipse);

        // Приватные поля для хранения контрола и радиуса закругления
        private Control _control;
        private int _cornerRadius = 25;

        // Поля для кэширования, чтобы избежать лишних обновлений
        private Size _lastSize;
        private int _lastCornerRadius;
        private Region _cachedRegion;

        // Свойство для установки целевого контрола
        public Control TargetControl
        {
            get => _control;
            set
            {
                // Если уже есть контрол, отписываемся от его событий
                if (_control != null)
                {
                    _control.SizeChanged -= Control_SizeChanged;
                }
                _control = value;
                // Если новый контрол не null, подписываемся на его события и обновляем регион
                if (_control != null)
                {
                    _control.SizeChanged += Control_SizeChanged;
                    UpdateControlRegion();
                }
            }
        }

        // Свойство для установки радиуса закругления
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                // Обновляем регион только если значение изменилось
                if (value != _cornerRadius)
                {
                    _cornerRadius = value;
                    UpdateControlRegion();
                }
            }
        }

        // Обработчик события изменения размера контрола
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            UpdateControlRegion();
        }

        // Метод для обновления региона контрола
        private void UpdateControlRegion()
        {
            if (_control != null)
            {
                // Обновляем регион только если изменился размер или радиус
                if (_control.Size != _lastSize || _cornerRadius != _lastCornerRadius)
                {
                    // Освобождаем предыдущий кэшированный регион
                    _cachedRegion?.Dispose();
                    // Создаем новый регион
                    _cachedRegion = Region.FromHrgn(CreateRoundRectRgn(0, 0, _control.Width, _control.Height, _cornerRadius, _cornerRadius));
                    // Применяем регион к контролу
                    _control.Region = _cachedRegion;
                    // Обновляем кэшированные значения
                    _lastSize = _control.Size;
                    _lastCornerRadius = _cornerRadius;
                }
            }
        }

        // Переопределение метода Dispose для освобождения ресурсов
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Отписываемся от событий контрола
                if (_control != null)
                {
                    _control.SizeChanged -= Control_SizeChanged;
                }
                // Освобождаем кэшированный регион
                _cachedRegion?.Dispose();
            }
            // Вызываем базовый метод Dispose
            base.Dispose(disposing);
        }
    }
}