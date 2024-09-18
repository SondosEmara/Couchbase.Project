using Couchbase.KeyValue;

namespace CouchBase.API.Services
{
    public interface IScopeService
    {
        public Task<IScope> GetScope();
    }
}
