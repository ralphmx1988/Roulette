using Microsoft.Extensions.DependencyInjection;
using Roulette.Core.Contracts;
using Roulette.Helpers;
using Roulette.Services;

namespace Roulette.Extensions
{
    public static class ConfigServiceExtensions
    {
        public static void RouletteServiceConfig(this IServiceCollection services)
        {
            services.AddScoped<ISpinService, SpinService>();
            services.AddScoped<CasinoService>();
            services.AddScoped<SingleNumberService>();
            services.AddScoped<RedBlackService>();
            services.AddScoped<DozenService>();
            services.AddScoped<HighLowService>();


            services.AddTransient<Func<int, IRouletteService>>(serviceProvider => key =>
            {
                return (key switch
                {
                    BetTypes.SingleNumber => serviceProvider.GetService<SingleNumberService>(),
                    BetTypes.Red => serviceProvider.GetService<RedBlackService>(),
                    BetTypes.Black => serviceProvider.GetService<RedBlackService>(),
                    BetTypes.Odd => serviceProvider.GetService<RedBlackService>(),
                    BetTypes.Even => serviceProvider.GetService<RedBlackService>(),
                    BetTypes.First12 => serviceProvider.GetService<DozenService>(),
                    BetTypes.Second12 => serviceProvider.GetService<DozenService>(),
                    BetTypes.Third12 => serviceProvider.GetService<DozenService>(),
                    BetTypes.Low => serviceProvider.GetService<HighLowService>(),
                    BetTypes.High => serviceProvider.GetService<HighLowService>(),
                    _ => throw new NotImplementedException()
                })!;
            });
        }



    }

}

