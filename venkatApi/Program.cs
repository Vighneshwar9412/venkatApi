using ApplicationApi.DAL.database;
using ApplicationApi.Data;
using ApplicationApi.Interfaces;
using ApplicationApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"));
            
        });
        builder.Services.AddScoped<Interface, SignupRepositiory>();
        builder.Services.AddScoped<ILogin, LoginRepository>();

        builder.Services.AddControllers();
        
        string mySecretKey = builder.Configuration.GetValue<string>("ApiSettings:SecretKey");
        // JWT AUTHENTICATION  
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                         .AddJwtBearer(options =>
                                              {
                                               options.RequireHttpsMetadata = false; // Not recommended for production
                                               options.TokenValidationParameters = new TokenValidationParameters
                                               {
                                                   ValidateIssuerSigningKey = true,
                                                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:Key")),
                                                   ValidateIssuer = false, // Not recommended for production
                                                   ValidateAudience = false  // Not recommended for production
                                               };
    });


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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}