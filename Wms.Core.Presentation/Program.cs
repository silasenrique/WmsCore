using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Wms.Core.Application.Configuration;
using Wms.Core.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WmsDb"),
            o => o.MigrationsAssembly("Wms.Core.Persistence"));
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.ResolveDependencies(); -- Comentado a busca das dependencias da propria camada

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