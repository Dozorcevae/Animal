using System;
using Animals.Models;

namespace Animals.Models
{
    // Случайное блуждание.
    public class ChaoticAnimal : BaseAnimal
    {
        private readonly Random rnd = new();
        public override void Run()
        {
            X = rnd.NextDouble() * Boundary.Width;
            Y = rnd.NextDouble() * Boundary.Height;

            while (true)
            {
                lock (locker) if (stopRequested) break;
                X += rnd.NextDouble() * 10 - 5;
                Y += rnd.NextDouble() * 10 - 5;
                if (X < 0 || X > Boundary.Width) X = rnd.NextDouble() * Boundary.Width;
                if (Y < 0 || Y > Boundary.Height) Y = rnd.NextDouble() * Boundary.Height;
                Thread.Sleep(50);
            }
        }
    }
}
