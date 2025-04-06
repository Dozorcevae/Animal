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

        //остаток времени до смены направления, сек
        private double timeToChangeDirection;

        //время в сек раз в которое меняем направление
        private double changeInterval;
        
        //генератор случайных чисел
        private static Random random = new Random();

        public ChaoticAnimal(double x, double y, double speed, double changeInterval) 
            : base ("Chaotic", "NoName", 0.0, new List<string>())
        {
            this.direcrionX = x;
            this.directionY = y;

            this.speed = speed;
            this.changeInterval = changeInterval;
            this.timeToChangeDirection = changeInterval;

            SetRandomDirection();
        }

        private void SetRandomDirection()
        {
            double angle = random.NextDouble() * 2 * Math.PI;
        }
        // TODO: другие методы, OneStep например там и другие)
        

    }
}
