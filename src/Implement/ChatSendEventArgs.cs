namespace Hosihikari.Minecraft.Extension.Event.Implement;

public class ChatSendEventArgs : PlayerEventArgs
{
    internal ChatSendEventArgs(Hosihikari.Minecraft.Player player, string message) : base(player)
    {
        Message = message;
    }

    public string Message { get; }
}

public sealed class ChatSendBeforeEventArgs : ChatSendEventArgs
{
    internal ChatSendBeforeEventArgs(Hosihikari.Minecraft.Player player, string message) : base(player, message)
    {
    }

    public bool Cancel { get; }
}