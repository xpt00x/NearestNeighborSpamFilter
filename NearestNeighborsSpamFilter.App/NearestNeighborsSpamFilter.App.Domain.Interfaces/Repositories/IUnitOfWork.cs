using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
