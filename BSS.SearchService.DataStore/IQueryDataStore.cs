using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS.SearchService.DataStore
{
    public interface IQueryDataStore
    {
        ICollection<JobProfile> JobProfiles { get; }
    }
}
