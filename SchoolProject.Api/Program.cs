using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Core;
using SchoolProject.Core.Filters;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service;
using SchoolProject.Service.Implementation;
using Serilog;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString, sql =>
        sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
    )
);

builder.Services.AddHttpContextAccessor();
// dependancy injection
builder.Services.AddInfrastructureDependancy()
    .AddServiceDependancy(builder.Configuration)
    .AddCoreDependancy()
    .AddServiceRegisteration();
#region localization

        builder.Services.AddControllersWithViews();
        builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
           });

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
        List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
        };

        options.DefaultRequestCulture = new RequestCulture("ar-EG");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
        });

#endregion
#region authentication
var JwtSettings = builder.Configuration.GetSection(JwtOptions.NameSection).Get<JwtOptions>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
     ).AddJwtBearer(o =>
     {
         o.SaveToken = true;
         o.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings?.Key!)),
             ValidIssuer = JwtSettings?.Issuer,
             ValidAudience = JwtSettings?.Audience
         };
     });
#endregion
#region cores
var Cors = "_Cors";
builder.Services.AddCors(options => options.AddPolicy(name: Cors,
    policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    }
    ));
#endregion
builder.Services.AddTransient<AuthFilter>();
#region SeriLog
builder.Host.UseSerilog((context, configration) =>
     configration.ReadFrom.Configuration(context.Configuration)
);
#endregion
var app = builder.Build();
//#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
app.UseSerilogRequestLogging();

app.UseStaticFiles();
app.UseRouting();
app.UseCors(Cors);
#region localization middelware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
