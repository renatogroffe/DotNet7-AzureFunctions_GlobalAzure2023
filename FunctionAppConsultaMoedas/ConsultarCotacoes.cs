using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FunctionAppConsultaMoedas.Data;
using FunctionAppConsultaMoedas.Models;

namespace FunctionAppConsultaMoedas;

public class ConsultarCotacoes
{
    private readonly ILogger _logger;
    private readonly CotacoesRepository _repository;

    public ConsultarCotacoes(ILoggerFactory loggerFactory,
        CotacoesRepository repository)
    {
        _logger = loggerFactory.CreateLogger<ConsultarCotacoes>();
        _repository = repository;
    }

    [Function(nameof(ConsultarCotacoes))]
    [OpenApiOperation(operationId: nameof(ConsultarCotacoes), tags: new[] { "Moeda" })]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<DadosCotacao>), Description = "Consulta a cotações de moedas estrangeiras")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        _logger.LogInformation("Consultando cotacoes ja cadastradas...");

        var dados = _repository.GetAll();
        _logger.LogInformation($"Numero de cotacoes encontradas = {dados.Count()}");

        var response = req.CreateResponse();
        response.StatusCode = HttpStatusCode.OK;
        await response.WriteAsJsonAsync(dados);
        return response;
    }
}