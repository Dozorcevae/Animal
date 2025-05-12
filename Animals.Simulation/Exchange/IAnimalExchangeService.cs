using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Domain;

namespace Animals.Simulation.Exchange
{
    public interface IAnimalExchangeService
    {
        // Поменять всех животных класса cls между коллекциями A и B
        void ExchangeByClass(AnimalCollection a, AnimalCollection b, AnimalClass cls);
    }
}
