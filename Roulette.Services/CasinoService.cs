using Roulette.Core.Contracts;
using Roulette.Core.Models;

namespace Roulette.Services
{
    public class CasinoService

    {
        private readonly Func<int, IRouletteService> _rouletteFactory;
        public CasinoService(Func<int, IRouletteService> rouletteFactory)
        {
            _rouletteFactory = rouletteFactory;
        }


        public Task<BetResult> Play(int betOption, int betMoney, int balance,int chosenNumber)
        {
            var result = _rouletteFactory(betOption).Bet(betOption, betMoney, balance,chosenNumber);

            return result;
        }
    }
}
