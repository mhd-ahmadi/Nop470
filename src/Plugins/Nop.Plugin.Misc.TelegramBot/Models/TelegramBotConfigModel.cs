using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.TelegramBot.Models;
public class TelegramBotConfigModel
{
    [NopResourceDisplayName("Plugins.Misc.TelegramBot.Fields.BotToken")]
    public string? BotToken { get; set; }

    [NopResourceDisplayName("Plugins.Misc.TelegramBot.Fields.ChatId")]
    public long? ChatId { get; set; }
}
