using Roulette.Core.Contracts;
using Roulette.Core.Models;

namespace Roulette.Services
{
    public class SingleNumberService : IRouletteService
    {
        private readonly ISpinService _spinService;
        public SingleNumberService(ISpinService spinService)
        {
            _spinService = spinService;
        }
        public async Task<BetResult> Bet(int betOption, int betMoney, int balance, int chosenNumber = 0, bool isOdd = false)
        {
            var result = new BetResult();
            var spinResult = await _spinService.Spin();

            if (spinResult.Number == chosenNumber)
            {
                result.Balance = balance += (betMoney * 35);
                result.IsWinner = true;
                result.Message = "You Have Won :) You choose Number: " + chosenNumber +
                                 " Roulette result is Number : " + spinResult.Number;


            }
            else
            {

                result.Balance = balance - betMoney;
                result.Message = "You Have Lost :( You choose Number: " + chosenNumber +
                                 " Roulette result is Number : " + spinResult.Number;

            }

            return result;
        }
    }
}
