using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace MaxFunkCalculator2024
{
    public partial class MaxCalculator : Form
    {
        // Объявление полей класса
        private decimal result = 0M; 
        private string operation = string.Empty;
        private string? fstNum, sndNum; 
        private bool enterValue = false; 
        private decimal memory = 0M;
        private decimal lastNumber = 0M;
        private string lastOperation = string.Empty; 
        // Флаг для определения текущей цветовой схемы (по умолчанию темная)
        private bool isDarkTheme = true;
        // Конструктор класса
        public MaxCalculator()
        {
            InitializeComponent(); 
            UpdateHistoryStatus(); 
            LoadThemeSettings();
        }
        // Метод для снятия фокуса с кнопок
        private void RemoveButtonFocus()
        {
            this.ActiveControl = null;
        }
        // Константы для работы с Windows API
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // Импорт функций из Windows API для перемещения окна
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // Обработчик события нажатия мыши на заголовок окна для его перемещения
        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // Метод для ограничения длины вводимого текста
        private void LimitInputLength(TextBox textBox, int maxLength)
        {
            if (textBox.Text.Length > maxLength)
            {
                textBox.Text = textBox.Text.Substring(0, maxLength);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
        // Метод для сброса состояния калькулятора
        private void ResetCalculatorState()
        {
            result = 0M;
            operation = string.Empty;
            fstNum = null;
            sndNum = null;
            enterValue = false;
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
        }
        // Обработчик нажатия на кнопки математических операций
        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            try
            {
                if (result != 0)
                {
                    BtnEquals.PerformClick(); // Выполнить предыдущую операцию, если она есть
                }
                else
                {
                    // Проверка корректности введенного числа
                    if (!decimal.TryParse(TxtDisplay1.Text, out result))
                    {
                        throw new FormatException("невозможно");
                    }
                }

                ButtonMax.ButtonMax button = (ButtonMax.ButtonMax)sender;
                operation = button.Text;
                enterValue = true;

                if (TxtDisplay1.Text != "0")
                {
                    fstNum = result.ToString();
                    TxtDisplay2.Text = $"{fstNum} {operation}";
                    TxtDisplay1.Text = string.Empty;
                }

                RemoveButtonFocus();
            }
            catch (FormatException)
            {
                // Обработка ошибок преобразования строки в число
                TxtDisplay1.Text = "невозможно";
                TxtDisplay2.Text = string.Empty;
            }
            catch (Exception)
            {
                // Обработка других исключений
                TxtDisplay1.Text = "невозможно";
                TxtDisplay2.Text = string.Empty;
            }
        }
        // Обработчик изменения текста на основном дисплее
        private void TxtDisplay1_TextChanged(object sender, EventArgs e)
        {
            LimitInputLength(TxtDisplay1, 13);
            // Проверка на наличие более одной запятой
            if (TxtDisplay1.Text.Contains(",") && TxtDisplay1.Text.Split(',').Length > 2)
            {
                TxtDisplay1.Text = TxtDisplay1.Text.Substring(0, TxtDisplay1.Text.LastIndexOf(','));
                TxtDisplay1.SelectionStart = TxtDisplay1.Text.Length;
            }
        }
        // Обработчик нажатия кнопки "равно"
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(lastOperation))
                {
                    
                    operation = lastOperation;
                    sndNum = lastNumber.ToString();
                }
                else
                {
                    
                    sndNum = TxtDisplay1.Text;
                    lastOperation = operation;
                    lastNumber = decimal.Parse(sndNum);
                }

                
                TxtDisplay2.Text = $"{fstNum}{operation}{sndNum}";

                if (TxtDisplay1.Text == "0")
                    TxtDisplay2.Text = string.Empty;

                // Выполнение соответствующей арифметической операции
                switch (operation)
                {
                    case "+":
                        result += decimal.Parse(sndNum);
                        break;
                    case "-":
                        result -= decimal.Parse(sndNum);
                        break;
                    case "x":
                        try
                        {
                            decimal currentValue = decimal.Parse(sndNum);
                            // Проверка на переполнение при умножении
                            decimal resultAfterMultiplication = result * currentValue;
                            if (result != 0 && (resultAfterMultiplication / result != currentValue))
                            {
                                throw new OverflowException("переполнение");
                            }
                            result = resultAfterMultiplication;
                        }
                        catch (OverflowException)
                        {
                            TxtDisplay1.Text = "переполнение";
                            return;
                        }
                        break;
                    case "/":
                        try
                        {
                            // Проверка деления на ноль
                            if (decimal.Parse(sndNum) == 0)
                            {
                                throw new DivideByZeroException("невозможно");
                            }
                            result /= decimal.Parse(sndNum);
                        }
                        catch (DivideByZeroException)
                        {
                            TxtDisplay1.Text = "невозможно";
                            return;
                        }
                        break;
                    default:
                        // Если операция не распознана
                        TxtDisplay2.Text = $"{TxtDisplay1.Text}= ";
                        break;
                }

                // Отображение результата
                if (Math.Abs(result) < 0.000001M && result != 0)
                {
                    TxtDisplay1.Text = result.ToString("0.###############################");
                }
                else
                {
                    TxtDisplay1.Text = result.ToString("G29");
                }

                // Добавление операции в историю
                AddToHistory($"  {fstNum}{operation}{sndNum}= {TxtDisplay1.Text} \n");

                // Очистка текущей операции
                operation = string.Empty;
                fstNum = result.ToString();
                sndNum = string.Empty;

                RemoveButtonFocus();
            }
            catch (FormatException)
            {
                // Обработка ошибок формата
                TxtDisplay1.Text = "ошибка";
                TxtDisplay2.Text = string.Empty;
            }
            catch (Exception)
            {
                // Обработка других исключений
                TxtDisplay1.Text = "ошибка";
                TxtDisplay2.Text = string.Empty;
            }
        }
        // Обработчик нажатия кнопки истории
        private void BtnHist_Click(object sender, EventArgs e)
        {
            PnlHistory.Height = (PnlHistory.Height == 5) ? PnlHistory.Height = 352 : 5;
            RemoveButtonFocus();
        }
        // Обработчик нажатия цифровых кнопок
        private void BtnNum_Click(object sender, EventArgs e)
        {
            if ((TxtDisplay1.Text == "0" && ((ButtonMax.ButtonMax)sender).Text != ",") || enterValue)
                TxtDisplay1.Text = string.Empty;

            enterValue = false;
            ButtonMax.ButtonMax button = (ButtonMax.ButtonMax)sender;
            if (button.Text == ",")
            {
                if (!TxtDisplay1.Text.Contains(","))
                {
                    // Добавление "0," если текст пустой или заканчивается на оператор
                    if (string.IsNullOrEmpty(TxtDisplay1.Text) ||
                        "+-x/".Contains(TxtDisplay1.Text[TxtDisplay1.Text.Length - 1].ToString()))
                    {
                        TxtDisplay1.Text += "0,";
                    }
                    else
                    {
                        TxtDisplay1.Text += ",";
                    }
                }
            }
            else
            {
                TxtDisplay1.Text += button.Text;
            }

            RemoveButtonFocus();
        }
        // Обработчик нажатия кнопки backspace
        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text.Length > 0)
                TxtDisplay1.Text = TxtDisplay1.Text.Remove(TxtDisplay1.Text.Length - 1, 1);
            if (TxtDisplay1.Text == string.Empty) TxtDisplay1.Text = "0";
            RemoveButtonFocus();
        }
        // Обработчик нажатия кнопки очистки
        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
            result = 0;
            ResetCalculatorState();
            RemoveButtonFocus();
        }
        // Обработчик нажатия кнопки очистки текущего ввода
        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            RemoveButtonFocus();
        }
        // Обработчик нажатия кнопок специальных операций
        private void BtnOperations_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonMax.ButtonMax button = (ButtonMax.ButtonMax)sender;
                string operation = button.Text;
                decimal currentValue;

                try
                {
                    currentValue = decimal.Parse(TxtDisplay1.Text);
                }
                catch (FormatException)
                {
                    throw new FormatException("не число");
                }
                catch (OverflowException)
                {
                    throw new OverflowException("переполнение");
                }

                switch (operation)
                {
                    case "√x":
                        // Вычисление квадратного корня
                        try
                        {
                            if (currentValue < 0)
                            {
                                throw new ArithmeticException("невозможно");
                            }
                            TxtDisplay2.Text = $"√({TxtDisplay1.Text})";
                            TxtDisplay1.Text = Math.Sqrt((double)currentValue).ToString("G29");
                        }
                        catch (ArithmeticException)
                        {
                            TxtDisplay1.Text = "невозможно";
                            TxtDisplay2.Text = string.Empty;
                            return;
                        }
                        break;

                    case "x²":
                        // Возведение в квадрат
                        try
                        {
                            if (currentValue > decimal.MaxValue / currentValue)
                            {
                                throw new OverflowException("переполнение");
                            }
                            TxtDisplay2.Text = $"({TxtDisplay1.Text})²";
                            TxtDisplay1.Text = (currentValue * currentValue).ToString("G29");
                        }
                        catch (OverflowException)
                        {
                            TxtDisplay1.Text = "переполнение";
                            TxtDisplay2.Text = string.Empty;
                            return;
                        }
                        break;

                    case "1/x":
                        // Вычисление обратного числа
                        try
                        {
                            if (currentValue == 0)
                            {
                                throw new DivideByZeroException("невозможно");
                            }
                            TxtDisplay2.Text = $"1/({TxtDisplay1.Text})";
                            TxtDisplay1.Text = (1M / currentValue).ToString("0.###########");
                        }
                        catch (DivideByZeroException)
                        {
                            TxtDisplay1.Text = "невозможно";
                            TxtDisplay2.Text = string.Empty;
                            return;
                        }
                        break;

                    case "%":
                        // Вычисление процента
                        try
                        {
                            decimal percentageValue = 0M;
                            if (result == 0)
                            {
                                TxtDisplay1.Text = "0";
                                TxtDisplay2.Text = "0";
                            }
                            else
                            {
                                // Если результат не равен нулю, вычисляем процентное значение в зависимости от предыдущей операции
                                if (this.operation == "+" || this.operation == "-")
                                {
                                    percentageValue = result * (currentValue / 100M);
                                }
                                else if (this.operation == "x" || this.operation == "/")
                                {
                                    percentageValue = result * (currentValue / 100M);
                                }

                                // В зависимости от предыдущей операции, обновляем отображение результата
                                if (this.operation == "+")
                                {
                                    TxtDisplay1.Text = (result + percentageValue).ToString("G29");
                                }
                                else if (this.operation == "-")
                                {
                                    TxtDisplay1.Text = (result - percentageValue).ToString("G29");
                                }
                                else
                                {
                                    TxtDisplay1.Text = percentageValue.ToString("G29");
                                }

                                // Если значение процента целое, отображаем его без дробной части, иначе с дробной частью
                                if (percentageValue % 1 == 0)
                                {
                                    TxtDisplay1.Text = percentageValue.ToString("F0");
                                }
                                else
                                {
                                    TxtDisplay1.Text = percentageValue.ToString("G29");
                                }

                                // Обновляем вторую строку отображения, показывая полное выражение
                                TxtDisplay2.Text = $"{result}{this.operation}{currentValue}%";
                            }
                        }
                        catch (Exception)
                        {
                            // Ловим любые возможные исключения, выводим сообщение об ошибке и прерываем выполнение
                            TxtDisplay1.Text = "ошибка";
                            TxtDisplay2.Text = string.Empty;
                            return;
                        }
                        break;

                    case "±":
                        // Меняем знак текущего значения на противоположный и обновляем отображение
                        TxtDisplay1.Text = (-1M * currentValue).ToString("G29");
                        TxtDisplay2.Text = $"±({TxtDisplay1.Text})";
                        break;

                    default:
                        // Если операция неизвестна, выбрасываем исключение с сообщением "неизвестно"
                        throw new InvalidOperationException("неизвестно");
                }

                AddToHistory($"  {TxtDisplay2.Text}= {TxtDisplay1.Text} \n");

                RemoveButtonFocus();
            }
            catch (Exception)
            {
                // Ловим любые другие возможные исключения, выводим сообщение об ошибке и очищаем вторую строку отображения
                TxtDisplay1.Text = "невозможно";
                TxtDisplay2.Text = string.Empty;
            }
        }
        // Обработчик события нажатия на кнопку закрытия окна.
        private void BtnCloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Обработчик события нажатия на кнопку с ссылкой на гитхаб учётную запись автора.
        private void BntMaxFGithub_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Mugen1992/Calculator2024";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку свернуть окно.
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            RemoveButtonFocus();
        }
        // Метод для добавления записи в историю
        private void AddToHistory(string entry)
        {
            if (RtBoxDisplayHistory.Text == "  Журнал вычислений пуст")
            {
                RtBoxDisplayHistory.Text = entry;
            }
            else
            {
                RtBoxDisplayHistory.Text = entry + RtBoxDisplayHistory.Text;
            }

            // Разбиваем текст на строки
            string[] lines = RtBoxDisplayHistory.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            // Ограничиваем количество строк до 15
            if (lines.Length > 15)
            {
                lines = lines.Take(15).ToArray();
            }
            // Обновляем текст в RtBoxDisplayHistory
            RtBoxDisplayHistory.Text = string.Join("\n", lines);

            RemoveButtonFocus();
        }
        // Метод обновления истории
        private void UpdateHistoryStatus()
        {
            if (string.IsNullOrWhiteSpace(RtBoxDisplayHistory.Text))
            {
                RtBoxDisplayHistory.Text = "  Журнал вычислений пуст";
            }
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку удалить историю.
        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            UpdateHistoryStatus();
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку декоративного характера.        
        private void CalculatorIcon_Click(object sender, EventArgs e)
        {
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на верхнюю панель. 
        private void PnlTitle_Paint(object sender, PaintEventArgs e)
        {
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку Memory Store, которая активирует кнопки memory.
        private void BtnMemStore_Click(object sender, EventArgs e)
        {
            BtnMemClear.Enabled = true;
            BtmMemResult.Enabled = true;
            TxtDisplayMem.Enabled = true;
            TxtDisplayMem.Text = "0";
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку очистки памяти кнопок memory.
        private void BtnMemClear_Click(object sender, EventArgs e)
        {
            memory = 0;
            BtnMemClear.Enabled = false;
            BtmMemResult.Enabled = false;
            TxtDisplayMem.Enabled = false;
            TxtDisplayMem.Text = string.Empty;
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку, которая выводит текущее значение memory.
        private void BtmMemResult_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = memory.ToString();
            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку memory плюс, которая записывает (складывает) значение на экране в память.
        private void BtnMemAdd_Click(object sender, EventArgs e)
        {
            if (TxtDisplayMem.Enabled == true)
            {
                decimal currentValue;

                // Проверяем, можно ли преобразовать текст в число
                if (decimal.TryParse(TxtDisplay1.Text, out currentValue))
                {
                    memory += currentValue;
                    TxtDisplayMem.Text = memory.ToString();
                }
                else
                {
                    // Если значение некорректное, выводим сообщение или просто игнорируем действие
                    TxtDisplay1.Text = "невозможно";
                    TxtDisplay2.Text = string.Empty;
                }
            }

            RemoveButtonFocus();
        }
        // Обработчик события нажатия на кнопку memory минус, которая вычитает из памяти значение с экрана.
        private void BtnMemSubstract_Click(object sender, EventArgs e)
        {
            if (TxtDisplayMem.Enabled == true)
            {
                decimal currentValue;

                // Проверяем, можно ли преобразовать текст в число
                if (decimal.TryParse(TxtDisplay1.Text, out currentValue))
                {
                    memory -= currentValue;
                    TxtDisplayMem.Text = memory.ToString();
                }
                else
                {
                    // Если значение некорректное, выводим сообщение или просто игнорируем действие
                    TxtDisplay1.Text = "невозможно";
                    TxtDisplay2.Text = string.Empty;
                }
            }

            RemoveButtonFocus();
        }
        // Метод ограничения кол-ва выводимых символов вспомогательного экрана, которые находится сверху от основого.
        private void TxtDisplay2_TextChanged(object sender, EventArgs e)
        {
            LimitInputLength(TxtDisplay2, 28);
        }
        // Метод ограничения кол-ва выводимых символов экрана memory, которые находится снизу от основого.
        private void TxtDisplayMem_TextChanged(object sender, EventArgs e)
        {
            LimitInputLength(TxtDisplayMem, 8);
        }
        // Обработчик события нажатия на кнопку смена темы
        private void BtnChangeTheme_Click(object sender, EventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            ApplyTheme(isDarkTheme);
            SaveThemeSettings(isDarkTheme);
            RemoveButtonFocus();
        }
        // Метод обновления иконок при смене темы
        private void UpdateIcons(bool isDarkTheme)
        {
            if (isDarkTheme)
            {
                CalculatorIcon.Image = Properties.Resources.Calc_icon_30;
                BtnCloseWindow.Image = Properties.Resources.close_btn_icon_15;
                BtnMinimize.Image = Properties.Resources.minimize_btn_icon_15;
                BtnChangeTheme.Image = Properties.Resources.chtheme_btn_icon_20;
                BtnBackspace.Image = Properties.Resources.backspace_btn_icon_15;
                BtnHist.Image = Properties.Resources.timemachine_btn_icon_25;
                BtnClearHistory.Image = Properties.Resources.trash_btn_icon_30;

            }
            else
            {
                CalculatorIcon.Image = Properties.Resources.Calc_icon_30;
                BtnCloseWindow.Image = Properties.Resources.closelight_btn_icon_15;
                BtnMinimize.Image = Properties.Resources.minimizelight_btn_icon_15;
                BtnChangeTheme.Image = Properties.Resources.chthemelight_btn_icon__20;
                BtnBackspace.Image = Properties.Resources.backspacelight_btn_icon_20;
                BtnHist.Image = Properties.Resources.timemachinelight_btn_icon_25;
                BtnClearHistory.Image = Properties.Resources.trashlight_btn_icon_30;
            }
        }
        // Метод применения смены темы с тёмной на светлую и наоборот.
        private void ApplyTheme(bool isDark)
        {
            if (isDark)
            {
                // Возвращаем элементы в темную тему (по умолчанию)
                this.BackColor = Color.FromArgb(26, 31, 51); // Основной цвет для темной темы
                // BtnChangeTheme
                BtnChangeTheme.ForeColor = Color.FromArgb(26, 31, 51);
                // BntMaxFGithub
                BntMaxFGithub.ForeColor = Color.Silver;
                // BtnMinimize
                BtnMinimize.ForeColor = Color.FromArgb(26, 31, 51);
                // CalculatorIcon
                CalculatorIcon.ForeColor = Color.FromArgb(26, 31, 51);
                // BtnCloseWindow
                BtnCloseWindow.FlatAppearance.MouseOverBackColor = Color.Red;
                BtnCloseWindow.ForeColor = Color.FromArgb(26, 31, 51);
                // RtBoxDisplayHistory
                RtBoxDisplayHistory.BackColor = Color.FromArgb(26, 31, 51);
                RtBoxDisplayHistory.ForeColor = Color.Silver;
                // BtnGithub
                BtnGithub.ForeColor = Color.Silver;
                // TxtDisplay2
                TxtDisplay2.BackColor = Color.FromArgb(26, 31, 51);
                TxtDisplay2.ForeColor = Color.Silver;
                // TxtDisplay1
                TxtDisplay1.BackColor = Color.FromArgb(26, 31, 51);
                TxtDisplay1.ForeColor = Color.White;
                // BtnMemStore
                BtnMemStore.BackColor = Color.FromArgb(26, 31, 51);
                BtnMemStore.BackgroundColor = Color.FromArgb(26, 31, 51);
                BtnMemStore.BorderColor = Color.FromArgb(26, 31, 51);
                BtnMemStore.ForeColor = Color.White;
                BtnMemStore.TextColor = Color.White;
                // BtnMemSubstract
                BtnMemSubstract.BackColor = Color.FromArgb(26, 31, 51);
                BtnMemSubstract.BackgroundColor = Color.FromArgb(26, 31, 51);
                BtnMemSubstract.BorderColor = Color.FromArgb(26, 31, 51);
                BtnMemSubstract.ForeColor = Color.White;
                BtnMemSubstract.TextColor = Color.White;
                // BtnMemAdd
                BtnMemAdd.BackColor = Color.FromArgb(26, 31, 51);
                BtnMemAdd.BackgroundColor = Color.FromArgb(26, 31, 51);
                BtnMemAdd.BorderColor = Color.FromArgb(26, 31, 51);
                BtnMemAdd.ForeColor = Color.White;
                BtnMemAdd.TextColor = Color.White;
                // BtnMemClear
                BtnMemClear.BackColor = Color.FromArgb(26, 31, 51);
                BtnMemClear.BackgroundColor = Color.FromArgb(26, 31, 51);
                BtnMemClear.BorderColor = Color.FromArgb(26, 31, 51);
                BtnMemClear.ForeColor = Color.White;
                BtnMemClear.TextColor = Color.White;
                // BtnBackspace
                BtnBackspace.BackColor = Color.FromArgb(38, 43, 60);
                BtnBackspace.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnBackspace.BorderColor = Color.FromArgb(26, 31, 51);
                BtnBackspace.ForeColor = Color.FromArgb(26, 31, 51);
                BtnBackspace.TextColor = Color.FromArgb(26, 31, 51);
                // Btn7
                Btn7.BackColor = Color.FromArgb(53, 58, 78);
                Btn7.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn7.BorderColor = Color.FromArgb(26, 31, 51);
                Btn7.ForeColor = Color.White;
                Btn7.TextColor = Color.White;
                // BtnEquals
                BtnEquals.BackColor = Color.FromArgb(76, 194, 255);
                BtnEquals.BackgroundColor = Color.FromArgb(76, 194, 255);
                BtnEquals.BorderColor = Color.FromArgb(26, 31, 51);
                BtnEquals.ForeColor = Color.Black;
                BtnEquals.TextColor = Color.Black;
                // BtnClear
                BtnClear.BackColor = Color.FromArgb(38, 43, 60);
                BtnClear.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnClear.BorderColor = Color.FromArgb(26, 31, 51);
                BtnClear.ForeColor = Color.White;
                BtnClear.TextColor = Color.White;
                // BtnClearEntry
                BtnClearEntry.BackColor = Color.FromArgb(38, 43, 60);
                BtnClearEntry.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnClearEntry.BorderColor = Color.FromArgb(26, 31, 51);
                BtnClearEntry.ForeColor = Color.White;
                BtnClearEntry.TextColor = Color.White;
                // BtnPercentage
                BtnPercentage.BackColor = Color.FromArgb(38, 43, 60);
                BtnPercentage.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnPercentage.BorderColor = Color.FromArgb(26, 31, 51);
                BtnPercentage.ForeColor = Color.White;
                BtnPercentage.TextColor = Color.White;
                // BtnDivision
                BtnDivision.BackColor = Color.FromArgb(38, 43, 60);
                BtnDivision.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnDivision.BorderColor = Color.FromArgb(26, 31, 51);
                BtnDivision.ForeColor = Color.White;
                BtnDivision.TextColor = Color.White;
                // BtnSquareRoot
                BtnSquareRoot.BackColor = Color.FromArgb(38, 43, 60);
                BtnSquareRoot.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnSquareRoot.BorderColor = Color.FromArgb(26, 31, 51);
                BtnSquareRoot.ForeColor = Color.White;
                BtnSquareRoot.TextColor = Color.White;
                // BtnSquareX
                BtnSquareX.BackColor = Color.FromArgb(38, 43, 60);
                BtnSquareX.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnSquareX.BorderColor = Color.FromArgb(26, 31, 51);
                BtnSquareX.ForeColor = Color.White;
                BtnSquareX.TextColor = Color.White;
                // BtnReciprocal
                BtnReciprocal.BackColor = Color.FromArgb(38, 43, 60);
                BtnReciprocal.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnReciprocal.BorderColor = Color.FromArgb(26, 31, 51);
                BtnReciprocal.ForeColor = Color.White;
                BtnReciprocal.TextColor = Color.White;
                // BtnMultiplication
                BtnMultiplication.BackColor = Color.FromArgb(38, 43, 60);
                BtnMultiplication.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnMultiplication.BorderColor = Color.FromArgb(26, 31, 51);
                BtnMultiplication.ForeColor = Color.White;
                BtnMultiplication.TextColor = Color.White;
                // BtnSubstraction
                BtnSubstraction.BackColor = Color.FromArgb(38, 43, 60);
                BtnSubstraction.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnSubstraction.BorderColor = Color.FromArgb(26, 31, 51);
                BtnSubstraction.ForeColor = Color.White;
                BtnSubstraction.TextColor = Color.White;
                // BtnAddition
                BtnAddition.BackColor = Color.FromArgb(38, 43, 60);
                BtnAddition.BackgroundColor = Color.FromArgb(38, 43, 60);
                BtnAddition.BorderColor = Color.FromArgb(26, 31, 51);
                BtnAddition.ForeColor = Color.White;
                BtnAddition.TextColor = Color.White;
                // Btn8
                Btn8.BackColor = Color.FromArgb(53, 58, 78);
                Btn8.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn8.BorderColor = Color.FromArgb(26, 31, 51);
                Btn8.ForeColor = Color.White;
                Btn8.TextColor = Color.White;
                // Btn9
                Btn9.BackColor = Color.FromArgb(53, 58, 78);
                Btn9.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn9.BorderColor = Color.FromArgb(26, 31, 51);
                Btn9.ForeColor = Color.White;
                Btn9.TextColor = Color.White;
                // Btn4
                Btn4.BackColor = Color.FromArgb(53, 58, 78);
                Btn4.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn4.BorderColor = Color.FromArgb(26, 31, 51);
                Btn4.ForeColor = Color.White;
                Btn4.TextColor = Color.White;
                // Btn5
                Btn5.BackColor = Color.FromArgb(53, 58, 78);
                Btn5.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn5.BorderColor = Color.FromArgb(26, 31, 51);
                Btn5.ForeColor = Color.White;
                Btn5.TextColor = Color.White;
                // Btn6
                Btn6.BackColor = Color.FromArgb(53, 58, 78);
                Btn6.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn6.BorderColor = Color.FromArgb(26, 31, 51);
                Btn6.ForeColor = Color.White;
                Btn6.TextColor = Color.White;
                // Btn1
                Btn1.BackColor = Color.FromArgb(53, 58, 78);
                Btn1.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn1.BorderColor = Color.FromArgb(26, 31, 51);
                Btn1.ForeColor = Color.White;
                Btn1.TextColor = Color.White;
                // Btn2
                Btn2.BackColor = Color.FromArgb(53, 58, 78);
                Btn2.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn2.BorderColor = Color.FromArgb(26, 31, 51);
                Btn2.ForeColor = Color.White;
                Btn2.TextColor = Color.White;
                // Btn3
                Btn3.BackColor = Color.FromArgb(53, 58, 78);
                Btn3.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn3.BorderColor = Color.FromArgb(26, 31, 51);
                Btn3.ForeColor = Color.White;
                Btn3.TextColor = Color.White;
                // BtnChangeSign
                BtnChangeSign.BackColor = Color.FromArgb(53, 58, 78);
                BtnChangeSign.BackgroundColor = Color.FromArgb(53, 58, 78);
                BtnChangeSign.BorderColor = Color.FromArgb(26, 31, 51);
                BtnChangeSign.ForeColor = Color.White;
                BtnChangeSign.TextColor = Color.White;
                // Btn0
                Btn0.BackColor = Color.FromArgb(53, 58, 78);
                Btn0.BackgroundColor = Color.FromArgb(53, 58, 78);
                Btn0.BorderColor = Color.FromArgb(26, 31, 51);
                Btn0.ForeColor = Color.White;
                Btn0.TextColor = Color.White;
                // BtnDecimal
                BtnDecimal.BackColor = Color.FromArgb(53, 58, 78);
                BtnDecimal.BackgroundColor = Color.FromArgb(53, 58, 78);
                BtnDecimal.BorderColor = Color.FromArgb(26, 31, 51);
                BtnDecimal.ForeColor = Color.White;
                BtnDecimal.TextColor = Color.White;
                // BtmMemResult
                BtmMemResult.BackColor = Color.FromArgb(26, 31, 51);
                BtmMemResult.BackgroundColor = Color.FromArgb(26, 31, 51);
                BtmMemResult.BorderColor = Color.FromArgb(26, 31, 51);
                BtmMemResult.ForeColor = Color.White;
                BtmMemResult.TextColor = Color.White;
                // TxtDisplayMem
                TxtDisplayMem.BackColor = Color.FromArgb(26, 31, 51);
                TxtDisplayMem.ForeColor = Color.Silver;
            }
            else
            {
                // Светлая тема
                this.BackColor = Color.FromArgb(243, 243, 243);
                // BtnChangeTheme
                BtnChangeTheme.ForeColor = Color.FromArgb(243, 243, 243);
                // BntMaxFGithub
                BntMaxFGithub.ForeColor = Color.FromArgb(3, 3, 3);
                // BtnMinimize
                BtnMinimize.ForeColor = Color.FromArgb(243, 243, 243);
                // CalculatorIcon
                CalculatorIcon.ForeColor = Color.FromArgb(243, 243, 243);
                // BtnCloseWindow
                BtnCloseWindow.FlatAppearance.MouseOverBackColor = Color.Red;
                BtnCloseWindow.ForeColor = Color.FromArgb(243, 243, 243);
                // RtBoxDisplayHistory
                RtBoxDisplayHistory.BackColor = Color.FromArgb(243, 243, 243);
                RtBoxDisplayHistory.ForeColor = Color.FromArgb(3, 3, 3);
                // BtnGithub
                BtnGithub.ForeColor = Color.FromArgb(3, 3, 3);
                // TxtDisplay2
                TxtDisplay2.BackColor = Color.FromArgb(243, 243, 243);
                TxtDisplay2.ForeColor = Color.FromArgb(3, 3, 3);
                // TxtDisplay1
                TxtDisplay1.BackColor = Color.FromArgb(243, 243, 243);
                TxtDisplay1.ForeColor = Color.FromArgb(3, 3, 3);
                // BtnMemStore
                BtnMemStore.BackColor = Color.FromArgb(243, 243, 243);
                BtnMemStore.BackgroundColor = Color.FromArgb(243, 243, 243);
                BtnMemStore.BorderColor = Color.FromArgb(243, 243, 243);
                BtnMemStore.ForeColor = Color.FromArgb(3, 3, 3);
                BtnMemStore.TextColor = Color.FromArgb(3, 3, 3);
                // BtnMemSubstract
                BtnMemSubstract.BackColor = Color.FromArgb(243, 243, 243);
                BtnMemSubstract.BackgroundColor = Color.FromArgb(243, 243, 243);
                BtnMemSubstract.BorderColor = Color.FromArgb(243, 243, 243);
                BtnMemSubstract.ForeColor = Color.FromArgb(3, 3, 3);
                BtnMemSubstract.TextColor = Color.FromArgb(3, 3, 3);
                // BtnMemAdd
                BtnMemAdd.BackColor = Color.FromArgb(243, 243, 243);
                BtnMemAdd.BackgroundColor = Color.FromArgb(243, 243, 243);
                BtnMemAdd.BorderColor = Color.FromArgb(243, 243, 243);
                BtnMemAdd.ForeColor = Color.FromArgb(3, 3, 3);
                BtnMemAdd.TextColor = Color.FromArgb(3, 3, 3);
                // BtnMemClear
                BtnMemClear.BackColor = Color.FromArgb(243, 243, 243);
                BtnMemClear.BackgroundColor = Color.FromArgb(243, 243, 243);
                BtnMemClear.BorderColor = Color.FromArgb(243, 243, 243);
                BtnMemClear.ForeColor = Color.FromArgb(3, 3, 3);
                BtnMemClear.TextColor = Color.FromArgb(3, 3, 3);
                // BtmMemResult
                BtmMemResult.BackColor = Color.FromArgb(243, 243, 243);
                BtmMemResult.BackgroundColor = Color.FromArgb(243, 243, 243);
                BtmMemResult.BorderColor = Color.FromArgb(243, 243, 243);
                BtmMemResult.ForeColor = Color.FromArgb(3, 3, 3);
                BtmMemResult.TextColor = Color.FromArgb(3, 3, 3);
                // BtnBackspace
                BtnBackspace.BackColor = Color.FromArgb(201, 201, 201);
                BtnBackspace.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnBackspace.BorderColor = Color.FromArgb(243, 243, 243);
                BtnBackspace.ForeColor = Color.FromArgb(243, 243, 243);
                BtnBackspace.TextColor = Color.FromArgb(243, 243, 243);
                // BtnClear
                BtnClear.BackColor = Color.FromArgb(201, 201, 201);
                BtnClear.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnClear.BorderColor = Color.FromArgb(243, 243, 243);
                BtnClear.ForeColor = Color.FromArgb(3, 3, 3);
                BtnClear.TextColor = Color.FromArgb(3, 3, 3);
                // BtnClearEntry
                BtnClearEntry.BackColor = Color.FromArgb(201, 201, 201);
                BtnClearEntry.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnClearEntry.BorderColor = Color.FromArgb(243, 243, 243);
                BtnClearEntry.ForeColor = Color.FromArgb(3, 3, 3);
                BtnClearEntry.TextColor = Color.FromArgb(3, 3, 3);
                // BtnPercentage
                BtnPercentage.BackColor = Color.FromArgb(201, 201, 201);
                BtnPercentage.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnPercentage.BorderColor = Color.FromArgb(243, 243, 243);
                BtnPercentage.ForeColor = Color.FromArgb(3, 3, 3);
                BtnPercentage.TextColor = Color.FromArgb(3, 3, 3);
                // BtnDivision
                BtnDivision.BackColor = Color.FromArgb(201, 201, 201);
                BtnDivision.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnDivision.BorderColor = Color.FromArgb(243, 243, 243);
                BtnDivision.ForeColor = Color.FromArgb(3, 3, 3);
                BtnDivision.TextColor = Color.FromArgb(3, 3, 3);
                // BtnSquareRoot
                BtnSquareRoot.BackColor = Color.FromArgb(201, 201, 201);
                BtnSquareRoot.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnSquareRoot.BorderColor = Color.FromArgb(243, 243, 243);
                BtnSquareRoot.ForeColor = Color.FromArgb(3, 3, 3);
                BtnSquareRoot.TextColor = Color.FromArgb(3, 3, 3);
                // BtnSquareX
                BtnSquareX.BackColor = Color.FromArgb(201, 201, 201);
                BtnSquareX.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnSquareX.BorderColor = Color.FromArgb(243, 243, 243);
                BtnSquareX.ForeColor = Color.FromArgb(3, 3, 3);
                BtnSquareX.TextColor = Color.FromArgb(3, 3, 3);
                // BtnReciprocal
                BtnReciprocal.BackColor = Color.FromArgb(201, 201, 201);
                BtnReciprocal.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnReciprocal.BorderColor = Color.FromArgb(243, 243, 243);
                BtnReciprocal.ForeColor = Color.FromArgb(3, 3, 3);
                BtnReciprocal.TextColor = Color.FromArgb(3, 3, 3);
                // BtnMultiplication
                BtnMultiplication.BackColor = Color.FromArgb(201, 201, 201);
                BtnMultiplication.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnMultiplication.BorderColor = Color.FromArgb(243, 243, 243);
                BtnMultiplication.ForeColor = Color.FromArgb(3, 3, 3);
                BtnMultiplication.TextColor = Color.FromArgb(3, 3, 3);
                // BtnSubstraction
                BtnSubstraction.BackColor = Color.FromArgb(201, 201, 201);
                BtnSubstraction.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnSubstraction.BorderColor = Color.FromArgb(243, 243, 243);
                BtnSubstraction.ForeColor = Color.FromArgb(3, 3, 3);
                BtnSubstraction.TextColor = Color.FromArgb(3, 3, 3);
                // BtnAddition
                BtnAddition.BackColor = Color.FromArgb(201, 201, 201);
                BtnAddition.BackgroundColor = Color.FromArgb(201, 201, 201);
                BtnAddition.BorderColor = Color.FromArgb(243, 243, 243);
                BtnAddition.ForeColor = Color.FromArgb(3, 3, 3);
                BtnAddition.TextColor = Color.FromArgb(3, 3, 3);
                // BtnEquals
                BtnEquals.BackColor = Color.FromArgb(0, 103, 192);
                BtnEquals.BackgroundColor = Color.FromArgb(0, 103, 192);
                BtnEquals.BorderColor = Color.FromArgb(243, 243, 243);
                BtnEquals.ForeColor = Color.White;
                BtnEquals.TextColor = Color.White;
                // Btn7
                Btn7.BackColor = Color.FromArgb(224, 224, 224);
                Btn7.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn7.BorderColor = Color.FromArgb(243, 243, 243);
                Btn7.ForeColor = Color.FromArgb(3, 3, 3);
                Btn7.TextColor = Color.FromArgb(3, 3, 3);
                // Btn8
                Btn8.BackColor = Color.FromArgb(224, 224, 224);
                Btn8.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn8.BorderColor = Color.FromArgb(243, 243, 243);
                Btn8.ForeColor = Color.FromArgb(3, 3, 3);
                Btn8.TextColor = Color.FromArgb(3, 3, 3);
                // Btn9
                Btn9.BackColor = Color.FromArgb(224, 224, 224);
                Btn9.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn9.BorderColor = Color.FromArgb(243, 243, 243);
                Btn9.ForeColor = Color.FromArgb(3, 3, 3);
                Btn9.TextColor = Color.FromArgb(3, 3, 3);
                // Btn4
                Btn4.BackColor = Color.FromArgb(224, 224, 224);
                Btn4.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn4.BorderColor = Color.FromArgb(243, 243, 243);
                Btn4.ForeColor = Color.FromArgb(3, 3, 3);
                Btn4.TextColor = Color.FromArgb(3, 3, 3);
                // Btn5
                Btn5.BackColor = Color.FromArgb(224, 224, 224);
                Btn5.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn5.BorderColor = Color.FromArgb(243, 243, 243);
                Btn5.ForeColor = Color.FromArgb(3, 3, 3);
                Btn5.TextColor = Color.FromArgb(3, 3, 3);
                // Btn6
                Btn6.BackColor = Color.FromArgb(224, 224, 224);
                Btn6.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn6.BorderColor = Color.FromArgb(243, 243, 243);
                Btn6.ForeColor = Color.FromArgb(3, 3, 3);
                Btn6.TextColor = Color.FromArgb(3, 3, 3);
                // Btn1
                Btn1.BackColor = Color.FromArgb(224, 224, 224);
                Btn1.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn1.BorderColor = Color.FromArgb(243, 243, 243);
                Btn1.ForeColor = Color.FromArgb(3, 3, 3);
                Btn1.TextColor = Color.FromArgb(3, 3, 3);
                // Btn2
                Btn2.BackColor = Color.FromArgb(224, 224, 224);
                Btn2.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn2.BorderColor = Color.FromArgb(243, 243, 243);
                Btn2.ForeColor = Color.FromArgb(3, 3, 3);
                Btn2.TextColor = Color.FromArgb(3, 3, 3);
                // Btn3
                Btn3.BackColor = Color.FromArgb(224, 224, 224);
                Btn3.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn3.BorderColor = Color.FromArgb(243, 243, 243);
                Btn3.ForeColor = Color.FromArgb(3, 3, 3);
                Btn3.TextColor = Color.FromArgb(3, 3, 3);
                // BtnChangeSign
                BtnChangeSign.BackColor = Color.FromArgb(224, 224, 224);
                BtnChangeSign.BackgroundColor = Color.FromArgb(224, 224, 224);
                BtnChangeSign.BorderColor = Color.FromArgb(243, 243, 243);
                BtnChangeSign.ForeColor = Color.FromArgb(3, 3, 3);
                BtnChangeSign.TextColor = Color.FromArgb(3, 3, 3);
                // Btn0
                Btn0.BackColor = Color.FromArgb(224, 224, 224);
                Btn0.BackgroundColor = Color.FromArgb(224, 224, 224);
                Btn0.BorderColor = Color.FromArgb(243, 243, 243);
                Btn0.ForeColor = Color.FromArgb(3, 3, 3);
                Btn0.TextColor = Color.FromArgb(3, 3, 3);
                // BtnDecimal
                BtnDecimal.BackColor = Color.FromArgb(224, 224, 224);
                BtnDecimal.BackgroundColor = Color.FromArgb(224, 224, 224);
                BtnDecimal.BorderColor = Color.FromArgb(243, 243, 243);
                BtnDecimal.ForeColor = Color.FromArgb(3, 3, 3);
                BtnDecimal.TextColor = Color.FromArgb(3, 3, 3);
                // TxtDisplayMem
                TxtDisplayMem.BackColor = Color.FromArgb(243, 243, 243);
                TxtDisplayMem.ForeColor = Color.FromArgb(3, 3, 3);
            }
            UpdateIcons(isDark);
        }
        // Метод записи текущего состояения темы в память.
        private void SaveThemeSettings(bool isDark)
        {
            Properties.Settings.Default.IsDarkTheme = isDark;
            Properties.Settings.Default.Save();
        }
        // Метод загрузки текущего состояения темы из памяти.
        private void LoadThemeSettings()
        {
            isDarkTheme = Properties.Settings.Default.IsDarkTheme;
            ApplyTheme(isDarkTheme);
        }
    }
}