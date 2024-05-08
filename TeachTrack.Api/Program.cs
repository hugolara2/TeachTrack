using Microsoft.EntityFrameworkCore;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.AutoMapper;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;
using TeachTrack.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<TeachTrackContext>(options => {
   var config = new ConfigurationBuilder()
      .AddUserSecrets<TeachTrackContext>()
      .Build();
   var connString = config.GetConnectionString("DefaultConn");
   options.UseNpgsql(connString);
});

//Repositories
builder.Services.AddSingleton<IRepository<Student>, StudentRepository>();

//Adding automapper
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
   public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}