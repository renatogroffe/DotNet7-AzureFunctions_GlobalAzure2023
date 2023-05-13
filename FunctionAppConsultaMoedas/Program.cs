using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FunctionAppConsultaMoedas.Data;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddDbContext<MoedasContext>(
            options => options.UseSqlServer(
                Environment.GetEnvironmentVariable("BaseMoedas")!));
        services.AddScoped<CotacoesRepository>();
    })
    .ConfigureOpenApi()
    .Build();

host.Run();