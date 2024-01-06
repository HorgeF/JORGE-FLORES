
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    services.AddControllers();

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
            ValidIssuer = "XYZ", 
            ValidAudience = "USERS", 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi ClaveSuperSecreta XYZ XDDDDDDDDDDDDD"))
        };
    });
}
builder.Configuration.AddJsonFile("appsettings.json", true, true);
var app = builder.Build();

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

{
    app.MapControllers();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Run service Login!");

app.Run();