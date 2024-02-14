using Roulette.Core.Contracts;
using Roulette.Core.Models;

namespace Roulette.Services
{
    public class DozenService : IRouletteService
    {
        private readonly ISpinService _spinService;

        public DozenService(ISpinService spinService)
        {
            _spinService = spinService;
        }
        public async Task<BetResult> Bet(int betOption, int betMoney, int balance, int chosenNumber = 0, bool isOdd = false)
        {
            {
                var result = new BetResult();
                var spinResult = await _spinService.Spin();

                switch (betOption)
                {
                    case 6:
                        if (spinResult.Number is >= 1 and <= 12)
                        {
                            result.Balance = balance += (betMoney * 2);
                            result.IsWinner = true;
                            result.Message = "You Have Won :) You choose 1st 12 bet. Roulette result is Number : " +
                                             spinResult.Number ;
                            break;
                        }

                        result.Balance = balance - betMoney;
                        result.Message = "You Have Lost :( You choose 1st 12 bet Bet. Roulette result is Number : " +
                                         spinResult.Number;
                        break;

                    case 7:
                        if (spinResult.Number is >= 13 and <= 24)
                        {
                            result.Balance = balance += (betMoney * 2);
                            result.IsWinner = true;
                            result.Message = "You Have Won :) You choose 2nd 12, Bet. Roulette result is Number : " +
                                             spinResult.Number;
                            break;
                        }

                        result.Balance = balance - betMoney;
                        result.Message = "You Have Lost :( You choose 2nd 12, Bet. Roulette result is Number : " +
                                         spinResult.Number;
                        break;

                    case 8:
                        if (spinResult.Number is >= 25 and <= 36)
                        {
                            result.Balance = balance += (betMoney * 2);
                            result.IsWinner = true;
                            result.Message = "You Have Won :) You choose 3rd 12, Bet. Roulette result is Number : " +
                                             spinResult.Number;
                            break;
                        }

                        result.Balance = balance - betMoney;
                        result.Message = "You Have Lost :( You choose 3rd 12, Bet. Roulette result is Number : " +
                                         spinResult.Number;
                        break;

                    default: throw new NotImplementedException();

                }

                return result;
            }
        }
    }
}
