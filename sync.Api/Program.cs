
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using sync.Api.Configs;
using sync.Data;
using sync.Data.Repository;
using sync.Core.Items;
using GraphQL;
using GraphQL.Server;
using Microsoft.Extensions.Options;
using sync.Domain.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCustomServices();

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
app.UseGraphQLAltair();
app.UseGraphQL<ISchema>();

app.Run();
