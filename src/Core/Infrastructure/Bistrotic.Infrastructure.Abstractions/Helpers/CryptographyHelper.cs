using System;
using System.Security.Cryptography;
using System.Text;

namespace Bistrotic.Infrastructure.Helpers
{
    public static class CryptographyHelper
    {
        /// <summary>
        /// Convert to a 128 bit hash.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The hash as a base 64 string</returns>
        public static string ToMD5Base64(this string text)
        {
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms
            using MD5 hash = MD5.Create();
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms

            return ToBase64(hash.ComputeHash(Encoding.Default.GetBytes(text)));
        }

        public static string ToSha256Base64(this string text)
        {
            using SHA256 hash = SHA256.Create();

            return ToBase64(hash.ComputeHash(Encoding.Default.GetBytes(text)));
        }

        public static string ToSha512Base64(this string text)
        {
            using SHA512 hash = SHA512.Create();

            return ToBase64(hash.ComputeHash(Encoding.Default.GetBytes(text)));
        }

        private static string ToBase64(byte[] bytes)
            => Convert.ToBase64String(bytes).TrimEnd('=');
    }
}