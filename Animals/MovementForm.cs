using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Animals.Models;

namespace Animals
{
    public partial class MovementForm : Form
    {
        private List<BaseAnimal> animals = new List<BaseAnimal>();
        private Random rand = new Random();
        private System.Windows.Forms.Timer refreshTimer;

        public MovementForm()
        {
            InitializeComponent();

            // Привязка обработчиков для кнопок (если не установлено в Designer)
            btnPause.Click += btnPause_Click;
            btnResume.Click += btnResume_Click;
            btnStop.Click += btnStop_Click;
            btnStart.Click += btnStart_Click;
            //btnCreate.Click += btnCreate_Click;

            panelDisplay.Paint += PanelDisplay_Paint;
       
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 50;
            refreshTimer.Tick += (s, e) =>
            {
                panelDisplay.Invalidate();
                UpdateStatus();
            };
            refreshTimer.Start();

            // Установка границ для хаотичных животных на основе панели
            BaseAnimal.Boundary = new Rectangle(0, 0, panelDisplay.ClientSize.Width, panelDisplay.ClientSize.Height);

            // Настраиваем общие параметры для круговых животных
            int margin = 10;
            int width = panelDisplay.ClientSize.Width;
            int height = panelDisplay.ClientSize.Height;
            int centerX = width / 2;
            int centerY = height / 2;
            CircleAnimal.CommonCenter = new Point(centerX, centerY);
            // Радиус выбирается так, чтобы круг полностью помещался в panelDisplay
            CircleAnimal.CommonRadius = Math.Min(width, height) / 2 - margin;

            // Инициализация comboBox приоритетов, если не задана
            comboBoxPriority.Items.Clear();
            comboBoxPriority.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxPriority.SelectedItem = "3";

            // Инициализация таймера (используем System.Windows.Forms.Timer)
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 500; // например, обновлять каждые 500 мс
            refreshTimer.Tick += (s, e) =>
            {
                panelDisplay.Invalidate(); // если нужно перерисовывать область отображения
                UpdateStatus();            // обновляем статус
            };
            refreshTimer.Start();
        }

        private void PanelDisplay_Paint(object sender, PaintEventArgs e)
        {
            int pointSize = 6;
            foreach (var animal in animals)
            {
                Brush brush = Brushes.Black;
                if (animal is ChaoticAnimal)
                    brush = Brushes.Red;   // хаотичные – красные
                else if (animal is CircleAnimal)
                    brush = Brushes.Blue;  // окружные – синие

                e.Graphics.FillEllipse(brush, (float)animal.X, (float)animal.Y, pointSize, pointSize);
            }
        }

        // Обновление статусной строки: можно выводить общее число рабочих/пауза и даже id потока
        private void UpdateStatus()
        {
            string status = "";
            foreach (var animal in animals)
            {
                status += $"{animal.Species} ({animal.GetStatus()}); ";
            }
            statusLabel.Text = status;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            GenerateAnimals();
            MessageBox.Show("Объекты сгенерированы!");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
            {
                animal.Start();
                // Устанавливаем приоритет, взятый из comboBox
                if (animal.movementThread != null && comboBoxPriority.SelectedItem != null)
                {
                    switch (comboBoxPriority.SelectedItem.ToString())
                    {
                        case "1":
                            animal.movementThread.Priority = ThreadPriority.Lowest;
                            break;
                        case "2":
                            animal.movementThread.Priority = ThreadPriority.BelowNormal;
                            break;
                        case "3":
                            animal.movementThread.Priority = ThreadPriority.Normal;
                            break;
                        case "4":
                            animal.movementThread.Priority = ThreadPriority.AboveNormal;
                            break;
                        case "5":
                            animal.movementThread.Priority = ThreadPriority.Highest;
                            break;
                    }
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Resume();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var animal in animals)
                animal.Stop();
        }

        // Генерация животных
        private void GenerateAnimals()
        {
            animals.Clear();

            // Генерация хаотичных животных (например, 5 штук)
            int countChaotic = rand.Next(10, 11);
            for (int i = 0; i < countChaotic; i++)
            {
                double startX = rand.Next(BaseAnimal.Boundary.Left, BaseAnimal.Boundary.Right);
                double startY = rand.Next(BaseAnimal.Boundary.Top, BaseAnimal.Boundary.Bottom);
                double speed = rand.Next(30, 80);         // скорость от 30 до 80 пикс/сек
                double changeInterval = rand.Next(2, 6);    // смена направления каждые 2-5 сек

                var chaoticAnimal = new ChaoticAnimal("Chaotic", $"Chaos{i}", 1.0, new List<string>(),
                                                      startX, startY, speed, changeInterval);
                animals.Add(chaoticAnimal);
            }

            // Генерация круговых животных
            int countCircle = rand.Next(10, 11);
            for (int i = 0; i < countCircle; i++)
            {
                // случайная угловая скорость от 0.2 до 1.2 рад/сек
                double angularSpeed = rand.NextDouble() * 1.0 + 0.2;
                var circleAnimal = new CircleAnimal("Circle", $"Circle{i}", 2.0, new List<string>(), angularSpeed);
                animals.Add(circleAnimal);
            }
        }

        // При изменении размера панели обновляем границы и настройки для круговых животных
        private void panelDisplay_Resize(object sender, EventArgs e)
        {
            BaseAnimal.Boundary = new Rectangle(0, 0, panelDisplay.ClientSize.Width, panelDisplay.ClientSize.Height);
            int margin = 10;
            CircleAnimal.CommonCenter = new Point(panelDisplay.ClientSize.Width / 2, panelDisplay.ClientSize.Height / 2);
            CircleAnimal.CommonRadius = Math.Min(panelDisplay.ClientSize.Width, panelDisplay.ClientSize.Height) / 2 - margin;
        }
    }
}
