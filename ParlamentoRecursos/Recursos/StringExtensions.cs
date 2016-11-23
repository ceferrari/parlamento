using System.Globalization;
using System.Text;

namespace ParlamentoRecursos.Recursos
{
    public static class StringExtensions
    {
        public static string RemoveDiacritics(this string source)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(source));
        }

        public static bool LatinContains(this string source, string dest)
        {
            CompareInfo ci = CultureInfo.InvariantCulture.CompareInfo;
            CompareOptions co = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;
            return ci.IndexOf(source, dest, co) != -1;
        }
    }
}