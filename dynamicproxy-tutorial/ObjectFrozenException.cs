using System.Runtime.Serialization;

namespace dynamicproxy_tutorial;

[Serializable]
public class ObjectFrozenException : Exception
{
    public ObjectFrozenException()
    {
    }

    public ObjectFrozenException(string? message) : base(message)
    {
    }

    public ObjectFrozenException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ObjectFrozenException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}