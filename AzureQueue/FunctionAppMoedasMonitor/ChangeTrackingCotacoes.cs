using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using FunctionAppMoedasMonitor.Models;

namespace FunctionAppMoedasMonitor;

public static class ChangeTrackingCotacoes
{
    [Function(nameof(ChangeTrackingCotacoes))]
    [QueueOutput("queue-cotacoes")]
    public static IEnumerable<TransacaoBancoDados> Run(
        [SqlTrigger(tableName: "dbo.Cotacoes", connectionStringSetting: "BaseMoedas")]
        IReadOnlyList<SqlChange<HistoricoCotacao>> changes,
        FunctionContext context)

    {
        var logger = context.GetLogger(nameof(ChangeTrackingCotacoes));
        var transacoes = new List<TransacaoBancoDados>();
        foreach (SqlChange<HistoricoCotacao> change in changes)
        {
            transacoes.Add(new TransacaoBancoDados
            {
                Operacao = change.Operation.ToString(),
                Dados = change.Item
            });
            logger.LogInformation($"Operacao: {change.Operation} | " +
                $"Dados ({change.Item.GetType().FullName}): {JsonSerializer.Serialize(change.Item)}");
        }
        
        logger.LogInformation($"Enviando informações para o Azure Queue Storage...");
        return transacoes;
    }
}