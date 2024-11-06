using Nop.Core;
using Nop.Plugin.Misc.TelegramBot.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.TelegramBot;

public class TelegramBotPlugin(ISettingService settingService, ILocalizationService localizationService, IWebHelper webHelper) : BasePlugin
{
    public override async Task InstallAsync()
    {
        //settings        
        await settingService.SaveSettingAsync(new TelegramBotSettings());

        //locals
        await localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Plugins.Misc.TelegramBot.Instructions"] = "ثبت سفارش از طریق تلگرام از این پلاگین قابل انجام است!",
            ["Plugins.Misc.TelegramBot.Fields.BotToken"] = "توکن بات",
            ["Plugins.Misc.TelegramBot.Fields.BotToken.Hint"] = "توکنی که توسط BotFather ساخته شده است.",
            ["Plugins.Misc.TelegramBot.Fields.ChatId"] = "شناسه چت",
            ["Plugins.Misc.TelegramBot.Fields.ChatId.Hint"] = "شناسه چت ادمین",
        });

        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        //settings
        await settingService.DeleteSettingAsync<TelegramBotSettings>();

        //locals
        await localizationService.DeleteLocaleResourcesAsync("Plugins.Misc.TelegramBot");

        await base.UninstallAsync();
    }

    public override string GetConfigurationPageUrl()
    {
        return $"{webHelper.GetStoreLocation()}Admin/TelegramBot/Configure";
    }
}
