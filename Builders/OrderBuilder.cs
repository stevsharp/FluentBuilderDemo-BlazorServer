using FluentBuilderDemo_BlazorServer.Domain;
using FluentBuilderDemo_BlazorServer.Services;
namespace FluentBuilderDemo_BlazorServer.Builders;
public sealed class OrderBuilder
{
    private string? _customerId; 
    private DateTime? _delivery; 
    private readonly List<OrderLine> _lines = []; 
    private bool _built;
    public static OrderBuilder Create() => new();
    public OrderBuilder ForCustomer(string id){
        _customerId = id; return this;
    }
    public OrderBuilder DeliverOn(DateTime date){ 
        _delivery = date; 
        return this; 
    }
    public OrderBuilder AddLine(string sku, int qty, Money unitPrice){ 
        _lines.Add(new OrderLine(sku, qty, unitPrice));
        return this; }
    public Result<Order> Build(){
        
        if (_built) 
            return Result<Order>.Failure("This builder was already used.");

        var errors = new List<string>();
        
        if (string.IsNullOrWhiteSpace(_customerId)) 
            errors.Add("CustomerId is required.");

        if (_delivery is DateTime d && d.Date < DateTime.Today)
            errors.Add("Delivery date cannot be in the past.");

        if (_lines.Count == 0) 
            errors.Add("At least one order line is required.");

        if (_lines.Select(l => l.UnitPrice.Currency).Distinct().Count() > 1) 
            errors.Add("All lines must use the same currency.");

        for (int i=0;i<_lines.Count;i++)
        { 
            var l=_lines[i];
            
            if (string.IsNullOrWhiteSpace(l.Sku)) 
                errors.Add($"Lines[{i}].Sku is required.");

            if (l.Quantity <= 0) 
                errors.Add($"Lines[{i}].Quantity must be positive.");

            if (string.IsNullOrWhiteSpace(l.UnitPrice.Currency)) 
                errors.Add($"Lines[{i}].Currency is required.");

            if (l.UnitPrice.Amount <= 0) 
                errors.Add($"Lines[{i}].UnitPrice.Amount cannot be negative or zero");
        }
        if (errors.Count>0) 
            return Result<Order>.Failure(errors);
        
        var currency=_lines[0].UnitPrice.Currency; 
        
        var total=new Money(_lines.Sum(l=>l.Quantity*l.UnitPrice.Amount),currency);
        _built =true;

        return Result<Order>.Success(new Order (
            _customerId!, 
            _delivery, 
            _lines.ToArray(), 
            total));
    }
    public OrderBuilder Reset()
    { 
        _customerId=null; 
        _delivery=null; 
        _lines.Clear(); 
        _built=false; 
        return this; 
    }
}
