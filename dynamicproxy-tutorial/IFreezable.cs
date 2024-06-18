namespace dynamicproxy_tutorial;

public interface IFreezable
{
    bool IsFrozen { get; }
    void Freeze();
}
