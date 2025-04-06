using System;
using System.Collections.Generic;

namespace Animals.Models{
    public abstract class BaseAnimal{
        public string Species {get; set; }
        public string Class {get; set; }
        public double AverageWeigth {get; set; }
        public List<string> Habitats {get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public virtual void Stop() { }
        public virtual void Pause() { }
        public virtual void Resume() { }
        public virtual void Start() { }




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