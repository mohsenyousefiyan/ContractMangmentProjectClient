using System;
using System.Text;

namespace ConsoleApp.Helpers
{
    public class StringHelper
    {
        public static string GetBase64(string text)
        {
            try
            {
                return Convert.ToBase64String(StringToByteArray(text));
            }
            catch
            {
                return null;
            }
        }
        public static string GetBase64(byte[] Data)
        {
            try
            {
                return Convert.ToBase64String(Data);
            }
            catch
            {
                return null;
            }
        }
        public static byte[] Base64ToByteArray(string Base64)
        {
            try
            {
                return Convert.FromBase64String(Base64);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string Base64ToString(string Base64)
        {
            try
            {
                byte[] keyBytes = Convert.FromBase64String(Base64);
                var stringKey = Encoding.UTF8.GetString(keyBytes);
                return stringKey;
            }
            catch
            {
                return null;
            }
        }

        public static string ByteArrayToString(byte[] Data)
        {
            try
            {
                return Encoding.UTF8.GetString(Data);
            }
            catch
            {
                return null;
            }
        }
        public static byte[] StringToByteArray(string txt)
        {
            try
            {
                return Encoding.UTF8.GetBytes(txt);
            }
            catch
            {
                return null;
            }
        }
        public static bool HasValue(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return false;

            return true;
        }
    }
}
