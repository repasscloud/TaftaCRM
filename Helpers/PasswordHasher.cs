using System.Security.Cryptography;
using System.Text;

namespace TaftaCRM.Helpers;

public static class PasswordHasher
{
    private static string? _salt;
    private static int _iterations;
    private static int _hashByteSize;

    public static void Initialize(IConfiguration configuration)
    {
        _salt = configuration["PasswordHasherSettings:Salt"]!;
        _iterations = int.Parse(configuration["PasswordHasherSettings:Iterations"]!);
        _hashByteSize = int.Parse(configuration["PasswordHasherSettings:HashByteSize"]!);
    }

    // method to hash a password
    public static string HashPassword(string password)
    {
        // convert the password and salt to byte arrays
        byte[] saltBytes = Encoding.UTF8.GetBytes(_salt!);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        // create the Rfc2898DeriveBytes object with the given parameters
        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, _iterations, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(_hashByteSize);
            // convert the byte array to a Base64 string
            return Convert.ToBase64String(hash);
        }
    }
}