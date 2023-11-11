using Microsoft.EntityFrameworkCore;
using EmpApi.Models;
using EmpApi.Repository;
using log4net.Config;
using log4net;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
 
builder.Services.AddDbContext<EmpApiDbContext>(options=> {
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});
 
XmlConfigurator.Configure(new FileInfo("log4net.config"));
 
builder.Services.AddSingleton(LogManager.GetLogger(typeof(Program)));
 
 
 
 
 
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
 
builder.Services.AddTransient<IEmployeeRepository , EmployeeRepository>();
 
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