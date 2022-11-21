using AutoMapper;
using System.Data;

namespace FormExDi.Infrastructure.Repository;

public class BaseRepository
{
    private readonly IDbSession _dbSession;
    protected IDbConnection _dbConnection => _dbSession.Connection;
    protected IDbTransaction? _dbTransaction => _dbSession.Transaction;
    protected readonly IMapper _mapper;

    public BaseRepository(IDbSession dbSession, IMapper mapper)
    {
        _dbSession = dbSession;
        _mapper = mapper;
    }
}