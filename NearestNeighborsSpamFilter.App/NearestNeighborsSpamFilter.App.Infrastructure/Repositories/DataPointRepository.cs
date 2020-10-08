using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities.Enums;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using System.Collections.Generic;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class DataPointRepository : IDataPointRepository
    {
        private NnDbContext _context { get; set; }

        public DataPointRepository(NnDbContext context)
        {
            _context = context;
        }


        public ICollection<DataPoint> GetAllDataPoints()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<DataPoint> GetDataPointsByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public DataPoint GetDataPointById(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataPoint GetDataPointsByClassification(Classification spam)
        {
            throw new System.NotImplementedException();
        }

        public DataPoint CreateOrUpdateDataPoint(DataPoint dataPoint)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<DataPoint> CreateOrUpdateDataPoints(ICollection<DataPoint> dataPoints)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDataPoint(DataPoint dataPoint)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDataPoints(ICollection<DataPoint> dataPoint)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDataPointById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDataPointsById(ICollection<int> id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDataPointByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDataPointsByWord(ICollection<string> words)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAllDataPoints()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
