using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories
{
    public interface ITrainingPointRepository
    {
        ICollection<TrainingPoint> GetAllTrainingPoints();
        ICollection<TrainingPoint> GetTrainingPointsByWord(string word);
        TrainingPoint GetTrainingPointById(int id);
        TrainingPoint GetTrainingPointsByClassification(Entities.Enums.Classification spam);


        TrainingPoint CreateOrUpdateTrainingPoint(TrainingPoint TrainingPoint);
        ICollection<TrainingPoint> CreateOrUpdateTrainingPoints(ICollection<TrainingPoint> TrainingPoints);


        void RemoveTrainingPoint(TrainingPoint TrainingPoint);
        void RemoveTrainingPoints(ICollection<TrainingPoint> TrainingPoint);
        void RemoveTrainingPointById(int id);
        void RemoveTrainingPointsById(ICollection<int> id);
        void RemoveTrainingPointByWord(string word);
        void RemoveTrainingPointsByWord(ICollection<string> words);

        void RemoveAllTrainingPoints();
    }
}
