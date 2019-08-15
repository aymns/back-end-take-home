namespace GuestLogix.Core.Helpers
{
    public static class StringExtensions
    {
        public static double SafeParseToDouble(this string input)
        {
            double.TryParse(input, out var result);
            return result;
        }
    }
}