using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using TheBookStore.Contracts;
using TheBookStore.DataStores;

namespace TheBookStore.Infrastructure
{
    public class ServiceResolver : IDependencyResolver
    {
        static readonly IUnitOfWork store = new SampleDataStore();
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.BaseType == typeof(ApiController))
                return Activator.CreateInstance(serviceType, store);

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            
        }
    }
}