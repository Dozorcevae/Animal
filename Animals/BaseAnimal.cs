using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models{
    public abstract class BaseAnimal{
        public string Species {get; set; }
        public string Class {get; set; }
        public double AverageWeigth {get; set; }
        public List<string> Habitats {get; set; }
        //коорддинаты объектов
        public double X { get; set; }
        public double Y { get; set; }
        // границы объектов для Хаотичных животных
        public static Rectangle Boundary { get; set; } = new Rectangle(0, 0, 500, 400);

        // поля для управления потоком 
        protected bool stopRequested = false;
        protected bool isPaused = false;
        protected readonly object locker = new object();
        protected Thread movementThread;

        //основной цикл движения
        public abstract void Run();

        protected virtual void Start()
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
        
        public BaseAnimal(string species, string Animalclass, double averageweigth, List<string> habitats){

            if (averageweigth <= 0)
                throw new InvalidWeigthException("Вес должен быть положительным!");

        Species = species;
        Class = Animalclass;
        AverageWeigth = averageweigth;
        Habitats = habitats;
    }

    public virtual string GetInfo()
    {
            return $"Вид: {Species}, Класс: {Class}, Вес: {AverageWeigth} кг.";
    }
    //public abstract string MakeSoundOfAnimal();
    }
}