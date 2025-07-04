using System.Net;

namespace VyosConfigGen;

public class ConfigBuilder
{
    public object[] CurrentlyBeingEdited = [];
    public Stack<object[]> PreviouslyBeingEdited = [];

    public void Edit(params object[] path)
    {
        CurrentlyBeingEdited = path;
        PreviouslyBeingEdited = [];
    }

    public void PushEdit(params object[] subPath)
    {
        PreviouslyBeingEdited.Push(CurrentlyBeingEdited);
        CurrentlyBeingEdited = CurrentlyBeingEdited.Concat(subPath).ToArray();
    }

    public void PopEdit()
    {
        CurrentlyBeingEdited = PreviouslyBeingEdited.Pop();
    }

    public void Set(params object[] args)
    {
        Console.WriteLine($"set {string.Join(" ", CurrentlyBeingEdited.Concat(args))}");
    }

    public void SetObject(object arg)
    {
        foreach (var property in arg.GetType().GetProperties())
        {
            if (property.PropertyType == typeof(string))
            {
                var value = property.GetValue(arg) as string;
                Set(property.Name.ToKebabCase(), value!.VyosEscape());
            } else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(IpInterface) || property.PropertyType == typeof(IpAddress))
            {
                var value = property.GetValue(arg)!.ToString();
                Set(property.Name.ToKebabCase(), value.VyosEscape());
            } else if (property.PropertyType == typeof(bool))
            {
                var value = property.GetValue(arg);
                if ((bool)value)
                {
                    Set(property.Name.ToKebabCase());
                }
            } else if (property.PropertyType == typeof(string[]))
            {
                var value = property.GetValue(arg) as string[];
                PushEdit(property.Name.ToKebabCase());
                foreach (var s in value!)
                {
                    Set(s.VyosEscape());
                }
                PopEdit();
            } else if (property.PropertyType == typeof(IpAddress[]))
            {
                var value = property.GetValue(arg) as string[];
                PushEdit(property.Name.ToKebabCase());
                foreach (var s in value!)
                {
                    Set(s.VyosEscape());
                }
                PopEdit();
            }
            else
            {
                PushEdit(property.Name.ToKebabCase());
                SetObject(property.GetValue(arg)!);
                PopEdit();
            }
        }
    }

    public void Delete(params object[] args)
    {
        Console.WriteLine($"delete {string.Join(" ", CurrentlyBeingEdited.Concat(args))}");
    }
}