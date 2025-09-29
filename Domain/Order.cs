namespace FluentBuilderDemo_BlazorServer.Domain;
public sealed class Order
{
    public string CustomerId { get; set; } = string.Empty;
    public DateTime? DeliveryDate { get; set; } = null;
    public IReadOnlyList<OrderLine> Lines { get; set; } = [];
    public Money Total { get; set; } = new Money(0, "EUR");

    public Order(string customerId, DateTime? deliveryDate, IReadOnlyList<OrderLine> lines, Money total)
    {
        CustomerId = customerId;
        DeliveryDate = deliveryDate;
        Lines = lines;
        Total = total;
    }

}

public sealed class OrderLine
{
    public string Sku { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public Money UnitPrice { get; set; } = new Money(0,"EUR");

    public OrderLine(string sku, int quantity, Money unitPrice)
    {
        Sku = sku;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}

public record  Money
{
    public decimal Amount { get; set; } = 0;
    public string Currency { get; set; } = string.Empty;

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}

