using System.Runtime.Serialization;

namespace Fhi.ClientCredentialsKeypairs;

[Serializable]
public class InvalidApiNameException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    public InvalidApiNameException() { }
    public InvalidApiNameException(string message) : base(message) { }
    public InvalidApiNameException(string message, Exception inner) : base(message, inner) { }

    protected InvalidApiNameException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class ConfigurationException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    public ConfigurationException()
    {
    }

    public ConfigurationException(string message) : base(message)
    {
    }

    public ConfigurationException(string message, Exception inner) : base(message, inner)
    {
    }

    protected ConfigurationException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class TokenRequestFailedException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    public TokenRequestFailedException()
    {
    }

    public TokenRequestFailedException(string message) : base(message)
    {
    }

    public TokenRequestFailedException(string message, Exception inner) : base(message, inner)
    {
    }

    protected TokenRequestFailedException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}

