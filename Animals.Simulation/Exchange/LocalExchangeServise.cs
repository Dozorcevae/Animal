using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Domain;

namespace Animals.Simulation.Exchange
{
    // Локальная реализация (без сети)
    public sealed class LocalExchangeService : IAnimalExchangeService
    {
        public void ExchangeByClass(AnimalCollection a, AnimalCollection b, AnimalClass cls)
        {
            var fromA = a.GetByClass(cls).ToList();
            var fromB = b.GetByClass(cls).ToList();

            a.RemoveByClass(cls);
            b.RemoveByClass(cls);

            a.AddRange(fromB);
            b.AddRange(fromA);
        }
    }
}
