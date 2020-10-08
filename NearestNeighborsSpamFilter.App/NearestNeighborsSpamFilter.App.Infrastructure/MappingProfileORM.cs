using AutoMapper;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class MappingProfileORM : Profile
    {
        public MappingProfileORM() {
            CreateMap<TrainingPoint, TrainingPoints>();
            CreateMap<TrainingPoints, TrainingPoint>();
            CreateMap<BowDictionary, BowDictionaryPair>();
            CreateMap<BowDictionaryPair, BowDictionary>();
        }
    }
}