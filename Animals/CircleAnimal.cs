using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Animals.Models
{
    public class CircleAnimal : BaseAnimal
    {
        
        public static Point CommonCenter { get; set; }
        public static double CommonRadius { get; set; } = 150.0;

        private double angularSpeed; // угловая скорость (рад/сек)
        private double currentAngle; // текущий угол
        private int sleepInterval = 50;

        public CircleAnimal(
            string species,
            string animalClass,
            double averageWeigth,
            List<string> habitats,
            double angularSpeed)
            : base(species, animalClass, averageWeigth, habitats)
        {
            this.angularSpeed = angularSpeed;
            this.currentAngle = 0;
        }

        public override void Run()
        {
            while (!stopRequested)
            {
                lock (locker)
                {
                    while (isPaused)
                    {
                        Monitor.Wait(locker);
                    }
                }

                double deltaTime = sleepInterval / 1000.0;
                currentAngle += angularSpeed * deltaTime;
                // нормализуем угол, чтобы не разрастался бесконечно
                if (currentAngle > 2 * Math.PI)
                    currentAngle -= 2 * Math.PI;

                // Вычисляем координаты по параметрическим уравнениям круга
                X = CommonCenter.X + CommonRadius * Math.Cos(currentAngle);
                Y = CommonCenter.Y + CommonRadius * Math.Sin(currentAngle);

                Thread.Sleep(sleepInterval);
            }
        }
    }
}
