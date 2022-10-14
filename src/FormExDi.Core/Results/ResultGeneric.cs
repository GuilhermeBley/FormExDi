using System.Net;

namespace FormExDi.Core.Results
{
    /// <summary>
    /// Internal implementation to <see cref="IResultGeneric{TResult}"/>
    /// </summary>
    /// <typeparam name="TResult">Validation type</typeparam>
    internal class ResultGeneric<TResult> : IResultGeneric<TResult>
        where TResult : class
    {
        public const char SepJoin = '\n';

        /// <summary>
        /// True : contains error, false : Don't contains.
        /// </summary>
        private bool _hasError { get; }

        /// <summary>
        /// Code
        /// </summary>
        private int _code { get; }

        /// <summary>
        /// <see cref="_messages"/> join
        /// </summary>
        private string _message => string.Join(SepJoin, _messages);

        /// <summary>
        /// Complements message
        /// </summary>
        private IEnumerable<string> _messages { get; } = Enumerable.Empty<string>();

        /// <summary>
        /// Result if don't has error
        /// </summary>
        private TResult? _result { get; }

        /// <inheritdoc cref="_code" path="*"/>
        public int Code => _code;

        /// <inheritdoc cref="_message" path="*"/>
        public string Message => _message;

        /// <inheritdoc cref="_result" path="*"/>
        public TResult? Result => _result;

        /// <inheritdoc cref="_hasError" path="*"/>
        public bool HasError => _hasError;

        /// <inheritdoc cref="_messages" path="*"/>
        public IEnumerable<string> Messages => _messages;

        private ResultGeneric(int code, TResult? result = null, params string[] messages)
        {
            _hasError = result is null;
            _code = code;
            _messages = messages;
            _result = result;
        }

        private ResultGeneric(HttpStatusCode code, TResult? result = null, params string[] messages) :
            this((int)code, result, messages)
        {
        }

        /// <summary>
        /// Return a new Result with a ok message and the object to return
        /// </summary>
        /// <param name="result">result</param>
        /// <returns>result with non nullable result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ResultGeneric<TResult> Ok(in TResult result)
        {
            if (result == null)
                throw new ArgumentNullException($"{typeof(TResult).Name} is null.");

            return new ResultGeneric<TResult>(HttpStatusCode.OK, result, "Ok");
        }

        /// <summary>
        /// Return a new Result with a bad message and the object to return null
        /// </summary>
        /// <param name="messages">complements messages of the error</param>
        /// <returns>result with nullable result</returns>
        public static ResultGeneric<TResult> Bad(params string[] messages)
        {
            return new ResultGeneric<TResult>(HttpStatusCode.BadRequest, null, messages);
        }
    }
}
