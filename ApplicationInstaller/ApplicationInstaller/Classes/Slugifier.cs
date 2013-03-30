using System;
using System.Text.RegularExpressions;

namespace ApplicationInstaller.Classes
{
    static class Slugifier
    {
        // Slight modified from https://gist.github.com/onebeatconsumer/1329568
        /// <summary>
        /// Generates a permalink slug for passed string
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns>clean slug string (ex. "some-cool-topic")</returns>
        public static string GenerateSlug(String str)
        {
            str = str.ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");                      // remove invalid characters
            str = Regex.Replace(str, @"\s+", " ").Trim();                       // single space
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();  // cut and trim
            str = Regex.Replace(str, @"\s", "-");                               // insert hyphens
            return str.ToLower();
        }
    }
}
