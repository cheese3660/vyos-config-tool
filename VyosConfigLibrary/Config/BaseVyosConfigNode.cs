using System.Text.Json.Serialization;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config;

public class BaseVyosConfigNode<T> : IVyosConfigNode<T> where T : BaseVyosConfigNode<T>, new()
{
    public T Clone()
    {
        var type = typeof(T);
        var properties = type.GetProperties().Where(x =>
            x.GetCustomAttributes(typeof(JsonIgnoreAttribute), true).Cast<JsonIgnoreAttribute>()
                .All(attr => attr.Condition != JsonIgnoreCondition.Always));
        var copy = new T();
        foreach (var property in properties)
        {
            var value = property.GetValue(this);
            if (value == null) continue;
            if (property.PropertyType.IsConfigNode())
            {
                property.SetValue(copy, property.PropertyType.CloneMethod().Invoke(value, []));
            } else if (property.PropertyType.IsArray)
            {
                if (property.PropertyType.GetElementType()!.IsConfigNode())
                {
                    var method = property.PropertyType.GetElementType()!.CloneMethod();
                    var newArray = Array.CreateInstanceFromArrayType(property.PropertyType,((Array)value).Length);
                    for (int i = 0; i < newArray.Length; i++)
                    {
                        newArray.SetValue(method.Invoke(((Array)value).GetValue(i),null),i);
                    }
                }
                else
                {
                    property.SetValue(copy, ((Array)value).Clone());
                }
            } else if (property.PropertyType.IsGenericType &&
                       property.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var secondParameter = property.PropertyType.GetGenericArguments()[1];
                if (secondParameter.IsConfigNode())
                {
                    property.SetValue(copy, secondParameter.DictionaryCloneMethod().Invoke(value, null));
                }
                else
                {
                    throw new Exception("Cloning non config node dictionaries is not supported!");
                }
            }
            else
            {
                property.SetValue(copy, value);
            }
        }

        return copy;
    }

    public IVyosConfig CloneConfig() => Clone();
}