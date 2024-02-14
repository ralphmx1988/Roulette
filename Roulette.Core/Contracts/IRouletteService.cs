using Roulette.Core.Models;

namespace Roulette.Core.Contracts
{
    public interface IRouletteService
    {
        Task<BetResult> Bet(int betOption, int betMoney, int balance, int chosenNumber = 0, bool isOdd = false);
    }
}
