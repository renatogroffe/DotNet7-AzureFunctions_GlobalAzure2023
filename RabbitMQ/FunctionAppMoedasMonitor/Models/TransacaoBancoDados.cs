namespace FunctionAppMoedasMonitor.Models;

public class TransacaoBancoDados
{
    public string? Operacao { get; set; }
    public HistoricoCotacao? Dados { get; set; }
}