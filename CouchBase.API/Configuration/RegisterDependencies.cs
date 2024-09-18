using Couchbase.Extensions.DependencyInjection;
using CouchBase.API.Services;
using CouchBase.API.Services.Classes;
using CouchBase.API.Services.Interfaces;

namespace CouchBase.API.Configuration
{
    public static class RegisterDependencies
    {
        public static IServiceCollection AddCouchBaseDependecy(this IServiceCollection _services,IConfiguration _configuration)
        {
            _services.AddCouchbase(_configuration.GetSection("CouchBase"));
            return _services;
        }
        public static IServiceCollection AddRegisterServices(this IServiceCollection _services)
        {
            _services.AddScoped<IScopeService, InventoryScopeService>();
            _services.AddScoped<ICouchService, CouchService>();
            return _services;
        }
    }
}
