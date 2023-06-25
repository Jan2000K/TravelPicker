using System.Security.Cryptography;
using System.Text;

namespace TravelPickerApp.Services;

public static class HashService
{
    public static async Task<byte[]> HashPassword(string password)
    {
        var hashedPass = await SHA256.HashDataAsync(new MemoryStream(Encoding.UTF8.GetBytes(password)));
        return hashedPass;
    }

    public static async Task<bool> CompareStringToHash(string password, byte[] hashedBytes)
        =>  Enumerable.SequenceEqual(await HashPassword(password),hashedBytes);
    
}