using WebProject.Application;
using WebProject.Infrastructure;
using WebProject.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using(var scope = app.Services.CreateScope())
        scope.ServiceProvider.GetService<IMigrationsHelper>()?.ApplyMigrations();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.MapControllers();
app.Run();
