namespace WebApplication2.Services
{
    public interface ITransientService
    {
        string Id { get; set; }
    }
    internal sealed class TransientService : ITransientService
    {
        private readonly ScopedService _scopedService;
        public TransientService(ScopedService scopedService, NoAddedService service)
        {
            _scopedService = scopedService;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
    public class NoAddedService
    {

    }
}
