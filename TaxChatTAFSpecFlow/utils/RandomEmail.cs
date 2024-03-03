using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaxChatTAFSpecFlow.utils
{
    public class RandomEmail
    {
        // what's available
        public static string possibleChars = "1234567890";
        public static string possibleCharsFile = "12345678";
        // optimized (?) what's available
        public static char[] possibleCharsArray = possibleChars.ToCharArray();
        public static char[] possibleCharsArrayFile = possibleCharsFile.ToCharArray();
        // optimized (precalculated) count
        public static int possibleCharsAvailable = possibleChars.Length;
        public static int possibleCharsAvailableFile = possibleCharsFile.Length;

        public static Random random = new Random();
        public string GenerateRandomString(int num)
        {
            var rBytes = new byte[num];
            random.NextBytes(rBytes);
            var rName = new char[num];
            while (num-- > 0)
                rName[num] = possibleCharsArray[rBytes[num] % possibleCharsAvailable];
            return new string(rName);
        }

        public string GenerateRandomStringGetFile(int num)
        {
            var rBytes = new byte[num];
            random.NextBytes(rBytes);
            var rName = new char[num];
            while (num-- > 0)
                rName[num] = possibleCharsArrayFile[rBytes[num] % possibleCharsAvailableFile];
            return new string(rName);
        }
    }

}
