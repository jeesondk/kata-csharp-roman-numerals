using System.Globalization;
using FluentAssertions;
using number_converter;

namespace number_converter_tests;

public class ArabicToRomanConverterTests
{

    private readonly NumberConverter _converter;

    public ArabicToRomanConverterTests()
    {
        _converter = new NumberConverter();
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
    public void CanConvertOneToTen(int i, string r)
    {
        _converter
            .ToRoman(i)
            .Should()
            .Be(r);
    }

    [Theory]
    [InlineData(-3, "Negative numbers are not allowed")]
    [InlineData(0, "Only positive numbers allowed")]
   // [InlineData(5001, "Roman numerals does not go beyond 5000")]
    [InlineData(11, "Converter only supports 1 .. 10 at the moment")]
    void CanValidateInput(int i, string s)
    {
        var act = () => _converter.ToRoman(i);
        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage(s);
    }
}