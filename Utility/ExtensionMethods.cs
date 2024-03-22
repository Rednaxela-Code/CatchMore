namespace CatchMore.Utility
{
    public static class ExtensionMethods
    {
        public static double CorrectDouble(this double inValue)
        {
            double doubleValue = inValue / Math.Pow(10, 8);
            return doubleValue;
        }
    }
}
