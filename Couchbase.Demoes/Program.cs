
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Couchbase.Demoes
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Update this to your cluster
            #region Cluster-Credinals
                var username = "Cluster-Admin";
                var password = "Cluster_Admin_1";
                var bucketName = "travel-sample";
                var scopeName = "inventory";
                var collectionName = "airline";
            #endregion


            #region Cluster-Options
            // Connecting to the cluster
            var clusterOptions = new ClusterOptions
                {
                    UserName = username,
                    Password = password,
                    KvTimeout = TimeSpan.FromSeconds(10),
                };
            #endregion



            #region Get-Collection
                clusterOptions.ApplyProfile("wan-development");
                var cluster = await Cluster.ConnectAsync($"couchbases://cb.5y1sde6zfjykkwck.cloud.couchbase.com", clusterOptions);
                var bucket = await cluster.BucketAsync(bucketName);
                var scope = await bucket.ScopeAsync(scopeName);
                var collection = await scope.CollectionAsync(collectionName);
            #endregion


            #region Simple-Insert
            try
            {
                var key = "airline_8091";

                //Json Object...
                var content = new JObject
                {
                   { "type", "airline" },
                   { "id", 8091 },
                   { "callsign", "CBS" },
                   { "iata", null },
                   { "icao", null },
                   { "name", "Couchbase Airways" }
                };
                var mutationResult = await collection.InsertAsync(key, content);
                Console.WriteLine($"Create document success. CAS: {mutationResult.Cas}");
            }
            catch (CouchbaseException)
            {
                Console.WriteLine("Document Already Exist..!");
                return;
            } 
            #endregion

        }
    }
}
