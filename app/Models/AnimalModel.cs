using Animals.Models;

namespace Animals.Models
{
    // Обёртка для удобства, можно расширять.
    public class AnimalModel : BaseAnimal
    {
        public AnimalModel(BaseAnimal source)
        {
            Species = source.Species;
            Type = source.Type;
            AverageWeight = source.AverageWeight;
            Habitats = source.Habitats;
        }

        // Пустой конструктор для десериализации.
        public AnimalModel() { }

        // Данных о движении в модели нет — только факты.
        public override void Run() { }
    }
}
