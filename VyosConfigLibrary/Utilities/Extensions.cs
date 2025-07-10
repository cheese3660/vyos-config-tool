using System.Reflection;
using VyosConfigLibrary.Config;

namespace VyosConfigLibrary.Utilities;

public static class Extensions
{
    public static Dictionary<string, T> Clone<T>(this Dictionary<string, T> dict) where T : IVyosConfigNode<T>
    {
        return dict.Select(x => new KeyValuePair<string, T>(x.Key, x.Value.Clone())).ToDictionary(x => x.Key, x => x.Value);
    }

    public static bool IsConfigNode(this Type t)
    {
        return t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IVyosConfigNode<>));
    }

    private static readonly Dictionary<Type, MethodInfo> CloneMethods = new Dictionary<Type, MethodInfo>();
    public static MethodInfo CloneMethod(this Type t)
    {
        if (CloneMethods.TryGetValue(t, out var result))
        {
            return result;
        }

        return (CloneMethods[t] = t.GetMethod("Clone")!)!;
    }

    private static readonly MethodInfo DictionaryClone = typeof(Extensions).GetMethod(nameof(Clone))!;
    public static MethodInfo DictionaryCloneMethod(this Type t) => DictionaryClone.MakeGenericMethod(t);
}