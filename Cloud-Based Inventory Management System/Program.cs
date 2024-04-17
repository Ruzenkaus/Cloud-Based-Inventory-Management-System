using Cloud_Based_Inventory_Management_System.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Cloud_Based_Inventory_Management_System.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ForCloudConn")));
builder.Services.AddDbContext<SupplierContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ForCloudConn")));
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ForCloudConn")));
builder.Services.AddDbContext<OrdersContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ForCloudConn")));
builder.Services.AddDbContext<InventoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ForCloudConn")));


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";

})
    .AddJwtBearer("Client", options => ConfigureJwtBearer(options, builder.Configuration, "AudienceClient"))
    .AddJwtBearer("Admin", options => ConfigureJwtBearer(options, builder.Configuration, "AudienceAdmin"))
    .AddJwtBearer("BasicSubscription", options => ConfigureJwtBearer(options, builder.Configuration, "BasicAccess"))
    .AddJwtBearer("AdvancedSubscription", options => ConfigureJwtBearer(options, builder.Configuration, "AdvancedAccess"))
    .AddJwtBearer("ExpertSubscription", options => ConfigureJwtBearer(options, builder.Configuration, "ExpertAccess"))
    .AddCookie("Cookies", DefaultAuthenticationTypes.ApplicationCookie, options =>
    {
        options.LoginPath = "/Users/Login";


    });



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientAccess", policy => policy.RequireRole("Client"));
    options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin"));
    options.AddPolicy("BasicAccess", policy => policy.RequireRole("BasicSubscription"));
    options.AddPolicy("AdvancedAccess", policy => policy.RequireRole("AdvancedSubscription"));
    options.AddPolicy("ExpertAccess", policy => policy.RequireRole("ExpertSubscription"));
});


builder.Services.AddScoped<TokenService>();
builder.Services.AddSingleton<IAuthorizationHandler, JwtAudienceHandler>();


//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();


void ConfigureJwtBearer(JwtBearerOptions options, IConfiguration configuration, string audienceKey)
{
    var jwtConfig = configuration.GetSection("JwtSettings");
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["Issuer"],
        ValidAudience = jwtConfig[audienceKey],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["SecretKey"]))
    };
}