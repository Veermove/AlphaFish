[System.Serializable]
public class LegalMoveException : System.Exception
{
    public LegalMoveException() { }
    public LegalMoveException(string message) : base(message) { }
    public LegalMoveException(string message, System.Exception inner) : base(message, inner) { }
    protected LegalMoveException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
