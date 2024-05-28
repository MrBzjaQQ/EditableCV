using EditableCV.Services;
using EditableCV.Dal;
using EditableCV.Infrastructure.Database;
using EditableCV.Server.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.AddSecurityDefinition(AuthenticationConstants.SchemeName, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = AuthenticationConstants.ApiKeyHeader,
        Type = SecuritySchemeType.ApiKey,
        
    });

    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = AuthenticationConstants.SchemeName
        },
        In = ParameterLocation.Header
    };

    var requirement = new OpenApiSecurityRequirement { { key, new List<string>() } };
    cfg.AddSecurityRequirement(requirement);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("ResumeConnection");
builder.Services.AddDatabase(connectionString);
builder.Services.AddValidation();
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddAuthenticationHandler(builder.Configuration);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.MapFallbackToFile("/index.html");

await app.MigrateDatabase();

app.Run();
