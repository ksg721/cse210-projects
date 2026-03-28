public class Cookie : Product
{
    private int _quantity;
    private string _type;

    public Cookie(string name, double basePrice, string type, int quantity) : base(name, basePrice)
    {
        _type = type;
        _quantity = quantity;
    }

    public override double CalculatePrice()
    {
        return _basePrice * _quantity;
    }

    public override string GetDescription()
    {
        return $"{_quantity} {_type} cookies";
    }
}