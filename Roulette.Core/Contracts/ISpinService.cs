using Roulette.Core.Models;

namespace Roulette.Core.Contracts
{
    public interface ISpinService
    {
        Task<RouletteItem> Spin();
    }
}
