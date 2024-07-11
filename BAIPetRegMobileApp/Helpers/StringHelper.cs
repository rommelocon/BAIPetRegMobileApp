namespace BAIPetRegMobileApp.Helpers;
public partial class StringHelper
{
    public static string CapitalizedFirstLetter(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        return char.ToUpper(str[0]) + str.Substring(1);
    }
}