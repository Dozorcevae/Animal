using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Domain
{
    // DTO-класс для отображения в таблицах.
    public record AnimalModel(
        string Species,
        string AnimalClass,
        double AverageWeight,
        string Habitats
    );
}

