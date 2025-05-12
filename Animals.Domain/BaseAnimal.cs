using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Domain.Interfaces;

namespace Animals.Domain
{
    // Базовые данные животного без потоков и GUI.
    public abstract class BaseAnimal
    {
        public string Species { get; set; } = string.Empty;
        public string AnimalClass { get; set; } = string.Empty;
        public double AverageWeight { get; set; }
        public List<string> Habitats { get; set; } = new();

        // Текущие координаты.
        public double X { get; set; }
        public double Y { get; set; }

        // Стратегия, отвечающая за перемещение.
        public IMovementStrategy? Movement { get; set; }

        // Вызывается симуляцией.
        public void Update(double dt)
        {
            Movement?.Move(this, dt);
        }
    }
}
