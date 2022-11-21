using System.Data;

namespace FormExDi.Infrastructure.Repository;

public class BaseRepository
{
    private readonly IDbSession _dbSession;
    protected IDbConnection _dbConnection => _dbSession.Connection;
    protected IDbTransaction? _dbTransaction => _dbSession.Transaction;

    public BaseRepository(IDbSession dbSession)
        => _dbSession = dbSession;
}