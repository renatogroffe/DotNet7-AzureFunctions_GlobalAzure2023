﻿namespace FunctionAppConsultaMoedas.Models;

public class DadosCotacao
{
    public string? Sigla { get; set; }
    public DateTime? Horario { get; set; }
    public decimal? Valor { get; set; }
}