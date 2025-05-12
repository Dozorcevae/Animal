using System.Threading;
using System.Threading.Tasks;
using Animals.Domain;

namespace Animals.Simulation
{
    // Если нужно управлять каждым животным отдельно.
    public class AnimalController
    {
        private readonly BaseAnimal _animal;
        private readonly int _tickMs;
        private CancellationTokenSource? _cts;

        public AnimalController(BaseAnimal animal, int tickMs = 50)
        {
            _animal = animal;
            _tickMs = tickMs;
        }

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
                _animal.Update(dt);
                await Task.Delay(_tickMs, token);
            }
        }
    }
}
