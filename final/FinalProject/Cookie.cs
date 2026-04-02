public class Cookie : Product
{
    private string _type;
    private int _qantity;


    public Cookie(double basePrice, string type, int quantity) : base(basePrice, $"{type} Cookie")
    {
        _type = type;
        _qantity = quantity;
    }

    public override double CalculatePrice()
    {
        return GetPrice() * _qantity;
    }

    public override string GetDescription()
    {
        return $"{_qantity} {GetName()} cookies ${CalculatePrice():F2}";
    }
}