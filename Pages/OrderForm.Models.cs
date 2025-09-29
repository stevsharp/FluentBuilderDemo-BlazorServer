namespace FluentBuilderDemo_BlazorServer.Pages;
public sealed class OrderVm{ 
    public string? CustomerId { get; set; } 
    public DateTime? DeliveryDate { get; set; } 
    public List<LineVm> Lines { get; set; } = new(); 
}
public sealed class LineVm{ 
    public string? Sku { get; set; } 
    public int Quantity { get; set; } = 1; 
    public decimal Amount { get; set; } = 0m; 
    public string? Currency { get; set; } = "EUR"; 
}
