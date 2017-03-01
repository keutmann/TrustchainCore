﻿using System;
using System.Text.RegularExpressions;

namespace TrustchainCore.Extensions
{
    public static class StringExtensions
    {
        public static string Left(this string s, int count)
        {
            if (s == null || s.Length < count)
                return s;

            return s.Substring(0, count);
        }

        public static string GetLeft(this string s, string search)
        {
            if (s == null || search == null)
                return s;

            var index = s.IndexOf(search, StringComparison.OrdinalIgnoreCase);
            if (index < 0)
                return s;

            return s.Substring(0, index);
        }

        public static string GetLastLeft(this string s, string search)
        {
            if (s == null || search == null)
                return s;

            var index = s.LastIndexOf(search, StringComparison.OrdinalIgnoreCase);
            if (index < 0)
                return s;

            return s.Substring(0, index);
        }


        public static string Right(this string s, int count)
        {
            if (s == null || s.Length < count)
                return s;

            return s.Substring(s.Length - count, count);
        }

        /// <summary>
        /// Gets the right part of the string including the search part.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static string GetRight(this string s, string search)
        {
            if (s == null || search == null)
                return s;

            var index = s.IndexOf(search, StringComparison.OrdinalIgnoreCase);
            if (index < 0)
                return s;

            return s.Substring(index);
        }


        /// <summary>
        /// Gets the right part of the string excluding the last search part.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static string GetLastRight(this string s, string search)
        {
            if (s == null || search == null)
                return s;

            var index = s.LastIndexOf(search, StringComparison.OrdinalIgnoreCase);
            if (index < 0)
                return s;

            return s.Substring(index+search.Length);
        }

        public static string Mid(this string s, int index, int count)
        {
            if (s == null || s.Length < count)
                return s;

            return s.Substring(index, count);
        }

        public static int ToInteger(this string s)
        {
            int integerValue = 0;
            int.TryParse(s, out integerValue);
            return integerValue;
        }

        public static bool IsInteger(this string s)
        {
            Regex regularExpression = new Regex("^-[0-9]+$|^[0-9]+$");
            return regularExpression.Match(s).Success;
        }

        public static bool ContainsIgnoreCase(this string text, string search)
        {
            if (text == null)
                return false;

            int index = text.IndexOf(search, StringComparison.OrdinalIgnoreCase);
            return (index >= 0);
        }

        public static bool EqualsIgnoreCase(this string source, string target)
        {
            if (source == null && target == null)
                return true;

            if (source == null && target != null)
                return false;

            return source.Equals(target, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EndsWithIgnoreCase(this string source, string target)
        {
            if (source == null && target == null)
                return true;

            if (source == null && target != null)
                return false;

            return source.EndsWith(target, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string source, string target)
        {
            if (source == null && target == null)
                return true;

            if (source == null && target != null)
                return false;

            return source.StartsWith(target, StringComparison.OrdinalIgnoreCase);
        }

        
        public static string[] Lines(this string source)
        {
            if (source == null)
                return null;

            return source.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }


        /// <summary>
        /// http://www.codeproject.com/KB/string/fastestcscaseinsstringrep.aspx
        /// </summary>
        /// <param name="original"></param>
        /// <param name="pattern"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string original, string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) *
                      (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                              position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }
    }
}
