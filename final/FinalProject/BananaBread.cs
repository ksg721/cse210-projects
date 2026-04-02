public class BananaBread : Product
{
    private bool _hasNuts;
    private bool _hasChocolateChips;


    public BananaBread(double price, bool hasNuts, bool hasChocolateChips)
        : base(price, "Banana Bread")
    {
        _hasNuts = hasNuts;
        _hasChocolateChips = hasChocolateChips;
    }

    public override double CalculatePrice()
    {
        double price = GetPrice();
        if (_hasNuts) 
        {
            price += 0.5;
        }
        if (_hasChocolateChips) 
        {
            price += 1.0;
        }
        return price;
    }

    public override string GetDescription()
    {
        if (_hasNuts && _hasChocolateChips) 
        {
            return $"{GetName()} with nuts and chocolate chips ${CalculatePrice():F2}";
        }
        else if (_hasNuts) 
        {
            return $"{GetName()} with nuts ${CalculatePrice():F2}";
        }
        else if (_hasChocolateChips) 
        {
            return $"{GetName()} with chocolate chips ${CalculatePrice():F2}";
        }
        else 
        {
            return $"{GetName()} ${CalculatePrice():F2}";
        }

    }
}