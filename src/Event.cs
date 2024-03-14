namespace Hosihikari.Minecraft.Extension.Event;

public class Event<T> where T : EventArgs
{
    internal Event()
    {
    }
    
    public event EventHandler<T>? After;

    internal void OnAfter(T args)
    {
        After?.Invoke(this, args);
    }
}

public sealed class BeforeEvent<TBefore, TAfter> : Event<TAfter>
    where TAfter : EventArgs
    where TBefore : EventArgs
{
    internal BeforeEvent()
    {
    }

    public event EventHandler<TBefore>? Before;

    internal void OnBefore(TBefore args)
    {
        Before?.Invoke(this, args);
    }
}