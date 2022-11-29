using FormExDi.Application.UoW;
using FormExDi.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;


namespace FormExDi.Infrastructure.UoW;

/// <summary>
/// Manage connections and transactions
/// </summary>
internal class MySqlDbSession : IUnitOfWork, IDbSession
{
    private Guid _identifier { get; } = Guid.NewGuid();
    private DbConnection? _connection { get; set; }
    private DbTransaction? _transaction { get; set; }
    private Func<DbConnection> _createConnection { get; }

    public Guid IdSession => _identifier;
    public Guid IdUoW => _identifier;

    public IDbConnection Connection => _connection ?? throw new ArgumentNullException(nameof(Connection));
    public IDbTransaction? Transaction => _transaction;


    public MySqlDbSession(IOptions<ConnectionOptions> connectionOptions)
    {
        _createConnection = () =>
        {
            return new MySqlConnection(connectionOptions.Value.ConnectionString);
        };
    }

    public async Task<IUnitOfWork> BeginTransactionAsync()
    {
        await TryCreateAndOpenConnection();

        if (_connection is null)
            throw new ArgumentNullException(nameof(Connection));

        if (_transaction is null)
            _transaction = await _connection.BeginTransactionAsync();

        return this;
    }

    public void Dispose()
    {
        if (_transaction is not null)
        {
            _transaction.Dispose();
            _transaction = null;
        }

        if (_connection is not null)
        {
            _connection.Dispose();
            _connection = null;
        }
    }

    public async Task<IUnitOfWork> OpenConnectionAsync()
    {
        await TryCreateAndOpenConnection();
        return this;
    }

    public async Task SaveChangesAsync()
    {
        if (_transaction is null)
            return;

        try
        {
            await _transaction.CommitAsync();
        }
        catch
        {
            await _transaction.RollbackAsync();
            throw;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }

    private async Task TryCreateAndOpenConnection()
    {
        if (_connection is null)
        {
            _connection = _createConnection.Invoke();
            await _connection.OpenAsync();
        }
    }
}
