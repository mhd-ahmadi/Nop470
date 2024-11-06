using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Misc.TelegramBot.Infrastructure;
public class TelegramRouteProvider : IRouteProvider
{
    public int Priority => 1;

    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(TelegramBotDefaults.ConfigurationRouteName, "Plugins/Misc.TelegramBot/Configure",
            new { controller = "TelegramBot", action = "Configure", area = AreaNames.ADMIN });
    }
}
