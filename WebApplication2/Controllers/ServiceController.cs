using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;
        private readonly ScopedService _scopedService2;
        private readonly ITransientService _transientService;
        private readonly ITransientService _transientService2;

        public ServiceController(SingletonService singletonService,
            ScopedService scopedService, 
            ScopedService scopedService2,
            ITransientService transientService,
            ITransientService transientService2)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _scopedService2 = scopedService2;
            _transientService = transientService;
            _transientService2 = transientService2;
            var type = _transientService.GetType();
            if (type == typeof(TransientService))
            {
                string olaf = "";
            }
        }

        [HttpGet(Name = "Singleton")]
        public string Get() 
            => $"Singleton:_{_singletonService.Id} Scoped:_{_scopedService.Id} Transient:_{_transientService.Id} Scoped:_{_scopedService2.Id} Transient:_{_transientService2.Id}";
    }
}