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
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//JWT Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("Authentication failed: " + context.Exception.Message);
            return Task.CompletedTask;
        }
    };
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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/v1.json", "Open Api V1");
        options.RoutePrefix = "swagger";
    });
}
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

