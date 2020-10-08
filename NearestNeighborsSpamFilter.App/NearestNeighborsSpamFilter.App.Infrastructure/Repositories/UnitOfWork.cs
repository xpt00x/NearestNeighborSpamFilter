using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Repository fields
        private DataPointRepository _dataPointRepository;
        private TrainingPointRepository _trainingPointRepository;
        private DictionaryRepository _dictionaryRepository;
        private EmailRepository _emailRepository;
        #endregion

        #region Repository getters
        public DataPointRepository DataPointRepository
        {
            get
            {
                if (this._dataPointRepository == null)
                {
                    this._dataPointRepository = new DataPointRepository(_dbContext);
                }
                return _dataPointRepository;
            }
        }
        public TrainingPointRepository TrainingPointRepository
        {
            get
            {
                if (this._trainingPointRepository == null)
                {
                    this._trainingPointRepository = new TrainingPointRepository(_dbContext);
                }
                return _trainingPointRepository;
            }
        }
        public DictionaryRepository DictionaryRepository
        {
            get
            {
                if (this._dictionaryRepository == null)
                {
                    this._dictionaryRepository = new DictionaryRepository(_dbContext);
                }
                return _dictionaryRepository;
            }
        }
        public EmailRepository EmailRepository
        {
            get
            {
                if (this._emailRepository == null)
                {
                    this._emailRepository = new EmailRepository(_dbContext);
                }
                return _emailRepository;
            }
        }
        #endregion

        private NnDbContext _dbContext { get; set; } = new NnDbContext();
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Rollback() {
            this.Dispose();
        }

        #region GC Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion
    }
}
