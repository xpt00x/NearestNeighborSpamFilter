using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        private BowDictionaryRepository _BowDictionaryRepository;
        private EmailRepository _emailRepository;
        #endregion

        #region Repository getters
        public DataPointRepository DataPointRepository
        {
            get
            {
                if (this._dataPointRepository == null)
                {
                    this._dataPointRepository = new DataPointRepository(_dbContext, _mapper);
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
                    this._trainingPointRepository = new TrainingPointRepository(_dbContext, _mapper);
                }
                return _trainingPointRepository;
            }
        }
        public BowDictionaryRepository BowDictionaryRepository
        {
            get
            {
                if (this._BowDictionaryRepository == null)
                {
                    this._BowDictionaryRepository = new BowDictionaryRepository(_dbContext, _mapper);
                }
                return _BowDictionaryRepository;
            }
        }
        public EmailRepository EmailRepository
        {
            get
            {
                if (this._emailRepository == null)
                {
                    this._emailRepository = new EmailRepository(_dbContext, _mapper);
                }
                return _emailRepository;
            }
        }
        #endregion

        private NnDbContext _dbContext { get; set; }
        private IMapper _mapper { get; set; }

        public UnitOfWork(ServiceProvider provider)
        {
            _dbContext = provider.GetRequiredService<NnDbContext>();
            this._mapper = provider.GetRequiredService<IMapper>();
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Rollback()
        {
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
