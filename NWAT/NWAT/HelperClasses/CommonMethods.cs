using System;
using System.Collections.Generic;

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
            List<string> listOfForbiddenChars = new List<string>(){@"|", @"\"};
            foreach (string forbidChar in listOfForbiddenChars)
            {
                if (text.Contains(forbidChar))
                {
                    foundForbiddenChar = true;
                }
            }
            return foundForbiddenChar;
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

            return String.Format("Die folgende Zeichen ddürfen nicht in Texteingaben verwendet werden: \"|\" und \"\\\"");
        }
       
        public static string MessageTextIsEmpty()
        {

            return String.Format("Sie müssen alle Felder ausfüllen.");
        }


    }
}
