using Hosihikari.Minecraft.Extension.Event.Implement;

namespace Hosihikari.Minecraft.Extension.Event;

public static class Player
{
    private static readonly Lazy<PlayerJoinEvent> s_joinHook = new(() =>
    {
        PlayerJoinEvent hook = new();
        hook.Install();
        return hook;
    });

    private static readonly Lazy<PlayerLeaveEvent> s_leaveHook = new(() =>
    {
        PlayerLeaveEvent hook = new();
        hook.Install();
        return hook;
    });

    private static readonly Lazy<ChatSendEvent> s_chatHook = new(() =>
    {
        ChatSendEvent hook = new();
        hook.Install();
        return hook;
    });

    public static Event<PlayerEventArgs> Join => s_joinHook.Value.Event;
    public static BeforeEvent<PlayerEventArgs, PlayerLeftEventArgs> Leave => s_leaveHook.Value.Event;
    public static BeforeEvent<ChatSendBeforeEventArgs, ChatSendEventArgs> Chat => s_chatHook.Value.Event;
}