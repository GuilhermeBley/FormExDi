using System.Data;

namespace FormExDi.Infrastructure.UoW
{
    public interface IDbSession
    {
        /// <summary>
        /// Avaliable connection
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Avaliable Transaction
        /// </summary>
        IDbTransaction? Transaction { get; }
    }
}
