using System.Runtime.Serialization;

namespace dynamicproxy_tutorial;

[Serializable]
public class NotFreezableObjectException : Exception
{
    private object freezable;

    public NotFreezableObjectException()
    {
    }

    public NotFreezableObjectException(object freezable)
    {
        this.freezable = freezable;
    }

    public NotFreezableObjectException(string? message) : base(message)
    {
    }

    public NotFreezableObjectException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NotFreezableObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}