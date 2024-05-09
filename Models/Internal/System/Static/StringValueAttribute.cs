namespace TaftaCRM.Models.Internal.System.Static
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; private set; }

        public StringValueAttribute(string stringValue)
        {
            this.StringValue = stringValue;
        }
    }
}