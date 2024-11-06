using Nop.Plugin.Misc.TelegramBot.Models;
using Telegram.Bot;

namespace Nop.Plugin.Misc.TelegramBot.Services;
public class TelegramBotService
{
    private readonly TelegramBotClient _botClient;
    public TelegramBotService(TelegramBotSettings settings)
    {
        if (string.IsNullOrEmpty(settings.BotToken))
            throw new ArgumentNullException(nameof(settings.BotToken));

        _botClient = new TelegramBotClient(settings.BotToken);
    }

    public Task SendMessageAsync(string messsage, long chatId)
    {
        return Task.CompletedTask;
        //await _botClient.SendTextMessageAsync(chatId, messsage);
    }

    public async Task SetWebhookAsync(string url)
    {
        await _botClient.SetWebhook(url);
    }

}
