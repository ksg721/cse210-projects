public class BananaBread : Product
{
    private bool _hasNuts;
    private bool _hasChocolateChips;

    public BananaBread(string name, double basePrice, bool hasNuts, bool hasChocolateChips)
        : base(name, basePrice)
    {
        _hasNuts = hasNuts;
        _hasChocolateChips = hasChocolateChips;
    }

    public override double CalculatePrice()
    {
        double price = _basePrice;

        if (_hasNuts) price += 1.5;
        if (_hasChocolateChips) price += 2.0;

        return price;
    }

    public override string GetDescription()
    {
        return $"Banana Bread (Nuts: {_hasNuts}, Chocolate Chips: {_hasChocolateChips})";
    }
}