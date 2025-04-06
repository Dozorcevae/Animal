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
        private double centerX;
        private double centerY;
        private double radius;  // Радиус окружности
        private double angle;   // Текущий угол в радианах
        private double omega;   // Угловая скорость (рад/сек)

        // Флаги и объекты для управления многопоточностью
        private bool stopRequested = false;
        private bool isPaused = false;
        private readonly object locker = new object();
        private Thread? movementThread;

        public CircleAnimal(
            string species,
            string name,
            double age,
            List<string> environment,
            double centerX,
            double centerY,
            double radius,
            double omega
        )
            : base(species, name, age, environment)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
            this.omega = omega;
            this.angle = 0.0;

            // Инициализируем X и Y (если BaseAnimal имеет такие поля/свойства)
            this.X = centerX + radius * Math.Cos(angle);
            this.Y = centerY + radius * Math.Sin(angle);
        }

        
        public override void Start()
        {
            stopRequested = false;
            isPaused = false;

            // Если поток ещё не создан или уже завершился, создаём заново
            if (movementThread == null || !movementThread.IsAlive)
            {
                movementThread = new Thread(MoveInCircleLoop);
                movementThread.Start();
            }
        }

        public override void Stop()
        {
            lock (locker)
            {
                stopRequested = true;
                // Снимаем паузу, если была, чтобы поток точно вышел из Wait
                isPaused = false;
                Monitor.PulseAll(locker);
            }
            movementThread?.Join();
            // Дожидаемся выхода из метода MoveInCircleLoop
        }

        public override void Pause()
        {
            lock (locker)
            {
                isPaused = true;
             
            }
        }

        public override void Resume()
        {
            lock (locker)
            {
                isPaused = false;
                Monitor.PulseAll(locker);
                // Будим поток, чтобы он продолжил движение.
            }
        }

       
        private void MoveInCircleLoop()
        {
            const int FRAME_INTERVAL_MS = 50;       // 50 мс между шагами
            double deltaTime = FRAME_INTERVAL_MS / 1000.0; // в секундах (0.05)

            while (!stopRequested)
            {
                // 1. Проверяем паузу
                lock (locker)
                {
                    while (isPaused && !stopRequested)
                    {
                        Monitor.Wait(locker); // поток "уснёт", пока не Resume() или Stop().
                    }
                }
                // Если во время паузы нажали Stop, выходим
                if (stopRequested)
                    break;

                // 2. Обновляем угол
                angle += omega * deltaTime;

                // 3. Пересчитываем координаты (если в BaseAnimal есть X и Y)
                X = centerX + radius * Math.Cos(angle);
                Y = centerY + radius * Math.Sin(angle);

                // 4. Можно обновить UI (например, form.Invoke(...) 
                //    или событие OnPositionChanged).
                //    UpdateUI(); // (Если нужно, делаем этот вызов)

                // 5. Небольшая пауза, чтобы не нагружать процессор
                Thread.Sleep(FRAME_INTERVAL_MS);
            }
        }
    }
}
