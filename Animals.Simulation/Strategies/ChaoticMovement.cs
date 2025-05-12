using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Animals.Domain;
using Animals.Domain.Interfaces;

namespace Animals.Simulation.Strategies
{
    // Хаотичное движение в пределах Bounds.
    public sealed class ChaoticMovement : IMovementStrategy
    {
        public Rectangle Bounds { get; set; } = new(0, 0, 600, 400);
        public double Speed { get; set; } = 90;
        public double ChangeInterval { get; set; } = 1.3;

        private readonly Random _rand = new();
        private double _angle;
        private double _elapsed;

        public void Move(BaseAnimal a, double dt)
        {
            _elapsed += dt;
            if (_elapsed >= ChangeInterval)
            {
                _angle = _rand.NextDouble() * 2 * Math.PI;
                _elapsed = 0;
            }

            a.X += Speed * Math.Cos(_angle) * dt;
            a.Y += Speed * Math.Sin(_angle) * dt;

            if (a.X < Bounds.Left || a.X > Bounds.Right)
            {
                _angle = Math.PI - _angle;
                a.X = Math.Clamp(a.X, Bounds.Left, Bounds.Right);
            }
            if (a.Y < Bounds.Top || a.Y > Bounds.Bottom)
            {
                _angle = -_angle;
                a.Y = Math.Clamp(a.Y, Bounds.Top, Bounds.Bottom);
            }
        }
    }
}

