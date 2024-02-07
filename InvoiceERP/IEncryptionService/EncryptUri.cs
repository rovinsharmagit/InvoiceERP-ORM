using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;

namespace InvoiceERP.IEncryptionService
{
    public class EncryptUri
    {
         private readonly byte[] _encryptionKey;

    public EncryptUri()
    {
        DotEnv.Load(); // Load the .env file
        string? encryptionKey = Environment.GetEnvironmentVariable("ENCRYPTION_KEY");
        
        if (string.IsNullOrEmpty(encryptionKey))
        {
            throw new Exception("Encryption key not found in .env file.");
        }

        // Convert the base64-encoded encryption key to bytes
        _encryptionKey = Convert.FromBase64String(encryptionKey);
    }

    public string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _encryptionKey;
            aesAlg.IV = new byte[16]; // Initialization vector (IV) should also be generated securely

            // Create an encryptor to perform the stream transform
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Convert the plaintext string to byte array
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Perform the encryption
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            // Convert the encrypted byte array to a base64-encoded string for safe storage or transmission
            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);
            return encryptedBase64;
        }
    }

    public string Decrypt(string encryptedText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _encryptionKey;
            aesAlg.IV = new byte[16]; // Initialization vector (IV) should match the one used during encryption

            // Create a decryptor to perform the stream transform
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Convert the base64-encoded encrypted string to byte array
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            // Perform the decryption
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            // Convert the decrypted byte array back to a plaintext string
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedText;
        }
    }
    }
}