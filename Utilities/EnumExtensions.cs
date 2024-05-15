using TaftaCRM.Helpers;

namespace TaftaCRM.Utilities;

public static class EnumExtensions
{
	public static string? GetStringvalue(this Enum value)
	{
		var type = value.GetType();
		var fieldInfo = type.GetField(value.ToString());
        var attribs = fieldInfo?.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
        return attribs?.Length > 0 ? attribs[0].StringValue : null;
    }
}

