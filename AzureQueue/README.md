# DotNet7-AzureFunctions-Isolated-SqlTrigger-AzureQueue_ChangeTrackingMoedas
Exemplo de implementação de aplicação serverless monitorando alterações em uma tabela de cotações de moedas estrangeiras com .NET 7 + Azure Functions + Isolated Process + SQL Trigger + Azure SQL/SQL Server (Change Retention + Change Tracking). Inclui também o envio das informações para uma Fila do Azure Queue Storage.

Aplicação para geração dos dados:

**https://github.com/renatogroffe/DotNet7-AzureFunctions-Isolated-SQL-InputOutputBindings-OpenApi_SimulacaoEuro**

Documentação:

[**Azure SQL trigger for Functions (preview)**](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql-trigger?pivots=programming-language-csharp&tabs=isolated-process%2Cportal)