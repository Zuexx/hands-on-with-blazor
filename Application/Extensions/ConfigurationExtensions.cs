﻿using HandsOnWithBlazor.Infrastructure.Security;
using Microsoft.Extensions.Configuration;

namespace HandsOnWithBlazor.Application.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationRoot Decrypt(this IConfigurationRoot root, string keyPath, string cipherPrefix)
        {
            var secret = root[keyPath];
            var cipher = new Aes256Cipher(secret);
            DecryptInChildren(root);
            return root;

            void DecryptInChildren(IConfiguration parent)
            {
                foreach (var child in parent.GetChildren())
                {
                    if (child.Value?.StartsWith(cipherPrefix) == true)
                    {
                        var cipherText = child.Value.Substring(cipherPrefix.Length);
                        parent[child.Key] = cipher.Decrypt(cipherText);
                    }

                    DecryptInChildren(child);
                }
            }
        }
    }    
}
