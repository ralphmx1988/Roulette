using Roulette.Core.Contracts;
using Roulette.Core.Models;

namespace Roulette.Services
{
    public class HighLowService : IRouletteService
    {
        private readonly ISpinService _spinService;

        public HighLowService(ISpinService spinService)
        {
            _spinService = spinService;
        }

        public async Task<BetResult> Bet(int betOption, int betMoney, int balance, int chosenNumber = 0, bool isOdd = false)
        {
            var result = new BetResult();
            var spinResult = await _spinService.Spin();

            switch (betOption)
            {
                case 9:
                    if (spinResult.Number is >= 1 and <= 18)
                    {
                        result.Balance = balance += (betMoney * 1);
                        result.IsWinner = true;
                        result.Message = "You Have Won :) You choose low bet. Roulette result is Number : " +
                                         spinResult.Number + " Low";
                        break;
                    }

                    result.Balance = balance - betMoney;
                    result.Message = "You Have Lost :( You choose Low Bet. Roulette result is Number : " +
                                     spinResult.Number + " High";
                    break;

                case 10:
                    if (spinResult.Number is >=19 and <=36)
                    {
                        result.Balance = balance += (betMoney * 1);
                        result.IsWinner = true;
                        result.Message = "You Have Won :) You choose High Bet. Roulette result is Number : " +
                                         spinResult.Number + " high";
                        break;
                    }

                    result.Balance = balance - betMoney;
                    result.Message = "You Have Lost :( You choose High Bet. Roulette result is Number : " +
                                     spinResult.Number + " Low";
                    break;

                default: throw new NotImplementedException();

            }

            return result;
        }
    }
}

