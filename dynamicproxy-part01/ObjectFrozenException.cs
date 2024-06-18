using System.Runtime.Serialization;

namespace dynamicproxy_part01;

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