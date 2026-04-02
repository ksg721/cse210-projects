public abstract class Product
{
    private double _price;
    private string _name;

    public Product(double price, string name)
    {
        _price = price;
        _name = name;
    }

    public double GetPrice()
    {
        return _price;
    }

    public string GetName()
    {
        return _name;
    }

    public abstract double CalculatePrice();
    public abstract string GetDescription();
}