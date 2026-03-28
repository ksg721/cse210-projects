public class Cake : Product
{
    private string _flavor;
    private string _frosting;

    public Cake(string name, double basePrice, string flavor, string frostingType) : base(name, basePrice)
    {
        _flavor = flavor;
        _frosting = frostingType;
    }

    public override double CalculatePrice()
    {
        return _basePrice + 5.0; // simple customization cost
    }

    public override string GetDescription()
    {
        return $"{_flavor} cake with {_frosting} frosting";
    }
}