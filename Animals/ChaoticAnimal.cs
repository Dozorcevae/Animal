using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Models;

namespace Animals
{
    public class ChaoticAnimal : BaseAnimal
    {
        private double speed;            // линейная скорость (пикселей/сек)
        private double changeInterval;   // интервал смены направления (сек)
        private double timeLeftToChange; // оставшееся время до смены направления
        private double directionX;       // горизонтальная составляющая вектора движения (нормированная)
        private double directionY;       // вертикальная составляющая
        private static Random rand = new Random();

        public ChaoticAnimal(string species, string name, double age, List<string> environment,
                             double startX, double startY, double speed, double changeInterval)
            : base(species, name, age, environment)
        {
            // Устанавливаем начальные координаты
            this.X = startX;
            this.Y = startY;
            this.speed = speed;
            this.changeInterval = changeInterval;
            this.timeLeftToChange = changeInterval;

            // Инициализируем случайное направление
            SetRandomDirection();
        }

        private void SetRandomDirection()
        {
            double angle = rand.NextDouble() * 2 * Math.PI;
            directionX = Math.Cos(angle);
            directionY = Math.Sin(angle);
        }
        public override void Run()
        {
            double dt = 0.05;
            while (!stopRequested)
            {
                lock (locker)
                {
                    while (isPaused && !stopRequested)
                        Monitor.Wait(locker);
                }
                if (stopRequested)
                    break;
                timeLeftToChange -= dt;
                if(timeLeftToChange <= 0)
                {
                    SetRandomDirection();
                    timeLeftToChange = changeInterval;
                }

                X += directionX * speed * dt;
                Y += directionY * speed * dt;

                // ogranichenie po granicam
                Rectangle b = Boundary;
                if (X < b.Left)
                {
                    X = b.Left;
                    directionX = -directionX;
                }
                if (X > b.Right)
                {
                    X = b.Right;
                    directionX = -directionX;
                }
                if (Y < b.Top)
                {
                    Y = b.Top;
                    directionY = -directionY;
                }
                if (Y > b.Bottom)
                {
                    Y = b.Bottom;
                    directionY = -directionY;
                }
                Thread.Sleep(50);
            }
        }
    }
}
