using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Wms.Core.API.Configuration;
using Wms.Core.Application;
using Wms.Core.Infrastructure;
using Wms.Core.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WmsDb"),
            o => o.MigrationsAssembly("Wms.Core.Infrastructure"));
    
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveDependencies();

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
