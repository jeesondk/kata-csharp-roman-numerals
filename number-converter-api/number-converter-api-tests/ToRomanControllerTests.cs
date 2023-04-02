using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using number_converter;
using number_converter_api.Controllers;
using number_converter_api.Dto;

namespace number_converter_api_tests;

public class ToRomanControllerTests
{
    private readonly ToRomanController _toRomanController;
    private readonly Mock<INumberConverter> _numberConverterMock = new(MockBehavior.Strict);


    public ToRomanControllerTests()
    {
        _toRomanController = new ToRomanController(_numberConverterMock.Object);
    }
    
    [Fact]
    public void CanInitController()
    {
        _toRomanController
            .Should()
            .NotBeNull()
            .And
            .BeOfType<ToRomanController>();
    }

    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    void CanConvertToRoman(int i, string s)
    {
        var body = new ArabicNumber(i);

        _numberConverterMock.Setup(m => m.ToRoman(i)).Returns(s);

        var result = (OkObjectResult)_toRomanController.ToRoman(body);
        var romanNum = (RomanNumeral)result.Value;
        romanNum.value.Should().Be(s);
        
        _numberConverterMock.Verify( m => m.ToRoman(i), Times.Once);
    }
}