namespace Hosihikari.Minecraft.Extension.Event.Implement;

public sealed class PlayerLeftEventArgs : EventArgs
{
    internal PlayerLeftEventArgs(Hosihikari.Minecraft.Player player)
    {
        // Id = player.Xuid;
        // Name = player.Name;
    }

    public string Id { get; }
    public string Name { get; }
}