using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Animals.Domain;

// Интерфейс стратегии перемещения.
namespace Animals.Domain.Interfaces
{
    public interface IMovementStrategy
    {
        // Двигает animal на dt секунд.
        void Move(BaseAnimal animal, double dt);
    }
}
