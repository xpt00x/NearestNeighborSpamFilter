using AutoMapper;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities.Enums;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;
using System.Collections.Generic;
using System.Linq;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class TrainingPointRepository : ITrainingPointRepository
    {
        public TrainingPointRepository(NnDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private IMapper _mapper { get; }
        private NnDbContext _dbContext { get; }

        public TrainingPoint CreateOrUpdateTrainingPoint(TrainingPoint trainingPoint)
        {
            BowDictionary pair = _dbContext.BowDictionary.Where(w => w.Word.Equals(trainingPoint.Word)).FirstOrDefault();
            TrainingPoints point = _mapper.Map<TrainingPoints>(trainingPoint);
            point.IdWord = pair.Id;
            _dbContext.Add(point);
            return trainingPoint;
        }

        public ICollection<TrainingPoint> CreateOrUpdateTrainingPoints(ICollection<TrainingPoint> TrainingPoints)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<TrainingPoint> GetAllTrainingPoints()
        {
            throw new System.NotImplementedException();
        }

        public TrainingPoint GetTrainingPointById(int id)
        {
            throw new System.NotImplementedException();
        }

        public TrainingPoint GetTrainingPointsByClassification(Classification spam)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<TrainingPoint> GetTrainingPointsByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAllTrainingPoints()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTrainingPoint(TrainingPoint TrainingPoint)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTrainingPointById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTrainingPointByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTrainingPoints(ICollection<TrainingPoint> TrainingPoint)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTrainingPointsById(ICollection<int> id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTrainingPointsByWord(ICollection<string> words)
        {
            throw new System.NotImplementedException();
        }
    }
}
