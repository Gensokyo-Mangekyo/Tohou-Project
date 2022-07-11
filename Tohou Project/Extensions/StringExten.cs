

namespace Tohou_Project.Extensions
{
    public static class StringExten
    {
        public static string GetNumberStr(this string str)
        {
            string result = "";
            foreach (var item in str)
            {
                if (char.IsDigit(item))
                    result += item;
            }
            return result;
        }
    }
}
