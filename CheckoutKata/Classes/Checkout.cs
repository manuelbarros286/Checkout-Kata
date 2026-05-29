using CheckoutKata.Classes.Interfaces;

namespace CheckoutKata.Classes;
//checkout bucket for scanning items and getting total price
public class Checkout : ICheckout
{
    private readonly PriceGuide _priceGuide;
    private readonly Dictionary<string, int> _basket = new();
    public Checkout(PriceGuide priceGuide)
    {
        _priceGuide = priceGuide;
    }

    public void Scan(string item)
    {
        if(!_basket.ContainsKey(item))
        {
            _basket.Add(item, 0);
        }
        _basket[item]++;
    }
    public int GetTotalPrice()
    {

        int total = 0;
        foreach (var item in _basket)
        {
            string sku = item.Key;
            int quantity = item.Value;

            ItemPricing pricing = _priceGuide.GetPricing(sku);
            total += pricing.CalculatePrice(quantity);
        }
        return total;
        
    }
}