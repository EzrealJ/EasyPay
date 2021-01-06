﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.Common.Security
{
    /// <summary>
    /// MD5哈希
    /// </summary>
    public class MD5Hash
    {
        /// <summary>
        /// MD5哈希加密为Base64字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HashToBase64(string value, string encoding = "UTF-8")
        {
            if (string.IsNullOrWhiteSpace(encoding))
            {
                throw new ArgumentException("message", nameof(encoding));
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.GetEncoding(encoding).GetBytes(value));
            return Convert.ToBase64String(result);
        }

        /// <summary>
        ///MD5哈希加密为16进制字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HashToHex(string value, string encoding = "UTF-8")
        {
            if (string.IsNullOrWhiteSpace(encoding))
            {
                throw new ArgumentException("message", nameof(encoding));
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = md5.ComputeHash(Encoding.GetEncoding(encoding).GetBytes(value));
            return BitConverter.ToString(byteArray).Replace("-", "");
        }
    }
}
