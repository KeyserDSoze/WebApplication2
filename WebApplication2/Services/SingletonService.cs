namespace WebApplication2.Services
{
    public class SingletonService
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
