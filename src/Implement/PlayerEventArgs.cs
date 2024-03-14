namespace Hosihikari.Minecraft.Extension.Event.Implement;

public class PlayerEventArgs : EventArgs
{
    internal PlayerEventArgs(Hosihikari.Minecraft.Player player)
    {
        Player = player;
    }

    public Hosihikari.Minecraft.Player Player { get; }
}