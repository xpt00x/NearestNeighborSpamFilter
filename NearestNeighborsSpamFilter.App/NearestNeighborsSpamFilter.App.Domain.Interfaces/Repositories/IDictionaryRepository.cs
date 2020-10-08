using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories
{
    public interface IBowDictionaryRepository
    {
        ICollection<BowDictionaryPair> GetAllBowDictionaryPairs();
        BowDictionaryPair GetBowDictionaryPairByWord(string word);
        BowDictionaryPair GetBowDictionaryPairById(int it);

        BowDictionaryPair CreateOrUpdateBowDictionaryPair(BowDictionaryPair pair);
        ICollection<BowDictionaryPair> CreateOrUpdateBowDictionaryPairs(ICollection<BowDictionaryPair> pairs);

        void RemoveBowDictionaryPair(BowDictionaryPair pair);
        void RemoveBowDictionaryPairById(int id);
        void RemoveBowDictionaryPairByWord(string word);
        void RemoveBowDictionaryPairs(ICollection<BowDictionaryPair> pair);

        void RemoveAllBowDictionaryPairs();
        
    }
}
