using System;
using System.Drawing;
using Animals.Models;

namespace Animals.Models
{
    // Движется по окружности.
    public class CircleAnimal : BaseAnimal
    {
        private readonly double radius;
        private double angle;
        private readonly double speedRad; // рад/сек

        public CircleAnimal(double radius = 50, double speed = 0.5)
        {
            this.radius = radius;
            speedRad = speed;
        }

        public override void Run()
        {
            var centerX = Boundary.Width / 2.0;
            var centerY = Boundary.Height / 2.0;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            while (true)
            {
                lock (locker) if (stopRequested) break;
                var t = sw.Elapsed.TotalSeconds;
                angle = speedRad * t;
                X = centerX + radius * Math.Cos(angle);
                Y = centerY + radius * Math.Sin(angle);
                Thread.Sleep(16); // ~60 fps
            }
        }
    }
}
