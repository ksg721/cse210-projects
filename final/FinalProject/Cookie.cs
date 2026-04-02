public class Cookie : Product
{
    private string _type;
    private int _quantity;


    public Cookie(double basePrice, string type, int quantity) : base(basePrice, $"{type} Cookie")
    {
        _type = type;
        _quantity = quantity;
    }

    public override double CalculatePrice()
    {
        return GetPrice() * _quantity;
    }

    public override string GetDescription()
    {
        return $"{_quantity} {GetName()} cookies ${CalculatePrice():F2}";
    }
}