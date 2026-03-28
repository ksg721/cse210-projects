public class Aebleskiver : Product
{
    private int _quantity;
    private string _filling;
    private string _topping;

    public Aebleskiver(string name, double basePrice, int quantity, string filling, string topping) : base(name, basePrice)
    {
        _quantity = quantity;
        _filling = filling;
        _topping = topping;
    }

    public override double CalculatePrice()
    {
        return _basePrice * _quantity;
    }

    public override string GetDescription()
    {
        return $"{_quantity} Aebleskiver with {_filling} and {_topping}";
    }
}