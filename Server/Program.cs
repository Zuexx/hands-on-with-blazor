using AuthPermissions;
using AuthPermissions.AspNetCore;
using AuthPermissions.AspNetCore.Services;
using HandsOnWithBlazor.Application.Handlers;
using HandsOnWithBlazor.Persistence;
using HandsOnWithBlazor.Shared.Constants;
using HandsOnWithBlazor.Shared.Enumerations;
using HandsOnWithBlazor.Shared.Models;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Mapster;
using HandsOnWithBlazor.Infrastructure.Security;
using AuthPermissions.PermissionsCode;
using HandsOnWithBlazor.Application;
using AuthPermissions.AspNetCore.StartupServices;
using RunMethodsSequentially;

var builder = WebApplication.CreateBuilder(args);

// Get Default Connection string from appsettings.json
var connectionString = 
    builder.Configuration.GetConnectionString(AppSettingKeys.DefaultConnection);

// Add services to the container.
// Add MediatR service
builder.Services
    .AddMediatR(typeof(WeatherForcastRequestHandler).Assembly);

builder.Services
    .AddDbContext<EFDbContext>(options => 
        options.UseSqlServer(connectionString));

// Configure Database/DataContext using Microsoft.AspNetCore.Identity
builder.Services
    .AddDefaultIdentity<IdentityUser>(options => 
        options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<EFDbContext>();

// Configure Authentication using JWT token with refresh capability
var jwtData = 
    builder.Configuration.GetSection(AppSettingKeys.JwtData).Get<JwtSetupData>();

builder.Services
    .AddAuthentication(auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtData.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtData.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtData.SigningKey)),
            ClockSkew = TimeSpan.Zero //The default is 5 minutes, but we want a quick expires for JTW refresh
        };

        //This code came from https://www.blinkingcaret.com/2018/05/30/refresh-tokens-in-asp-net-core-web-api/
        //It returns a useful header if the JWT Token has expired
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services
    .RegisterAuthPermissions<Permissions>(options =>
    {
        //This tells AuthP that you don't have multiple instances of your app running,
        //so it can run the startup services without a global lock
        options.UseLocksToUpdateGlobalResources = false;

        //This sets up the JWT Token. The config is suitable for using the Refresh Token with your JWT Token
        options.ConfigureAuthPJwtToken = new AuthPJwtConfiguration
        {
            Issuer = jwtData.Issuer,
            Audience = jwtData.Audience,
            SigningKey = jwtData.SigningKey,
            TokenExpires = new TimeSpan(0, 5, 0), //Quick Token expiration because we use a refresh token
            RefreshTokenExpires = new TimeSpan(1, 0, 0, 0) //Refresh token is valid for one day
        };
    })
    .UsingEfCoreSqlServer(connectionString) //NOTE: This uses the same database as the individual accounts DB                                
    .IndividualAccountsAuthentication()
    .AddSuperUserToIndividualAccounts()    
    .RegisterFindUserInfoService<IndividualAccountUserLookup>()
    .AddRolesPermissionsIfEmpty(AppAuthSetupData.RolesDefinition)
    .AddAuthUsersIfEmpty(AppAuthSetupData.UsersRolesDefinition)    
    .SetupAspNetCoreAndDatabase(options =>
    {
        //Migrate individual account database
        options.RegisterServiceToRunInJob<StartupServiceMigrateAnyDbContext<EFDbContext>>();
        //Add demo users to the database
        options.RegisterServiceToRunInJob<StartupServicesIndividualAccountsAddDemoUsers>();
    });

// TODO: Mapster config section should be set to an indivisual place.
var config = new TypeAdapterConfig();
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddScoped<IDisableJwtRefreshToken, DisableJwtRefreshToken>();
builder.Services.AddTransient<IUserAccessor, UserAccessor>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
