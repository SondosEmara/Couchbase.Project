using Couchbase.KeyValue;
using CouchBase.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouchBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IScope inventoryScope;
        private ICouchbaseCollection couchbaseCollectionAirport;

        public AirportController(IScopeService scopeService)
        {
            inventoryScope = scopeService.GetScope().GetAwaiter().GetResult();
        }


        //[HttpGet("list-Airports")]
        //public async Task<IActionResult> GetAirports()
        //{
        //    //Collection -->Airport Table...
        //    couchbaseCollectionAirport = await inventoryScope.CollectionAsync("Airport");
        //    await couchbaseCollectionAirport.GetAsync();
        //}

    }
}
