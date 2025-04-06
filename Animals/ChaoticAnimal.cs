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
        public ChaoticAnimal(string species, string Animalclass, double averageweigth, List<string> habitats)
            : base(species, Animalclass, averageweigth, habitats)
        { }

        private double speed; //pix/sec, speed 
        private double direcrionX;
        private double directionY;

        private bool StopRequested;
        private bool IsPaused;
        private readonly object locker = new object();

        //остаток времени до смены направления, сек
        private double timeTillChangeDirection;

        //время в сек раз в которое меняем направление
        private double changeInterval;

        private Thread? movementThread;
        
        //генератор случайных чисел
        private static Random random = new Random();

        public ChaoticAnimal(
            double x,
            double y,
            double speed,
            double changeInterval
            ) 
            : base ("Chaotic", "NoName", 0.0, new List<string>())
        {
            this.direcrionX = x;
            this.directionY = y;

            this.speed = speed;
            this.changeInterval = changeInterval;
            this.timeTillChangeDirection = changeInterval;

            SetRandomDirection();
        }

        private void SetRandomDirection()
        {
            double angle = random.NextDouble() * 2 * Math.PI;
            direcrionX = Math.Cos(angle);
            directionY = Math.Sin(angle);
        }
        public override void Start()
        {
            StopRequested = false;
            IsPaused = false;

            if (movementThread == null || !movementThread.IsAlive)
            {
                movementThread = new Thread(MoveChaoticLoop);
                movementThread.Start();

            }
        }

        public override void Stop()
        {
            lock (locker)
            {
                StopRequested = true;
                IsPaused = false;

                Monitor.PulseAll(locker);
            }
            movementThread?.Join();
        }

        public override void Pause()
        {
            lock (locker)
            {
                IsPaused = true;
            }
        }

        public override void Resume()
        {
            lock (locker)
            {
                IsPaused = false;
                Monitor.PulseAll(locker);
            }
        }

        private void MoveChaoticLoop()
        {
            double dt = 0.05;
            int sleepMs = 50;

            while (!StopRequested)
            {
                lock (locker)
                {
                    while (IsPaused && !StopRequested)
                    {
                        Monitor.Wait(locker);
                    }
                }
                if (StopRequested)
                    break;
                timeTillChangeDirection -= dt;
                if(timeTillChangeDirection <= 0.0)
                {
                    SetRandomDirection();
                    timeTillChangeDirection = changeInterval;
                }

                X += direcrionX * speed * dt;
                Y += directionY * speed * dt;

                Thread.Sleep(sleepMs);
            }
        }
    }
}
