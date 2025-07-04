using System.Text;

namespace VyosConfigGen;

public static class Extensions
{
    public static string ToKebabCase(this string text)
    {
        if (text.StartsWith("__"))
        {
            return text[2..];
        }
        if(text == null) {
            throw new ArgumentNullException(nameof(text));
        }
        if(text.Length < 2) {
            return text.ToLowerInvariant();
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for(int i = 1; i < text.Length; ++i) {
            char c = text[i];
            if(char.IsUpper(c)) {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            } else {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    public static string VyosEscape(this string text)
    {
        if (text.Contains(' '))
        {
            return '"' + text + '"';
        }
        else
        {
            return text;
        }
    }
}