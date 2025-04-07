using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Animals.Models;


namespace Animal
{
    public class CircleAnimal : BaseAnimal
    {
        // Параметры движения по окружности:

        private double angle;   // Текущий угол в радианах
        private double omega;   // Угловая скорость (рад/сек)
        public static Point CommonCenter { get; set; } = new Point(250, 200);
        public double CommonRadius { get; set; } = 150;


        public CircleAnimal(
        string species,
        string name,
        double age,
        List<string> environment,
        double omega
        )
        : base(species, name, age, environment)
        {
            this.omega = omega;
            this.angle = 0;
            // Начальные координаты берём из CommonCenter и CommonRadius
            this.X = CommonCenter.X + CommonRadius * Math.Cos(angle);
            this.Y = CommonCenter.Y + CommonRadius * Math.Sin(angle);
        }



        public override void Run()
        {
            double dt = 0.05;
            while (!stopRequested)
            {
                lock (locker)
                {
                    while (isPaused && stopRequested)
                        Monitor.Wait(locker);
                }
                if (stopRequested)
                    break;

                angle += omega * dt;

                this.X = CommonCenter.X + CommonRadius * Math.Cos(angle);
                this.Y = CommonCenter.Y + CommonRadius * Math.Sin(angle);

                Thread.Sleep(50);
            }
        }
    }
}