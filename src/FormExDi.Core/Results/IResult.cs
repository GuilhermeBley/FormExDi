namespace FormExDi.Core.Results
{
    /// <summary>
    /// Results a message with object or null if has error.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IResult<TResult>
        where TResult : class
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

        /// <summary>
        /// Result object if no has error, if has error, is null.
        /// </summary>
        TResult? Result { get; }
    }
}
