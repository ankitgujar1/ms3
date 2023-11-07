using Microsoft.EntityFrameworkCore;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiDbContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});

IConfiguration con=builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddAuthentication(x=>{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(token=>{
    var key=Encoding.UTF8.GetBytes(con["JWT:Key"]);
    token.TokenValidationParameters=new TokenValidationParameters{
        ValidateIssuer=false,
        ValidateAudience=false,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuers=con["JWT:Issuer"],
        ValidAudience=con["JWT:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(key)
    };
});


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
