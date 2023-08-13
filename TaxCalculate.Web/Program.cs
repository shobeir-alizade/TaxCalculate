using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaxCalculate.Service.Tax.Infrastructure;
using TaxCalculate.Service.Tax.Services;
using TaxCalculate.Common;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var DefaultCorsPolicyName = "Default";
        ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

        // Add services to the container.

        builder.Services.AddControllers();
        byte[] key = Encoding.UTF8.GetBytes(configuration.GetValue<string>(key: """TokenKey"""));

        builder.Services.AddSingleton<EncryptionUtility>();
        builder.Services.AddScoped<ITaxService, TaxService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.FromMinutes(configuration.GetValue<int>("TokenTimeout")),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication(
               CertificateAuthenticationDefaults.AuthenticationScheme)
               .AddCertificate();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(DefaultCorsPolicyName, builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.TrimEnd('/'))
                            .ToArray()
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.UseCors(DefaultCorsPolicyName);

        app.Run();
    }
}