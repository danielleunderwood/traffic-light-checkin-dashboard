using Api.Helpers;
using MongoDB.Driver;
using Repository;

const string CorsPolicyName = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Database");
var mongoClient = new MongoClient(connectionString);
builder.Services.AddSingleton<MongoClient>(mongoClient);
// TODO: write cleaner service adder
builder.Services.AddSingleton<CheckinRepository>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<CheckinHelper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        CorsPolicyName,
        policy => policy.WithOrigins(builder.Configuration["ClientUrl"]));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsPolicyName);
app.UseAuthorization();

app.MapControllers();

app.Run();
