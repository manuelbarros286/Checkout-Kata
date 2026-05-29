namespace CheckoutKata.Classes;

public class PriceGuide
{
    private readonly Dictionary<string, ItemPricing> _prices = new();


    public void AddPrice(ItemPricing item)
    {
        _prices[item.Sku] = item;
    }
    
    public ItemPricing GetPricing(string sku)
    {
        return _prices[sku];
    }
}