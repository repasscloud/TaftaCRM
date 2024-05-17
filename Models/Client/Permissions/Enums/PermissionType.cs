namespace TaftaCRM.Models.Client.Permissions.Enums;

[Flags]
public enum PermissionType
{
    NONE = 0,
    READ = 1 << 0,  // 1
    WRITE = 1 << 1, // 2
    CREATE = 1 << 2, // 4
    DELETE = 1 << 3 // 8
}
