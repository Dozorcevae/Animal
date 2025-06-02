using System.Collections.Generic;
using System.Linq;

namespace Animals.Domain
{
    public static class AnimalCollectionExtensions
    {
        // Все животные выбранного класса
        public static IEnumerable<BaseAnimal>
            GetByClass(this AnimalCollection col, AnimalClass cls) =>
                col.Where(a => a.AnimalClass == cls);

        // Удалить всех животных выбранного класса
        public static void RemoveByClass(this AnimalCollection col, AnimalClass cls)
        {
            foreach (var a in col.GetByClass(cls).ToList()) col.Remove(a);
        }

        // Добавить диапазон
        public static void AddRange(this AnimalCollection col, IEnumerable<BaseAnimal> src)
        {
            foreach (var a in src) col.Add(a);
        }
    }
}
