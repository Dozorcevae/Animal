using System.Collections.Generic;
using System.Linq;
using Animals.Models;

namespace Animals.Models
{
    public class AnimalCollection
    {
        private readonly List<AnimalModel> animals = new();

        public void Add(AnimalModel a) => animals.Add(a);
        public void Remove(AnimalModel a) => animals.Remove(a);
        public IReadOnlyList<AnimalModel> GetAll() => animals;
        public AnimalModel? GetAt(int i) => i >= 0 && i < animals.Count ? animals[i] : null;

        // Возвращает и удаляет всех животных данного типа.
        public List<AnimalModel> ExtractByType(AnimalType type)
        {
            var group = animals.Where(a => a.Type == type).ToList();
            animals.RemoveAll(a => a.Type == type);
            return group;
        }

        public void AddRange(IEnumerable<AnimalModel> list) => animals.AddRange(list);
    }
}
