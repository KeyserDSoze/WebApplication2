using WebApplication2.Middlewares;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SingletonService>();
builder.Services.AddSingleton<NoAddedService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddTransient<DefaultMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<DefaultMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
