namespace HandsOnWithBlazor.Infrastructure.Security
{
    public interface IAes256Cipher
    {
        string Decrypt(string value);

        string Encrypt(string value);        
    }
}
