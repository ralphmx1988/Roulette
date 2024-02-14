using Roulette.Core.Contracts;
using Roulette.Core.Models;

namespace Roulette.Services
{
    public class SpinService : ISpinService
    {
        private List<RouletteItem> RouletteSlots { get; set; }

        public SpinService()
        {
            RouletteSlots = new List<RouletteItem>
            {
                new() { Number = 0 },
                new() { Number = -1 },
                new() { Number = 1, IsOdd = true },
                new() { Number = 2 },
                new() { Number = 3, IsOdd = true },
                new() { Number = 4 },
                new() { Number = 5, IsOdd = true },
                new() { Number = 6 },
                new() { Number = 7, IsOdd = true },
                new() { Number = 8 },
                new() { Number = 9, IsOdd = true },
                new() { Number = 10 },
                new() { Number = 11, IsOdd = true },
                new() { Number = 12 },
                new() { Number = 13, IsOdd = true },
                new() { Number = 14 },
                new() { Number = 15, IsOdd = true },
                new() { Number = 16 },
                new() { Number = 17, IsOdd = true },
                new() { Number = 18 },
                new() { Number = 19, IsOdd = true },
                new() { Number = 20 },
                new() { Number = 21, IsOdd = true },
                new() { Number = 22 },
                new() { Number = 23, IsOdd = true },
                new() { Number = 24 },
                new() { Number = 25, IsOdd = true },
                new() { Number = 26 },
                new() { Number = 27, IsOdd = true },
                new() { Number = 28, },
                new() { Number = 29, IsOdd = true },
                new() { Number = 30 },
                new() { Number = 31, IsOdd = true },
                new() { Number = 32 },
                new() { Number = 33, IsOdd = true },
                new() { Number = 34 },
                new() { Number = 35, IsOdd = true },
                new() { Number = 36 }
            };
        }

        public async Task<RouletteItem> Spin(){
            var random = new Random();
            var index = random.Next(RouletteSlots.Count);

            return RouletteSlots[index];
        }

    }
}