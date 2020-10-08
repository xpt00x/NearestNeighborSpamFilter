using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories
{
    public interface IDictionaryRepository
    {
        ICollection<DictionaryPair> GetAllDictionaryPairs();
        DictionaryPair GetDictionaryPairByWord(string word);
        DictionaryPair GetDictionaryPairById(int it);

        DictionaryPair CreateOrUpdateDictionaryPair(DictionaryPair pair);
        ICollection<DictionaryPair> CreateOrUpdateDictionaryPairs(ICollection<DictionaryPair> pairs);

        void RemoveDictionaryPair(DictionaryPair pair);
        void RemoveDictionaryPairById(int id);
        void RemoveDictionaryPairByWord(string word);
        void RemoveDictionaryPairs(ICollection<DictionaryPair> pair);

        void RemoveAllDictionaryPairs();
        
    }
}
