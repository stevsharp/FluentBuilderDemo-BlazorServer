namespace FluentBuilderDemo_BlazorServer.Dtos;

public sealed record OrderLineDto{ 
    public string? Sku { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public decimal Amount { get; set; } = 0m;
    public string? Currency { get; set; }  = "EUR";
} 
