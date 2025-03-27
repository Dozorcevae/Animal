using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class AnimalCollection
    {
        private List<BaseAnimal> animals = new List<BaseAnimal>();

        public void Add(BaseAnimal animal) => animals.Add(animal);
        public void Remove(BaseAnimal animal) => animals.Remove(animal);
        public List<BaseAnimal> GetAll() => new List<BaseAnimal>(animals);
        public BaseAnimal GetAt(int index) => animals[index];
    }
}
