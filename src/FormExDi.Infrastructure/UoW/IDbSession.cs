using System.Data;

namespace FormExDi.Infrastructure.UoW
{
    /// <summary>
    /// Provides a session connection
    /// </summary>
    public interface IDbSession
    {
        /// <summary>
        /// Id
        /// </summary>
        Guid IdSession { get; }

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
