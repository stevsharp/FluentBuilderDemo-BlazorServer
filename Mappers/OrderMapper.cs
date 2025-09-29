using FluentBuilderDemo_BlazorServer.Dtos;
using FluentBuilderDemo_BlazorServer.Domain;
using FluentBuilderDemo_BlazorServer.Builders;
namespace FluentBuilderDemo_BlazorServer.Mappers;

public partial class OrderMapper
{
    public OrderLine ToOrderLine(OrderLineDto dto)
    {
        //return new OrderLine
        //{
        //    Sku = dto.Sku ?? string.Empty,
        //    Quantity = dto.Quantity,
        //    UnitPrice = new Money { Amount = dto.Amount, Currency = dto.Currency ?? "EUR" }
        //};

        return new OrderLine(
            dto.Sku ?? string.Empty,
            dto.Quantity,
            new Money(dto.Amount, dto.Currency ?? "EUR")
        );

    }

    public OrderBuilder ToBuilder(OrderDto dto)
    {
        var b = OrderBuilder.Create();

        if (!string.IsNullOrWhiteSpace(dto.CustomerId))
            b.ForCustomer(dto.CustomerId!);

        if (dto.DeliveryDate is DateTime d)
            b.DeliverOn(d);
        
        foreach (var ldto in dto.Lines ?? []) { 
            var line = ToOrderLine(ldto); b.AddLine(line.Sku, line.Quantity, line.UnitPrice); 
        }
        return b;
    }
}
