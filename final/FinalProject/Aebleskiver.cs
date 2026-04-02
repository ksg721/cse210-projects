public class Aebleskiver : Product
{
    private int _quantity;
    private string _filling;
    private bool _hasSyrup;
    private bool _hasPowderedSugar;


    public Aebleskiver(double price, int quantity, string filling, bool syrup, bool powderedSugar)
        : base(price, "Aebleskivers")
    {
        _filling = filling;
        _hasSyrup = syrup;
        _hasPowderedSugar = powderedSugar;
        _quantity = quantity;
    }

    public override double CalculatePrice()
    {
        return GetPrice() * _quantity;
    }

    public override string GetDescription()
    {
        if (_hasSyrup && _hasPowderedSugar) 
        {
            return $"{_quantity} Aebleskivers with {_filling} and syrup and powdered sugar ${CalculatePrice():F2}";
        }
        else if (_hasSyrup) 
        {
            return $"{_quantity} Aebleskivers with {_filling} and syrup ${CalculatePrice():F2} ";
        }
        else if (_hasPowderedSugar) 
        {
            return $"{_quantity} Aebleskivers with {_filling} and powdered sugar ${CalculatePrice():F2}";
        }
        else 
        {
            return $"{_quantity} Aebleskivers with {_filling} ${CalculatePrice():F2}";
        }
    }
}