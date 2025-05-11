using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Animals.Models
{
    // Базовый класс с минимальным набором для лаборатории.
    public abstract class BaseAnimal
    {
        public string Species { get; set; } = string.Empty;           // вид
        public AnimalType Type { get; set; }                          // категория
        public double AverageWeight { get; set; }                     // средний вес
        public List<string> Habitats { get; set; } = new();           // места обитания

        // Координаты для визуализации движения.
        public double X { get; set; }
        public double Y { get; set; }
        public static Rectangle Boundary { get; set; } = new(0, 0, 500, 400);

        protected bool stopRequested;
        protected bool isPaused;
        protected readonly object locker = new();

        public Thread? MovementThread { get; private set; }

        // Абстрактное движение.
        public abstract void Run();

        public void Start()
        {
            stopRequested = false;
            MovementThread = new Thread(Run) { IsBackground = true };
            MovementThread.Start();
        }

        public void Stop()
        {
            lock (locker) stopRequested = true;
        }

        public string GetInfo() =>
            $"{Species} ({Type})  {AverageWeight:F1} кг  [{string.Join(", ", Habitats)}]";
    }
}
