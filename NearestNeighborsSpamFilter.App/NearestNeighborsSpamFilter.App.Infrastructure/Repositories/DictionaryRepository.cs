

using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        public DictionaryRepository(NnDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public NnDbContext DbContext { get; }
    }
}
