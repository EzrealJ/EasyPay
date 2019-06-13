using Ezreal.EasyPay.Common.Credentials;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string pemstring = @"";

            System.Security.Cryptography.X509Certificates.X509Certificate2 a = X509Certificate2Loader.FromPemString(pemstring);
            Console.ReadKey();
        }
    }
}
