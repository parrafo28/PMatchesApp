namespace PMatches.Infrastructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
