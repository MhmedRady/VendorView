using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using VendorView.Application;
using VendorView.Domain;
using VendorView.InfrastructureCore;
using VendorView.InfrastructureCore.Seeding;
using VendorView.Repositories;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using VendorView.WebApi;
using VendorView.Domain.BaseEntities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region General Services
    builder.Services.AddControllers()
                   .AddJsonOptions(o => o.JsonSerializerOptions
                       .ReferenceHandler = ReferenceHandler.IgnoreCycles);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    // builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
    // builder.Services.AddTransient<IAuthorizationHandler, PermissionHandler>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
#endregion

#region IdentityOptions
    builder.Services.Configure<SignInOptions>(p =>
    {
        p.RequireConfirmedEmail = false;
    });
    builder.Services.Configure<IdentityOptions>(p =>
    {
        p.Password.RequiredLength = 8;
        p.Password.RequireDigit = true;
        p.Password.RequireUppercase = true;
        p.Password.RequiredUniqueChars = 0;
        p.Password.RequireNonAlphanumeric = true;
        p.Password.RequireLowercase = true;
        p.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
        p.Lockout.MaxFailedAccessAttempts = 5;
    });
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<MainDbContext>()
        .AddRoles<IdentityRole>()
        .AddDefaultTokenProviders();
#endregion

#region Managers
    builder.Services.AddScoped<IApplicationUserManager, ApplicationUserManager>();
    builder.Services.AddScoped<IVendorService, VendorService>();
#endregion

#region Repositories
builder.Services.AddScoped(typeof(ICrudGenericManager<,,,>), typeof(CrudGenericManager<,,,>));
builder.Services.AddScoped(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,>));
#endregion

#region SqlServise
builder.Services.AddDbContext<MainDbContext>(db =>
{
    db.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
#endregion

#region JWT & Swagger
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTSettings:Key"]))
    };
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "v1",
        Title = "Indicator Api"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
            }
        });
});
#endregion
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    if (!context.User.Identities.Any(i => i.IsAuthenticated))
    {
        //Assign all anonymous users the same generic identity, which is authenticated
        context.User = new ClaimsPrincipal(new GenericIdentity("anonymous"));
    }
    await next.Invoke();
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCors(x => 
    x.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
);
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await DataInitialize.Initialize(app);

app.Run();
