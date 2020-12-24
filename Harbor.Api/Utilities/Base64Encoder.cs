using Harbor.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api.Utilities
{
    public class Base64Encoder
    {
        public static string Encode(Credentials credentials)
        {
            var bytes = Encoding.UTF8.GetBytes($"{credentials.UserName}:{credentials.Password}");
            return Convert.ToBase64String(bytes);
        }

        public static string Encode(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}
