public class Cake : Product
{
    private string _flavor;
    private string _frosting;

    public Cake(double price, string flavor, string frosting) : base(price, $"{flavor} Cake")
    {
        _flavor = flavor;
        _frosting = frosting;
    }

    public override double CalculatePrice()
    {
        if (_flavor == "Chocolate Carrot")
        {
            return GetPrice() + 1.0; 
        }
        return GetPrice();
    }

    public override string GetDescription()
    {
        return $"{GetName()} with {_frosting} frosting ${CalculatePrice():F2}";
    }
}