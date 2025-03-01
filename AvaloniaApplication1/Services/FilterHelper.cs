namespace AvaloniaApplication1.Services;

public static class FilterHelper
{
    public static string PriceTextDefaults(string name)
    {
        if (name == "Low")
        {
            return "0";
        }

        if (name == "High")
        {
            return "9999";
        }

        return "";
    }
}