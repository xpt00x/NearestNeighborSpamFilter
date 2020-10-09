using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Tests.Repositories
{
    public class SharedSetup
    {
        protected NnDbContext nnDbContext = new NnDbContext();
        public SharedSetup()
        {
            //var options = new DbContextOptionsBuilder<NnDbContext>().UseInMemoryDatabase(databaseName: "NNSPAMFILTER").Options;
        }
    }
}
