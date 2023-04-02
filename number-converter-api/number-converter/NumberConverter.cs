namespace number_converter;

public class NumberConverter : INumberConverter
{
    private readonly Dictionary<int, string> _arabicToRomanLookUp;

    public NumberConverter()
    {
        _arabicToRomanLookUp = InitArabicToRomanLookUp();
    }

    public string ToRoman(int i)
    {
        IsValid(i);
        
        return _arabicToRomanLookUp[i];
    }
    
    
    private Dictionary<int, string> InitArabicToRomanLookUp()
    {
        var collection = new Dictionary<int, string>
        {
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
            {10, "X"}
        };

        return collection;
    }

    private void IsValid(int i)
    {
        Tuple<bool, string> state;

        state = i switch
        {
            < 0 => new Tuple<bool, string>(false, "Negative numbers are not allowed"),
            0 => new Tuple<bool, string>(false, "Only positive numbers allowed"),
            > 10 => new Tuple<bool, string>(false, "Converter only supports 1 .. 10 at the moment"),
          //  > 5000 => new Tuple<bool, string>(false, "Roman numerals does not go beyond 5000"),
            _ => new Tuple<bool, string>(true, string.Empty)
        };
        
        if(state.Item1 != true)
            throw new ArgumentException(state.Item2);
    }
}