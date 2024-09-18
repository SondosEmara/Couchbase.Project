using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;

namespace CouchBase.API.Services
{
    public class InventoryScopeService : IScopeService
    {
        private readonly IBucketProvider bucketProvider;
        private readonly IConfiguration configuration;

        public InventoryScopeService(IBucketProvider _bucketProvider, IConfiguration _configuration)
        {
            bucketProvider = _bucketProvider;
            configuration = _configuration;
        }


        public async Task<IScope> GetScope()
        {
            var bucketName = configuration["CouchBase:bucketName"];
            var scopeName = configuration["CouchBase:scopeName"];
            if (String.IsNullOrEmpty(bucketName)|| String.IsNullOrEmpty(scopeName)) { throw new InvalidOperationException("Scope name is not provided in the configuration."); }
            IBucket bucket;
            try
            {
                bucket= await bucketProvider.GetBucketAsync(bucketName);
            }
            catch(Exception ex) {throw;}

            if (!await CheckScopeExistAsync(bucket, scopeName)) throw new InvalidOperationException("The scope not exits .....!");
                
            return await bucket.ScopeAsync(scopeName);
        }


        public async Task<bool> CheckScopeExistAsync(IBucket bucket, string scopeName)
        {
            var scopes = await bucket.Collections.GetAllScopesAsync();
            return scopes.Any(scope => scope.Name == scopeName);
        }
    }
}
