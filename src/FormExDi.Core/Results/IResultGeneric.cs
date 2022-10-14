namespace FormExDi.Core.Results
{
    /// <summary>
    /// Results a message with object or null if has error.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IResultGeneric<TResult> : IResult
        where TResult : class
    {
        /// <summary>
        /// Result object if no has error, if has error, is null.
        /// </summary>
        TResult? Result { get; }

        /// <summary>
        /// Gets result or throw new null argument exception
        /// </summary>
        /// <returns>TResult</returns>
        /// <exception cref="ArgumentNullException"></exception>
        TResult GetResult();
    }
}
