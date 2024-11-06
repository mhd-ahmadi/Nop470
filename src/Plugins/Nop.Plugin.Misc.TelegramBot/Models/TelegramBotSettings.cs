using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.TelegramBot.Models;

public class TelegramBotSettings : ISettings
{
    public string? BotToken { get; set; }
    public long? ChatId { get; set; } // Optional: if you want to specify a default chat ID
}
