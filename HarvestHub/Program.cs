using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HarvestHub.Context;
using HarvestHub.JWT;
using Microsoft.Extensions.Options;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using HarvestHub.Repository;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

        services.AddDbContext<AppDBContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("local");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();



        services.AddIdentity<User, IdentityRole>(options =>
        {
             options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<AppDBContext>()
        .AddDefaultTokenProviders();

        services.AddHttpContextAccessor();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var jwtSettings = services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
        })
        .AddCookie();
    }
}