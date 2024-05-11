using Microsoft.EntityFrameworkCore;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Service.AutoMapper;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;
using TeachTrack.Model.Repositories;
using TeachTrack.Service.AutoMapper;
using TeachTrack.Service.DTOs;
using TeachTrack.Service.Services;

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

//AddingServices
builder.Services.AddKeyedScoped<ICommonService<StudentDto, StudentInsertDto, StudentUpdateDto>, StudentService>(
   "StudentService");
builder.Services.AddKeyedScoped<ICommonService<CareerDto, CareerInsertDto, CareerUpdateDto>, CareerService>(
   "CareerService");
builder.Services.AddKeyedScoped<IBasicService<DegreeDto>, DegreeService>("DegreeService");
   
   
//AddingRepositories
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Career>, CareerRepository>();
builder.Services.AddScoped<IBasicRepository<Degree>, DegreeRepository>();

//Adding automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

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