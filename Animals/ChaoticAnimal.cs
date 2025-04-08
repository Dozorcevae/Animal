using System;
using System.Collections.Generic;
using System.Threading;

namespace Animals.Models
{
    public class ChaoticAnimal : BaseAnimal
    {
        private double speed;            // скорость в пикселях в секунду
        private double changeInterval;   // интервал смены направления (сек)
        private Random rand;

        public ChaoticAnimal(
            string species,
            string animalClass,
            double averageWeigth,
            List<string> habitats,
            double startX,
            double startY,
            double speed,
            double changeInterval)
            : base(species, animalClass, averageWeigth, habitats)
        {
            this.X = startX;
            this.Y = startY;
            this.speed = speed;
            this.changeInterval = changeInterval;
            rand = new Random();
        }

        public override void Run()
        {
            double angle = rand.NextDouble() * 2 * Math.PI; // начальный угол движения
            DateTime lastDirectionChange = DateTime.Now;
            int sleepInterval = 50; // интервал обновления в миллисекундах

            while (!stopRequested)
            {
                // Пауза
                lock (locker)
                {
                    while (isPaused)
                    {
                        Monitor.Wait(locker);
                    }
                }

                // расчёт смещения (учитывая, что 50 мс ~ 0,05 сек)
                double deltaTime = sleepInterval / 1000.0;
                double dx = speed * Math.Cos(angle) * deltaTime;
                double dy = speed * Math.Sin(angle) * deltaTime;
                X += dx;
                Y += dy;

                // Проверка границ – если достигли края, инвертируем направление
                if (X < Boundary.Left)
                {
                    X = Boundary.Left;
                    angle = Math.PI - angle;
                }
                if (X > Boundary.Right)
                {
                    X = Boundary.Right;
                    angle = Math.PI - angle;
                }
                if (Y < Boundary.Top)
                {
                    Y = Boundary.Top;
                    angle = -angle;
                }
                if (Y > Boundary.Bottom)
                {
                    Y = Boundary.Bottom;
                    angle = -angle;
                }

                // Смена направления через заданный интервал времени
                if ((DateTime.Now - lastDirectionChange).TotalSeconds >= changeInterval)
                {
                    angle = rand.NextDouble() * 2 * Math.PI;
                    lastDirectionChange = DateTime.Now;
                }

                Thread.Sleep(sleepInterval);
            }
        }
    }
}
