namespace TaftaCRM.Helpers;

[AttributeUsage(AttributeTargets.Field)]
public class StringValueAttribute : Attribute
{
    public string StringValue { get; private set; }

    public StringValueAttribute(string stringValue)
    {
        this.StringValue = stringValue;
    }
}
