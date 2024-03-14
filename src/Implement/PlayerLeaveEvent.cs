using Hosihikari.NativeInterop.Hook.ObjectOriented;
using Hosihikari.NativeInterop.Unmanaged;

namespace Hosihikari.Minecraft.Extension.Event.Implement;

internal sealed class PlayerLeaveEvent() : HookBase<PlayerLeaveEvent.HookDelegateType>(ServerPlayer.Original.Disconnect)
{
    public delegate void HookDelegateType(Reference<Hosihikari.Minecraft.Player> player);

    public readonly BeforeEvent<PlayerEventArgs, PlayerLeftEventArgs> Event = new();

    protected override HookDelegateType HookDelegate => player =>
    {
        PlayerEventArgs args = new(player.Target);
        PlayerLeftEventArgs afterArgs = new(player.Target);
        Event.OnBefore(args);
        Original(player);
        Event.OnAfter(afterArgs);
    };
}