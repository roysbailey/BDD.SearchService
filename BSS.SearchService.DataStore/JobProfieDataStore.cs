using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS.SearchService.DataStore
{
    public class JobProfieDataStore : IQueryDataStore, IManageDataStore
    {
        private List<JobProfile> _profiles = new List<JobProfile>();

        public ICollection<JobProfile> JobProfiles {
            get
            {
                return this._profiles;
            }
        }

        public void SetDataStore(ICollection<JobProfile> profiles)
        {
            this._profiles.Clear();
            this._profiles.AddRange(profiles);
        }
    }
}
