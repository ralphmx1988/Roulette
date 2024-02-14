using Roulette.Core.Contracts;
using Roulette.Core.Models;

namespace Roulette.Services
{
    public class RedBlackService : IRouletteService
    {
        private readonly ISpinService _spinService;
        public RedBlackService(ISpinService spinService)
        {
            _spinService = spinService;
        }
        public async Task<BetResult> Bet(int betOption, int betMoney, int balance, int chosenNumber = 0, bool isOdd = false)
        {
            var result = new BetResult();
            var spinResult = await _spinService.Spin();

            switch (betOption)
            {
                case 1:
                case 4:
                    if (spinResult.Number % 2 is 0)
                    {
                        result.Balance = balance += (betMoney * 1);
                        result.IsWinner = true;
                        result.Message = "You Have Won :) You choose Even/Red Bet. Roulette result is Number : " +
                                         spinResult.Number + " color red";
                        break;
                    }

                    result.Balance = balance - betMoney;
                    result.Message = "You Have Lost :( You choose Even/Red Bet. Roulette result is Number : " +
                                     spinResult.Number + " color black";
                    break;

                case 2:
                case 3:
                    if (spinResult.Number % 2 is not 0)
                    {
                        result.Balance = balance += (betMoney * 1);
                        result.IsWinner = true;
                        result.Message = "You Have Won :) You choose Odd/Black Bet. Roulette result is Number : " +
                                         spinResult.Number + " color Black";
                        break;
                    }

                    result.Balance = balance - betMoney;
                    result.Message = "You Have Lost :( You choose Odd/Black Bet. Roulette result is Number : " +
                                     spinResult.Number + " color red";
                    break;

                default: throw new NotImplementedException();

            }
            return result;
        }
    }
}
