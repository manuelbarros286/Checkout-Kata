namespace CheckoutKata.Classes;
// isolating math to calculate the price 
public class ItemPricing
{
    public string? Sku { get; set; }
    public int UnitPrice { get; set; }
    
    public int? OfferQuantity { get; set; }
    public int? OfferPrice { get; set; }
    
    public int CalculatePrice(int quantity)
    {
        if (OfferQuantity.HasValue && OfferPrice.HasValue)
        {
            int bundleCount = quantity / OfferQuantity.Value;
            int remainingCount = quantity % OfferQuantity.Value;
            return (bundleCount * OfferPrice.Value) + (remainingCount * UnitPrice);
        }
        // Default for flat-rate pricing
        return quantity * UnitPrice;
    }
}