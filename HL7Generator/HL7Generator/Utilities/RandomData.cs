using System;
using System.Globalization;
using HL7Generator.Base.Properties;

namespace HL7Generator.Base.Utilities
{
    public class RandomData
    {
        public static readonly Random rand = new Random();

        public static string[] GetRandomLineFromResourceFile(string resourceFile)
        {
            var linesInFile = Extensions.ReadAllResourceLines(resourceFile);
            var randomLineNumber = rand.Next(0, linesInFile.Length - 1);
            return linesInFile[randomLineNumber].Split(',');
        }

        public static string[] Race()
        {
            return GetRandomLineFromResourceFile(Resources.race_ethnicity);
        }

        public static string[] MaritalStatus(string resourceFile = null)
        {
            if (resourceFile == null)
            {
                return GetRandomLineFromResourceFile(Resources.marital_status_hl7v2);
            }

            return GetRandomLineFromResourceFile(resourceFile);
        }

        public static string GetRandomNumber(string from, string to)
        {
            if (int.TryParse(to, out var toInt) && int.TryParse(from, out var fromInt))
            {
                return rand.Next(fromInt, toInt).ToString();
            }
            if (double.TryParse(to, out var toDouble) && double.TryParse(from, out var fromDouble))
            {
                double randomDouble = rand.NextDouble() * (toDouble - fromDouble) + fromDouble;
                double roundedValue = Math.Round(randomDouble, 2);

                /**
                 * RECURSIVE CALL
                 *
                 * If we have a low of 0.2 and a high of 1.2, and the random value generated is 1.22, we need to reject it and try again.
                 */
                if (roundedValue > toDouble)
                    GetRandomNumber(from, to);

                return roundedValue.ToString(CultureInfo.InvariantCulture);
            }

            if (from.Equals(">="))
            {
                if (int.TryParse(to, out toInt))
                {
                    return rand.Next(toInt, 200).ToString();
                }
            }

            return "0";
        }

        /// <summary>
        /// Gets a random date time in the range of the supplied parameters
        /// </summary>
        /// <param name="to">the end date</param>
        /// <param name="from">the start date</param>
        /// <returns></returns>
        public static DateTime GetRandomDateTime(DateTime to, DateTime from)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rand.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

    }
}
