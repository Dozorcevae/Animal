using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;
using Animals.Domain;
using Animals.Domain.Interfaces;

namespace Animals.Simulation.Strategies
{
    // Круговое движение вокруг Center.
    public sealed class CircularMovement : IMovementStrategy
    {
        public Point Center { get; set; } = new(300, 200);
        public double Radius { get; set; } = 120;
        public double AngularSpeed { get; set; } = Math.PI; // рад/с
        private double _angle;

        public void Move(BaseAnimal a, double dt)
        {
            _angle += AngularSpeed * dt;
            if (_angle > 2 * Math.PI) _angle -= 2 * Math.PI;

            a.X = Center.X + Radius * Math.Cos(_angle);
            a.Y = Center.Y + Radius * Math.Sin(_angle);
        }
    }
}

