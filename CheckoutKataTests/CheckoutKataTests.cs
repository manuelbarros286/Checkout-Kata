using CheckoutKata.Classes;
using CheckoutKata.Classes.Interfaces;

namespace CheckoutKataTests;
using NUnit.Framework;
public class CheckoutKataTests
{
    private ICheckout _checkout;
    [SetUp]
    public void Setup()
    {
        _checkout = new Checkout(new PriceGuide());
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
        Assert.Throws<ArgumentException>(() => _checkout.Scan(null));
        Assert.Throws<ArgumentException>(() => _checkout.Scan(""));
        Assert.Throws<ArgumentException>(() => _checkout.Scan(" "));
    }
    
    [Test]
    public void Scan_InvalidSku_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _checkout.Scan("E"));
    }

}