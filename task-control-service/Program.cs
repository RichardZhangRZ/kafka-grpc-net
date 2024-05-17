using task_control_service.Models;
using task_control_service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KafkaConfiguration>(
    builder.Configuration.GetSection("Kafka"));

// Add services to the container.
builder.Services.AddScoped<ITaskDispatcherService, TaskDispatcherService>();
builder.Services.AddControllers();
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
