using System;
using System.Collections.Generic;
using System.Threading;

namespace Animals.Models
{
    public abstract class BaseAnimal
    {
        public string Species { get; set; }
        public string AnimalClass { get; set; }
        public double AverageWeigth { get; set; }
        public List<string> Habitats { get; set; }

        // координаты объекта
        public double X { get; set; }
        public double Y { get; set; }

        // границы для хаотичных животных – задаются из формы
        public static System.Drawing.Rectangle Boundary { get; set; } = new System.Drawing.Rectangle(0, 0, 500, 400);

        // Флаги для управления потоком
        protected bool stopRequested = false;
        protected bool isPaused = false;
        protected readonly object locker = new object();
        public Thread movementThread;

        // Абстрактный метод движения
        public abstract void Run();

        // Запуск потока
        public virtual void Start()
        {
            stopRequested = false;
            isPaused = false;
            movementThread = new Thread(Run);
            movementThread.IsBackground = true;
            movementThread.Start();
        }

        public virtual void Pause()
        {
            lock (locker)
            {
                isPaused = true;
            }
        }

        public virtual void Resume()
        {
            lock (locker)
            {
                isPaused = false;
                Monitor.PulseAll(locker);
            }
        }

        public virtual void Stop()
        {
            lock (locker)
            {
                stopRequested = true;
                isPaused = false;
                Monitor.PulseAll(locker);
            }
            if (movementThread != null && movementThread.IsAlive)
                movementThread.Join();
        }

        public BaseAnimal(string species, string animalClass, double averageWeigth, List<string> habitats)
        {
            if (averageWeigth <= 0)
                throw new ArgumentException("Вес должен быть положительным!");

            Species = species;
            AnimalClass = animalClass;
            AverageWeigth = averageWeigth;
            Habitats = habitats;
        }

        // Для вывода инфо можно добавить дополнительное свойство статуса
        public virtual string GetStatus()
        {
            if (stopRequested)
                return "Остановлен";
            if (isPaused)
                return "На паузе";
            return "Работает";
        }
    }
}
