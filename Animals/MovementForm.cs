using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Animal;
using Animals.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Animals
{
    public partial class MovementForm : Form
    {
        // Список животных (оба типа)
        private List<BaseAnimal> animals = new List<BaseAnimal>();
        private Random rand = new Random();
        private System.Windows.Forms.Timer refreshTimer;

        public MovementForm()
        {
            InitializeComponent();

            // Подписываемся на событие Paint панели отображения
            panelDisplay.Paint += PanelDisplay_Paint;

            // Инициализируем таймер для обновления панели
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 50; // 50 мс
            refreshTimer.Tick += (s, e) => panelDisplay.Invalidate();
            refreshTimer.Start();

            // Устанавливаем границы для хаотичных животных по размерам panelDisplay
            BaseAnimal.Boundary = new Rectangle(0, 0, panelDisplay.ClientSize.Width, panelDisplay.ClientSize.Height);

            // Устанавливаем общий круг для круговых животных так, чтобы он вписывался в panelDisplay
            int margin = 10;
            int width = panelDisplay.ClientSize.Width;
            int height = panelDisplay.ClientSize.Height;
            int centerX = width / 2;
            int centerY = height / 2;
            int radius = Math.Min(width, height) / 2 - margin;
            CircleAnimal.CommonCenter = new Point(centerX, centerY);
            var circle = new CircleAnimal("Circle", $"Circle{i}", 2.0, new List<string>());
            circle.CommonRadius = 150.0;


        }

        // Обработчик отрисовки панели отображения
        private void PanelDisplay_Paint(object sender, PaintEventArgs e)
        {
            int pointSize = 6; // диаметр точки

            foreach (var animal in animals)
            {
                // Различаем цвета по типу движения:
                Brush brush = Brushes.Black;
                if (animal is ChaoticAnimal)
                    brush = Brushes.Red;   // хаотичные – красные
                else if (animal is CircleAnimal)
                    brush = Brushes.Blue;  // окружные – синие

                e.Graphics.FillEllipse(brush, (float)animal.X, (float)animal.Y, pointSize, pointSize);
            }
        }

        // Обработчик кнопки "Создать"
        private void btnCreate_Click(object sender, EventArgs e)
        {
            GenerateAnimals();
            MessageBox.Show("Животные сгенерированы!");
        }

        // Обработчик кнопки "Старт"
        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Start();
        }

        // Обработчик кнопки "Пауза"
        private void btnPause_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Pause();
        }

        // Обработчик кнопки "Продолжить"
        private void btnResume_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Resume();
        }

        // Обработчик кнопки "Стоп"
        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Stop();
        }

        // Метод генерации животных
        private void GenerateAnimals()
        {
            animals.Clear();

            // Генерация 5 хаотичных животных
            int countChaotic = 5;
            for (int i = 0; i < countChaotic; i++)
            {
                double startX = rand.Next(BaseAnimal.Boundary.Left, BaseAnimal.Boundary.Right);
                double startY = rand.Next(BaseAnimal.Boundary.Top, BaseAnimal.Boundary.Bottom);
                double speed = rand.Next(30, 80);         // 30-80 px/сек
                double changeInterval = rand.Next(2, 6);    // смена направления каждые 2-5 сек

                var chaos = new ChaoticAnimal("Chaotic", $"Chaos{i}", 1.0, new List<string>(),
                                              startX, startY, speed, changeInterval);
                animals.Add(chaos);
            }

            // Генерация 5 окружных животных
            int countCircle = 5;
            for (int i = 0; i < countCircle; i++)
            {
                // Определяем угловую скорость случайно: от 0.2 до 1.2 рад/сек
                double omega = rand.NextDouble() * 1.0 + 0.2;
                var circle = new CircleAnimal("Circle", $"Circle{i}", 2.0, new List<string>(), omega);
                animals.Add(circle);
            }
        }
    }
}

