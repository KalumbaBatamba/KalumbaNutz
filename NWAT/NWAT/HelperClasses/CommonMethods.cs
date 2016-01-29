using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NWAT.HelperClasses
{
    public static class CommonMethods
    {
        
        // this class holds static methods as members, which can be used by several different classes/objects in this project



        /// <summary>
        /// Chrecks if string is empty.
        /// </summary>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        /// Erstellt von Veit Berg, am 28.01.16
        public static bool ChreckIfStringIsEmpty(String income)
        {
            if (income == "")
            {
                return true;
            }else{
                return false;
            }  
        }

        /// <summary>
        /// Checks if forbitten delimiter in database.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public static bool CheckIfForbiddenDelimiterInDb(string text)
        {
            bool foundForbiddenChar = false;
            if (text != null)
            {
                List<string> listOfForbiddenChars = new List<string>() { @"|", @"\" };
                foreach (string forbidChar in listOfForbiddenChars)
                {
                    if (text.Contains(forbidChar))
                    {
                        foundForbiddenChar = true;
                    }
                }
            }
            return foundForbiddenChar;
        }

        /// <summary>
        /// Compares strings without whitespaces and returns true if they are the same
        /// </summary>
        /// <param name="stringOne">The string one.</param>
        /// <param name="stringTwo">The string two.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 28.01.2016
        public static bool CompareStringWithoutWhitespaces(string stringOne, string stringTwo)
        {
            bool result = false;
            if (stringOne != null && stringTwo != null)
            {
                string stringOneWithoutWS = Regex.Replace(stringOne, @"\s+", "");
                string stringTwoWithoutWS = Regex.Replace(stringTwo, @"\s+", "");

                if (stringOneWithoutWS == stringTwoWithoutWS)
                {
                    result = true;  
                }
            }
            if (stringOne == null && stringTwo == null)
            {
                result = true;
            }
            return result;
        }


        /// <summary>
        /// Checks if slash is in string. Will be called to check ProjectName. ProjectName must not contain "/" because
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 28.01.2016
        public static bool CheckIfSpecialCharsAreInString(string text)
        {

            bool result = false;
            if (text != null)
            {
                List<string> listOfForbiddenChars = new List<string>() { @"|", @"\", @"/", @":", @"*", @"?", @"<", @">", "\""};
                foreach (string forbidChar in listOfForbiddenChars)
                {
                    if (text.Contains(forbidChar))
                    {
                        result = true;
                    }
                }
            }
            return result;            
        }

        /// <summary>
        /// Replaces the new line in string with space if it contains one.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// Erstellt von Joshua Frey, am 28.01.2016
        public static string ReplaceNewLineInStringWithSpaceIfItContainsOne(string inputString)
        {
            string resultString = inputString;
            if (resultString != null)
            {
                resultString = resultString.Replace("\r\n", " ");
                resultString = resultString.Replace("\n", " ");
            }
            return resultString;
        }

        /// <summary>
        /// Creates the timestamp for file.
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 15.01.2016
        public static string GetTimestamp()
        {
            string timeStampDelimiter = ".";
            DateTime now = DateTime.Now;
            string year = now.Year.ToString();
            string month = now.Month.ToString();
            string day = now.Day.ToString();
            string hour = now.Hour.ToString();
            string minute = now.Minute.ToString();
            string second = now.Second.ToString();

            NormalizeTimeStampNumbers(ref month);
            NormalizeTimeStampNumbers(ref day);
            NormalizeTimeStampNumbers(ref hour);
            NormalizeTimeStampNumbers(ref minute);
            NormalizeTimeStampNumbers(ref second);


            return String.Format(@"{1}{0}{2}{0}{3}_{4}{0}{5}{0}{6}", timeStampDelimiter, year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Normalizes the time stamp numbers.
        /// </summary>
        /// <param name="number">The number.</param>
        /// Erstellt von Joshua Frey, am 15.01.2016
        private static void NormalizeTimeStampNumbers(ref string number)
        {
            try
            {
                if (Convert.ToInt32(number) < 10)
                    number = "0" + number;
            }
            catch (FormatException e)
            {
                throw(e);
            }
        }

        /// <summary>
        /// Gets the nullable double value from string.
        /// </summary>
        /// <param name="valueString">The value string.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public static System.Nullable<double> GetNullableDoubleValueFromString(string valueString)
        {
            if (valueString == "")
            {
                return null;
            }
            else
            {
                return Convert.ToDouble(valueString);
            }
        }

        /// <summary>
        /// Gets the nullable int value from string.
        /// </summary>
        /// <param name="valueString">The value string.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public static System.Nullable<int> GetNullableIntValueFromString(string valueString)
        {
            if (valueString == "")
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(valueString);
            }
        }

        /// <summary>
        /// If given String is empty, it will return null. 
        /// Else it will return the string.
        /// </summary>
        /// <param name="valueString">The value string.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public static string GetNullableStringValueFromString(string valueString)
        {
            if (valueString == "")
            {
                return null;
            }
            else
            {
                return valueString;
            }
        }


        /*
         * Messages
         */

        public static string MessageInsertionToFulFillmentTableFailed(int prodId, int projCritId)
        {
            return String.Format(@"Der Eintrag für das Produkt mit der ID {0} und das Kriterium mit der ID {1} 
                                    konnte nicht in die Erfüllungstabelle eingefügt werden.", prodId, projCritId);
        }

        public static string MessageForbiddenDelimiterWasFoundInText()
        {

            return String.Format("Die folgende Zeichen dürfen nicht in Texteingaben verwendet werden: \"|\" und \"\\\"");
        }

        public static string MessageForbiddenDelimiterWasFoundInProjectName()
        {

            return String.Format("Die folgende Zeichen dürfen nicht im Projektnamen verwendet werden: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", @"|", @"\", @"/", @":", @"*", @"?", @"<", @">", "\"");
        }

        public static string MessageTextIsEmpty()
        {

            return String.Format("Sie müssen alle Felder ausfüllen.");
        }


    }
}
