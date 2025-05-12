using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Animals.Domain
{
    // Упрощённая коллекция с базовыми операциями.
    public class AnimalCollection : IEnumerable<BaseAnimal>
    {
        private readonly List<BaseAnimal> _animals = new();

        public void Add(BaseAnimal animal) => _animals.Add(animal);

        public bool Remove(BaseAnimal animal) => _animals.Remove(animal);

        public BaseAnimal ElementAt(int index) => _animals[index];

        public int Count => _animals.Count;

        public IEnumerator<BaseAnimal> GetEnumerator() => _animals.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
