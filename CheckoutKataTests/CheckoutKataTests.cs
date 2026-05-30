using CheckoutKata.Classes;
using CheckoutKata.Classes.Interfaces;
using NUnit.Framework;

namespace CheckoutKataTests;
public class CheckoutKataTests
{
    private ICheckout _checkout;
    private PriceGuide _priceGuide;
    
    [SetUp]
    public void Setup()
    {
        _priceGuide = new PriceGuide();
        _priceGuide.AddPrice(new ItemPricing{ Sku = "A", UnitPrice = 50, OfferQuantity = 3, OfferPrice = 130 });
        _priceGuide.AddPrice(new ItemPricing{ Sku = "B", UnitPrice = 30, OfferQuantity = 2, OfferPrice = 45 });
        _priceGuide.AddPrice(new ItemPricing{ Sku = "C", UnitPrice = 20 });
        _priceGuide.AddPrice(new ItemPricing{ Sku = "D", UnitPrice = 15 });
        _checkout = new Checkout(_priceGuide);
    }
    
    [Test]
    public void GetTotalPrice_ForEmptyBasket_ReturnsZero()
    {
        Assert.AreEqual(0, _checkout.GetTotalPrice());
    }
    [Test]
    public void SpecialPricing_ForA()
    {
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("A");
        
        Assert.AreEqual(130, _checkout.GetTotalPrice());
    }
    
    [Test]
    public void SpecialPricing_ForB()
    {
        _checkout.Scan("B");
        _checkout.Scan("B");

        Assert.AreEqual(45, _checkout.GetTotalPrice());
    }

    [Test]
    public void GetTotalPrice_ForMixedBasket()
    {
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("B");
        _checkout.Scan("B");
        _checkout.Scan("C");
        _checkout.Scan("D");

        Assert.AreEqual(210, _checkout.GetTotalPrice());
    }

    [Test]
    public void Scan_NullOrEmptyBasket_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => _checkout.Scan(null));
        Assert.Throws<ArgumentNullException>(() => _checkout.Scan(""));
        Assert.Throws<ArgumentNullException>(() => _checkout.Scan(" "));
    }
    
    [Test]
    public void Scan_InvalidSku_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _checkout.Scan("E"));
    }

}