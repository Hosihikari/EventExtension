using Hosihikari.NativeInterop.Hook.ObjectOriented;
using Hosihikari.NativeInterop.Unmanaged;
using Hosihikari.NativeInterop.Unmanaged.STL;
using System.Runtime.InteropServices;

namespace Hosihikari.Minecraft.Extension.Event.Implement;

internal sealed class ChatSendEvent()
    : HookBase<ChatSendEvent.HookDelegateType>(ServerNetworkHandler.Original._displayGameMessage)
{
    public delegate void HookDelegateType(Reference<ServerNetworkHandler> handler,
        Reference<Hosihikari.Minecraft.Player> player, Reference<ChatEvent> chatEvent);

    public readonly BeforeEvent<ChatSendBeforeEventArgs, ChatSendEventArgs> Event = new();

    protected override HookDelegateType HookDelegate => (handler, player, chatEvent) =>
    {
        StdString message = Marshal.PtrToStructure<StdString>(chatEvent.Target.Pointer);
        ChatSendBeforeEventArgs args = new(player.Target, message.ToString());
        Event.OnBefore(args);
        if (args.Cancel)
        {
            return;
        }

        Original(handler, player, chatEvent);
        ChatSendEventArgs afterArgs = new(player.Target, message.ToString());
        Event.OnAfter(afterArgs);
    };
}