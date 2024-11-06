using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.TelegramBot.Models;
using Nop.Services.Configuration;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.TelegramBot.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
[AutoValidateAntiforgeryToken]
public class TelegramBotController : BasePluginController
{
    private readonly ISettingService _settingService;
    private readonly IPermissionService _permissionService;
    private readonly INotificationService _notificationService;

    public TelegramBotController(ISettingService settingService, IPermissionService permissionService, INotificationService notificationService)
    {
        _settingService = settingService;
        _permissionService = permissionService;
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> Configure()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePlugins))
            return AccessDeniedView();

        var settings = await _settingService.LoadSettingAsync<TelegramBotSettings>();
        var model = new TelegramBotConfigModel
        {
            BotToken = settings.BotToken,
            ChatId = settings.ChatId
        };
        return View("~/Plugins/Misc.TelegramBot/Views/Configure.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> Configure(TelegramBotConfigModel model)
    {
        if (!ModelState.IsValid)
            return await Configure();

        var settings = await _settingService.LoadSettingAsync<TelegramBotSettings>();
        settings.BotToken = model.BotToken;
        settings.ChatId = model.ChatId;
        await _settingService.SaveSettingAsync(settings);

        await _settingService.ClearCacheAsync();

        _notificationService.SuccessNotification("Settings saved successfully.");
        return await Configure();
    }
}
