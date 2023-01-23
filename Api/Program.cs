using Data.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using Data.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using HH2;
using Api.Middleware;
using Data;
using HH2.Entities;
using Domain.Models;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();
    builder.Services.AddControllers().AddFluentValidation();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<HHDbContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
        );

    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(
        c =>
        {
            c.Cookie.Name = "cookie";
            c.Cookie.SameSite = SameSiteMode.Strict;
            c.Cookie.HttpOnly = true;
            c.Events.OnRedirectToLogin = (context) =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };
        });

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // builder.Services.AddScoped<IOfferentServices, OfferentServices>();
    // builder.Services.AddScoped<ISeekerServices, SeekerServices>();
    //builder.Services.AddScoped<ICarpetWashingServices, CarpetWashingServices>();
    // builder.Services.AddScoped<ICleaningServices, CleaningServices>();
    // builder.Services.AddScoped<IWindowsCleaningServices, WindowsCleaningServices>();
    builder.Services.AddScoped<IAccountServices, AccountServices>();
    builder.Services.AddScoped<IUserServices, UserServices>();
    builder.Services.AddSingleton<ILog, Log>();
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();

    builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    ));


    var app = builder.Build();


    // Configure the HTTP request pipeline.
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseAuthentication();
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HH2");
    });

    app.UseAuthorization();


    app.MapControllers();
    app.UseCors();
    app.Run();
}

catch (Exception exception)
{

    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{

    LogManager.Shutdown();
}

