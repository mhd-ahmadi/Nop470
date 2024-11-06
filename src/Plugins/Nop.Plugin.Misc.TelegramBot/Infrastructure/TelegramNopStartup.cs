using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.TelegramBot.Services;

namespace Nop.Plugin.Misc.TelegramBot.Infrastructure;
internal class TelegramNopStartup : INopStartup
{
    public int Order => 2000;

    public void Configure(IApplicationBuilder application)
    {
        
    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<TelegramBotService>();
    }
}
