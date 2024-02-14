using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Roulette.Extensions;
using Roulette.Services;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.RouletteServiceConfig();
    })
    .Build();

var casino = host.Services.GetRequiredService<CasinoService>();

var moneyBalance = 0;
var amount = string.Empty;
var option = string.Empty;
var betOption = 0;
int betNumber = 0;
var betOptions = new List<string?>()
{
    "1","2","3","4","5","6","7","8","9","10"
};


Console.WriteLine("\n Welcome to the Roulette Game!");
Console.WriteLine("\n Your Current Balance is: " + moneyBalance);


recharge:
Console.WriteLine("\n Please please enter the money to your Balance:");
amount = Console.ReadLine();

if (!int.TryParse(amount, out moneyBalance))
{
    Console.WriteLine("\n You should enter a valid amount, press enter to try again or press esc to try again :(");
    goto recharge;
}


Console.WriteLine("Balance: " + "$" + moneyBalance);

play:
while (moneyBalance > 0)
{
    Console.WriteLine(" \nEnter your bet option");
    Console.WriteLine(" \n1. Red" +
                      " \n2. Black" +
                      " \n3. Odd" +
                      " \n4. Even" +
                      " \n5. Single Number" +
                      " \n6. 1st 12" +
                      " \n7. 2nd 12" +
                      " \n8. 3rd 12" +
                      " \n9. Low (1-18)" +
                      " \n10. High (19-36)"
                      
                     );
    option = Console.ReadLine();
    var validOption = betOptions.Contains(option);

    if (!validOption)
    {
        Console.WriteLine("\nYou entered an invalid bet option, please try again or press esc to Exit the game\n");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    betOption = Convert.ToInt32(option);

    if (betOption == 5)
    {
        Console.WriteLine("\nEnter the number to bet:\n");
        betNumber = Convert.ToInt32(Console.ReadLine());
    }

    bet:

    if (moneyBalance == 0)
    {
        Console.WriteLine("\nYou don't enough Balance");
        Console.WriteLine("\nPress enter to recharge ");
        goto recharge;
    }

    Console.WriteLine("\nEnter the amount to bet:\n");
    amount = Console.ReadLine();

    if (!int.TryParse(amount, out var betMoney))
    {
        Console.WriteLine("\n You should enter a valid amount, please try again or press esc to Exit the Game :(");
        goto bet;
    }




    if (betMoney > moneyBalance)
    {
        Console.WriteLine("\nYou don't enough Balance");
        Console.WriteLine("\nPress enter to try again or press esc to Exit the Game ");
        Console.ReadLine();
        goto bet;
    }




    var result = await casino.Play(betOption, betMoney, moneyBalance,betNumber );

    Console.WriteLine(result.Message);

    moneyBalance = result.Balance;

    Console.WriteLine("\nCurrent Balance:  "+moneyBalance +"\n");


    if (moneyBalance == 0)
    {
        Console.WriteLine("\nYou lost all your Balance");
        Console.WriteLine("\nPress enter to recharge or press esc to Exit ");
        Console.Read();
        goto recharge;
    }
    else
    {
        Console.WriteLine("\ndo you want to play again?, press enter to continue or press esc to Exit\n");
        Console.ReadLine();
        goto play;
    }


    Console.Clear();
}


await host.RunAsync();




