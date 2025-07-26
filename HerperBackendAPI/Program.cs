using System.Text;
using HelperBackendAPI.Entity.DataContext;
using HelperBackendAPI.Repository.Repository;
using HelperBackendAPI.Service.Service;
using HelperBackendAPI.Services.Service;
using HerperBackendAPI.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//JWT Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5172/",
        ValidAudience = "http://localhost:5172/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"))

    };
});
builder.Services.AddAuthorization();

//Mapper Config
builder.Services.AddAutoMapper(typeof(MapperConfig));


// Register Repository and Services 
builder.Services.AddTransient<ILoginRepository, LoginService>();
builder.Services.AddTransient<IUserRepository, UserService>();
builder.Services.AddTransient<IMasterService, MasterUserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Swagger UI available at /swagger
    });
}
app.UseCors(builders => builders
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

