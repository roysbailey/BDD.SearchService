using BSS.SearchService.DataStore;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Linq;

namespace BSS.SearchService.IntegrationTests
{
    [Binding]
    public class SearchJobProfilesSteps
    {
        JobProfieDataStore _profilesStore = new JobProfieDataStore();
        IJobProfileSearchService _searchService = null;
        ICollection<JobProfile> _matchingProfiles = null;

        [Given(@"a set of job profiles as follows")]
        public void GivenASetOfJobProfilesAsFollows(Table table)
        {
            List<JobProfile> profiles = ProfileListFromTable(table);

            var dataStoreNanager = _profilesStore as IManageDataStore;
            dataStoreNanager.SetDataStore(profiles);
            _searchService = new JobProfileSearchService(_profilesStore);
        }

        [When(@"I search for the keyword ""(.*)""")]
        public void WhenISearchForTheKeyword(string keywordPhrase)
        {
            _matchingProfiles = _searchService.FindProfilesByKeywordPhrase(keywordPhrase);
        }
        
        [Then(@"I should see ""(.*)"" results")]
        public void ThenIShouldSeeResults(int resultCount)
        {
            resultCount.Should().Equals(_matchingProfiles.Count);
        }
        
        [Then(@"the results should contain the following")]
        public void ThenTheResultsShouldContainTheFollowing(Table table)
        {
            var expectedProfiles = ProfileListFromTable(table);

            List<JobProfile> test = new List<JobProfile>();

            var firstNotSecond = expectedProfiles.Where(
                ep => _matchingProfiles.Where(mp => mp.Title == ep.Title).Count() == 0);
            var secondNotFirst = _matchingProfiles.Where(
                mp => expectedProfiles.Where(ep => ep.Title == mp.Title).Count() == 0);

            firstNotSecond.Should().BeEmpty();
            secondNotFirst.Should().BeEmpty();
        }

        private List<JobProfile> ProfileListFromTable(Table table)
        {
            List<JobProfile> profiles = new List<JobProfile>();
            foreach (var row in table.Rows)
            {
                var profile = new JobProfile
                {
                    Title = row["Title"],
                    AltTitle = row["AlternativeTitle"]
                };
                profiles.Add(profile);
            }

            return profiles;
        }
    }
}
