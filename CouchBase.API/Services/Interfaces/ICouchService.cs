using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;

namespace CouchBase.API.Services.Interfaces
{
    public interface ICouchService
    {
        public ICluster Cluster { get; }
        public IBucket TravelSystemDB { get; }
        public ICouchbaseCollection AirportCollection { get; }

        public Task<bool> IntilaizeDb(IClusterProvider clusterProvider);
    }

}
