using System.Runtime.InteropServices;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace FunctionAppConsultaMoedas.Configurations;

public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
{
    public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
    {
        Version = "1.0.0",
        Title = "Consulta a Cotações de Moedas Estrangeiras (Entity Framework Core)",
        Description = "API de consulta a cotações de moedas estrangeiras utilizando Entity Framework Core | " +
            $"Worker Runtime: {Environment.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME")} | " +
            $"Versão do .NET: {RuntimeInformation.FrameworkDescription}",
        Contact = new OpenApiContact()
        {
            Name = "Renato Groffe",
            Url = new Uri("https://github.com/renatogroffe"),
        },
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("http://opensource.org/licenses/MIT"),
        }
    };

    public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
}