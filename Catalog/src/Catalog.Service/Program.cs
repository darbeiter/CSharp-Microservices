using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = false; // Prevents MVC to Remove the suffix "Async" in the Controller (e.g ItemsController.cs)
    BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String)); // Serializer for GUID ID Data => Makes the ID in the DB more readable
    BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String)); // Serializer for DateTime Data => Makes the DateTimne in the DB more readable

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
