using Microsoft.EntityFrameworkCore;
using TeachTrack.Model.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TeachTrackContext>(options => {
   var config = new ConfigurationBuilder()
      .AddUserSecrets<TeachTrackContext>()
      .Build();
   var connString = config.GetConnectionString("DefaultConn");
   options.UseNpgsql(connString);
});

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