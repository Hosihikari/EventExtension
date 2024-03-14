using Hosihikari.NativeInterop.Hook.ObjectOriented;
using Hosihikari.NativeInterop.Unmanaged;

namespace Hosihikari.Minecraft.Extension.Event.Implement;

internal sealed class PlayerJoinEvent()
    : HookBase<PlayerJoinEvent.HookDelegateType>(ServerNetworkHandler.Original._createNewPlayer)
{
    public delegate Reference<Hosihikari.Minecraft.Player> HookDelegateType(Reference<ServerNetworkHandler> handler,
        Reference<NetworkIdentifier> source,
        Reference<SubClientConnectionRequest> connectionRequest, /* enum SubClientId */ byte subId);

    public readonly Event<PlayerEventArgs> Event = new();

    protected override HookDelegateType HookDelegate => (handler, source, connectionRequest, subId) =>
    {
        Reference<Hosihikari.Minecraft.Player> result = Original(handler, source, connectionRequest, subId);
        PlayerEventArgs args = new(result.Target);
        Event.OnAfter(args);
        return result;
    };
}