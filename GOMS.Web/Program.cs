using Blazored.LocalStorage;
using GOMS.Web.Components;
using GOMS.Web.Core.Models;
using GOMS.Web.DataAccess.Implementation;
using GOMS.Web.DataAccess.Interface;
using GOMS.Web.Services.Implementation;
using GOMS.Web.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



RegisterCORS(builder);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<GORMContext>(options => options.EnableDetailedErrors(true));

RegisterHttpClient(builder);

RegisterServiceDependency(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static void RegisterCORS(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("https://localhost:7179") // Add your Blazor app URL
                       .SetIsOriginAllowed((host) => true)
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
            });
    });
}

static void RegisterHttpClient(WebApplicationBuilder builder)
{
    builder.Services.AddScoped(http => new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration.GetSection("BaseUrl").Value),
        Timeout = TimeSpan.FromMinutes(20)
    });
}

static void RegisterServiceDependency(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
}