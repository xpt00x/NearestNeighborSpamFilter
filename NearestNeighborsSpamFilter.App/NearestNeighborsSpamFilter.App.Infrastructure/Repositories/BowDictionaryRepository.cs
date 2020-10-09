

using AutoMapper;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;
using System.Collections.Generic;
using System.Linq;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class BowDictionaryRepository : IBowDictionaryRepository
    {
        public BowDictionaryRepository(NnDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private NnDbContext _dbContext { get; }
        private IMapper _mapper { get; }

        public BowDictionaryPair CreateOrUpdateBowDictionaryPair(BowDictionaryPair pair)
        {
            //GetWordIdForTrainingPoint();
            //    _dbContext.BowDictionary.Add(item);
            //return pair;
            throw new System.NotImplementedException();
        }

        public ICollection<BowDictionaryPair> CreateOrUpdateBowDictionaryPairs(ICollection<BowDictionaryPair> pairs)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<BowDictionaryPair> GetAllBowDictionaryPairs()
        {
            throw new System.NotImplementedException();
        }

        public BowDictionaryPair GetBowDictionaryPairById(int it)
        {
            throw new System.NotImplementedException();
        }

        public BowDictionaryPair GetBowDictionaryPairByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAllBowDictionaryPairs()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBowDictionaryPair(BowDictionaryPair pair)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBowDictionaryPairById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBowDictionaryPairByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBowDictionaryPairs(ICollection<BowDictionaryPair> pair)
        {
            throw new System.NotImplementedException();
        }
    }
}
