using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using Animals.Domain;

namespace Animals.Simulation
{
    // Общая петля симуляции.
    public class SimulationManager : IDisposable
    {
        private readonly List<BaseAnimal> _animals = new();
        private CancellationTokenSource? _cts;
        private readonly int _tickMs;

        public SimulationManager(int tickMs = 50) => _tickMs = tickMs;

        public void Add(BaseAnimal a) => _animals.Add(a);

        public IReadOnlyList<BaseAnimal> Snapshot() => _animals.AsReadOnly();

        public void Start()
        {
            if (_cts != null) return;
            _cts = new CancellationTokenSource();
            Task.Run(() => Loop(_cts.Token));
        }

        public void Stop()
        {
            _cts?.Cancel();
            _cts = null;
        }

        private async Task Loop(CancellationToken token)
        {
            var dt = _tickMs / 1000.0;
            while (!token.IsCancellationRequested)
            {
                foreach (var a in _animals) a.Update(dt);
                await Task.Delay(_tickMs, token);
            }
        }

        public void Dispose() => Stop();
    }
}
