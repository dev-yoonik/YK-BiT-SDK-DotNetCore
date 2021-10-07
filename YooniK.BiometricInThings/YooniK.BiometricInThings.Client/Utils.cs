using System.Collections.Generic;
using System.Text;

namespace YooniK.BiometricInThings.Client
{
    public static class Utils
    {
        public static string ListOfStringsToString(List<string> list, char delimiter = ',')
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                stringBuilder.Append(list[i]);
                if (i != list.Count - 1)
                    stringBuilder.Append(delimiter).Append(' ');
            }
            return stringBuilder.ToString();
        }
    }
}
