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



namespace Animals
{
    public partial class MovementForm : Form
    {
        private System.Windows.Forms.Timer refreshTimer;


        private List<BaseAnimal> animals = new List<BaseAnimal>();
        public MovementForm()
        {
            InitializeComponent();
            this.panelDisplay.Paint += panelDisplay_Paint;

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 50; // 50 мс
            refreshTimer.Tick += (s, e) => panelDisplay.Invalidate();
            refreshTimer.Start();

        }
       

        
       
        private void btnCreate_Click(object sender, EventArgs e)
        {
            GenerateAnimals();
            MessageBox.Show("Случайные животные успешно сгенерированы!");
        }

        private Random rand = new Random();
        private void GenerateAnimals()
        {
            animals.Clear();

            for (int i = 0; i < 5; i++)
            {
                double startX = rand.Next(50, 400);
                double startY = rand.Next(50, 300);

                double speed = rand.Next(30, 80);         // скорость, 30..80
                double changeInterval = rand.Next(2, 6);  // каждые 2..5 сек меняем направление

                var chaos = new ChaoticAnimal
                    ("Chaotic",
                    $"Chaos{i}",
                    1,
                    new List<string>(),
                    startX,
                    startY,
                    speed,
                    changeInterval);
                animals.Add(chaos);
            }

            for (int i = 0; i < 5; i++)
            {
                // Создание CircleAnimal
                double centerX = rand.Next(100, 300);
                double centerY = rand.Next(100, 300);

                double radius = rand.Next(30, 100);              
                double omega = rand.NextDouble() * 1.0 + 0.2;
                
                var circle = new CircleAnimal(
                    "Circle",
                    $"Circle{i}",
                    2,
                    new List<string>(),
                    centerX,
                    centerY,
                    radius,
                    omega);
                animals.Add(circle);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (var a in animals)
                a.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            foreach (var a in animals)
                a.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            foreach (var a in animals)
                a.Resume();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var a in animals)
                a.Stop();
        }

        private void panelDisplay_Paint(object sender, PaintEventArgs e)
        {
            // Задаём размер точки (диаметр)
            int pointSize = 6; // например, 6 пикселей

            // Проходим по списку животных
            foreach (var animal in animals)
            {
               
                e.Graphics.FillEllipse(Brushes.Red, (float)animal.X, (float)animal.Y, pointSize, pointSize);
            }
        }
        

        

    }
}
