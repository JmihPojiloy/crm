using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Notes.WebApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
            _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach(var descriptions in _provider.ApiVersionDescriptions)
            {
                var apiVersion = descriptions.ApiVersion.ToString();

                options.SwaggerDoc(descriptions.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Notes API {apiVersion}",
                        Description =
                            "ASP NET Core Web API for storing and processing client requests",
                        TermsOfService = new Uri("https://en.wikipedia.org/wiki/Unlicense"),
                        Contact = new OpenApiContact
                        {
                            Name = "JmihPojiloy",
                            Email = "mr.d.pod@mail.ru"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "JmihPojiloy"
                        }
                    });

                options.AddSecurityDefinition($"AuthToken {apiVersion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorization",
                        Description = "Authorization Token"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = $"AuthToken{apiVersion}"
                            }
                        }, new string[]{}
                    }
                });

                options.CustomOperationIds(apiDescriptions =>
                    apiDescriptions.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }
}
