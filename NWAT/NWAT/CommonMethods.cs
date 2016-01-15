using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT
{
    class CommonMethods
    {
        // this class holds static methods as members, which can be used by several different classes/objects in this project


        //TODO by Veit: Diese Methode bitte immer nutzen, um Benutzereingaben zu überprüfen, bevor die Daten an den jeweiligen Controller weitergereicht werden.
        
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
                int indexOfDelimiter = text.IndexOf(forbidChar);
                if (indexOfDelimiter == -1 || indexOfDelimiter == 0)
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

        //TODO by Veit: Diese Methode bitte immer nutzen, falls verbotenes Trennzeichen in Text entdeckt, um einen Hinweistext an den Benutzer auszugeben.
        public static string MessageForbiddenDelimiterWasFoundInText()
        {

            return String.Format("Das folgendes Zeichen darf nicht in Texteingaben verwendet werden: \"{0}\"", "|");
        }
    }
}
