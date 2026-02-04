using DirectoryService.Infrastructure.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<DirectoryServiceDbContext>(_ => 
    new DirectoryServiceDbContext(builder.Configuration.GetConnectionString("DirectoryServiceDB")!));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DirectoryService"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();