namespace FluentBuilderDemo_BlazorServer.Dtos;
public sealed record OrderDto{
    public string? CustomerId { get; set; } = string.Empty;
    public DateTime? DeliveryDate { get; set; } 
    public List<OrderLineDto> Lines { get; set; } = []; 
}
