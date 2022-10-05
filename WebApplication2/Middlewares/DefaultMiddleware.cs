using WebApplication2.Services;

namespace WebApplication2.Middlewares
{
    public class DefaultMiddleware : IMiddleware
    {
        public DefaultMiddleware(SingletonService service)
        {
            Service = service;
        }

        public SingletonService Service { get; }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var x = Service.Id;
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
            else
                return next.Invoke(context);
        }
    }
}
