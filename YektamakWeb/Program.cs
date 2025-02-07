using ApiService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Utilities;
using YektamakWeb.Commands.Accounts;
using YektamakWeb.Hub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Kimlik do�rulama ve yetkilendirme ekleniyor
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/"; // Yetkisiz eri�imde y�nlendirilecek sayfa
//        options.AccessDeniedPath = "/accessdenied";
//    });

builder.Services.AddAuthorization();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();

// Dependency Injection
builder.Services.AddApiServices();
builder.Services.AddUtilities();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<YektamakWeb.Commands.Accounts.UserService>();
builder.Services.AddScoped<LoginService>();

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("jwtsettings");
var secretKey = jwtSettings.GetValue<string>("SecretKey");
builder.Services.AddDistributedMemoryCache();  // Bellek tabanl� bir da��t�k �nbellek kullan�yoruz
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Oturumun ge�erlilik s�resi (�rne�in 30 dakika)
    options.Cookie.HttpOnly = true;  // Yaln�zca sunucu taraf�ndan eri�ilebilir
    options.Cookie.IsEssential = true;  // Oturum �erezi, GDPR gereksinimleri nedeniyle gerekli
});

//builder.Services.AddSignalR();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie() // �erez tabanl� kimlik do�rulama
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "237674586250-37kfov6pqiso417jchbt9huun762nkfg.apps.googleusercontent.com"; // Google Developers Console'dan ald���n Client ID
    googleOptions.ClientSecret = "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"; // Google Developers Console'dan ald���n Client Secret
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", "1"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("Role", "2"));
    options.AddPolicy("ProjeTasarimMuhendisiOnly", policy => policy.RequireClaim("Role", "5"));
});
// Session servisini ekleyin
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub(); // Blazor hub'� tan�mlay�n
    endpoints.MapHub<MyHub>("/myhub"); // SignalR hub'�n� tan�mlay�n
    endpoints.MapFallbackToPage("/_Host");
});
app.UseAuthentication();
app.UseMiddleware<AuthMiddleware>();
app.UseAuthorization();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_host");
app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Redirect("/");
});
app.Run();
