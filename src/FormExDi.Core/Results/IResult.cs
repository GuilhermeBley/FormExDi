namespace FormExDi.Core.Results
{
    /// <summary>
    /// Results a message with object or null if has error.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// True : contains error, false : Don't contains.
        /// </summary>
        bool HasError { get; }

        /// <summary>
        /// Status
        /// </summary>
        int Code { get; }

        /// <summary>
        /// <see cref="Messages"/> join
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Messages complement, normally this is used when has error
        /// </summary>        
        IEnumerable<string> Messages { get; }
    }
}
