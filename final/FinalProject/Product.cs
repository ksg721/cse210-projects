public class Product
{
    protected string _name;
    protected double _basePrice;

    public Product(string name, double basePrice)
    {
        _name = name;
        _basePrice = basePrice;
    }

    public string GetName()
    {
        return _name;
    }

    public virtual double CalculatePrice()
    {
        return _basePrice;
    }

    public virtual string GetDescription()
    {
        return _name;
    }
}