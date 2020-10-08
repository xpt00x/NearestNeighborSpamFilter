using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories
{
    public interface IDataPointRepository
    {
        ICollection<DataPoint> GetAllDataPoints();
        ICollection<DataPoint> GetDataPointsByWord(string word);
        DataPoint GetDataPointById(int id);
        DataPoint GetDataPointsByClassification(Entities.Enums.Classification spam);


        DataPoint CreateOrUpdateDataPoint(DataPoint dataPoint);
        ICollection<DataPoint> CreateOrUpdateDataPoints(ICollection<DataPoint> dataPoints);


        void RemoveDataPoint(DataPoint dataPoint);
        void RemoveDataPoints(ICollection<DataPoint> dataPoint);
        void RemoveDataPointById(int id);
        void RemoveDataPointsById(ICollection<int> id);
        void RemoveDataPointByWord(string word);
        void RemoveDataPointsByWord(ICollection<string> words);

        void RemoveAllDataPoints();
        
    }
}
