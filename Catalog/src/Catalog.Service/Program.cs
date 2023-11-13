using Catalog.Service.Entities;
using Common.MassTransit;
using Common.MongoDB;
using Common.Settings;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
ServiceSettings serviceSettings;

builder.Configuration.AddJsonFile("appsettings.json");
serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
builder.Services.AddMongo().AddMongoRepository<Item>("items").AddMassTransitWithRabbitMq();

// Add services to the container.
builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = false; // Prevents MVC to Remove the suffix "Async" in the Controller (e.g ItemsController.cs)
    
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
