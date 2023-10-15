using Newtonsoft.Json.Serialization;
using WP.API;
using WP.API.Extentions;
using WP.Common;
using WP.DAL;
using WP.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.RegisterServices();

builder.Services.AddControllers().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseResponseErrorMiddleware();

app.MigrationInitialization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
