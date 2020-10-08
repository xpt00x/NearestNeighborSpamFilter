using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db
{
    public interface INnDbContext : IDisposable
    {
        NnDbContext Instance { get; }
    }
}
