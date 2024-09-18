
using Couchbase;
using Couchbase.Core.Exceptions;
using Couchbase.KeyValue;
using Couchbase.Search;
using Couchbase.Search.Queries.Compound;
using Couchbase.Search.Queries.Range;
using Couchbase.Search.Queries.Simple;
using Couchbase.Search.Queries.Vector;

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


            #region  CRUD
            //try
            //{
            //    var key = "airline_8091";

            //    //Json Object...
            //    var content = new JObject
            //    {
            //       { "type", "airline" },
            //       { "id", 8091 },
            //       { "callsign", "CBS" },
            //       { "iata", null },
            //       { "icao", null },
            //       { "name", "Couchbase Airways" }
            //    };
            //    var mutationResult = await collection.InsertAsync(key, content);
            //    Console.WriteLine($"Create document success. CAS: {mutationResult.Cas}");
            //}
            //catch (CouchbaseException)
            //{
            //    Console.WriteLine("Document Already Exist..!");
            //    return;
            //}
            #endregion

            #region KV Range Scan for all documents in a collection
            //IAsyncEnumerable<IScanResult> results = collection.ScanAsync(new RangeScan());
            //await foreach (var scanResult in results)
            //{
            //    Console.WriteLine(scanResult.ContentAs<Airline>().ToString());
            //}
            //var scan2 = new RangeScan(from: ScanTerm.Inclusive(""), to: ScanTerm.Inclusive("id999"));


            //Prefix Scan..
            //IAsyncEnumerable<IScanResult> prefixScanResult = collection.ScanAsync(new PrefixScan("airline_1"));// Scan for all keys starting with "airline::"
            //await foreach (var scanResult in prefixScanResult)
            //{
            //    Console.WriteLine(scanResult.ContentAs<Airline>().ToString());
            //}
            #endregion

            #region Queries
            //var result = await scope.QueryAsync<dynamic>("SELECT * FROM `airline`");
            //if (result?.MetaData?.Status != QueryStatus.Success){}

            //else
            //{
            //    await foreach (var row in result)
            //    {
            //        Console.WriteLine(row);
            //    }
            //}


            //Count Query
            //var result = await scope.QueryAsync<dynamic>("select count(*)  as CountCounteryFrench from `travel-sample`.inventory.airport where country =$countery",options => options.Parameter("countery", "France")) ;
            //if (result?.MetaData?.Status != QueryStatus.Success){}
            //else
            //{
            //    await foreach (var row in result)
            //    {
            //        Console.WriteLine(row);
            //    }
            //}




            #endregion

            #region Search
            //var searchResult = await scope.SearchAsync("hoteldescription",
            //                                 SearchRequest.Create(new MatchQuery("swanky")),
            //                                 new SearchOptions().Limit(10)
            //);

            //foreach (var row in searchResult)
            //{
            //   Console.WriteLine("result: {row}", row.Locations?.ToString());
            //}

            #endregion
        }
    }
}
