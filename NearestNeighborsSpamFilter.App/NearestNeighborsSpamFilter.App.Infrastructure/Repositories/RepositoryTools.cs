using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories.Tools
{
    public static class RepositoryTools
    {
        
        public static int? GetWordIdForTrainingPoint(INnDbContext nnDbContext, TrainingPoint point) {
            BowDictionary word = nnDbContext.Instance.BowDictionary.FirstOrDefault(dict => dict.Word == point.Word);
            return word?.Id;
        }
            
        public static Dictionary<TrainingPoint,int> GetWordIdForTrainingPoints(INnDbContext nnDbContext, ICollection<TrainingPoint> point)
        {
            return nnDbContext.Instance.BowDictionary.Join(point, d => d.Word, p => p.Word, (d, p) => new KeyValuePair<TrainingPoint, int>(p, d.Id)).ToDictionary(k => k.Key, d => d.Value);
        }
    }
}
