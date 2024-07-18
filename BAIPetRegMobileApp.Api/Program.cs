using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
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
builder.Services.AddControllers();

//jwt utils
builder.Services.AddScoped<IJwtUtils, JwtUtils>(); // Add this line

// Add email sender service
builder.Services.AddTransient<IEmailSender, EmailSender>();

// Add Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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
builder.Services.AddDbContext<UserDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb")));

builder.Services.AddDbContext<PetRegistrationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("PetRegistrationDb")));

// Add Identity with JWT Authentication
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

// Add JWT Authentication
builder.Services.AddAuthentication(options =>
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
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Replace with your actual issuer
            ValidAudience = builder.Configuration["Jwt:Audience"], // Replace with your actual audience
            IssuerSigningKey = GetSymmetricSecurityKey(builder.Configuration["Jwt:Key"]) // Replace with your actual key
        };
    });

SecurityKey GetSymmetricSecurityKey(string? key)
{
    // Method to retrieve SymmetricSecurityKey safely
    if (key == null)
    {
        throw new ArgumentNullException(nameof(key), "JWT key configuration is missing or null.");
    }

    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
}

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAll");

app.UseRouting();

// Use authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();