using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Couchbase;
using CouchBase.API.Services.Interfaces;

namespace CouchBase.API.Services.Classes
{
    public class CouchService : ICouchService
    {
        public ICluster Cluster { get; private set; } = null!;

        public IBucket TravelSystemDB { get; private set; } = null!;

        public ICouchbaseCollection AirportCollection { get; private set; } = null!;

        public async Task<bool> IntilaizeDb(IClusterProvider clusterProvider)
        {
            try
            {
                Cluster = await clusterProvider.GetClusterAsync();
                TravelSystemDB = await Cluster.BucketAsync("travel-sample");
                var inventoryScope = await TravelSystemDB.ScopeAsync("inventory");
                AirportCollection = await inventoryScope.CollectionAsync("Airport");
                return true;
            }
            catch (Exception) { return false; }
        }

        public CouchService(IClusterProvider clusterProvider)
        {
            var intializeTask = Task.Run(async () => { await IntilaizeDb(clusterProvider); });
            intializeTask.Wait();
        }
    }
}
