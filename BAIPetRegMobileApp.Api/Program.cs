using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.Interfaces;
using BAIPetRegMobileApp.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMiddleware(app, app.Environment);

app.Run();

// Method to configure services
static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();

    // JWT Utils
    services.AddScoped<IJWTConfiguration, JwtUtils>();

    // Email sender service
    services.AddTransient<IEmailSender, EmailSender>();

    // Swagger/OpenAPI configuration
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                Array.Empty<string>()
            }
        });
    });

    // Add DbContexts
    services.AddDbContext<UserDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("UserDb")));

    services.AddDbContext<PetRegistrationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("PetRegistrationDb")));

    // Add AutoMapper
    services.AddAutoMapper(typeof(Program));

    // Identity and JWT Authentication
    services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

    // Configure CORS
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });
}

// Method to configure middleware
static void ConfigureMiddleware(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowAll");

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}