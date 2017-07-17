using BSS.SearchService.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS.SearchService
{

    public interface IJobProfileSearchService
    {
        ICollection<JobProfile> FindProfilesByKeywordPhrase(string keywordPhrase);
    }

    public class JobProfileSearchService : IJobProfileSearchService
    {
        JobProfieDataStore _jpDataStore = null;
        IQueryDataStore _queryService = null;

        public JobProfileSearchService(JobProfieDataStore jpDataStore)
        {
            _jpDataStore = jpDataStore;
            _queryService = _jpDataStore as IQueryDataStore;
        }
        public ICollection<JobProfile> FindProfilesByKeywordPhrase(string keywordPhrase)
        {
            var results = _queryService.JobProfiles
                .Where(jp => jp.Title.Contains(keywordPhrase) || jp.AltTitle.Contains(keywordPhrase))
                .ToList();

            return results;
        }
    }
}
